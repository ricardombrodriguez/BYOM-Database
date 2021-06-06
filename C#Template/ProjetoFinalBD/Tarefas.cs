using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinalBD
{
    public partial class Tarefas : Form
    {
        public Tarefas()
        {
            InitializeComponent();
            panelLeft.Height = btnTarefas.Height;
            panelLeft.Top = btnTarefas.Top;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            BYOM home = new BYOM();
            home.Show();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            BYOM home = new BYOM();
            home.Show();
        }

        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.ForeColor = Color.White;
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void lblHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.ForeColor = Color.White;
        }

        private void btnCadeiras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cadeira cadeira = new Cadeira();
            cadeira.Show();
        }

        private void lblCadeiras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cadeira cadeira = new Cadeira();
            cadeira.Show();
        }

        private void btnCadeiras_MouseEnter(object sender, EventArgs e)
        {
            btnCadeiras.ForeColor = Color.White;
        }

        private void btnCadeiras_MouseLeave(object sender, EventArgs e)
        {
            btnCadeiras.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void lblCadeiras_MouseEnter(object sender, EventArgs e)
        {
            btnCadeiras.ForeColor = Color.White;
        }

        private void btnPaginas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Paginas pagina = new Paginas();
            pagina.Show();
        }

        private void lblPaginas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Paginas pagina = new Paginas();
            pagina.Show();
        }

        private void btnPaginas_MouseEnter(object sender, EventArgs e)
        {
            btnPaginas.ForeColor = Color.White;
        }

        private void btnPaginas_MouseLeave(object sender, EventArgs e)
        {
            btnPaginas.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void lblPaginas_MouseEnter(object sender, EventArgs e)
        {
            btnPaginas.ForeColor = Color.White;
        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grupos grupos = new Grupos();
            grupos.Show();
        }

        private void lblGrupos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grupos grupos = new Grupos();
            grupos.Show();
        }

        private void btnGrupos_MouseEnter(object sender, EventArgs e)
        {
            btnGrupos.ForeColor = Color.White;
        }

        private void btnGrupos_MouseLeave(object sender, EventArgs e)
        {
            btnGrupos.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void lblGrupos_MouseEnter(object sender, EventArgs e)
        {
            btnGrupos.ForeColor = Color.White;
        }

        private void btnInstituicoes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instituicoes instituicao = new Instituicoes();
            instituicao.Show();
        }

        private void lblInstituicoes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instituicoes instituicao = new Instituicoes();
            instituicao.Show();
        }

        private void btnInstituicoes_MouseEnter(object sender, EventArgs e)
        {
            btnInstituicoes.ForeColor = Color.White;
        }

        private void btnInstituicoes_MouseLeave(object sender, EventArgs e)
        {
            btnInstituicoes.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void lblInstituicoes_MouseEnter(object sender, EventArgs e)
        {
            btnInstituicoes.ForeColor = Color.White;
        }

        private void btnTarefas_Click(object sender, EventArgs e)
        {
            //
        }

        private void lblTarefas_Click(object sender, EventArgs e)
        {
            //
        }
        private void btnTarefas_MouseEnter(object sender, EventArgs e)
        {
            btnTarefas.ForeColor = Color.White;
        }

        private void btnTarefas_MouseLeave(object sender, EventArgs e)
        {
            btnTarefas.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void lblTarefas_MouseEnter(object sender, EventArgs e)
        {
            btnTarefas.ForeColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CriarTarefa tarefa = new CriarTarefa();
            tarefa.Show();
            FormState.PreviousPage = this;
        }
    }
}
