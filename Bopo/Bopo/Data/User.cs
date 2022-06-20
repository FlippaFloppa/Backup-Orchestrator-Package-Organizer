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
        }

        public override String ToString()
        {
            return username + " " + password;
        }

        
    }
}
