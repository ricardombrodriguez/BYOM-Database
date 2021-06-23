using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoFinalBD
{
    public partial class BYOM : Form
    {
        private SqlConnection cn;
        private List<ClasseTarefa> lstTarefas;

        public BYOM()
        {
            InitializeComponent();
            panelLeft.Height = btnHome.Height;
            panelLeft.Top = btnHome.Top;

            PopulateLists();
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

        private void PopulateLists()
        {
            // fazer para os dias todos da semana
            String[] diasSemana = new string[] {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
            ListBox[] ls = new ListBox[] { listboxSegunda, listboxTerca, listboxQuarta, listboxQuinta, listboxSexta, listboxSabado, listboxDomingo };

            int x = 0;
            foreach (String day in diasSemana)
            {
                cn = getSGBDConnection();

                if (!verifySGBDConnection())
                    return;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM PROJETO.getTarefasSemanaByDia(@dia)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dia", day);
                cmd.Connection = cn;

                lstTarefas= new List<ClasseTarefa>();

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    ls[x].Items.Clear();

                    while (reader.Read())
                    {
                        int var_id = Convert.ToInt32(reader["id"]);
                        String var_titulo = reader["titulo"].ToString();
                        String var_descricao = reader["descricao"].ToString();
                        String var_completada_ts = reader["completada_ts"].ToString();
                        String var_data_inicio = reader["data_inicio"].ToString();
                        String var_date_final = reader["date_final"].ToString();
                        int var_tipoTarefa = Convert.ToInt32(reader["tipoTarefa"]);
                        String var_aluno = reader["aluno"].ToString();
                        int var_cadeira = Convert.ToInt32(reader["cadeira"]);
                        String var_codigo_criador = reader["codigo_criador"].ToString();


                        ClasseTarefa inst = new ClasseTarefa(var_id,
                                                           var_titulo,
                                                           var_descricao,
                                                           var_completada_ts,
                                                           var_data_inicio,
                                                           var_date_final,
                                                           var_tipoTarefa,
                                                           var_aluno,
                                                           var_cadeira,
                                                           var_codigo_criador);

                        this.lstTarefas.Add(inst);
                        ls[x].Items.Add(inst.Titulo);
                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);

                }

                cn.Close();

                x++;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            //
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
            Cadeira cadeira = new Cadeira();
            cadeira.Show();
        }

        private void lblCadeiras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cadeira cadeira = new Cadeira();
            cadeira.Show();
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

       

      

        private void btnAddTarefa_Click(object sender, EventArgs e)
        {
            this.Hide();
            CriarTarefa tarefa = new CriarTarefa();
            tarefa.Show();
            CriarTarefa.createTarefa = true;
            FormState.PreviousPage = this;
        }

    }
}
