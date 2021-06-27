using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalBD
{
    public class ClassePagina
    {
        private int id;
        private String titulo;
        private String texto;
        private String aluno;
        private int cadeira;
        private String codigo_criador;
        private int grupo;

        public ClassePagina(int id, string titulo, string texto, string aluno, int cadeira, string codigo_criador)
        {
            this.id = id;
            this.titulo = titulo;
            this.texto = texto;
            this.aluno = aluno;
            this.cadeira = cadeira;
            this.codigo_criador = codigo_criador;
        }

        public ClassePagina(int id, string titulo, string texto, string aluno, int cadeira, string codigo_criador, int grupo) : this(id, titulo, texto, aluno, cadeira, codigo_criador)
        {
            this.grupo = grupo;
        }

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Texto { get => texto; set => texto = value; }
        public string Aluno { get => aluno; set => aluno = value; }
        public int Cadeira { get => cadeira; set => cadeira = value; }
        public string Codigo_criador { get => codigo_criador; set => codigo_criador = value; }



    }
}
