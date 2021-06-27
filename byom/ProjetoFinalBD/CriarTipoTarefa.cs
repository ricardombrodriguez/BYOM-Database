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
    public partial class CriarTipoTarefa : Form
    {

        private SqlConnection cn;

        public CriarTipoTarefa()
        {
            InitializeComponent();
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

        private void btnAdicionarTipoTarefa_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            if (designacao.TextLength == 0)
            {
                MessageBox.Show("Insira todos os parâmetros obrigatórios.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //verificar se já existe uma cadeira com esse nome para esse utilizador

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM PROJETO.TipoTarefa WHERE designacao = @designacao AND aluno_criador = @aluno_criador AND disabled = 0";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@designacao", designacao.Text);
                cmd.Parameters.AddWithValue("@aluno_criador", Login.utilizador);
                cmd.Connection = cn;
                int num = Convert.ToInt32(cmd.ExecuteScalar());


                if (num == 0)
                {
                    //insert
                    SqlCommand command = new SqlCommand();

                    command.CommandText = "INSERT INTO PROJETO.TipoTarefa(designacao,aluno_criador) " +
                            "VALUES (@designacao,@aluno_criador)";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@designacao", designacao.Text);
                    command.Parameters.AddWithValue("@aluno_criador", Login.utilizador);
                    command.Connection = cn;


                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Tipo de tarefa " + designacao.Text + " criada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CriarTarefa.tarefaAtual.PopulateTipoTarefa();

                        cn.Close();
                        this.Hide();

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Não foi possível inserir a cadeira na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Já existe um tipo de tarefa com essa designação.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                cn.Close();
            }
        }
    }
}
