namespace Bopo.Data
{
  using System;

    public class User
    {

        public String username { get; set; }
        public String password { get; set; }
        public String role { get; set; }

        public User(String username, String password)
        {
            this.username = username;
            this.password = password;
            this.role = "Utente";
        }
        public User(String username, String password, Boolean admin)
        {
            this.username = username;
            this.password = password;
            if (admin) role = "Amministratore";
            else role = "Utente";
        }

        public override String ToString()
        {
            return username + " " + password;
        }

        
    }
}
