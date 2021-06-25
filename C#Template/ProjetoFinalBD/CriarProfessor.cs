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
    public partial class CriarProfessor : Form
    {
        private SqlConnection cn;
        public static Boolean createProfessorCadeira;
        public static InfoCadeira instCadeira;
        public static Boolean createProfessor = true;
        public static CriarGrupo inst;
        public static ClasseProfessor professorAtual;

        public CriarProfessor()
        {
            InitializeComponent();
            if (createProfessor == false)
            {
                email.Text = professorAtual.Email;
                nome.Text = professorAtual.Nome;
                btnGuardarProfessor.Enabled = false;
                email.Enabled = false;
                nome.Enabled = false;
            } else
            {
                btnApagarProfessor.Enabled = false;
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

        private void btnGuardarProfessor_Click(object sender, EventArgs e)
        {

            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            //verificar se faltam parâmetros obrigatórios
            if (email.TextLength == 0 || nome.TextLength == 0)
            {
                MessageBox.Show("Insira todos os parâmetros obrigatórios.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM PROJETO.Professor WHERE nome = @nome AND email = @email";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nome", nome.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Connection = cn;
                int numProf = Convert.ToInt32(cmd.ExecuteScalar());


                if (numProf == 0)
                {
                    //é para fazer insert

                    cn = getSGBDConnection();

                    if (!verifySGBDConnection())
                        return;

                    SqlCommand command = new SqlCommand();

                    command.CommandText = "INSERT INTO PROJETO.Professor(email,nome) VALUES (@email,@nome);";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@email", email.Text);
                    command.Parameters.AddWithValue("@nome", nome.Text);
                    command.Connection = cn;


                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Professor(a) " + nome.Text + " criado(a).", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Não foi possível inserir o professor na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                    }

                    if (createProfessorCadeira)
                    {
                        cn = getSGBDConnection();

                        if (!verifySGBDConnection())
                            return;

                        SqlCommand comando = new SqlCommand();

                        comando.CommandText = "INSERT INTO PROJETO.ProfessorCadeira(professor,cadeira) VALUES (@professor,@cadeira);";
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@professor", email.Text);
                        comando.Parameters.AddWithValue("@cadeira", Cadeira.cadeiraAtual.Id);
                        comando.Connection = cn;


                        try
                        {
                            comando.ExecuteNonQuery();
                            MessageBox.Show("Professor(a) " + nome.Text + " adicionado à cadeira.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }

                        catch (Exception ex)
                        {
                            throw new Exception("Não foi possível inserir o professor na cadeira na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                        }
                        finally
                        {
                            instCadeira.showProfessores();
                            cn.Close();
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Já existe um(a) professor(a) com esse email.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            cn.Close();
            

        }

        private void btnApagarProfessor_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "PROJETO.deleteProfessor";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@email", email.Text);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível remover o professor da base de dados. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                
                if (InfoCadeira.returnToCriarTarefa)
                {
                    SqlCommand comando = new SqlCommand();
                    comando.CommandText = "DELETE FROM PROJETO.ProfessorCadeira WHERE professor = @professor AND cadeira = @cadeira";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@professor", email.Text);
                    comando.Parameters.AddWithValue("@cadeira", Cadeira.cadeiraAtual.Id);
                    comando.Connection = cn;

                    try
                    {
                        comando.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Não foi possível remover o professor da professorCadeira na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                    }

                    instCadeira.showProfessores();
                }
                else
                {
                    inst.ShowProfessores();
                }
                cn.Close();
                this.Hide();
            }
        }
    }
}
