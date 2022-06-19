    public sealed class DatabaseUsers {  
        public DatabaseUsers() {}  
        private static DatabaseUsers instance = null;  
        public static DatabaseUsers Instance {  
            get {  
                if (instance == null) {  
                    instance = new DatabaseUsers();  
                    string[] lines = System.IO.File.ReadAllLines(@"Ingegneria-del-Software/Bopo/Bopo/Data/database.txt");
                    foreach (string line in lines)
                    {
                        Console.WriteLine("\t" + line);
                    }
                }  
                return instance;  
            }  
            
        }  



    
    }  

        


    

