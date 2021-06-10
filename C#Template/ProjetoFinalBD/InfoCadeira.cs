using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinalBD
{
    public partial class InfoCadeira: Form
    {
        private SqlConnection cn;

        public InfoCadeira()
        {
            InitializeComponent();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source=tcp:mednat.ieeta.pt\\SQLSERVER,8101;User ID=p9g5;Password=-737279605@BD");
        }

        private bool verifySGBDConnection()
        {

            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }


        private void btnGuardarCadeira_Click(object sender, EventArgs e)
        {
            //Funcionalidades:
            // Alterar os parâmetros da cadeira (NÃO SE FAZ INSERT)
            // -> cuidado com as dependências.. apagar a cadeira = apagar pags, tarefas associadas
            // Criar a cadeira (FAZ-SE INSERT)

            

            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

        private void btnApagarCadeira_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

    }
}
