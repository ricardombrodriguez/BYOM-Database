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
        public static Boolean createPagina;
        public static ClassePagina paginaAtual;
        private List<ClasseCadeira> lstCadeiras;

        public CriarPagina()
        {
            InitializeComponent();
            PopulateCadeiras();

            if (createPagina)
            {
                label2.Visible = false;
                texto.Visible = false;
                btnApagarPagina.Visible = false;
            } else
            {
               
                label2.Visible = true;
                texto.Visible = true;
                btnApagarPagina.Visible = true;

                ClassePagina pagina = paginaAtual;
                titulo.Text = pagina.Titulo;
                cadeira.Text = lstCadeiras[pagina.Cadeira].Nome;

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
                cadeira.Items.Clear();

                while (reader.Read())
                {
                    ClasseCadeira inst = new ClasseCadeira(Convert.ToInt32(reader["id"]),
                                                            reader["nome"].ToString());

                    lstCadeiras.Add(inst);

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

        private void btnApagarPagina_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
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

                    SqlCommand cmd = new SqlCommand("PROJETO.createPagina", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@titulo", titulo.Text);
                    cmd.Parameters.AddWithValue("@cadeira", lstCadeiras[cadeira.SelectedIndex].Id);
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
                        cn.Close();
                        Paginas pg = new Paginas();
                        pg.Show();
                        this.Hide();
                    }
                }   
                else {
                    //update 

                    ClassePagina pagina = paginaAtual;

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "UPDATE PROJETO.Pagina(titulo,texto,aluno,cadeira) " +
                        "SET titulo = @titulo, texto = @texto, aluno = @aluno, cadeira = @cadeira) " +
                        "WHERE PROJETO.Pagina.id = @id;";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@titulo", titulo.Text);
                    command.Parameters.AddWithValue("@id", pagina.Id);
                    command.Parameters.AddWithValue("@aluno", Login.utilizador);
                    command.Parameters.AddWithValue("@cadeira", lstCadeiras[cadeira.SelectedIndex].Id);
                    command.Connection = cn;


                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Página " + titulo.Text + " criada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Não foi possível inserir a pagina na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                        Paginas pg = new Paginas();
                        pg.Show();
                        this.Hide();
                    }

                }
            } 
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }
    }
}
