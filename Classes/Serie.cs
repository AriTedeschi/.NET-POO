using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id        = id;
            this.Genero    = genero;
            this.Titulo    = titulo;
            this.Descricao = descricao;
            this.Ano       = ano;
            this.Excluido  = false;
        }

        private Genero  Genero { get; set;}
        private string  Titulo { get; set;}
        private string  Descricao { get; set;}
        private int     Ano { get; set;}
        private bool    Excluido { get; set; }

        public override string ToString()
        {
            string re = "";
            re += "Gênero        : " + this.Genero + Environment.NewLine;
            re += "Titulo        : " + this.Titulo + Environment.NewLine;
            re += "Descrição     : " + this.Descricao + Environment.NewLine;
            re += "Ano de Início : " + this.Ano + Environment.NewLine;
            re += "Excluido      : " + this.Excluido + Environment.NewLine;
            return re;
        }

        #region Encapsulamento
        public int    getId()
        {
            return this.Id;
        }
        public string getTitulo()
        {
            return this.Titulo;
        }
        public string getDescricao()
        {
            return this.Descricao;
        }
        public int    getAno()
        {
            return this.Ano;
        }
        public bool   getExcluir()
        {
            return this.Excluido;
        }

        public void excluir()
        {
            this.Excluido = true;
        }
        #endregion
    }
}