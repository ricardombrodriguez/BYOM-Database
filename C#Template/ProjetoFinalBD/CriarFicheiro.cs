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
    public partial class CriarFicheiro : Form
    {
        private SqlConnection cn;
        public static String codigo_criador;
        public static ClasseFicheiro ficheiroAtual;
        public static Boolean createFicheiro;
        public static Boolean createFicheiroGrupo;
        public static Boolean createFicheiroTarefa;
        public static Boolean createFicheiroPagina;
        public static Boolean createFicheiroCadeira;

        public CriarFicheiro()
        {
            InitializeComponent();

            if (createFicheiro)
            {
                btnApagarFicheiro.Enabled = false;
                btnGuardarFicheiro.Enabled = true;
            } else
            {
                nome.Text = ficheiroAtual.Nome;
                localizacao.Text = ficheiroAtual.Localizacao;
                btnApagarFicheiro.Enabled = true;
                btnGuardarFicheiro.Enabled = false;
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

        private void btnGuardarFicheiro_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            if (nome.TextLength == 0 || localizacao.TextLength == 0)
            {
                MessageBox.Show("Os campos têm de estar preenchidos.", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO PROJETO.Ficheiro(nome,localizacao,aluno,codigo_criador) VALUES (@nome,@localizacao,@aluno,@codigo_criador)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nome", nome.Text);
                cmd.Parameters.AddWithValue("@localizacao", localizacao.Text);
                cmd.Parameters.AddWithValue("@aluno", Login.utilizador);
                cmd.Parameters.AddWithValue("@codigo_criador", codigo_criador);
                cmd.Connection = cn;

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ficheiro " + nome.Text + " adicionado.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi adicionar o ficheiro na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                }
                finally
                {
                    cn.Close();

                    if (createFicheiroTarefa) CriarTarefa.instTarefa.ShowFicheiros();
                    //if (createFicheiroGrupo) CriarGrupo.instGrupo.ShowFicheiros();
                    if (createFicheiroPagina) CriarPagina.instPagina.ShowFicheiros();
                    //if (createFicheiroCadeira) InfoCadeira.instCadeira.ShowFicheiros();

                    this.Hide();

                }
            }
        }


        private void btnApagarFicheiro_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM PROJETO.Ficheiro WHERE id = @id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", ficheiroAtual.Id);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ficheiro " + nome.Text + " removido.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível remover o ficheiro na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();

                if (createFicheiroTarefa) CriarTarefa.instTarefa.ShowFicheiros();
                //if (createFicheiroGrupo) CriarGrupo.instGrupo.ShowFicheiros();
                if (createFicheiroPagina) CriarPagina.instPagina.ShowFicheiros();
                //if (createFicheiroCadeira) InfoCadeira.instCadeira.ShowFicheiros();

                this.Hide();
            }
            
        }
    }
}
