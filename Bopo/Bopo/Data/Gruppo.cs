
namespace Bopo.Data
{
    public class Gruppo : IEquatable<Gruppo>
    {

        public String usernameAdmin { get; set; }
        public String nome { get; set; }
        public String password { get; set; }
        public int maxPartecipanti { get; set; }
        public int postiDisponibili { get; set; }
        public List<String> partecipanti { get; }
        public DateTime dateTime { get; set; }
        public bool disabled { get; set; }
        public String insertPassword { get; set; }
        public Gruppo(string usernameAdmin, string nome, string password, int maxPartecipanti, DateTime dateTime)
        {
            this.usernameAdmin = usernameAdmin;
            this.nome = nome;
            this.password = password;
            this.maxPartecipanti = maxPartecipanti;
            this.dateTime = dateTime;
            this.postiDisponibili = maxPartecipanti;
            partecipanti = new List<String>();
            this.disabled = false;
        }
        public override string ToString()
        {
            return usernameAdmin + "," + nome + "," + password + "," + maxPartecipanti + "," + dateTime;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Gruppo objAsPart = obj as Gruppo;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return usernameAdmin.GetHashCode();
        }
        public bool Equals(Gruppo other)
        {
            if (other == null) return false;
            return (this.usernameAdmin.Equals(other.usernameAdmin));
        }
    }
}