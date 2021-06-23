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
    public partial class ModalColega : Form
    {
        private SqlConnection cn;
        public static CriarGrupo inst;

        public ModalColega()
        {
            InitializeComponent();
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

        private void btnAdicionarColega_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            //verificar se faltam parâmetros obrigatórios
            if (email.TextLength == 0)
            {
                MessageBox.Show("Insira o email do colega", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM PROJETO.Aluno WHERE email = @email";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Connection = cn;
                int alunoExistente = Convert.ToInt32(cmd.ExecuteScalar());

                if (alunoExistente == 1)
                {

                    SqlCommand command = new SqlCommand();

                    command.CommandText = "SELECT COUNT(*) FROM PROJETO.GrupoAluno WHERE grupo = @grupo AND aluno = @aluno";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@grupo", CriarGrupo.grupoAtual.Id);
                    command.Parameters.AddWithValue("@aluno", email.Text);
                    command.Connection = cn;
                    int pertence = Convert.ToInt32(command.ExecuteScalar());

                    if (pertence == 1)
                    {
                        MessageBox.Show("O aluno já pertence a esse grupo", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        SqlCommand c = new SqlCommand();

                        c.CommandText = "INSERT INTO PROJETO.GrupoAluno(grupo,aluno) VALUES (@grupo,@aluno)";
                        c.Parameters.Clear();
                        c.Parameters.AddWithValue("@grupo", CriarGrupo.grupoAtual.Id);
                        c.Parameters.AddWithValue("@aluno", email.Text);
                        c.Connection = cn;

                        try
                        {
                            c.ExecuteNonQuery();
                            cn.Close();
                            MessageBox.Show("Colega " + email.Text + " adicionado(a).", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            inst.ShowColegas();
                            this.Hide();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Não foi possível inserir a instituição na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Não existe uma conta associada a esse email", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
