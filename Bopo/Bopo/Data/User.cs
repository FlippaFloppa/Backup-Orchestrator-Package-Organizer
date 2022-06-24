namespace Bopo.Data
{
  using System;

    public class User
    {

        public String username { get; set; }
        public String password { get; set; }
        public String role { get; set; }
        public DateTime dateTime { get; set; }
        public int freeSpace { get; set; }
        public String nickname { get; set; }
        public User(String username, String password)
        {   this.dateTime = DateTime.Now;
            this.nickname = "";
            this.freeSpace = 1000;
            this.username = username;
            this.password = password;
            this.role = "Utente";
        }
        public User(String username, String password,DateTime dateTime, String nickname,int freeSpace)
        {   
            this.username = username;
            this.password = password;
            this.dateTime = dateTime;
            this.nickname = nickname;
            this.freeSpace = freeSpace;
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
            return username + "," + password+","+dateTime+","+nickname+","+freeSpace;
        }

        
    }
}
