using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinalBD
{
    public partial class CriarConta : Form
    {
        private SqlConnection cn;
        private ArrayList emails;
        private Boolean birthdayChange = false;

        public CriarConta()
        {
            InitializeComponent();
  
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


        private void goback_Click(object sender, EventArgs e)
        {
            FormState.PreviousPage.Show();
            this.Hide();
            FormState.PreviousPage = this;
        }

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;
    

            if (nome.TextLength == 0 || password.TextLength == 0 || email.TextLength == 0)
            {
                MessageBox.Show("Insira todos os parâmetros obrigatórios.","ERRO",MessageBoxButtons.OK,MessageBoxIcon.Error);
            } else if (password.Text != confirmarPassword.Text || password.TextLength == 0)
            {
                MessageBox.Show("Defina passwords iguais.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM PROJETO.Aluno WHERE email = @email;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Connection = cn;
                int count = 1;


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count = (int)reader[0];
                }

                // Call Close when done reading.
                reader.Close();
                if (count > 0)
                {
                    MessageBox.Show("Já existe uma conta com esse email.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!birthdayChange)
                    {
        
                        SqlCommand command = new SqlCommand();
                        command.CommandText = "INSERT INTO PROJETO.Aluno(email,nome,password) VALUES (@email,@nome,@password);";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@email", email.Text);
                        command.Parameters.AddWithValue("@nome", nome.Text);
                        command.Parameters.AddWithValue("@password", password.Text);
                        command.Connection = cn;

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("A sua conta foi criada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                            BYOM byom = new BYOM();
                            byom.Show();

                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
                        }
                   
                    }
                    else
                    {
                        SqlCommand command = new SqlCommand();
                        command.CommandText = "INSERT INTO PROJETO.Aluno(email,nome,password,data_nascimento) VALUES (@email,@nome,@password,@data_nascimento);";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@email", email.Text);
                        command.Parameters.AddWithValue("@nome", nome.Text);
                        command.Parameters.AddWithValue("@password", password.Text);
                        command.Parameters.AddWithValue("@data_nascimento", dataNascimento.Value);
                        command.Connection = cn;

                        try
                        {
                            command.ExecuteNonQuery();

                            MessageBox.Show("A sua conta foi criada.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                            BYOM byom = new BYOM();
                            byom.Show();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
                        }

                    }
                }
            }

            cn.Close();
        }

        private void dataNascimento_ValueChanged(object sender, EventArgs e)
        {
            birthdayChange = true;
        }

    }
}
