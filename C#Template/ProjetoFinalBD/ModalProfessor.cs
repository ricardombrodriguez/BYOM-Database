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
    public partial class ModalProfessor : Form
    {
        private SqlConnection cn;
        public static CriarGrupo inst;

        public ModalProfessor()
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


        private void btnAdicionarProfessor_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            //verificar se faltam parâmetros obrigatórios
            if (email.TextLength == 0)
            {
                MessageBox.Show("Insira o email do professor", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM PROJETO.Professor WHERE email = @email";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Connection = cn;
                int professorExistente = Convert.ToInt32(cmd.ExecuteScalar());

                if (professorExistente == 1)
                {

                    SqlCommand cm = new SqlCommand();
                    cm.CommandText = "SELECT COUNT(*) FROM PROJETO.GrupoProfessor WHERE grupo = @grupo AND professor = @professor";
                    cm.Parameters.Clear();
                    cm.Parameters.AddWithValue("@grupo", CriarGrupo.grupoAtual.Id);
                    cm.Parameters.AddWithValue("@professor", email.Text);
                    cm.Connection = cn;
                    int professorNoGrupo = Convert.ToInt32(cm.ExecuteScalar());

                    //se o prof já está no grupo ou n
                    if (professorNoGrupo != 0)
                    {

                        MessageBox.Show("O professor já é orientador do grupo.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    } else
                    {
                        SqlCommand command = new SqlCommand();

                        command.CommandText = "INSERT INTO PROJETO.GrupoProfessor(grupo,professor) VALUES (@grupo,@professor);";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@grupo", CriarGrupo.grupoAtual.Id);
                        command.Parameters.AddWithValue("@professor", email.Text);
                        command.Connection = cn;


                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Professor(a) " + email.Text + " foi adicionado(a) ao grupo.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Não foi possível inserir o professor no grupo \n ERROR MESSAGE: \n" + ex.Message);
                        }


                        //inserir professor no professorcadeira se ainda n estiver

                        SqlCommand temp = new SqlCommand();
                        temp.CommandText = "SELECT COUNT(*) FROM PROJETO.ProfessorCadeira WHERE professor = @professor AND cadeira = @cadeira";
                        temp.Parameters.Clear();
                        temp.Parameters.AddWithValue("@cadeira", CriarGrupo.grupoAtual.Cadeira);
                        temp.Parameters.AddWithValue("@professor", email.Text);
                        temp.Connection = cn;
                        int professorNaCadeira = Convert.ToInt32(temp.ExecuteScalar());

                        if (professorNaCadeira == 0)
                        {
                            SqlCommand comando = new SqlCommand();

                            comando.CommandText = "INSERT INTO PROJETO.ProfessorCadeira(professor,cadeira) VALUES (@professor,@cadeira);";
                            comando.Parameters.Clear();
                            comando.Parameters.AddWithValue("@professor", email.Text);
                            comando.Parameters.AddWithValue("@cadeira", CriarGrupo.grupoAtual.Cadeira);
                            comando.Connection = cn;


                            try
                            {
                                comando.ExecuteNonQuery();
                                MessageBox.Show("Professor(a) " + email.Text + " foi adicionado(a) à cadeira do grupo.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Não foi possível inserir o professor no grupo \n ERROR MESSAGE: \n" + ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("O professor já pertence à cadeira", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Não existe esse professor. Crie um novo professor.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
 
            cn.Close();
            inst.ShowProfessores();
            this.Hide();

        }

        private void btnCriarProfessor_Click(object sender, EventArgs e)
        {
            CriarProfessor prof = new CriarProfessor();
            prof.Show();
            CriarProfessor.createProfessor = true;
        }
    }
}

