namespace Bopo.Data
{
    public class RichiestaGruppo
    {
        public RichiestaGruppo(string usernameAdmin, string nome, string password, int maxPartecipanti, DateTime dateTime)
        {
            this.usernameAdmin = usernameAdmin;
            this.nome = nome;
            this.password = password;
            this.maxPartecipanti = maxPartecipanti;
            this.dateTime = dateTime;
        }

        public String usernameAdmin { get; set; }
        public String nome { get; set; }
        public String password { get; set; }
        public int maxPartecipanti { get; set; }
        public DateTime dateTime { get; set; }

        public override string ToString()
        {
            return usernameAdmin + "," + nome + "," + password + "," + maxPartecipanti + "," + dateTime;
        }
    }
}
