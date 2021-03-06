using System;
using System.Text;

namespace Estrutura_De_Dados
{
    public class ListaLigada
    {
        private Celula Primeira { get; set; }
        private Celula Ultima { get; set; }
        private int TotalDeElementos { get; set; }

        public void AdicionarNoComeco(object elemento)
        {
            var novaCelula = new Celula(elemento, Primeira);
            Primeira = novaCelula;

            if (TotalDeElementos == 0)
            {
                Ultima = Primeira;
            }

            TotalDeElementos++;
        }


        public void Adicionar(object elemento)
        {
            if (this.TotalDeElementos == 0)
                AdicionarNoComeco(elemento);
            else
            {
                var nova = new Celula(elemento, null);
                Ultima.Proximo = nova;
                Ultima = nova;
                TotalDeElementos++;
            }
        }

        public void Adicionar(int posicao, object elemento)
        {
            if (posicao == 0)
            {
                AdicionarNoComeco(elemento);
            }
            else if (posicao == TotalDeElementos)
            {
                Adicionar(elemento);
            }
            else
            {
                var anterior = ObterCelula(posicao - 1);
                var novaCelula = new Celula(elemento, anterior.Proximo);
                anterior.Proximo = novaCelula;
                TotalDeElementos++;
            }
        }

        private bool PosicaoOcupada(int posicao) => posicao >= 0 && posicao < TotalDeElementos;

        private Celula ObterCelula(int posicao)
        {
            if (!PosicaoOcupada(posicao))
            {
                throw new ArgumentOutOfRangeException($"Posicao inexistente.");
            }
            var atual = Primeira;

            for (var i = 0; i < posicao; i++) atual = atual.Proximo;

            return atual;
        }

        public object Obter(int posicao) => this.ObterCelula(posicao).Elemento;

        public void RemoverDoComeco()
        {
            if (TotalDeElementos == 0)
                throw new ArgumentOutOfRangeException($"Lista vazia.");

            Primeira = Primeira.Proximo;
            TotalDeElementos--;

            if (TotalDeElementos == 0) Ultima = null;
        }

        public int Tamanho() => TotalDeElementos;

        public bool Contem(object elemento)
        {
            var atual = Primeira;
            while (atual != null)
            {
                if (atual.Elemento.Equals(elemento)) return true;

                atual = atual.Proximo;
            }
            return false;
        }

        public override string ToString()
        {
            if (TotalDeElementos == 0) return "[]";
            var atual = Primeira;

            var stringBuilder = new StringBuilder("[");

            for (var i = 0; i < TotalDeElementos; i++)
            {
                stringBuilder.Append(atual.Elemento);
                stringBuilder.Append(",");
                atual = atual.Proximo;
            }

            stringBuilder.Append("]");

            return stringBuilder.ToString();
        }
    }
}
