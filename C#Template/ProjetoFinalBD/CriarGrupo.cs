using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjetoFinalBD
{
    public partial class CriarGrupo : Form
    {
        private SqlConnection cn;
        private string id;

        public CriarGrupo(string id = "")
        {
            InitializeComponent();

            if (id == "")
            {
                btnApagarGrupo.Visible = false;

                // carregar todas as cadeiras e meter na combo
            }

            else
            {
                // deixar o botão visivel,
                // carregar os dados para as caixas de texto e meter o id numa text escondida
            }
        }

        private void CriarGrupo_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source=tcp:mednat.ieeta.pt\\SQLSERVER,8101;Persist Security Info=True;User ID=p9g5;Password=-737279605@BD;");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void btnApagarGrupo_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

        private void btnGuardarGrupo_Click(object sender, EventArgs e)
        {
            if (grupo_nome.TextLength == 0 || grupo_cadeira.Text.Length == 0)
            {
                MessageBox.Show("Os campos têm de estar preenchidos.", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // ver também o que fazer com as listBoxes

                if (!verifySGBDConnection())
                    return;
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "INSERT PROJETO.Grupo VALUES (@nome, @cadeira, @codigo_criador) ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nome", grupo_nome.Text);
                cmd.Parameters.AddWithValue("@cadeira", grupo_cadeira.SelectedValue);
                cmd.Parameters.AddWithValue("@codigo_criador", "");
                cmd.Connection = cn;

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to insert Group in database. \n ERROR MESSAGE: \n" + ex.Message);
                }
                finally
                {
                    cn.Close();
                }

                MessageBox.Show("", "Grupo Adicionado",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormState.PreviousPage.Show();
                this.Hide();
                FormState.PreviousPage = this;
            }
            
            
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
