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
    public partial class CriarInstituicao : Form
    {

        private SqlConnection cn;

        public CriarInstituicao()
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

        private void btnApagarInstituicao_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

        private void btnGuardarInstituicao_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            //verificar se faltam parâmetros obrigatórios
            if (nome.TextLength == 0 || descricao.TextLength == 0)
            {
                MessageBox.Show("Insira todos os parâmetros obrigatórios.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //verificar se já existe uma instituião com esse nome (não importa se estamos a fazer update/insert)

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM PROJETO.Instituicao WHERE nome = @nome";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nome", nome.Text);
                cmd.Connection = cn;
                int numInstituicoesHomonimas = Convert.ToInt32(cmd.ExecuteScalar());

                if (numInstituicoesHomonimas == 0)
                {
                    if (Instituicoes.selected_id == 0)
                    {
                        //é para fazer insert

                        SqlCommand command = new SqlCommand();

                        command.CommandText = "INSERT PROJETO.Instituicao VALUES (@nome, @descricao, @aluno_criador) ";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@nome", nome.Text);
                        command.Parameters.AddWithValue("@descricao", descricao.Text);
                        command.Parameters.AddWithValue("@aluno_criador", Login.utilizador);
                        command.Connection = cn;
                        
                        MessageBox.Show(nome.Text);
                        MessageBox.Show(descricao.Text);
                        MessageBox.Show(Login.utilizador);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Instituição " + nome.Text + " criada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            FormState.PreviousPage.Show();
                            this.Hide();
                            FormState.PreviousPage = this;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Não foi possível inserir a instituição na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                        }
                    } else
                    {
                        // é para fazer update

                        SqlCommand command = new SqlCommand();

                        command.CommandText = "UPDATE PROJETO.Instituicao SET nome = @nome, descricao = @descricao WHERE id = @selected_id ";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@nome", nome.Text);
                        command.Parameters.AddWithValue("@descricao", descricao.Text);
                        command.Parameters.AddWithValue("@selected_id", Instituicoes.selected_id);
                        command.Connection = cn;

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Instituição " + nome.Text + " foi atualizada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            FormState.PreviousPage.Show();
                            this.Hide();
                            FormState.PreviousPage = this;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Não foi possível inserir a instituição na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                        }
                    }
                    
                } else
                {
                    MessageBox.Show("Já existe uma cadeira com esse nome.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }
    }
}
