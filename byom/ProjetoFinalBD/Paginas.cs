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
    public partial class Paginas : Form
    {
        private SqlConnection cn;
        private List<ClassePagina> lstPaginas;
        private Dictionary<String, ClasseCadeira> lstCadeiras;

        public Paginas()
        {
            InitializeComponent();
            FormState.PreviousPage = this;
            panelLeft.Height = btnPaginas.Height;
            panelLeft.Top = btnPaginas.Top;
            ShowPaginas();
            PopulateCadeiras();
        }

        public void PopulateCadeiras()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PROJETO.Pagina JOIN PROJETO.Cadeira ON PROJETO.Pagina.cadeira = PROJETO.Cadeira.id " +
                "WHERE PROJETO.Pagina.aluno = @aluno AND disabled = 0";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@aluno", Login.utilizador);
            command.Connection = cn;

            lstCadeiras = new Dictionary<String, ClasseCadeira>();

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                filtroCadeira.Items.Clear();

                while (reader.Read())
                {
                    ClasseCadeira inst = new ClasseCadeira(Convert.ToInt32(reader[7]),
                                                            reader["nome"].ToString());

                    if (lstCadeiras.ContainsKey(inst.Nome) == false)
                    {
                        lstCadeiras.Add(inst.Nome, inst);
                        filtroCadeira.Items.Add(inst.Nome);
                    }
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);

            }

            cn.Close();
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

        public void ShowPaginas()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.Pagina WHERE aluno = @aluno;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@aluno", Login.utilizador);
            cmd.Connection = cn;

            lstPaginas = new List<ClassePagina>();

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                listboxPaginas.Items.Clear();

                while (reader.Read())
                {
                    ClassePagina inst = new ClassePagina(Convert.ToInt32(reader["id"]),
                                                       reader["titulo"].ToString(),
                                                       reader["texto"].ToString(),
                                                       reader["aluno"].ToString(),
                                                       reader["cadeira"] == DBNull.Value ? -1 :
                                                       Convert.ToInt32(reader["cadeira"]),
                                                       reader["codigo_criador"].ToString());

                    lstPaginas.Add(inst);
                    listboxPaginas.Items.Add(inst.Titulo);
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
            this.Hide();
            Cadeira home = new Cadeira();
            home.Show();
        }

        private void lblCadeiras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cadeira home = new Cadeira();
            home.Show();
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
            //
        }

        private void lblPaginas_Click(object sender, EventArgs e)
        {
            //
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
            Grupos tarefa = new Grupos();
            tarefa.Show();
        }

        private void lblGrupos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Grupos tarefa = new Grupos();
            tarefa.Show();
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
            Instituicoes tarefa = new Instituicoes();
            tarefa.Show();
        }

        private void lblInstituicoes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instituicoes tarefa = new Instituicoes();
            tarefa.Show();
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

      

        private void btnAddPagina_Click(object sender, EventArgs e)
        {
            CriarPagina.inst = this;
            CriarPagina.createPagina = true;
            CriarPagina pagina = new CriarPagina();
            pagina.Show();
            FormState.PreviousPage = this;
        }

        private void listboxPaginas_DoubleClick(object sender, EventArgs e)
        {

            if (listboxPaginas.SelectedItem != null)
            {
                CriarPagina.inst = this;
                CriarPagina.createPagina = false;
                CriarPagina.paginaAtual = lstPaginas[listboxPaginas.SelectedIndex];
                CriarPagina inst = new CriarPagina();
                inst.Show();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.Pagina WHERE aluno = @aluno ";
            cmd.Parameters.Clear();

            String strSql = "";

            if (filtroCadeira.SelectedIndex != -1)
            {
                int cadeira_id = lstCadeiras[filtroCadeira.Text].Id;
                strSql += String.Format("AND cadeira = {0} ", cadeira_id);
            }

            if (filtroNome.TextLength != 0)
            {
                strSql += String.Format("AND titulo LIKE '%{0}%' ", filtroNome.Text);
            }
            cmd.CommandText += strSql;
            cmd.Parameters.AddWithValue("@aluno", Login.utilizador);
            cmd.Connection = cn;

            lstPaginas = new List<ClassePagina>();

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                listboxPaginas.Items.Clear();

                while (reader.Read())
                {
                    ClassePagina inst = new ClassePagina(Convert.ToInt32(reader["id"]),
                                                       reader["titulo"].ToString(),
                                                       reader["texto"].ToString(),
                                                       reader["aluno"].ToString(),
                                                       Convert.ToInt32(reader["cadeira"]),
                                                       reader["codigo_criador"].ToString());

                    lstPaginas.Add(inst);
                    listboxPaginas.Items.Add(inst.Titulo);
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
    }
}
