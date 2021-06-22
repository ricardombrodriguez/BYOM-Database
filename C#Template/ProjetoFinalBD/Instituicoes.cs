using System;
using System.Collections;
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
    public partial class Instituicoes : Form
    {
        //guarda o id da instituição selecionada (é 0 se n houver nenhuma selecionada)
        //vai haver um método de isSelected que vê se há alguma linha que está selecionada
        //se tiver guarda o seu id, se não este passa a ter valor 0
        //isto vai ser usado para saber se queremos inserir uma instituicao ou fazer update

        private SqlConnection cn;
        private Dictionary<String, ClasseInstituicao> instituicoes = new Dictionary<String, ClasseInstituicao>();

        public Instituicoes()
        {
            InitializeComponent();
            panelLeft.Height = btnInstituicoes.Height;
            panelLeft.Top = btnInstituicoes.Top;
            showInstituicoes();
        }

        public void showInstituicoes()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.Instituicao WHERE aluno_criador = @aluno_criador AND disabled = 0;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@aluno_criador", Login.utilizador);
            cmd.Connection = cn;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                instituicoes.Clear();
                listboxInstituicoes.Items.Clear();

                while (reader.Read())
                {
                    ClasseInstituicao inst = new ClasseInstituicao(Convert.ToInt32(reader["id"]),
                                                       reader["nome"].ToString(),
                                                       reader["descricao"].ToString(),
                                                       reader["aluno_criador"].ToString(),
                                                       Convert.ToBoolean(reader["disabled"]));

                    instituicoes.Add(inst.Nome + " | " + inst.Descricao, inst);
                    listboxInstituicoes.Items.Add(inst.Nome + " | " + inst.Descricao);
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
            //
        }

        private void lblInstituicoes_Click(object sender, EventArgs e)
        {
            //
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

        private void btnAddInstituicao_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage = this;
            CriarInstituicao inst = new CriarInstituicao(this);
            inst.Show();
            CriarInstituicao.cadeirasVisiveis = false;
        }

        private void listboxInstituicoes_DoubleClick(object sender, EventArgs e)
        {
            FormState.PreviousPage = this;
            if (listboxInstituicoes.SelectedItem != null)
            {
                CriarInstituicao.cadeirasVisiveis = true;
                CriarInstituicao.instituicaoAtual = instituicoes[listboxInstituicoes.GetItemText(listboxInstituicoes.SelectedItem)];
                CriarInstituicao inst = new CriarInstituicao(this);
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
            cmd.CommandText = "SELECT * FROM PROJETO.Instituicao WHERE aluno_criador = @aluno_criador ";

            if (filtroNome.TextLength != 0) {
                strSql += String.Format("AND nome LIKE '%{0}%' ", filtroNome.Text);
            }
            if (filtroDescricao.TextLength != 0) {
                strSql += String.Format("AND descricao LIKE '%{0}%' ", filtroDescricao.Text);
            }

            cmd.CommandText += strSql;
            cmd.Parameters.AddWithValue("@aluno_criador", Login.utilizador);
            cmd.Connection = cn;

            MessageBox.Show(cmd.CommandText);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                listboxInstituicoes.Items.Clear();

                while (reader.Read())
                {
                    ClasseInstituicao inst = new ClasseInstituicao(Convert.ToInt32(reader[0]),
                                                       reader[1].ToString(),
                                                       reader[2].ToString(),
                                                       reader[3].ToString(),
                                                       Convert.ToBoolean(reader[4]));


                    listboxInstituicoes.Items.Add(inst.Nome + " | " + inst.Descricao);
                }

                if (instituicoes.Count() == 0)
                {
                    listboxInstituicoes.Items.Add("Não existem cadeiras que contenham o nome introduzido.");
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