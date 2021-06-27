using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinalBD
{
    public partial class Login : Form
    {

        private SqlConnection cn;
        public static String utilizador;

        public Login()
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

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage = this;
            this.Hide();
            CriarConta novaconta = new CriarConta();
            novaconta.Show();

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {

            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            using (cn)
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(password.Text);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                String hashedPassword = System.Text.Encoding.ASCII.GetString(data);

                SqlCommand command = new SqlCommand("PROJETO.login", cn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@email", email.Text);
                command.Parameters.AddWithValue("@password", hashedPassword);
                int result = (int)command.ExecuteScalar();
                Boolean validation = Convert.ToBoolean(result);
                try
                {
     
                    if (validation)
                    {
                        Login.utilizador = email.Text;
                        this.Hide();
                        BYOM entrar = new BYOM();
                        entrar.Show();
                     
                    }
                    else
                    {
                        MessageBox.Show("Insira um email e password correta", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
                }
            }

            cn.Close();
        }
    }
}
