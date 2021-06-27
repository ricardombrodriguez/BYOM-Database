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

    public partial class CriarPagina : Form
    {

        private SqlConnection cn;
        public static CriarPagina instPagina;
        public static Boolean createPagina = false;
        public static Boolean createPaginaCadeira = false;
        public static Boolean createPaginaGrupo = false;
        public static ClassePagina paginaAtual;
        public static Paginas inst;
        public static CriarGrupo instGrupo;
        public static InfoCadeira instCadeira;
        private Dictionary<String, ClasseCadeira> lstCadeiras = new Dictionary<String, ClasseCadeira>();
        private Dictionary<string, ClasseFicheiro> lstFicheiros = new Dictionary<string, ClasseFicheiro>();


        public CriarPagina()
        {
            InitializeComponent();
            PopulateCadeiras();

            if (createPagina)
            {
                label2.Visible = false;
                texto.Visible = false;
                btnApagarPagina.Visible = false;
                label3.Visible = false;
                btnAdicionarFicheiro.Visible = false;
                listboxFicheiros.Visible = false;
               


                if (createPaginaCadeira)
                {
                    cadeira.Text = Cadeira.cadeiraAtual.Nome;
                } 
                else if (createPaginaGrupo)
                {
                    foreach (KeyValuePair<string, ClasseCadeira> entry in lstCadeiras)
                    {
                        if (entry.Value.Id == CriarGrupo.grupoAtual.Cadeira)
                        {
                            cadeira.Text = entry.Value.Nome;
                        }
                    }
                }
            } else
            {
              
                ClassePagina pagina = paginaAtual;
                titulo.Text = pagina.Titulo;
                texto.Text = pagina.Texto;
                for (int i = lstCadeiras.Count - 1; i >= 0; i--)
                {
                    var item = lstCadeiras.ElementAt(i);
                    var itemKey = item.Key;
                    var itemValue = item.Value;
                    if (itemValue.Id == pagina.Cadeira)
                    {
                        cadeira.Text = itemValue.Nome;
                        break;
                    }
                }
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
            command.Parameters.AddWithValue("@codigo_criador", paginaAtual.Codigo_criador);
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

            lstCadeiras = new Dictionary<String, ClasseCadeira>();

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                cadeira.Items.Clear();

                while (reader.Read())
                {
                    ClasseCadeira inst = new ClasseCadeira(Convert.ToInt32(reader["id"]),
                                                            reader["nome"].ToString());

                    lstCadeiras.Add(inst.Nome,inst);
                    cadeira.Items.Add(inst.Nome);
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
            return Login.bdConnection.getSGBDConnection();
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void btnApagarPagina_Click(object sender, EventArgs e)
        {

            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            int id = paginaAtual.Id;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "PROJETO.deletePagina";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@pagId", id);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível remover a página na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                if (createPaginaCadeira)
                {
                    instCadeira.showPaginas();
                    cn.Close();
                    this.Hide();
                }
                else if (createPaginaGrupo)
                {
                    instGrupo.ShowPaginas();
                    cn.Close();
                    this.Hide();
                }
                else
                {

                    cn.Close();
                    inst.ShowPaginas();
                    this.Hide();
                }
            }
        }

        private void btnGuardarPagina_Click(object sender, EventArgs e)
        {

            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            if (titulo.TextLength == 0)
            {
                MessageBox.Show("Os campos têm de estar preenchidos.", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (createPagina)
                {
                    //insert
                    

                    if (createPaginaGrupo)
                    {
                        SqlCommand cmd = new SqlCommand("PROJETO.createPaginaGrupo", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@titulo", titulo.Text);
                        cmd.Parameters.AddWithValue("@cadeira", lstCadeiras[cadeira.Text].Id);
                        cmd.Parameters.AddWithValue("@aluno", Login.utilizador);
                        cmd.Parameters.AddWithValue("@grupo", CriarGrupo.grupoAtual.Id);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Página de grupo " + titulo.Text + " criada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Não foi possível inserir a pagina na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                        }
                        finally
                        {
                            cn.Close();
                            this.Hide();
                            instGrupo.ShowPaginas();
                        }
                    }
                    else
                    {

                      
                        SqlCommand cmd = new SqlCommand("PROJETO.createPagina", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@titulo", titulo.Text);
                        cmd.Parameters.AddWithValue("@cadeira",
                            lstCadeiras.ContainsKey(cadeira.Text) == false ? (object)DBNull.Value : lstCadeiras[cadeira.Text].Id);
                        cmd.Parameters.AddWithValue("@aluno", Login.utilizador);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Página " + titulo.Text + " criada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Não foi possível inserir a pagina na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                        }
                        finally
                        {
                            if (createPaginaCadeira)
                            {
                                cn.Close();
                                this.Hide();
                                instCadeira.showPaginas();
                            }
                            else
                            {
                                cn.Close();
                                inst.PopulateCadeiras();
                                inst.ShowPaginas();
                                this.Hide();
                            }
                        }
                    }

                }
                    
                else {
                    //update 

                    ClassePagina pagina = paginaAtual;

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "UPDATE PROJETO.Pagina SET titulo = @titulo, texto = @texto, cadeira = @cadeira " +
                        "WHERE PROJETO.Pagina.id = @id;";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@titulo", titulo.Text);
                    command.Parameters.AddWithValue("@texto", texto.Text);
                    command.Parameters.AddWithValue("@cadeira", lstCadeiras[cadeira.Text].Id);
                    command.Parameters.AddWithValue("@id", paginaAtual.Id);
                    command.Connection = cn;

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Página atualizada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Não foi possível fazer update da pagina na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                    }
                    finally
                    {
                        if (createPaginaCadeira)
                        {
                            instCadeira.showPaginas();
                            cn.Close();
                            this.Hide();
                        } else
                        {
                            inst.PopulateCadeiras();
                            inst.ShowPaginas();
                            cn.Close();
                            this.Hide();
                        }
                    }

                }
            } 
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAdicionarFicheiro_Click(object sender, EventArgs e)
        {
            
            instPagina = this;
            CriarFicheiro.createFicheiro = true;
            CriarFicheiro.createFicheiroPagina = true;
            CriarFicheiro.codigo_criador = paginaAtual.Codigo_criador;
            CriarFicheiro inst = new CriarFicheiro();
            inst.Show();

        }

        private void listboxFicheiros_DoubleClick(object sender, EventArgs e)
        {
            if (listboxFicheiros.SelectedItem != null)
            {
                instPagina = this;
                CriarFicheiro.createFicheiro = false;
                CriarFicheiro.createFicheiroPagina = true;
                CriarFicheiro.codigo_criador = paginaAtual.Codigo_criador;
                CriarFicheiro.ficheiroAtual = lstFicheiros[listboxFicheiros.GetItemText(listboxFicheiros.SelectedItem)];

                CriarFicheiro inst = new CriarFicheiro();
                inst.Show();
            }
        }
    }
}
