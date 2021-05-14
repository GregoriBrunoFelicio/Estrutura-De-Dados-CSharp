using System;
using System.Text;

namespace Estrutura_De_Dados
{
    public class ListaDuplamenteLigada
    {
        private Celula Primeira { get; set; }
        private Celula Ultima { get; set; }
        private int TotalDeElementos { get; set; }

        public void AdicionarNoComeco(object elemento)
        {
            if (TotalDeElementos == 0)
            {
                var nova = new Celula(elemento);
                Primeira = nova;
                Ultima = nova;
            }
            else
            {
                var nova = new Celula(elemento, Primeira);
                Primeira.Anterior = nova;
                Primeira = nova;
            }
            TotalDeElementos++;
        }


        public void Adicionar(object elemento)
        {
            if (this.TotalDeElementos == 0)
                AdicionarNoComeco(elemento);
            else
            {
                var nova = new Celula(elemento);
                Ultima.Proximo = nova;
                nova.Anterior = Ultima;
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
                var proxima = anterior.Proximo;
                var nova = new Celula(elemento, anterior.Proximo) { Anterior = anterior };
                anterior.Proximo = nova;
                proxima.Anterior = nova;
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

        public void RemoverDoFim()
        {
            if (TotalDeElementos == 1)
            {
                RemoverDoComeco();
            }
            else
            {
                var penultima = Ultima.Anterior;
                penultima.Proximo = null;
                Ultima = penultima;
                TotalDeElementos--;
            }
        }

        public void Remover(int posicao)
        {
            if (TotalDeElementos == 0)
            {
                RemoverDoComeco();
            }
            else if (posicao == TotalDeElementos - 1)
            {
                RemoverDoFim();
            }
            else
            {
                var anterior = ObterCelula(posicao - 1);
                var atual = anterior.Proximo;
                var proximo = atual.Proximo;

                anterior.Proximo = proximo;
                proximo.Anterior = anterior;

                TotalDeElementos--;
            }
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
