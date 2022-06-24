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
        public List<Gruppo> listaGruppiUtente;

        public User(String username, String password)
        {   this.dateTime = DateTime.Now;
            this.nickname = "nickname";
            this.freeSpace = 1000;
            this.username = username;
            this.password = password;
            this.role = "Utente";
            listaGruppiUtente=new List<Gruppo>();
        }
        public User(String username, String password,DateTime dateTime, String nickname,int freeSpace)
        {   
            this.username = username;
            this.password = password;
            this.dateTime = dateTime;
            this.nickname = nickname;
            this.freeSpace = freeSpace;
            this.role = "Utente";
            listaGruppiUtente=new List<Gruppo>();

        }
        public User(String username, String password, Boolean admin)
        {
            this.username = username;
            this.password = password;
            if (admin) role = "Amministratore";
            else role = "Utente";
        }
        public List<Gruppo> getListaGruppiUtente()
        {
            return listaGruppiUtente;
        }

        public override String ToString()
        {
            return username + "," + password+","+dateTime+","+nickname+","+freeSpace;
        }

        
    }
}
