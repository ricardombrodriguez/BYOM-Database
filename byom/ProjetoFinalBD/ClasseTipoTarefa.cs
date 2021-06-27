using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalBD
{
    public class ClasseTipoTarefa
    {
        private int id;
        private String designacao;
        private String aluno_criador;
        private Boolean disabled;

        public ClasseTipoTarefa(int id, string designacao, string aluno_criador, bool disabled)
        {
            this.id = id;
            this.designacao = designacao;
            this.aluno_criador = aluno_criador;
            this.disabled = disabled;
        }

        public int Id { get => id; set => id = value; }
        public string Designacao { get => designacao; set => designacao = value; }
        public string Aluno_criador { get => aluno_criador; set => aluno_criador = value; }
        public bool Disabled { get => disabled; set => disabled = value; }
    }
}
