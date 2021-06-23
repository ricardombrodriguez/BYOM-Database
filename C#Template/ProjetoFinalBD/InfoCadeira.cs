using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinalBD
{
    public partial class InfoCadeira: Form
    {
        private SqlConnection cn;
        private List<ClasseInstituicao> lstInstituicoes;
        public static bool returnToCriarTarefa = false;

 
        public InfoCadeira()
        {
            InitializeComponent();
            PopulateCadeiras();
            

            if (Cadeira.criarCadeira)
            {
                listaPaginas.Visible = false;
                listaTarefas.Visible = false;
                listaProfessores.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                removerPagina.Visible = false;
                removerTarefa.Visible = false;
                removerProfessor.Visible = false;
                adicionarProfessor.Visible = false;
                adicionarTarefa.Visible = false;
                adicionarPagina.Visible = false;
                btnApagarCadeira.Visible = false;
            } else
            {
                listaPaginas.Visible = true;
                listaTarefas.Visible = true;
                listaProfessores.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                removerPagina.Visible = true;
                removerTarefa.Visible = true;
                removerProfessor.Visible = true;
                adicionarProfessor.Visible = true;
                adicionarTarefa.Visible = true;
                adicionarPagina.Visible = true;

                LoadCadeiraInfo();
                showTarefas();
                showPaginas();
                showProfessores();

            }
        }

        private void LoadCadeiraInfo()
        {
            nome.Text = Cadeira.cadeiraAtual.Nome;
            link.Text = Cadeira.cadeiraAtual.Link;
            ano.Text = Cadeira.cadeiraAtual.Ano.ToString();
            semestre.Text = Cadeira.cadeiraAtual.Semestre.ToString();
            nota.Text = Cadeira.cadeiraAtual.Nota_final.ToString();
            instituicoes.SelectedIndex = Cadeira.cadeiraAtual.Instituicao;
        }

        private void showTarefas()
        {

        }

        private void showPaginas()
        {

        }
        private void showProfessores()
        {

        }

        private void changeView()
        {
            if (Cadeira.criarCadeira)
            {
                listaPaginas.Visible = false;
                listaTarefas.Visible = false;
                listaProfessores.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                removerPagina.Visible = false;
                removerTarefa.Visible = false;
                removerProfessor.Visible = false;
                adicionarProfessor.Visible = false;
                adicionarTarefa.Visible = false;
                adicionarPagina.Visible = false;
            }
            else
            {
                listaPaginas.Visible = true;
                listaTarefas.Visible = true;
                listaProfessores.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                removerPagina.Visible = true;
                removerTarefa.Visible = true;
                removerProfessor.Visible = true;
                adicionarProfessor.Visible = true;
                adicionarTarefa.Visible = true;
                adicionarPagina.Visible = true;

                showTarefas();
                showPaginas();
                showProfessores();

            }
        }


        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source=tcp:mednat.ieeta.pt\\SQLSERVER,8101;User ID=p9g5;Password=-737279605@BD");
        }

        private bool verifySGBDConnection()
        {

            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void PopulateCadeiras()
        {

            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            lstInstituicoes = new List<ClasseInstituicao>();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PROJETO.Instituicao WHERE aluno_criador = @aluno_criador AND disabled = 0;";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@aluno_criador", Login.utilizador);
            command.Connection = cn;

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                instituicoes.Items.Clear();

                while (reader.Read())
                {
                    ClasseInstituicao inst = new ClasseInstituicao(Convert.ToInt32(reader["id"]),
                                                       reader["nome"].ToString(),
                                                       reader["descricao"].ToString(),
                                                       reader["aluno_criador"].ToString(),
                                                       Convert.ToBoolean(reader["disabled"]));

                    lstInstituicoes.Add(inst);
                    instituicoes.Items.Add(inst.Nome);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            
            } finally
            {
                cn.Close();
            }
          
        }


        private void btnGuardarCadeira_Click(object sender, EventArgs e)
        {
            //Funcionalidades:
            // Alterar os parâmetros da cadeira (NÃO SE FAZ INSERT)
            // -> cuidado com as dependências.. apagar a cadeira = apagar pags, tarefas associadas
            // Criar a cadeira (FAZ-SE INSERT)

            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            if (Cadeira.criarCadeira)
            {
                
                if (nome.TextLength == 0 || instituicoes.SelectedItem == null)
                {
                    MessageBox.Show("Insira todos os parâmetros obrigatórios.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //verificar se já existe uma cadeira com esse nome para esse utilizador

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT COUNT(*) FROM PROJETO.Cadeira WHERE nome = @nome AND aluno = @aluno AND disabled = 0";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@nome", nome.Text);
                    cmd.Parameters.AddWithValue("@aluno", Login.utilizador);
                    cmd.Connection = cn;
                    int numCadeirasHomonimas = Convert.ToInt32(cmd.ExecuteScalar());


                    if (numCadeirasHomonimas == 0)
                    {

                        String Cnome = nome.Text;
                        String Clink = link.Text;
                        Int32 Cano = (ano.Text != String.Empty) ? Convert.ToInt32(ano.Text) : 0;
                        Int32 Csemestre = (semestre.Text != String.Empty) ? Convert.ToInt32(semestre.Text) : 0;
                        Double Cnota_final = (nota.Text != String.Empty) ? Convert.ToDouble(nota.Text, CultureInfo.InvariantCulture) : 0.0;
                        String Caluno = Login.utilizador;
                        Int32 Cinstituicao = lstInstituicoes[instituicoes.SelectedIndex].Id;


                        SqlCommand command = new SqlCommand("PROJETO.createCadeira", cn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@nome", Cnome);
                        command.Parameters.AddWithValue("@link", Clink);
                        command.Parameters.AddWithValue("@ano", Cano);
                        command.Parameters.AddWithValue("@semestre", Csemestre);
                        command.Parameters.AddWithValue("@nota_final", Cnota_final);
                        command.Parameters.AddWithValue("@aluno", Caluno);
                        command.Parameters.AddWithValue("@instituicao", Cinstituicao);
                        

                        try
                        {
                            SqlDataReader reader = command.ExecuteReader();
                            MessageBox.Show("Cadeira " + nome.Text + " criada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            while (reader.Read())
                            {
                                ClasseCadeira novaCadeira = new ClasseCadeira(Convert.ToInt32(reader["id"]),
                                                                   Cnome,
                                                                   Clink,
                                                                   Cano,
                                                                   Csemestre,
                                                                   Cnota_final,
                                                                   Caluno,
                                                                   reader["code"].ToString(),
                                                                   Convert.ToInt32(Cinstituicao),
                                                                   false);
                            }

                            if (returnToCriarTarefa)
                            {
                                CriarTarefa.tarefaAtual.Show();
                                this.Hide();
                                InfoCadeira.returnToCriarTarefa = false;
                            }
                            else
                            {
                                Cadeira c = new Cadeira();
                                c.Show();
                                this.Hide();
                            }                        
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Não foi possível inserir a cadeira na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                        }

                    } 
                    else
                    {
                        MessageBox.Show("Já existe uma cadeira com esse nome.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                   
                }

            } else
            {
                //alterar/ver cadeira (update)
            }

            cn.Close();

        }

        private void btnApagarCadeira_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (returnToCriarTarefa)
            {
                CriarTarefa.tarefaAtual.Show();
                this.Hide();
            }
            else
            {
                FormState.PreviousPage.Show();
                this.Hide();
                FormState.PreviousPage = this;
            }
        }
    }
}
