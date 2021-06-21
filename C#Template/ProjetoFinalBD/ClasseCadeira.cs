using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalBD
{
    public class ClasseCadeira
    {
        private int id;
        private String nome;
        private String link;
        private int ano;
        private int semestre;
        private double nota_final;
        private String aluno;
        private String codigo_criador;
        private int instituicao;
        private Boolean disabled;

        public ClasseCadeira(int id, string nome, string link, int ano, int semestre, double nota_final, string aluno, string codigo_criador, int instituicao, bool disabled)
        {
            this.id = id;
            this.nome = nome;
            this.link = link;
            this.ano = ano;
            this.semestre = semestre;
            this.nota_final = nota_final;
            this.aluno = aluno;
            this.codigo_criador = codigo_criador;
            this.instituicao = instituicao;
            this.disabled = disabled;
        }

        public ClasseCadeira(int id, String nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Link { get => link; set => link = value; }
        public int Ano { get => ano; set => ano = value; }
        public int Semestre { get => semestre; set => semestre = value; }
        public double Nota_final { get => nota_final; set => nota_final = value; }
        public string Aluno { get => aluno; set => aluno = value; }
        public string Codigo_criador { get => codigo_criador; set => codigo_criador = value; }
        public int Instituicao { get => instituicao; set => instituicao = value; }
        public bool Disabled { get => disabled; set => disabled = value; }

        public String Show()
        {
            return this.Nome + " - Ano: " + this.ano;
        }
    }
}
