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
    public partial class CriarGrupo : Form
    {
        public CriarGrupo()
        {
            InitializeComponent();
        }

        private void btnApagarGrupo_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

        private void btnGuardarGrupo_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

        private void addColega_Click(object sender, EventArgs e)
        {
            ModalColega colega = new ModalColega();
            colega.Show();
        }

        private void addOrientador_Click(object sender, EventArgs e)
        {
            ModalProfessor professor = new ModalProfessor();
            professor.Show();
        }
    }
}
