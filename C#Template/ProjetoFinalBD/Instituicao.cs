using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalBD
{
    class Instituicao
    {
        private int id;
        private String nome;
        private String descricao;
        private String aluno_criador;
        private Boolean disabled;

        public Instituicao(int id, string nome, string descricao, string aluno_criador, bool disabled)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
            this.aluno_criador = aluno_criador;
            this.disabled = disabled;
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Aluno_criador { get => aluno_criador; set => aluno_criador = value; }
        public bool Disabled { get => disabled; set => disabled = value; }

        public String Show()
        {
            return this.nome + " | " + this.descricao;
        }
    }
}
    