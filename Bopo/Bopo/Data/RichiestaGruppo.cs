namespace Bopo.Data
{
    public class RichiestaGruppo
    {
        public RichiestaGruppo(string usernameAdmin, string nome, string password, DateTime dateTime)
        {
            this.usernameAdmin = usernameAdmin;
            this.nome = nome;
            this.password = password;
            this.dateTime = dateTime;
        }

        public String usernameAdmin { get; set; }
        public String nome { get; set; }
        public String password { get; set; }
        public DateTime dateTime { get; set; }
    }
}
