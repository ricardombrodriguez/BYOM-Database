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
    public partial class CriarTarefa : Form
    {

        private SqlConnection cn;
        public static Boolean createTarefa;
        private List<ClasseCadeira> lstCadeiras;
        private List<ClasseTipoTarefa> lstTipoTarefa;

        public CriarTarefa()
        {
            InitializeComponent();
            PopulateTipoTarefa();
            PopulateCadeiras();

            if (createTarefa)
            {
                btnApagar.Visible = false;
            } else
            {

            }

        }

        private void PopulateCadeiras()
        {

            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PROJETO.Cadeira WHERE aluno = @aluno AND disabled = 0;";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@aluno", Login.utilizador);
            command.Connection = cn;

            lstCadeiras = new List<ClasseCadeira>();

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                cadeira.Items.Clear();

                while (reader.Read())
                {
                    ClasseCadeira inst = new ClasseCadeira(Convert.ToInt32(reader["id"]),
                                                            reader["nome"].ToString());

                    lstCadeiras.Add(inst);

                    cadeira.Items.Add(inst.Nome);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);

            }

            cn.Close();

        }

        private void PopulateTipoTarefa()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            lstTipoTarefa = new List<ClasseTipoTarefa>();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PROJETO.TipoTarefa WHERE aluno_criador = @aluno_criador AND disabled = 0;";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@aluno_criador", Login.utilizador);
            command.Connection = cn;

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                tipoTarefa.Items.Clear();

                while (reader.Read())
                {
                    ClasseTipoTarefa inst = new ClasseTipoTarefa(Convert.ToInt32(reader["id"]),
                                                       reader["designacao"].ToString(),
                                                       reader["aluno_criador"].ToString(),
                                                       Convert.ToBoolean(reader["disabled"]));

                    lstTipoTarefa.Add(inst);
                    tipoTarefa.Items.Add(inst.Designacao);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);

            }
            finally
            {
                cn.Close();
            }
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

        private void btnApagar_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            if (titulo.TextLength == 0 || tipoTarefa.SelectedItem == null)
            {
                MessageBox.Show("Os campos têm de estar preenchidos.", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

        private void addTipoTarefa_Click(object sender, EventArgs e)
        {
            CriarTipoTarefa novo = new CriarTipoTarefa();
            novo.Show();
        }
    }

}
