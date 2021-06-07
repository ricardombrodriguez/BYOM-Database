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
    public partial class ModalProfessor : Form
    {
        public ModalProfessor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }
    }
}
