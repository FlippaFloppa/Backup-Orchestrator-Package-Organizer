    using System;
    namespace Singleton.DatabaseUsers;
    public class DatabaseUsers
    {
        static DatabaseUsers instance;
        static List<User> listaUtenti;
        protected DatabaseUsers()
        {   
            initialize();
        }
        public static DatabaseUsers Instance()
        {

            if (instance == null)
            {
                instance = new DatabaseUsers();
                Console.WriteLine("Created");
            }
            else {
            Console.WriteLine("Already Created");
            }
            return instance;
        }


    
    private static void initialize(){
    //bovino ma no voglia 
    string[] lines = System.IO.File.ReadAllLines("Files/database.txt");
    listaUtenti=new List<User>();
    foreach (string line in lines)
    {   
        string[] credentials=line.Split(",");
        listaUtenti.Add(new User(credentials[0],credentials[1]));
    }   
    }

    public List<User> getListaUtenti(){
    return listaUtenti;
    }
    }


