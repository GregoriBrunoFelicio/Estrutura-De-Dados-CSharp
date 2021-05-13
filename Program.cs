using System;

namespace Estrutura_De_Dados
{
    class Program
    {
        static void Main(string[] args)
        {

            var listaLiaga = new ListaLigada();
            listaLiaga.AdicionarNoComeco("A");
            listaLiaga.AdicionarNoComeco("B");
            listaLiaga.AdicionarNoComeco("C");
            listaLiaga.Adicionar("Z");
            listaLiaga.Adicionar(2, "G");

            listaLiaga.RemoverDoComeco();
            Console.WriteLine(listaLiaga.ToString());
        }
    }
}
