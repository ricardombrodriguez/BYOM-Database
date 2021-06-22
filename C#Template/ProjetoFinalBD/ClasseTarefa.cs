using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalBD
{
    public class ClasseTarefa
    {
        private int id;
        private String titulo;
        private String descricao;
        private String completada_ts;
        private String data_inicio;
        private String date_final;
        private int tipoTarefa;
        private String aluno;
        private int cadeira;
        private String codigo_criador;

        public ClasseTarefa(int id, string titulo, string descricao, String completada_ts, String data_inicio, String date_final, int tipoTarefa, string aluno, int cadeira, string codigo_criador)
        {
            this.id = id;
            this.titulo = titulo;
            this.descricao = descricao;
            this.completada_ts = completada_ts;
            this.data_inicio = data_inicio;
            this.date_final = date_final;
            this.tipoTarefa = tipoTarefa;
            this.aluno = aluno;
            this.cadeira = cadeira;
            this.codigo_criador = codigo_criador;
        }

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public String Completada_ts { get => completada_ts; set => completada_ts = value; }
        public String Data_inicio { get => data_inicio; set => data_inicio = value; }
        public int TipoTarefa { get => tipoTarefa; set => tipoTarefa = value; }
        public string Aluno { get => aluno; set => aluno = value; }
        public String Date_final { get => date_final; set => date_final = value; }
        public int Cadeira { get => cadeira; set => cadeira = value; }
        public string Codigo_criador { get => codigo_criador; set => codigo_criador = value; }
    }
}
