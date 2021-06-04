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
    public partial class BYOM : Form
    {
        public BYOM()
        {
            InitializeComponent();
            panelLeft.Height = btnHome.Height;
            panelLeft.Top = btnHome.Top;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnHome.Height;
            panelLeft.Top = btnHome.Top;
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnHome.Height;
            panelLeft.Top = btnHome.Top;
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
            panelLeft.Height = btnCadeiras.Height;
            panelLeft.Top = btnCadeiras.Top;
        }

        private void lblCadeiras_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnCadeiras.Height;
            panelLeft.Top = btnCadeiras.Top;
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

        private void btnInstituicoes_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnInstituicoes.Height;
            panelLeft.Top = btnInstituicoes.Top;
        }

        private void lblInstituicoes_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnInstituicoes.Height;
            panelLeft.Top = btnInstituicoes.Top;
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

        private void btnPaginas_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnPaginas.Height;
            panelLeft.Top = btnPaginas.Top;
        }

        private void lblPaginas_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnPaginas.Height;
            panelLeft.Top = btnPaginas.Top;
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

        private void btnTarefas_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnTarefas.Height;
            panelLeft.Top = btnTarefas.Top;
        }

        private void lblTarefas_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnTarefas.Height;
            panelLeft.Top = btnTarefas.Top;
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
    }
}
