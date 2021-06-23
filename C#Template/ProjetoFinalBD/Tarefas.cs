﻿using System;
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
    public partial class Tarefas : Form
    {
        private SqlConnection cn;
        private List<ClasseTarefa> lstTarefas;
        private List<ClasseTipoTarefa> lstTiposTarefa;
        private string order = "";
        private string where = "";

        public Tarefas()
        {
            InitializeComponent();
            panelLeft.Height = btnTarefas.Height;
            panelLeft.Top = btnTarefas.Top;
            ShowTarefas();
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


        public void ShowTarefas()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            this.lstTarefas = new List<ClasseTarefa>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.Tarefa " +
                "WHERE aluno = @aluno " + this.where + " " + this.order;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@aluno", Login.utilizador);
            cmd.Connection = cn;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                listboxTarefas.Items.Clear();

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
                    listboxTarefas.Items.Add(inst.Titulo);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível visualizar as instituições na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
                this.PopulateTipoTarefa();
            }
        }

        private void PopulateTipoTarefa()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            this.lstTiposTarefa = new List<ClasseTipoTarefa>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.TipoTarefa " +
                "WHERE disabled = 0 AND id IN (" + "SELECT tipoTarefa FROM PROJETO.Tarefa " +
                "WHERE aluno = @aluno " + this.where + " " + this.order + ")";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@aluno", Login.utilizador);
            cmd.Connection = cn;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                listboxTarefas.Items.Clear();

                while (reader.Read())
                {
                    ClasseTipoTarefa inst = new ClasseTipoTarefa(
                            Convert.ToInt32(reader["id"]),
                            reader["designacao"].ToString(),
                            reader["aluno_criador"].ToString(),
                            false
                        );

                    this.lstTiposTarefa.Add(inst);
                    checkTipo.Items.Add(inst.Designacao);
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

        private void lblGrupos_MouseEnter(object sender, EventArgs e)
        {
            btnGrupos.ForeColor = Color.White;
        }


        private void lblInstituicoes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instituicoes instituicao = new Instituicoes();
            instituicao.Show();
        }

        private void btnGrupos_MouseLeave(object sender, EventArgs e)
        {
            btnGrupos.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void lblTarefas_MouseEnter(object sender, EventArgs e)
        {
            btnTarefas.ForeColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CriarTarefa tarefa = new CriarTarefa();
            CriarTarefa.createTarefa = true;
            tarefa.Show();
            FormState.PreviousPage = this;
        }

        private void btnInstituicoes_Click(object sender, EventArgs e)
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
            //
        }

        private void lblTarefas_Click(object sender, EventArgs e)
        {
            //
        }
        private void btnTarefas_MouseEnter(object sender, EventArgs e)
        {
            btnTarefas.ForeColor = Color.White;
        }

        private void btnTarefas_MouseLeave(object sender, EventArgs e)
        {
            btnTarefas.ForeColor = Color.FromArgb(41, 44, 51);
        }

        private void listboxTarefas_DoubleClick(object sender, EventArgs e)
        {
            if (listboxTarefas.SelectedIndex >= 0)
            {
                CriarTarefa.createTarefa = false;
                CriarTarefa.tarefa = this.lstTarefas[listboxTarefas.SelectedIndex];
                CriarTarefa ct = new CriarTarefa();
                ct.Show();
                this.Hide();
                FormState.PreviousPage = this;
            }
        }

        private void orderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (orderBy.SelectedIndex)
            {
                case 0:
                    this.order = "ORDER BY data_inicio ASC";
                    break;
                case 1:
                    this.order = "ORDER BY data_inicio DESC";
                    break;
                case 2:
                    this.order = "ORDER BY date_final ASC";
                    break;
                case 3:
                    this.order = "ORDER BY date_final DESC";
                    break;
            }

            this.ShowTarefas();
        }

        private void search_Click(object sender, EventArgs e)
        {

        }
    }
}
