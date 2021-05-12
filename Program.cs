using System;

namespace Estrutura_De_Dados
{
    class Program
    {
        static void Main(string[] args)
        {
            var aluno1 = new Aluno("A");
            var aluno2 = new Aluno("B");
            var aluno3 = new Aluno("C");

            var lista = new Lista();
            lista.Adicionar(aluno1);
            lista.Adicionar(aluno2);

            //Console.WriteLine(lista.Tamanho());
            //Console.WriteLine(lista.Contem(aluno1));
            //Console.WriteLine(lista.Obter(0).Nome);
            //lista.Remover(1);

            foreach (var aluno in lista.alunos) Console.WriteLine(aluno != null ? aluno.Nome : "Vazio");
        }
    }
}
