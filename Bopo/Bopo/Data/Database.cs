    using System;
    namespace Singleton.Database;
    public class Database
    {
        static Database instance;
        static List<Utente> listaUtenti;
        protected Database()
        {   
            initialize();
        }
        public static Database Instance()
        {

            if (instance == null)
            {
                instance = new Database();
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
    listaUtenti=new List<Utente>();
    foreach (string line in lines)
    {   
        string[] credentials=line.Split(",");
        listaUtenti.Add(new Utente(credentials[0],credentials[1]));
    }   
    }

    public List<Utente> getListaUtenti(){
    return listaUtenti;
    }
    }


