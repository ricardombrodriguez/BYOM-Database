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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage = this;
            this.Hide();
            CriarConta novaconta = new CriarConta();
            novaconta.Show();

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage = this;
            this.Hide();
            BYOM entrar = new BYOM();
            entrar.Show();
        }
    }
}
