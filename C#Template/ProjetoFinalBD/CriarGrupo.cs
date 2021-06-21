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
        private List<ClasseCadeira> lstCadeiras;
        public static Boolean createGrupo;

        public CriarGrupo()
        {
            InitializeComponent();
            PopulateCadeiras();

            if (createGrupo)
            {
                btnApagarGrupo.Visible = false;
                label3.Visible = false;
                label5.Visible = false;
                listboxColegas.Visible = false;
                listboxOrientadores.Visible = false;
                addColega.Visible = false;
                remColega.Visible = false;
                addOrientador.Visible = false;
                remOrientador.Visible = false;

            }
            else
            {
                btnApagarGrupo.Visible = true;
                label3.Visible = true;
                label5.Visible = true;
                listboxColegas.Visible = true;
                listboxOrientadores.Visible = true;
                addColega.Visible = true;
                remColega.Visible = true;
                addOrientador.Visible = true;
                remOrientador.Visible = true;
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

        private void btnApagarGrupo_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
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
                    "WHERE nome = @nome AND aluno = @aluno AND PROJETO.Grupo.disabled = 0";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nome", grupo_nome.Text);
                comando.Parameters.AddWithValue("@aluno", Login.utilizador);
                comando.Connection = cn;
                int numGruposHomonimos = Convert.ToInt32(comando.ExecuteScalar());


                if (numGruposHomonimos == 0)
                {

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "INSERT INTO PROJETO.Grupo(nome,cadeira) VALUES (@nome, @cadeira) ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@nome", grupo_nome.Text);
                    cmd.Parameters.AddWithValue("@cadeira", lstCadeiras[grupo_cadeira.SelectedIndex].Id);
                    cmd.Connection = cn;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Failed to insert Group in database. \n ERROR MESSAGE: \n" + ex.Message);
                    }


                    //get do id do grupo
                    SqlCommand cm = new SqlCommand();
                    cm.CommandText = "SELECT id FROM PROJETO.Grupo JOIN PROJETO.GrupoAluno ON id = grupo " +
                        "WHERE nome = @nome AND aluno = @aluno AND PROJETO.Grupo.disabled = 0";
                    cm.Parameters.Clear();
                    cm.Parameters.AddWithValue("@nome", grupo_nome.Text);
                    cm.Parameters.AddWithValue("@aluno", Login.utilizador);
                    cm.Connection = cn;

                    int grupo_id = 0;
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            grupo_id = Convert.ToInt32(reader["id"]);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Failed to insert Group in database. \n ERROR MESSAGE: \n" + ex.Message);
                    }
                    MessageBox.Show(grupo_id.ToString());


                    //inserir o aluno no grupoaluno

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "INSERT INTO PROJETO.GrupoAluno(grupo,aluno) VALUES (@grupo,@aluno)";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@grupo", grupo_id);
                    command.Parameters.AddWithValue("@aluno", Login.utilizador);
                    command.Connection = cn;
                    command.ExecuteReader();

                    cn.Close();

                    MessageBox.Show("", "Grupo Adicionado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormState.PreviousPage.Show();
                    this.Hide();
                    FormState.PreviousPage = this;
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
            ModalColega colega = new ModalColega();
            colega.Show();
        }

        private void addOrientador_Click(object sender, EventArgs e)
        {
            ModalProfessor professor = new ModalProfessor();
            professor.Show();
        }

    }
}
