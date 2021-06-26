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
        private Dictionary<string, ClasseTarefa> lstTarefas;

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

        private void PopulateLists(String order = "")
        {
            // fazer para os dias todos da semana
            String[] diasSemana = new string[] {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
            ListBox[] ls = new ListBox[] { listboxSegunda, listboxTerca, listboxQuarta, listboxQuinta, listboxSexta, listboxSabado, listboxDomingo };

            int x = 0;
            lstTarefas = new Dictionary<string, ClasseTarefa>();

            foreach (String day in diasSemana)
            {
                cn = getSGBDConnection();

                if (!verifySGBDConnection())
                    return;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM PROJETO.getTarefasSemanaByDia(@dia) WHERE completada_ts IS NULL AND aluno = @aluno " + order;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dia", day);
                cmd.Parameters.AddWithValue("@aluno", Login.utilizador);
                cmd.Connection = cn;

                int c = 0;

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
                        int var_cadeira;
                        if (reader["cadeira"].GetType().ToString() == "System.DBNull")
                        {
                            var_cadeira = -1;
                        }else
                        {
                            var_cadeira = Convert.ToInt32(reader["cadeira"]);
                        }
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

                        this.lstTarefas.Add(ls[x].Name+"_"+c.ToString(), inst);
                        ls[x].Items.Add("- " + inst.Titulo);
                        c++;
                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao carregar as tarefas da base de dados. \n ERROR MESSAGE: \n" + ex.Message);

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
            CriarTarefa.createTarefa = true;
            FormState.PreviousPage = this;
            CriarTarefa tarefa = new CriarTarefa();
            tarefa.Show();
        }

        private void orderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (orderBy.SelectedIndex)
            {
                case 0:
                    this.PopulateLists("ORDER BY data_inicio ASC");
                    break;
                case 1:
                    this.PopulateLists("ORDER BY data_inicio DESC");
                    break;
                case 2:
                    this.PopulateLists("ORDER BY date_final ASC");
                    break;
                case 3:
                    this.PopulateLists("ORDER BY date_final DESC");
                    break;
            }
        }

        private void listboxSegunda_DoubleClick(object sender, EventArgs e)
        {
            editTarefa(listboxSegunda);
        }

        private void listboxTerca_DoubleClick(object sender, EventArgs e)
        {
            editTarefa(listboxTerca);
        }

        private void listboxQuarta_DoubleClick(object sender, EventArgs e)
        {
            editTarefa(listboxQuarta);
        }

        private void listboxQuinta_DoubleClick(object sender, EventArgs e)
        {
            editTarefa(listboxQuinta);
        }

        private void listboxSexta_DoubleClick(object sender, EventArgs e)
        {
            editTarefa(listboxSexta);
        }

        private void listboxSabado_DoubleClick(object sender, EventArgs e)
        {
            editTarefa(listboxSabado);
        }

        private void listboxDomingo_DoubleClick(object sender, EventArgs e)
        {
            editTarefa(listboxDomingo);
        }

        private void editTarefa(ListBox lb)
        {
            if (lb.SelectedIndex >= 0)
            {
                CriarTarefa.createTarefa = false;
                CriarTarefa.tarefa = this.lstTarefas[lb.Name+"_"+ lb.SelectedIndex.ToString()];
                CriarTarefa ct = new CriarTarefa();
                ct.Show();
                this.Hide();
                FormState.PreviousPage = this;
            }
        }
    }
}
