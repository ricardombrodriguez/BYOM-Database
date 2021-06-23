using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalBD
{
    public class ClasseProfessor
    {
        private String email;
        private String nome;
        private Boolean disabled;

        public ClasseProfessor(string email, string nome, bool disabled)
        {
            this.email = email;
            this.nome = nome;
            this.disabled = disabled;
        }

        public string Email { get => email; set => email = value; }
        public string Nome { get => nome; set => nome = value; }
        public bool Disabled { get => disabled; set => disabled = value; }
    }
}
