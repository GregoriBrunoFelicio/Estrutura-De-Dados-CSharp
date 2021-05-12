namespace Estrutura_De_Dados
{
    public class Aluno
    {
        public Aluno(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Aluno)) return false;

            return (Nome == ((Aluno)obj).Nome);
        }

        public override int GetHashCode()
        {
            return (Nome != null ? Nome.GetHashCode() : 0);
        }
    }
}
