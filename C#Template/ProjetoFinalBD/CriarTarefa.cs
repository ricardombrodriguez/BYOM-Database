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
    public partial class CriarTarefa : Form
    {

        private SqlConnection cn;
        public static Boolean createTarefa;
        public static CriarTarefa tarefaAtual;
        public static ClasseTarefa tarefa;
        private List<ClasseCadeira> lstCadeiras;
        private List<ClasseTipoTarefa> lstTipoTarefa;

        public CriarTarefa()
        {
            InitializeComponent();
            PopulateTipoTarefa();
            PopulateCadeiras();

            if (createTarefa)
            {
                btnApagar.Visible = false;
            }
            else
            {
                titulo.Text = tarefa.Titulo;
                descricao.Text = tarefa.Descricao;
                dataInicio.Value = DateTime.Parse(tarefa.Data_inicio);
                dataFinal.Value = DateTime.Parse(tarefa.Date_final);
                cadeira.SelectedIndex = this.getCadeiraIndex(tarefa.Cadeira);
                tipoTarefa.SelectedIndex = this.getTipoTarefaIndex(tarefa.TipoTarefa);
                if (tarefa.Completada_ts != "")
                {
                    checkbox.Checked = true;
                }
            }

        }

        private int getCadeiraIndex(int cadeira)
        {
            int x = 0;
            foreach (ClasseCadeira c in this.lstCadeiras)
            {
                if (c.Id == cadeira)
                {
                    return x;
                }
                x++;
            }

            return -1;
        }

        private int getTipoTarefaIndex(int tipo)
        {
            int x = 0;
            foreach (ClasseTipoTarefa t in this.lstTipoTarefa)
            {
                if (t.Id == tipo)
                {
                    return x;
                }
                x++;
            }

            return -1;
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
                throw new Exception("Falha ao carregar as acdeiras da base de dados. \n ERROR MESSAGE: \n" + ex.Message);

            }

            cn.Close();

        }

        public void PopulateTipoTarefa()
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            lstTipoTarefa = new List<ClasseTipoTarefa>();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PROJETO.TipoTarefa WHERE aluno_criador = @aluno_criador AND disabled = 0;";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@aluno_criador", Login.utilizador);
            command.Connection = cn;

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                tipoTarefa.Items.Clear();

                while (reader.Read())
                {
                    ClasseTipoTarefa inst = new ClasseTipoTarefa(Convert.ToInt32(reader["id"]),
                                                       reader["designacao"].ToString(),
                                                       reader["aluno_criador"].ToString(),
                                                       Convert.ToBoolean(reader["disabled"]));

                    lstTipoTarefa.Add(inst);
                    tipoTarefa.Items.Add(inst.Designacao);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao carregar os tipos de tarefa da base de dados. \n ERROR MESSAGE: \n" + ex.Message);

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

        private void btnApagar_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("PROJETO.deleteTarefa", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", tarefa.Id);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tarefa " + tarefa.Titulo + " apagada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível apagar a instituição da base de dados. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
                Tarefas tf = new Tarefas();
                tf.Show();
                this.Hide();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            if (titulo.TextLength == 0 || tipoTarefa.SelectedItem == null)
            {
                MessageBox.Show("Os campos têm de estar preenchidos.", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //verificar se já existe uma tarefa com esse nome para esse utilizador (não importa se estamos a fazer update/insert)

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM PROJETO.Tarefa WHERE titulo = @titulo AND aluno = @aluno";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@titulo", titulo.Text);
                cmd.Parameters.AddWithValue("@aluno", Login.utilizador);
                cmd.Connection = cn;
                int num = Convert.ToInt32(cmd.ExecuteScalar());

                cn.Close();

                if (num == 0 || !createTarefa)
                {
                    cn = getSGBDConnection();

                    if (!verifySGBDConnection())
                        return;

                    String var_titulo = titulo.Text;
                    String var_descricao = descricao.Text;
                    DateTime var_dataInicio = dataInicio.Value.Date;
                    DateTime var_dataFinal = dataFinal.Value.Date;
                    int var_tipoTarefa = lstTipoTarefa[tipoTarefa.SelectedIndex].Id;
                    String var_aluno = Login.utilizador;
                    int var_cadeira = lstCadeiras[cadeira.SelectedIndex].Id;

                    if (DateTime.Compare(var_dataFinal, var_dataInicio) < 0)
                    {
                        MessageBox.Show("A data final da tarefa não pode ser anterior à data inicial.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SqlCommand command = new SqlCommand();

                    if (createTarefa)
                    {
                        //é para fazer insert                       

                        command.CommandText = "INSERT INTO PROJETO.Tarefa(titulo,descricao,data_inicio,date_final,tipoTarefa,aluno,cadeira) VALUES (@titulo,@descricao,@data_inicio,@date_final,@tipoTarefa,@aluno,@cadeira);";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@titulo", var_titulo);
                        command.Parameters.AddWithValue("@data_inicio", var_dataInicio);
                        command.Parameters.AddWithValue("@date_final", var_dataFinal);
                        command.Parameters.AddWithValue("@tipoTarefa", var_tipoTarefa);
                        command.Parameters.AddWithValue("@cadeira", var_cadeira);
                        command.Parameters.AddWithValue("@descricao", var_descricao);
                        command.Parameters.AddWithValue("@aluno", Login.utilizador);
                        command.Connection = cn;


                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Tarefa " + var_titulo + " criada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Não foi possível inserir a instituição na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                        }
                        finally
                        {
                            cn.Close();
                            Tarefas tf = new Tarefas();
                            tf.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        // é para fazer update

                        command.CommandText = "UPDATE PROJETO.Tarefa SET titulo = @titulo, descricao = @descricao, data_inicio = @data_inicio, date_final = @date_final, tipoTarefa = @tipoTarefa, cadeira = @cadeira WHERE id = @id;";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@titulo", var_titulo);
                        command.Parameters.AddWithValue("@data_inicio", var_dataInicio);
                        command.Parameters.AddWithValue("@date_final", var_dataFinal);
                        command.Parameters.AddWithValue("@tipoTarefa", var_tipoTarefa);
                        command.Parameters.AddWithValue("@cadeira", var_cadeira);
                        command.Parameters.AddWithValue("@descricao", var_descricao);
                        command.Parameters.AddWithValue("@aluno", Login.utilizador);
                        command.Parameters.AddWithValue("@id", tarefa.Id);
                        command.Connection = cn;


                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Tarefa " + var_titulo + " atualizada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Não foi possível inserir a instituição na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
                        }
                        finally
                        {
                            Tarefas tf = new Tarefas();
                            tf.Show();
                            this.Hide();
                        }
                    }
                    cn.Close();

                }
                else
                {
                    MessageBox.Show("Já existe uma tarefa com esse nome.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

        private void addTipoTarefa_Click(object sender, EventArgs e)
        {
            CriarTipoTarefa novo = new CriarTipoTarefa();
            novo.Show();
            tarefaAtual = this;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

        private void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;

            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE PROJETO.Tarefa SET completada_ts = @ts WHERE id = @id;";
            command.Parameters.Clear();
            String msg = "";

            if (checkbox.Checked)
            {
                // marcar como realizada
                tarefa.Completada_ts = DateTime.Now.ToString();
                command.Parameters.AddWithValue("@ts", DateTime.Now);
                msg = "Tarefa " + tarefa.Titulo + " marcada como realizada.";
            }
            else
            {
                // tirar de realizada
                command.Parameters.AddWithValue("@ts", DBNull.Value);
                msg = "Tarefa " + tarefa.Titulo + " marcada como não realizada.";
            }

            command.Parameters.AddWithValue("@id", tarefa.Id);
            command.Connection = cn;


            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show(msg, "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar a tarefa na base de dados. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void addCadeira_Click(object sender, EventArgs e)
        {
            Cadeira.criarCadeira = true;
            InfoCadeira.returnToCriarTarefa = true;
            InfoCadeira novo = new InfoCadeira();
            novo.Show();
            tarefaAtual = this;
        }
    }

}