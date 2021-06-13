using System;

namespace poo_exemple
{
    public class Serie : BaseEntity
    {
        // Atributos

        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private int Type { get; set; }
        private bool Removed { get; set; }
        // Métodos

        public Serie(int id, int type, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Type = type;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
        }

        public override string ToString()
        {
            return $"\nGênero: {this.Genero}\nTítulo: {this.Titulo}\nDescrição: {this.Descricao}\nAno de Início: {this.Ano}\nTipo: {Enum.GetName(typeof(Types), this.Type)}\nRemoved: {this.getRemoved()}";
        }

        public string getTitulo()
        {
            return this.Titulo;
        }
        public int getType()
        {
            return this.Type;
        }
        public bool getRemoved()
        {
            return this.Removed;
        }
        public void remove()
        {
            this.Removed = true;
        }

        public int getId()
        {
            return this.Id;
        }
    }
}