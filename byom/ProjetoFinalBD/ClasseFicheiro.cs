using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalBD
{
    public class ClasseFicheiro
    {

        private int id;
        private String nome;
        private String localizacao;
        private String aluno;
        private String codigo_criador;

        public ClasseFicheiro(int id, string nome, string localizacao, string aluno, string codigo_criador)
        {
            this.id = id;
            this.nome = nome;
            this.localizacao = localizacao;
            this.aluno = aluno;
            this.codigo_criador = codigo_criador;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Localizacao { get => localizacao; set => localizacao = value; }
        public string Aluno { get => aluno; set => aluno = value; }
        public string Codigo_criador { get => codigo_criador; set => codigo_criador = value; }
    }
}
