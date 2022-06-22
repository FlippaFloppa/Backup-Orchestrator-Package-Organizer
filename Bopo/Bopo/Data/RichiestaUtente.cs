namespace Bopo.Data
{
    public class RichiestaUtente
    {
        public RichiestaUtente(string username, string password, DateTime dateTime)
        {
            this.username = username;
            this.password = password;
            this.dateTime = dateTime;
        }

        public String username { get; set; }
        public String password { get; set; }

        public DateTime dateTime { get; set; }
    }
}
