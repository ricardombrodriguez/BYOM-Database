﻿using System;
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
    public partial class Cadeira : Form
    {
        public Cadeira()
        {
            InitializeComponent();
            panelLeft.Height = btnCadeiras.Height;
            panelLeft.Top = btnCadeiras.Top;
        }

        private void btnCadeiras_Click(object sender, EventArgs e)
        {
            //mesmo
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

        private void lblCadeiras_Click(object sender, EventArgs e)
        {
            //mesmo
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

        private void lblTarefas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tarefas tarefa = new Tarefas();
            tarefa.Show();
        }

        private void btnTarefas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tarefas tarefa = new Tarefas();
            tarefa.Show();
        }

        private void btnCriarCadeira_Click(object sender, EventArgs e)
        {
            CadeiraInfo novaCadeira = new CadeiraInfo();
            novaCadeira.Show();
        }

    }
}
