namespace Estrutura_De_Dados
{
    public class Celula
    {
        public Celula(object elemento, Celula proximo)
        {
            Elemento = elemento;
            Proximo = proximo;
        }

        public Celula(object elemento)
        {
            Elemento = elemento;
            Proximo = null;

        }

        public object Elemento { get; set; }
        public Celula Proximo { get; set; }
        public Celula Anterior { get; set; }
    }
}