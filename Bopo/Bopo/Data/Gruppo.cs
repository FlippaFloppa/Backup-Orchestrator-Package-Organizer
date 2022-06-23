
namespace Bopo.Data
{
    public class Gruppo : IEquatable<Gruppo>
    {

        public String nome { get; set; }

        public int partecipanti { get; set; }

        public Gruppo(String nome, int part)
        {
            this.nome = nome;
            this.partecipanti = part;
        }
        public override string ToString()
        {
            return nome + "," + partecipanti;
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
            return nome.GetHashCode();
        }
        public bool Equals(Gruppo other)
        {
            if (other == null) return false;
            return (this.nome.Equals(other.nome));
        }
    }
}