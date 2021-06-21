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

        public static Boolean cadeirasVisiveis;
        public static ClasseInstituicao instituicaoAtual;
        private List<ClasseCadeira> listaCadeiras;
        private Instituicoes inst;
        private SqlConnection cn;

        public CriarInstituicao(Instituicoes inst)
        {
            InitializeComponent();
            if (!cadeirasVisiveis)
            {
                label1.Visible = false;
                cadeiras_instituicao.Visible = false;
            } else
            {
                label1.Visible = true;
                cadeiras_instituicao.Visible = true;
                listaCadeiras = new List<ClasseCadeira>();
                showCadeiras();
            }
            this.inst = inst;
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

        private void showCadeiras()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.Instituicao " +
                              "JOIN PROJETO.Cadeira ON Instituicao.id = Cadeira.instituicao" +
                              "WHERE Instituicao.id = @id AND Cadeira.disabled = 0";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", instituicaoAtual.Id);
            cmd.Connection = cn;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                cadeiras_instituicao.Items.Clear();

                while (reader.Read())
                {
                    ClasseCadeira cadeira = new ClasseCadeira(Convert.ToInt32(reader["id"]),
                                                       reader["nome"].ToString(),
                                                       reader["link"].ToString(),
                                                       Convert.ToInt32(reader["ano"]),
                                                       Convert.ToInt32(reader["semestre"]),
                                                       Convert.ToDouble(reader["nota_final"]),
                                                       reader["aluno"].ToString(),
                                                       reader["codigo_criador"].ToString(),
                                                       Convert.ToInt32(reader["instituicao"]),
                                                       Convert.ToBoolean(reader["disabled"]));

                    listaCadeiras.Add(cadeira);
                    cadeiras_instituicao.Items.Add(cadeira.Show());
                }

                if (listaCadeiras.Count() == 0)
                {
                    cadeiras_instituicao.Items.Add("Não existem cadeiras associadas à instituição");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível visualizar as cadeiras da instituição. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
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
                    //verificar se já existe uma instituião com esse nome para esse utilizador (não importa se estamos a fazer update/insert)

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM PROJETO.Instituicao WHERE nome = @nome AND aluno_criador = @aluno_criador";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@nome", nome.Text);
                    cmd.Parameters.AddWithValue("@aluno_criador", Login.utilizador);
                    cmd.Connection = cn;
                    int numInstituicoesHomonimas = Convert.ToInt32(cmd.ExecuteScalar());

                    cn.Close();

                    if (numInstituicoesHomonimas == 0)
                    {
                        if (Instituicoes.selected_id == 0)
                        {
                            //é para fazer insert

                            cn = getSGBDConnection();

                            if (!verifySGBDConnection())
                                return;

                            SqlCommand command = new SqlCommand();

                            command.CommandText = "INSERT INTO PROJETO.Instituicao(nome,descricao,aluno_criador) VALUES (@nome,@descricao,@aluno_criador);";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@nome", nome.Text);
                            command.Parameters.AddWithValue("@descricao", descricao.Text);
                            command.Parameters.AddWithValue("@aluno_criador", Login.utilizador);
                            command.Connection = cn;


                            try
                            {
                                command.ExecuteNonQuery();
                                MessageBox.Show("Instituição " + nome.Text + " criada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.inst.showInstituicoes();
                                this.Hide();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Não foi possível inserir a instituição na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                            } finally
                            {
                                cn.Close();
                            }
                        } else
                        {
                            // é para fazer update

                            cn = getSGBDConnection();

                            if (!verifySGBDConnection())
                                return;

                            SqlCommand command = new SqlCommand();

                            command.CommandText = "UPDATE PROJETO.Instituicao SET nome = @nome, descricao = @descricao WHERE id = @selected_id ";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@nome", nome.Text);
                            command.Parameters.AddWithValue("@descricao", descricao.Text);
                            command.Parameters.AddWithValue("@selected_id", Instituicoes.selected_id);
                            command.Connection = cn;

                            try
                            {
                                command.ExecuteNonQuery();
                                MessageBox.Show("Instituição " + nome.Text + " foi atualizada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                FormState.PreviousPage.Show();
                                this.Hide();
                                FormState.PreviousPage = this;
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Não foi possível inserir a instituição na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                            } finally
                            {
                                cn.Close();
                            }
                        }
                    
                    } else
                    {
                        MessageBox.Show("Já existe uma cadeira com esse nome.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }
    }
}
