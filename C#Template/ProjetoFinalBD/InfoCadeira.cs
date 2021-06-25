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
        public static InfoCadeira instCadeira;
        private Dictionary<String,ClasseInstituicao> lstInstituicoes;
        private Dictionary<String, ClasseTarefa> lstTarefas;
        private Dictionary<String, ClassePagina> lstPaginas;
        private Dictionary<String, ClasseProfessor> lstProfessores;
        private Dictionary<string, ClasseFicheiro> lstFicheiros = new Dictionary<string, ClasseFicheiro>();
        public static bool returnToCriarTarefa = false;

 
        public InfoCadeira()
        {
            InitializeComponent();
            PopulateCadeiras();
            CriarPagina.instCadeira = this;


            if (Cadeira.criarCadeira)
            {
                listaPaginas.Visible = false;
                listaTarefas.Visible = false;
                listaProfessores.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label5.Visible = false;
                btnAdicionarPagina.Visible = false;
                btnAdicionarTarefa.Visible = false;
                btnAdicionarProfessor.Visible = false;
                btnAdicionarPagina.Visible = false;
                btnAdicionarFicheiro.Visible = false;
                listboxFicheiros.Visible = false;

            } else
            {
                LoadCadeiraInfo();
                showTarefas();
                showPaginas();
                showProfessores();
                ShowFicheiros();
            }
        }

        public void ShowFicheiros()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PROJETO.Ficheiro WHERE codigo_criador = @codigo_criador";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@codigo_criador", Cadeira.cadeiraAtual.Codigo_criador);
            command.Connection = cn;

            lstFicheiros.Clear();

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                listboxFicheiros.Items.Clear();

                while (reader.Read())
                {
                    ClasseFicheiro inst = new ClasseFicheiro(Convert.ToInt32(reader["id"]),
                                                            reader["nome"].ToString(),
                                                            reader["localizacao"].ToString(),
                                                            reader["aluno"].ToString(),
                                                            reader["codigo_criador"].ToString());

                    lstFicheiros.Add(inst.Nome, inst);
                    listboxFicheiros.Items.Add(inst.Nome);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao carregar as acdeiras da base de dados. \n ERROR MESSAGE: \n" + ex.Message);

            }

            cn.Close();
        }

        private void LoadCadeiraInfo()
        {
            nome.Text = Cadeira.cadeiraAtual.Nome;
            link.Text = Cadeira.cadeiraAtual.Link;
            ano.Text = Cadeira.cadeiraAtual.Ano.ToString();
            semestre.Text = Cadeira.cadeiraAtual.Semestre.ToString();
            nota.Text = Cadeira.cadeiraAtual.Nota_final.ToString();
            foreach (KeyValuePair<string, ClasseInstituicao> entry in lstInstituicoes)
            {
                if (Cadeira.cadeiraAtual.Instituicao == entry.Value.Id)
                {
                    instituicoes.Text = entry.Value.Nome;
                }
            }
        }

        public void showTarefas()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.Tarefa JOIN PROJETO.Cadeira ON cadeira = PROJETO.Cadeira.id WHERE cadeira = @cadeira AND PROJETO.Cadeira.aluno = @aluno_criador AND disabled = 0";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@cadeira", Cadeira.cadeiraAtual.Id);
            cmd.Parameters.AddWithValue("@aluno_criador", Login.utilizador);
            cmd.Connection = cn;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                lstTarefas = new Dictionary<string, ClasseTarefa>();
                listaTarefas.Items.Clear();

                while (reader.Read())
                {
                    ClasseTarefa inst = new ClasseTarefa(Convert.ToInt32(reader[0]),
                                                       reader[1].ToString(),
                                                       reader[2].ToString(),
                                                       reader[3].ToString(),
                                                       reader[4].ToString(),
                                                       reader[5].ToString(),
                                                       Convert.ToInt32(reader[6]),
                                                       reader[7].ToString(),
                                                       Convert.ToInt32(reader[8]),
                                                       reader[9].ToString());

                    lstTarefas.Add(inst.Titulo, inst);
                    listaTarefas.Items.Add(inst.Titulo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível visualizar as tarefas da cadeira na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void showPaginas()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.Pagina JOIN PROJETO.Cadeira ON cadeira = PROJETO.Cadeira.id " +
                     "WHERE PROJETO.Cadeira.aluno = @aluno_criador AND cadeira = @cadeira AND disabled = 0";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@cadeira", Cadeira.cadeiraAtual.Id);
            cmd.Parameters.AddWithValue("@aluno_criador", Login.utilizador);
            cmd.Connection = cn;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                lstPaginas = new Dictionary<string, ClassePagina>();
                listaPaginas.Items.Clear();

                while (reader.Read())
                {
                    ClassePagina inst = new ClassePagina(Convert.ToInt32(reader[0]),
                                                       reader[1].ToString(),
                                                       reader[5].ToString(),
                                                       reader[2].ToString(),
                                                       Convert.ToInt32(reader[3]),
                                                       reader[4].ToString());

                    lstPaginas.Add(inst.Titulo, inst);
                    listaPaginas.Items.Add(inst.Titulo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível visualizar as páginas da cadeira na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void showProfessores()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.ProfessorCadeira JOIN PROJETO.Cadeira ON cadeira = PROJETO.Cadeira.id JOIN PROJETO.Professor ON email = professor " +
                     "WHERE PROJETO.Cadeira.aluno = @aluno_criador AND cadeira = @cadeira AND PROJETO.Cadeira.disabled = 0 AND PROJETO.Professor.disabled = 0";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@cadeira", Cadeira.cadeiraAtual.Id);
            cmd.Parameters.AddWithValue("@aluno_criador", Login.utilizador);
            cmd.Connection = cn;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                lstProfessores = new Dictionary<string, ClasseProfessor>();
                listaProfessores.Items.Clear();

                while (reader.Read())
                {
                    ClasseProfessor inst = new ClasseProfessor(reader[12].ToString(),
                                                               reader[13].ToString(),
                                                               false);

                    lstProfessores.Add(inst.Email, inst);
                    listaProfessores.Items.Add(inst.Email);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível visualizar os professores da cadeira na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
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
                btnAdicionarPagina.Visible = false;
                btnAdicionarTarefa.Visible = false;
                btnAdicionarProfessor.Visible = false;
            }
            else
            {
                listaPaginas.Visible = true;
                listaTarefas.Visible = true;
                listaProfessores.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                btnAdicionarPagina.Visible = true;
                btnAdicionarTarefa.Visible = true;
                btnAdicionarProfessor.Visible = true;

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

            lstInstituicoes = new Dictionary<string, ClasseInstituicao>();

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

                    lstInstituicoes.Add(inst.Nome,inst);
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
                        Int32 Cinstituicao = lstInstituicoes[instituicoes.Text].Id;


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

            }
            else
            {
                //alterar/ver cadeira (update)

                SqlCommand command = new SqlCommand();

                command.CommandText = "UPDATE PROJETO.Cadeira SET nome = @nome, link = @link, ano = @ano, semestre = @semestre, " +
                    "nota_final = @nota_final, instituicao = @instituicao WHERE id = @id;";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@id", Cadeira.cadeiraAtual.Id);
                command.Parameters.AddWithValue("@nome", nome.Text);
                command.Parameters.AddWithValue("@link", link.Text);
                command.Parameters.AddWithValue("@ano", ano.Text);
                command.Parameters.AddWithValue("@semestre", semestre.Text);
                command.Parameters.AddWithValue("@nota_final", nota.Text);
                command.Parameters.AddWithValue("@instituicao", lstInstituicoes[instituicoes.Text].Id);
                command.Connection = cn;


                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Tarefa atualizada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível inserir a instituição na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                }
                finally
                {
                    if (returnToCriarTarefa)
                    {
                        CriarTarefa.tarefaAtual.Show();
                        this.Hide();
                        InfoCadeira.returnToCriarTarefa = false;
                    }
                    else
                    {
                        this.Hide();
                    }
                }

                cn.Close();

            }

            cn.Close();

        }

        private void btnApagarCadeira_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (returnToCriarTarefa)
            {
                if (CriarTarefa.tarefaAtual != null) CriarTarefa.tarefaAtual.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
            }
        }

        private void btnAdicionarPagina_Click(object sender, EventArgs e)
        {
            CriarPagina.createPagina = true;
            CriarPagina.createPaginaCadeira = true;
            CriarPagina.instCadeira = this;
            CriarPagina inst = new CriarPagina();
            inst.Show();
        }

        private void btnAdicionarTarefa_Click(object sender, EventArgs e)
        {
            CriarTarefa.createTarefa = true;
            CriarTarefa.createTarefaCadeira = true;
            CriarTarefa.instCadeira = this;
            CriarTarefa inst = new CriarTarefa();
            inst.Show();
        }

        private void btnAdicionarProfessor_Click(object sender, EventArgs e)
        {
            CriarProfessor.instCadeira = this;
            CriarProfessor.createProfessor = true;
            CriarProfessor.createProfessorCadeira = true;
            CriarProfessor.instCadeira = this;
            ModalProfessor inst = new ModalProfessor();
            inst.Show();
        }

        private void listaPaginas_DoubleClick(object sender, EventArgs e)
        {
            if (listaPaginas.SelectedItem != null)
            {
                CriarPagina.createPaginaCadeira = true;
                CriarProfessor.instCadeira = this;
                returnToCriarTarefa = true;
                CriarPagina.createPagina = false;
                CriarPagina.paginaAtual = lstPaginas[listaPaginas.GetItemText(listaPaginas.SelectedItem)];
                CriarPagina inst = new CriarPagina();
                inst.Show();
            }
        }

        private void listaTarefas_DoubleClick(object sender, EventArgs e)
        {
            if (listaTarefas.SelectedItem != null)
            {
                CriarTarefa.createTarefaCadeira = true;
                CriarProfessor.instCadeira = this;
                returnToCriarTarefa = true;
                CriarTarefa.createTarefa = false;
                CriarTarefa.tarefa = lstTarefas[listaTarefas.GetItemText(listaTarefas.SelectedItem)];
                CriarTarefa inst = new CriarTarefa();
                inst.Show();
            }
        }

        private void listaProfessores_DoubleClick(object sender, EventArgs e)
        {
            if (listaProfessores.SelectedItem != null)
            {
                returnToCriarTarefa = true;
                CriarProfessor.createProfessor = false;
                CriarProfessor.professorAtual = lstProfessores[listaProfessores.GetItemText(listaProfessores.SelectedItem)];
                CriarProfessor inst = new CriarProfessor();
                inst.Show();
            }
        }

        private void btnAdicionarFicheiro_Click(object sender, EventArgs e)
        {

            instCadeira = this;
            CriarFicheiro.createFicheiro = true;
            CriarFicheiro.createFicheiroCadeira = true;
            CriarFicheiro.codigo_criador = Cadeira.cadeiraAtual.Codigo_criador;

            CriarFicheiro inst = new CriarFicheiro();
            inst.Show();
        }

        private void listboxFicheiros_DoubleClick(object sender, EventArgs e)
        {
            if (listboxFicheiros.SelectedItem != null)
            {
                instCadeira = this;
                CriarFicheiro.createFicheiro = false;
                CriarFicheiro.createFicheiroCadeira = true;
                CriarFicheiro.ficheiroAtual = lstFicheiros[listboxFicheiros.GetItemText(listboxFicheiros.SelectedItem)];
                CriarFicheiro inst = new CriarFicheiro();
                inst.Show();
            }
        }
    }
}
