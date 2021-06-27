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
        private Dictionary<string, ClasseCadeira> listaCadeiras = new Dictionary<string, ClasseCadeira>();
        private Instituicoes inst;
        private String nomeAtual;
        private SqlConnection cn;

        public CriarInstituicao(Instituicoes inst)
        {
            InitializeComponent();
            this.inst = inst;
            if (!cadeirasVisiveis)
            {
                label1.Visible = false;
                cadeiras_instituicao.Visible = false;
                btnProcurar.Visible = false;
                filtroNome.Visible = false;
                btnApagarInstituicao.Visible = false;
            }
            else
            {
                nomeAtual = instituicaoAtual.Nome;
                loadInstInfo();
                showCadeiras();
            }
        }

        public void loadInstInfo()
        {
            nome.Text = instituicaoAtual.Nome;
            descricao.Text = instituicaoAtual.Descricao;
        }

        private SqlConnection getSGBDConnection()
        {
            return Login.bdConnection.getSGBDConnection();
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

            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            int id = instituicaoAtual.Id;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "PROJETO.deleteInstituicao";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível remover a instituição na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
                this.inst.showInstituicoes();
                this.Hide();
            }
        }

        private void showCadeiras()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.Instituicao " +
                              "JOIN PROJETO.Cadeira ON PROJETO.Instituicao.id = PROJETO.Cadeira.instituicao " +
                              "WHERE PROJETO.Instituicao.id = @id AND PROJETO.Cadeira.disabled = 0";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", instituicaoAtual.Id);
            cmd.Connection = cn;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                cadeiras_instituicao.Items.Clear();

                while (reader.Read())
                {
                    ClasseCadeira cadeira = new ClasseCadeira(Convert.ToInt32(reader[5]),
                                                       reader[6].ToString(),
                                                       reader[7].ToString(),
                                                       Convert.ToInt32(reader[8]),
                                                       Convert.ToInt32(reader[9]),
                                                       Convert.ToDouble(reader[10]),
                                                       reader[11].ToString(),
                                                       reader[12].ToString(),
                                                       Convert.ToInt32(reader[13]),
                                                       Convert.ToBoolean(reader[14]));


                    listaCadeiras.Add(cadeira.Nome,cadeira);
                    cadeiras_instituicao.Items.Add(cadeira.Nome);
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

               

                if (cadeirasVisiveis)
                {
                  
                    // é para fazer update

                    if (numInstituicoesHomonimas != 0 && nomeAtual != nome.Text)
                    {
                        MessageBox.Show("Já existe uma cadeira com esse nome.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    } else
                    {

                        SqlCommand command = new SqlCommand();

                        command.CommandText = "UPDATE PROJETO.Instituicao SET nome = @nome, descricao = @descricao WHERE id = @id ";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@nome", nome.Text);
                        command.Parameters.AddWithValue("@descricao", descricao.Text);
                        command.Parameters.AddWithValue("@id", instituicaoAtual.Id);
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
                        }
                        finally
                        {
                            this.inst.showInstituicoes();
                            this.Hide();
                            cn.Close();
                        }

                    }


                } else
                {

                    if (numInstituicoesHomonimas == 0)
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
                        }
                        finally
                        {
                            cn.Close();
                        }


                    }
                    else
                    {
                        MessageBox.Show("Já existe uma cadeira com esse nome.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                cn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.Instituicao " + 
                              "JOIN PROJETO.Cadeira ON PROJETO.Instituicao.id = PROJETO.Cadeira.instituicao " +
                              "WHERE PROJETO.Instituicao.id = @id " +
                              "AND PROJETO.Cadeira.disabled = 0 " +
                              "AND PROJETO.Cadeira.nome LIKE '%' + @filtro_nome + '%'";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", instituicaoAtual.Id);
            cmd.Parameters.AddWithValue("@filtro_nome", filtroNome.Text);
            cmd.Connection = cn;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                cadeiras_instituicao.Items.Clear();

                while (reader.Read())
                {
                    ClasseCadeira cadeira = new ClasseCadeira(Convert.ToInt32(reader[0]),
                                                       reader[6].ToString(),
                                                       reader[7].ToString(),
                                                       Convert.ToInt32(reader[8]),
                                                       Convert.ToInt32(reader[9]),
                                                       Convert.ToDouble(reader[10]),
                                                       reader[11].ToString(),
                                                       reader[12].ToString(),
                                                       Convert.ToInt32(reader[13]),
                                                       Convert.ToBoolean(reader[14]));

                    cadeiras_instituicao.Items.Add(cadeira.Nome);
                }

                if (listaCadeiras.Count() == 0)
                {
                    cadeiras_instituicao.Items.Add("Não existem cadeiras que contenham o nome introduzido.");
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

        private void cadeiras_instituicao_DoubleClick(object sender, EventArgs e)
        {
            FormState.PreviousPage = this;
            if (cadeiras_instituicao.SelectedItem != null)
            {
                //mostrar a cadeira
                Cadeira.criarCadeira = false;
                Cadeira.cadeiraAtual = listaCadeiras[cadeiras_instituicao.GetItemText(cadeiras_instituicao.SelectedItem)];
                InfoCadeira inst = new InfoCadeira();
                inst.Show();
            }
        }
    }
}