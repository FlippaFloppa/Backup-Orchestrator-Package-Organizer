using System.Xml;
using System.Xml.Serialization;

namespace Bopo.Data
{
    public class Database
    {
        //static Database instance;
        static List<User> listaUtenti;
        static List<Gruppo> listaGruppi;
        static public List<RichiestaUtente> richiesteUtente;
        static List<RichiestaGruppo> richiesteGruppi;

        public Database()
        {
            initialize();

            updateUtenti();
            updateGruppi();
            updateRichiestaUtente();
            updateRichiestaGruppo();
        }

        private static void initialize()
        {
            //bovino ma no voglia 
            listaUtenti = new List<User>();

            listaGruppi = new List<Gruppo>();

            richiesteUtente = new List<RichiestaUtente>();

            richiesteGruppi = new List<RichiestaGruppo>();

        }

        public List<User> getListaUtenti()
        {
            return listaUtenti;
        }
        public List<Gruppo> getListaGruppi()
        {
            return listaGruppi;
        }
        public List<RichiestaUtente> getListaRichiesteUtente()
        {
            return richiesteUtente;
        }
        public List<RichiestaGruppo> getListaRichiesteGruppo()
        {
            return richiesteGruppi;
        }
        public void insertUser(User u)
        {
            listaUtenti.Add(u);
            System.IO.File.AppendAllText(@"Files/utenti.txt", u.ToString() + Environment.NewLine);

            //Creazione storage
            System.IO.Directory.CreateDirectory(@"wwwroot/storage/" + u.username);

            return;
        }

        public void deleteUser(User u)
        {   
            try{
            listaUtenti.Remove(u);
            File.WriteAllText(@"Files/utenti.txt", string.Empty);
            foreach (User user in listaUtenti)
            {
                if (user.username != "admin")
                    System.IO.File.AppendAllText(@"Files/utenti.txt", user.ToString() + Environment.NewLine);
            }

            //Rimozione storage
            DeleteDirectory(@"wwwroot/storage/" + u.username);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public bool UpdateCredentials(String user, String oldPassword, String newPassword, String? nickname)
        {
            Console.WriteLine("Ricevuto update utente: " + user + " oldpass " + oldPassword + " newpass " + newPassword + " nick " + nickname);
            User u = getUserByUsername(user);
            if (u.password == oldPassword)
            {
                u.password = newPassword;
                if (nickname != null) u.nickname = nickname;
                deleteUser(u);
                insertUser(u);
                return true;
            }
            return false;
        }
        public void insertUserRequest(RichiestaUtente r)
        {
            richiesteUtente.Add(r);
            System.IO.File.AppendAllText(@"Files/richiesteutenti.txt", r.ToString() + Environment.NewLine);
        }
        public void deleteUserRequest(RichiestaUtente r)
        {
            richiesteUtente.Remove(r);
            File.WriteAllText(@"Files/richiesteutenti.txt", string.Empty);
            foreach (RichiestaUtente richiesta in richiesteUtente)
            {
                System.IO.File.AppendAllText(@"Files/richiesteutenti.txt", richiesta.ToString() + Environment.NewLine);
            }
        }
        public void insertGroup(Gruppo g)
        {
            listaGruppi.Add(g);
            System.IO.File.AppendAllText(@"Files/gruppi.txt", g.ToString() + Environment.NewLine);
            return;
        }
        public void deleteGroup(Gruppo g)
        {
            listaGruppi.Remove(g);
            File.WriteAllText(@"Files/gruppi.txt", string.Empty);
            foreach (Gruppo group in listaGruppi)
            {
                System.IO.File.AppendAllText(@"Files/gruppi.txt", group.ToString() + Environment.NewLine);
            }
        }
        public void insertGroupRequest(RichiestaGruppo r)
        {
            richiesteGruppi.Add(r);
            System.IO.File.AppendAllText(@"Files/richiestegruppi.txt", r.ToString() + Environment.NewLine);
        }
        public void deleteGroupRequest(RichiestaGruppo r)
        {
            richiesteGruppi.Remove(r);
            File.WriteAllText(@"Files/richiestegruppi.txt", string.Empty);
            foreach (RichiestaGruppo richiesta in richiesteGruppi)
            {
                System.IO.File.AppendAllText(@"Files/richiestegruppi.txt", richiesta.ToString() + Environment.NewLine);
            }
        }
        public User getUserByUsername(String username)
        {
            return listaUtenti.FirstOrDefault(x => x.username == username);
        }


        public Gruppo? getGruppoByName(String nome)
        {
            return listaGruppi.FirstOrDefault(x => x.nome == nome);
        }

        public void updateUtenti()
        {
            listaUtenti.Clear();

            // ADMIN
            listaUtenti.Add(new User("admin", "admin", true));

            string[] linesUtenti = System.IO.File.ReadAllLines("Files/utenti.txt");

            foreach (string line in linesUtenti)
            {
                if (line.Length > 0)
                {
                    Console.WriteLine(line);
                    string[] credentials = line.Split(",");
                    listaUtenti.Add(new User(credentials[0], credentials[1]));
                }
            }
        }

        public void updateGruppi()
        {
            listaGruppi.Clear();

            string[] linesGruppi = System.IO.File.ReadAllLines("Files/gruppi.txt");

            foreach (string line in linesGruppi)
            {
                Console.WriteLine(line);
                string[] groups = line.Split(",");
                listaGruppi.Add(new Gruppo(groups[0], groups[1], groups[2], Int32.Parse(groups[3]), DateTime.Parse(groups[4])));
            }
        }

        public void updateRichiestaUtente()
        {
            richiesteUtente.Clear();

            string[] linesRichiestaUtente = System.IO.File.ReadAllLines("Files/richiesteutenti.txt");

            foreach (string line in linesRichiestaUtente)
            {
                Console.WriteLine(line);
                string[] str = line.Split(",");
                richiesteUtente.Add(new RichiestaUtente(str[0], str[1], DateTime.Parse(str[2])));
            }
        }


        public void updateRichiestaGruppo()
        {
            richiesteGruppi.Clear();

            string[] linesRichiestaGruppo = System.IO.File.ReadAllLines("Files/richiestegruppi.txt");

            foreach (string line in linesRichiestaGruppo)
            {
                Console.WriteLine(line);
                string[] str = line.Split(",");
                richiesteGruppi.Add(new RichiestaGruppo(str[0], str[1], str[2], int.Parse(str[3]), DateTime.Parse(str[4])));
            }
        }


        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }

    }
}


