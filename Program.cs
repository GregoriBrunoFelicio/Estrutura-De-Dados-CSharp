using System;

namespace Estrutura_De_Dados
{
    class Program
    {
        static void Main(string[] args)
        {

            var listaLiaga = new ListaDuplamenteLigada();
            //listaLiaga.AdicionarNoComeco("A");
            //listaLiaga.AdicionarNoComeco("B");
            //listaLiaga.AdicionarNoComeco("C");
            //listaLiaga.Adicionar("Z");
            //listaLiaga.Adicionar(2, "G");

            //listaLiaga.RemoverDoComeco();
            listaLiaga.Adicionar(1);
            listaLiaga.AdicionarNoComeco(0);
            listaLiaga.Adicionar(2);
            listaLiaga.Remover(1);
            //Console.WriteLine(listaLiaga.ToString());
            Console.WriteLine(listaLiaga.Contem(0));
        }
    }
}
