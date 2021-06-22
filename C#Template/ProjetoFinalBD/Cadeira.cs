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
    public partial class Cadeira : Form
    {
        private SqlConnection cn;
        public static Boolean criarCadeira;
        public static ClasseCadeira cadeiraAtual;
        private List<ClasseCadeira> lstCadeiras = new List<ClasseCadeira>();

        public Cadeira()
        {
            InitializeComponent();
            panelLeft.Height = btnCadeiras.Height;
            panelLeft.Top = btnCadeiras.Top;
            showCadeiras();
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


        public void showCadeiras()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.Cadeira " +
                "WHERE aluno = @aluno AND disabled = 0";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@aluno", Login.utilizador);
            cmd.Connection = cn;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                listboxCadeiras.Items.Clear();

                while (reader.Read())
                {
                    ClasseCadeira novaCadeira = new ClasseCadeira(Convert.ToInt32(reader["id"]),
                                                       reader["nome"].ToString(),
                                                       reader["link"].ToString(),
                                                       Convert.ToInt32(reader["ano"]),
                                                       Convert.ToInt32(reader["semestre"]),
                                                       Convert.ToDouble(reader["nota_final"].ToString()),
                                                       reader["aluno"].ToString(),
                                                       reader["codigo_criador"].ToString(),
                                                       Convert.ToInt32(reader["instituicao"]),
                                                       false);

                    lstCadeiras.Add(novaCadeira);
                    listboxCadeiras.Items.Add(novaCadeira.Nome);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível visualizar as instituições na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            BYOM home = new BYOM();
            home.Show();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            BYOM home = new BYOM();
            home.Show();
        }

        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.ForeColor = Color.White;
        }

        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void lblHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.ForeColor = Color.White;
        }

        private void btnCadeiras_Click(object sender, EventArgs e)
        {
            //
        }

        private void lblCadeiras_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnCadeiras_MouseEnter(object sender, EventArgs e)
        {
            btnCadeiras.ForeColor = Color.White;
        }

        private void btnCadeiras_MouseLeave(object sender, EventArgs e)
        {
            btnCadeiras.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void lblCadeiras_MouseEnter(object sender, EventArgs e)
        {
            btnCadeiras.ForeColor = Color.White;
        }

        private void btnPaginas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Paginas pagina = new Paginas();
            pagina.Show();
        }

        private void lblPaginas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Paginas pagina = new Paginas();
            pagina.Show();
        }

        private void btnPaginas_MouseEnter(object sender, EventArgs e)
        {
            btnPaginas.ForeColor = Color.White;
        }

        private void btnPaginas_MouseLeave(object sender, EventArgs e)
        {
            btnPaginas.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void lblPaginas_MouseEnter(object sender, EventArgs e)
        {
            btnPaginas.ForeColor = Color.White;
        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grupos grupos = new Grupos();
            grupos.Show();
        }

        private void lblGrupos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grupos grupos = new Grupos();
            grupos.Show();
        }

        private void btnGrupos_MouseEnter(object sender, EventArgs e)
        {
            btnGrupos.ForeColor = Color.White;
        }

        private void btnGrupos_MouseLeave(object sender, EventArgs e)
        {
            btnGrupos.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void lblGrupos_MouseEnter(object sender, EventArgs e)
        {
            btnGrupos.ForeColor = Color.White;
        }

        private void btnInstituicoes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instituicoes instituicao = new Instituicoes();
            instituicao.Show();
        }

        private void lblInstituicoes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instituicoes instituicao = new Instituicoes();
            instituicao.Show();
        }

        private void btnInstituicoes_MouseEnter(object sender, EventArgs e)
        {
            btnInstituicoes.ForeColor = Color.White;
        }

        private void btnInstituicoes_MouseLeave(object sender, EventArgs e)
        {
            btnInstituicoes.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void lblInstituicoes_MouseEnter(object sender, EventArgs e)
        {
            btnInstituicoes.ForeColor = Color.White;
        }

        private void btnTarefas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tarefas tarefa = new Tarefas();
            tarefa.Show();
        }

        private void lblTarefas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tarefas tarefa = new Tarefas();
            tarefa.Show();
        }
        private void btnTarefas_MouseEnter(object sender, EventArgs e)
        {
            btnTarefas.ForeColor = Color.White;
        }

        private void btnTarefas_MouseLeave(object sender, EventArgs e)
        {
            btnTarefas.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void lblTarefas_MouseEnter(object sender, EventArgs e)
        {
            btnTarefas.ForeColor = Color.White;
        }

        private void btnCriarCadeira_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cadeira.criarCadeira = true;
            InfoCadeira novaCadeira = new InfoCadeira();
            novaCadeira.Show();
            FormState.PreviousPage = this;
        }

        private void listboxCadeiras_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("eddeded");
            if (listboxCadeiras.SelectedItem != null)
            {
                MessageBox.Show("entrei");
                InfoCadeira inst = new InfoCadeira();
                Cadeira.criarCadeira = false;
                Cadeira.cadeiraAtual = lstCadeiras[listboxCadeiras.SelectedIndex];
                inst.Show();
            }
        }

        private void btnEditarCadeira_Click(object sender, EventArgs e)
        {
            if (listboxCadeiras.SelectedIndex >= 0)
            {
                Cadeira.criarCadeira = false;
                Cadeira.cadeiraAtual = lstCadeiras[listboxCadeiras.SelectedIndex];
                MessageBox.Show(Cadeira.cadeiraAtual.ToString());
                InfoCadeira inst = new InfoCadeira();                
                inst.Show();
                FormState.PreviousPage = this;
            }
        }
    }
}
