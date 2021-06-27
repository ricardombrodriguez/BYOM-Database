using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjetoFinalBD
{
    public partial class CriarGrupo : Form
    {
        private SqlConnection cn;
        private Dictionary<String, ClasseProfessor> lstProfessores = new Dictionary<String, ClasseProfessor>();
        private Dictionary<String, ClassePagina> lstPaginas = new Dictionary<String, ClassePagina>();
        private List<String> lstColegas = new List<String>();
        private List<ClasseCadeira> lstCadeiras = new List<ClasseCadeira>();
        public static ClasseGrupo grupoAtual;
        public static String nome_cadeira;
        public static Boolean createGrupo;
        public static CriarGrupo instGrupo;
        private Dictionary<string, ClasseFicheiro> lstFicheiros = new Dictionary<string, ClasseFicheiro>();


        public CriarGrupo()
        {
            InitializeComponent();
            PopulateCadeiras();

            if (createGrupo)
            {
                label3.Visible = false;
                label5.Visible = false;
                listboxColegas.Visible = false;
                listboxOrientadores.Visible = false;
                addColega.Visible = false;
                remColega.Visible = false;
                addOrientador.Visible = false;
                remOrientador.Visible = false;
                btnAdicionarFicheiro.Visible = false;
                listboxFicheiros.Visible = false;
                label2.Visible = false;
                btnGuardarGrupo.Enabled = false;

            }
            else
            {
               
                grupo_nome.Text = grupoAtual.Nome;
                grupo_cadeira.Text = nome_cadeira;
                grupo_nome.Enabled = false;
                grupo_cadeira.Enabled = false;
                ShowProfessores();
                ShowColegas();
                ShowPaginas();
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
            command.Parameters.AddWithValue("@codigo_criador", grupoAtual.Codigo_criador);
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

        public void ShowPaginas()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.Pagina " +
                "WHERE grupo = @grupo_id ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@grupo_id", grupoAtual.Id);
            cmd.Connection = cn;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                lstPaginas.Clear();
                listboxPaginas.Items.Clear();

                while (reader.Read())
                {
                    ClassePagina pagina = new ClassePagina(Convert.ToInt32(reader[0]),
                                                      reader[1].ToString(),
                                                      reader[5].ToString(),
                                                      reader[2].ToString(),
                                                      Convert.ToInt32(reader[3]),
                                                      reader[4].ToString(),
                                                      Convert.ToInt32(reader[6]));

                    if (lstPaginas.ContainsKey(pagina.Titulo) == false)
                    {
                        lstPaginas.Add(pagina.Titulo,pagina);
                        listboxPaginas.Items.Add(pagina.Titulo);
                    }

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

        public void ShowColegas()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.Grupo JOIN PROJETO.GrupoAluno ON id = grupo " +
                "WHERE id = @grupo_id ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@grupo_id", grupoAtual.Id);
            cmd.Connection = cn;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                lstColegas.Clear();
                listboxColegas.Items.Clear();

                while (reader.Read())
                {
                    String email = reader[5].ToString();

                    if (email != Login.utilizador)
                    {
                        lstColegas.Add(email);
                        listboxColegas.Items.Add(email);
                    }
                    
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

        public void ShowProfessores()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM PROJETO.Grupo JOIN PROJETO.GrupoProfessor ON id = grupo " +
                "JOIN PROJETO.Professor ON professor = email " +
                "JOIN PROJETO.GrupoAluno ON PROJETO.GrupoAluno.grupo = id " +
                "WHERE id = @grupo_id AND PROJETO.Professor.disabled = 0 ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@grupo_id", grupoAtual.Id);
            cmd.Connection = cn;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                lstProfessores.Clear();
                listboxOrientadores.Items.Clear();

                while (reader.Read())
                {
                    ClasseProfessor prof = new ClasseProfessor(reader[6].ToString(),
                                                       reader[7].ToString(),
                                                       false);

                    if (lstProfessores.ContainsKey(prof.Nome + " | " + prof.Email) == false)
                    {
                        lstProfessores.Add(prof.Nome + " | " + prof.Email, prof);
                        listboxOrientadores.Items.Add(prof.Nome + " | " + prof.Email);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void PopulateCadeiras()
        {

            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PROJETO.Cadeira WHERE aluno = @aluno AND disabled = 0;";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@aluno", Login.utilizador);
            command.Connection = cn;

            lstCadeiras = new List<ClasseCadeira>();

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                grupo_cadeira.Items.Clear();

                while (reader.Read())
                {
                    ClasseCadeira inst = new ClasseCadeira(Convert.ToInt32(reader["id"]),
                                                            reader["nome"].ToString());

                    lstCadeiras.Add(inst);

                    grupo_cadeira.Items.Add(inst.Nome);
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

        private void btnGuardarGrupo_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            if (grupo_nome.TextLength == 0 || grupo_cadeira.SelectedItem == null)
            {
                MessageBox.Show("Os campos têm de estar preenchidos.", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //verificar se já existe grupo com esse nome

                SqlCommand comando = new SqlCommand();
                comando.CommandText = "SELECT COUNT(*) FROM PROJETO.Grupo JOIN PROJETO.GrupoAluno ON id = grupo " +
                    "WHERE nome = @nome AND aluno = @aluno";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nome", grupo_nome.Text);
                comando.Parameters.AddWithValue("@aluno", Login.utilizador);
                comando.Connection = cn;
                int numGruposHomonimos = Convert.ToInt32(comando.ExecuteScalar());


                if (numGruposHomonimos == 0)
                {

                    if (createGrupo)
                    {

                        SqlCommand cmd = new SqlCommand("PROJETO.createGroup", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@nome", grupo_nome.Text);
                        cmd.Parameters.AddWithValue("@cadeira", lstCadeiras[grupo_cadeira.SelectedIndex].Id);
                        cmd.Parameters.AddWithValue("@aluno", Login.utilizador);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Grupo " + grupo_nome.Text + " criado.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Não foi possível inserir o grupo na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                        }
                        finally
                        {
                            cn.Close();
                            Grupos pg = new Grupos();
                            pg.Show();
                            this.Hide();
                        }
                    } else
                    {
                        //update

                    
                        SqlCommand command = new SqlCommand();

                        command.CommandText = "UPDATE PROJETO.Grupo SET nome = @nome, cadeira = @cadeira, WHERE id = @id ";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@nome", grupo_nome.Text);
                        command.Parameters.AddWithValue("@cadeira", lstCadeiras[grupo_cadeira.SelectedIndex].Id);
                        command.Parameters.AddWithValue("@id", grupoAtual.Id);
                        command.Connection = cn;

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Grupo " + grupo_nome.Text + " foi atualizado.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                            Grupos gp = new Grupos();
                            gp.Show();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Não foi possível inserir a instituição na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                        }
                        finally
                        {
                            cn.Close();
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Já pertence a um grupo com esse nome.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

        private void addColega_Click(object sender, EventArgs e)
        {
            ModalColega.inst = this;
            ModalColega colega = new ModalColega();
            colega.Show();
        }

        private void addOrientador_Click(object sender, EventArgs e)
        {
            ModalProfessor.inst = this;
            ModalProfessor professor = new ModalProfessor();
            professor.Show();
        }

        private void remColega_Click(object sender, EventArgs e)
        {
            if (listboxColegas.SelectedIndex != -1)
            {
                cn = getSGBDConnection();

                if (!verifySGBDConnection())
                    return;

                SqlCommand command = new SqlCommand();

                command.CommandText = "DELETE FROM PROJETO.GrupoAluno WHERE grupo = @grupo AND aluno = @aluno";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@grupo", grupoAtual.Id);
                command.Parameters.AddWithValue("@aluno", listboxColegas.GetItemText(listboxColegas.SelectedItem));
                command.Connection = cn;

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Colega " + listboxColegas.GetItemText(listboxColegas.SelectedItem) + " foi removido.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowColegas();
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível inserir a instituição na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            } else
            {
                MessageBox.Show("Selecione um colega para remover", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listboxOrientadores_DoubleClick(object sender, EventArgs e)
        {
            if (listboxOrientadores.SelectedItem != null)
            {
                //mostrar a cadeira
                CriarProfessor.createProfessor = false;
                CriarProfessor.professorAtual = lstProfessores[listboxOrientadores.GetItemText(listboxOrientadores.SelectedItem)];
                CriarProfessor inst = new CriarProfessor();
                inst.Show();
            }
        }

        private void remOrientador_Click(object sender, EventArgs e)
        {
            if (listboxOrientadores.SelectedItem != null)
            {
                ClasseProfessor professorAtual = lstProfessores[listboxOrientadores.GetItemText(listboxOrientadores.SelectedItem)];

                cn = getSGBDConnection();

                if (!verifySGBDConnection())
                    return;

                String email = professorAtual.Email;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM PROJETO.GrupoProfessor WHERE professor = @professor";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@professor", email);
                cmd.Connection = cn;

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Orientador " + email + " foi removido.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível inserir a instituição na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                }
                finally
                {
                    ShowProfessores();
                    cn.Close();
                }

               
            }
        }

        private void btnAdicionarPágina_Click(object sender, EventArgs e)
        {
            CriarPagina.createPagina = true;
            CriarPagina.createPaginaGrupo = true;
            CriarPagina.instGrupo = this;
            CriarPagina pagina = new CriarPagina();
            pagina.Show();
        }

        private void listboxPaginas_DoubleClick(object sender, EventArgs e)
        {
            if (listboxPaginas.SelectedItem != null)
            {
                //mostrar a cadeira
                CriarPagina.instGrupo = this;
                CriarPagina.createPagina = false;
                CriarPagina.createPaginaGrupo = true;
                CriarPagina.paginaAtual = lstPaginas[listboxPaginas.GetItemText(listboxPaginas.SelectedItem)];
                CriarPagina inst = new CriarPagina();
                inst.Show();
            }
        }

        private void btnAdicionarFicheiro_Click(object sender, EventArgs e)
        {
            instGrupo = this;
            CriarFicheiro.createFicheiro = true;
            CriarFicheiro.createFicheiroGrupo = true;
            CriarFicheiro.codigo_criador = grupoAtual.Codigo_criador;

            CriarFicheiro inst = new CriarFicheiro();
            inst.Show();
        }

        private void listboxFicheiros_DoubleClick(object sender, EventArgs e)
        {
            if (listboxFicheiros.SelectedItem != null)
            {
                instGrupo = this;
                CriarFicheiro.createFicheiro = false;
                CriarFicheiro.createFicheiroGrupo = true;
                CriarFicheiro.ficheiroAtual = lstFicheiros[listboxFicheiros.GetItemText(listboxFicheiros.SelectedItem)];
                CriarFicheiro inst = new CriarFicheiro();
                inst.Show();
            }
        }
    }
}
