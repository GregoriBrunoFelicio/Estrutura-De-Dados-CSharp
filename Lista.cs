using System;

namespace Estrutura_De_Dados
{
    public class Lista
    {
        public Aluno[] alunos = new Aluno[100];
        private int totalDeAlunos;

        public void Adicionar(Aluno aluno)
        {
            VerificarEspacoArray();
            alunos[totalDeAlunos] = aluno;
            totalDeAlunos++;
        }


        public void Adicionar(int posicao, Aluno aluno)
        {
            VerificarEspacoArray();

            if (!PosicaoValida(posicao)) throw new IndexOutOfRangeException("Posicão inválida.");
            for (var i = totalDeAlunos - 1; i >= posicao; i -= 1)
            {
                alunos[i + 1] = alunos[i];
            }

            alunos[posicao] = aluno;
            totalDeAlunos++;
        }

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

        private bool PosicaoValida(int posicao) => posicao >= 0 && posicao <= totalDeAlunos;

        private bool PosicaoOcupada(int posicao) => posicao >= 0 && posicao < totalDeAlunos;

        private void VerificarEspacoArray()
        {
            if (totalDeAlunos != alunos.Length) return;
            var novoArray = new Aluno[alunos.Length * 2];
            for (var i = 0; i < alunos.Length; i++)
            {
                novoArray[i] = alunos[i];
            }
            alunos = novoArray;
        }
    }
}
