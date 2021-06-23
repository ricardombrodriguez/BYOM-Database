using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoFinalBD
{
    public partial class Grupos : Form
    {
        private SqlConnection cn;
        private Dictionary<String, ClasseCadeira> lstCadeiras;
        private Dictionary<String, ClasseGrupo> lstGrupos;

        public Grupos()
        {
            InitializeComponent();
            panelLeft.Height = btnGrupos.Height;
            panelLeft.Top = btnGrupos.Top;
            showGrupos();
            PopulateCadeiras();
    
        }

        public void PopulateCadeiras()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PROJETO.Cadeira WHERE aluno = @aluno AND disabled = 0;";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@aluno", Login.utilizador);
            command.Connection = cn;

            lstCadeiras = new Dictionary<String,ClasseCadeira>();

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                filtroCadeira.Items.Clear();

                while (reader.Read())
                {
                    ClasseCadeira inst = new ClasseCadeira(Convert.ToInt32(reader["id"]),
                                                            reader["nome"].ToString());

                    lstCadeiras.Add(inst.Nome,inst);

                    filtroCadeira.Items.Add(inst.Nome);
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

        private void showGrupos()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            

            //mostrar o nome dos grupos ao qual o aluno pertence
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.GrupoAluno JOIN PROJETO.Grupo " +
                "ON grupo = id WHERE aluno = @aluno AND disabled = 0;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@aluno", Login.utilizador);
            cmd.Connection = cn;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                lstGrupos = new Dictionary<String, ClasseGrupo>();
                listboxGrupos.Items.Clear();

                while (reader.Read())
                {
                    ClasseGrupo inst = new ClasseGrupo(Convert.ToInt32(reader["id"]),
                                                       reader["nome"].ToString(),
                                                       Convert.ToInt32(reader["cadeira"]),
                                                       reader["codigo_criador"].ToString(),
                                                       Convert.ToBoolean(reader["disabled"]));

                    lstGrupos.Add(inst.Nome,inst);
                    listboxGrupos.Items.Add(inst.Nome);
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
            //
        }

        private void lblGrupos_Click(object sender, EventArgs e)
        {
            //
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


        private void btnTarefas_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void lblTarefas_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }

        private void btnCreateGrupo_Click(object sender, EventArgs e)
        {
            CriarGrupo.createGrupo = true;
            this.Hide();
            CriarGrupo grupo = new CriarGrupo();
            grupo.Show();
            FormState.PreviousPage = this;
        }


        private void listboxGrupos_DoubleClick(object sender, EventArgs e)
        {
            if (listboxGrupos.SelectedItem != null)
            {
                FormState.PreviousPage = this;
                CriarGrupo.createGrupo = false;
                CriarGrupo.grupoAtual = lstGrupos[listboxGrupos.GetItemText(listboxGrupos.SelectedItem)];

                cn = getSGBDConnection();

                if (!verifySGBDConnection())
                    return;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM PROJETO.Grupo JOIN PROJETO.Cadeira " +
                    "ON PROJETO.Grupo.cadeira =  PROJETO.Cadeira.id WHERE PROJETO.Grupo.id = @group_id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@group_id", CriarGrupo.grupoAtual.Id);
                cmd.Connection = cn;

                String nome = "";
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        nome = reader[6].ToString();
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível visualizar as instituições na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                }
                

                cn.Close();
                CriarGrupo.nome_cadeira = nome;
                CriarGrupo inst = new CriarGrupo();
                inst.Show();
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            string strSql = "";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Clear();
            cmd.CommandText = String.Format("SELECT * FROM PROJETO.GrupoAluno JOIN PROJETO.Grupo ON PROJETO.GrupoAluno.grupo = PROJETO.Grupo.id " +
                "LEFT JOIN PROJETO.GrupoProfessor ON PROJETO.Grupo.id = PROJETO.GrupoProfessor.grupo " +
                "WHERE aluno = '{0}' ", Login.utilizador);

            if (filtroCadeira.SelectedIndex != -1)
            {
                int cadeira_id = lstCadeiras[filtroCadeira.Text].Id;
                strSql += String.Format("AND cadeira = {0} ", cadeira_id);
            }

            if (filtroNome.TextLength != 0)
            {
                strSql += String.Format("AND PROJETO.Grupo.nome LIKE '%{0}%' ", filtroNome.Text);
            }

            if (filtroOrientador.TextLength != 0)
            {
                strSql += String.Format("AND PROJETO.GrupoProfessor.professor = '{0}' ", filtroOrientador.Text);
            }

            cmd.CommandText += strSql;
            cmd.Connection = cn;

            MessageBox.Show(cmd.CommandText);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                listboxGrupos.Items.Clear();
                lstGrupos.Clear();

                while (reader.Read())
                {
                    ClasseGrupo inst = new ClasseGrupo(Convert.ToInt32(reader[2]),
                                                       reader[3].ToString(),
                                                       Convert.ToInt32(reader[4]),
                                                       reader[5].ToString(),
                                                       false);

                    if (lstGrupos.ContainsKey(inst.Nome) == false)
                    {
                        lstGrupos.Add(inst.Nome, inst);
                        listboxGrupos.Items.Add(inst.Nome);
                    }
                }

                if (lstGrupos.Count() == 0)
                {
                    listboxGrupos.Items.Add("Não existem grupos compatíveis.");
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
    }
}
