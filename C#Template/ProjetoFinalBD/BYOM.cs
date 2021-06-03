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

        private void btnCadeiras_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnCadeiras.Height;
            panelLeft.Top = btnCadeiras.Top;
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

        private void lblCadeiras_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnCadeiras.Height;
            panelLeft.Top = btnCadeiras.Top;
        }
    }
}
