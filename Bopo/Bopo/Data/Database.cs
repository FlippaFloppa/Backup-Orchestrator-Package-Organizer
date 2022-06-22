
namespace Bopo.Data
{
    public class Database
    {
        //static Database instance;
        static List<User> listaUtenti;
        static List<Gruppo> listaGruppi;

        static List<RichiestaUtente> richiesteUtente;
        static List<RichiestaGruppo> richiesteGruppi;

        public Database()
        {
            initialize();
        }

        /*
        public static Database Instance()
        {

            if (instance == null)
            {
                instance = new Database();
                Console.WriteLine("Created");
            }
            else
            {
                Console.WriteLine("Already Created");
            }
            return instance;
        }
        */


        private static void initialize()
        {
            //bovino ma no voglia 
            listaUtenti = new List<User>();

            listaGruppi = new List<Gruppo>();

            richiesteUtente = new List<RichiestaUtente>();
            
            richiesteGruppi = new List<RichiestaGruppo>();

            // ADMIN
            listaUtenti.Add(new User("admin","admin",true));

        }

        public List<User> getListaUtenti()
        {
            return listaUtenti;
        }
        public List<Gruppo> getListaGruppi()
        {
            return listaGruppi;
        }

        public void insertUser(User u){
        listaUtenti.Add(u);
        }

        public User? getUserByUsername(String username)
        {
            return listaUtenti.FirstOrDefault(x => x.username == username);
        }


        public Gruppo? getGruppoByName(String nome)
        {
            return listaGruppi.FirstOrDefault(x => x.nome == nome);
        }

        public void updateUtenti()
        {
            string[] linesUtenti = System.IO.File.ReadAllLines("Files/utenti.txt");

            foreach (string line in linesUtenti)
            {
                Console.WriteLine(line);
                string[] credentials = line.Split(",");
                listaUtenti.Add(new User(credentials[0], credentials[1]));
            }
        }

        public void updateGruppi()
        {

            string[] linesGruppi = System.IO.File.ReadAllLines("Files/gruppi.txt");

            foreach (string line in linesGruppi)
            {
                Console.WriteLine(line);
                string[] groups = line.Split(",");
                listaGruppi.Add(new Gruppo(groups[0], Int32.Parse(groups[1])));
            }
        }

        public void updateRichiestaUtente()
        {
            string[] linesRichiestaUtente = System.IO.File.ReadAllLines("Files/richiestautente.txt");

            foreach (string line in linesRichiestaUtente)
            {
                Console.WriteLine(line);
                string[] groups = line.Split(",");
                richiesteUtente.Add(new Gruppo(groups[0], Int32.Parse(groups[1])));
            }
        }


        public void updateRichiestaGruppo()
        {
            string[] linesRichiestaGruppo = System.IO.File.ReadAllLines("Files/richiestagruppo.txt");

            foreach (string line in linesRichiestaGruppo)
            {
                Console.WriteLine(line);
                string[] groups = line.Split(",");
                richiesteGruppi.Add(new Gruppo(groups[0], Int32.Parse(groups[1])));
            }
        }


    }
}


