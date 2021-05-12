using System;

namespace Estrutura_De_Dados
{
    public class Lista
    {
        public Aluno[] alunos = new Aluno[100];
        private int totalDeAlunos = 0;

        public void Adicionar(Aluno aluno)
        {
            alunos[totalDeAlunos] = aluno;
            totalDeAlunos++;
        }

        private bool PosicaoValida(int posicao) => posicao >= 0 && posicao <= totalDeAlunos;

        public void Adicionar(int posicao, Aluno aluno)
        {
            if (!PosicaoValida(posicao)) throw new IndexOutOfRangeException("Posicão inválida.");
            for (var i = totalDeAlunos - 1; i >= posicao; i -= 1)
            {
                alunos[i + 1] = alunos[i];
            }

            alunos[posicao] = aluno;
            totalDeAlunos++;
        }

        private bool PosicaoOcupada(int posicao) => posicao >= 0 && posicao < totalDeAlunos;

        public Aluno Obter(int posicao) =>
            !PosicaoOcupada(posicao) ?
                throw new IndexOutOfRangeException("Posicão inválida.") :
                alunos[posicao];

        public void Remover(int posicao)
        {
            for (var i = posicao; i < totalDeAlunos; i++)
            {
                alunos[i] = alunos[i + 1];
            }

            totalDeAlunos--;
        }

        public bool Contem(Aluno aluno)
        {
            for (var i = 0; i < totalDeAlunos; i++)
                if (aluno.Equals(alunos[i]))
                    return true;

            return false;
        }

        public int Tamanho() => totalDeAlunos;
    }
}
