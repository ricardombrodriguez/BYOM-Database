
namespace ProjetoFinalBD
{
    partial class ModalProfessor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label111 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdicionarProfessor = new System.Windows.Forms.Button();
            this.btnCriarProfessor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label111.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label111.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label111.Location = new System.Drawing.Point(21, 25);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(472, 33);
            this.label111.TabIndex = 3;
            this.label111.Text = "ADICIONAR PROFESSOR AO GRUPO";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(129, 93);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(335, 27);
            this.email.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label4.Location = new System.Drawing.Point(51, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Email *";
            // 
            // btnAdicionarProfessor
            // 
            this.btnAdicionarProfessor.Location = new System.Drawing.Point(294, 187);
            this.btnAdicionarProfessor.Name = "btnAdicionarProfessor";
            this.btnAdicionarProfessor.Size = new System.Drawing.Size(199, 46);
            this.btnAdicionarProfessor.TabIndex = 13;
            this.btnAdicionarProfessor.Text = "Adicionar professor";
            this.btnAdicionarProfessor.UseVisualStyleBackColor = true;
            this.btnAdicionarProfessor.Click += new System.EventHandler(this.btnAdicionarProfessor_Click);
            // 
            // btnCriarProfessor
            // 
            this.btnCriarProfessor.Location = new System.Drawing.Point(21, 187);
            this.btnCriarProfessor.Name = "btnCriarProfessor";
            this.btnCriarProfessor.Size = new System.Drawing.Size(199, 46);
            this.btnCriarProfessor.TabIndex = 14;
            this.btnCriarProfessor.Text = "Criar novo professor";
            this.btnCriarProfessor.UseVisualStyleBackColor = true;
            this.btnCriarProfessor.Click += new System.EventHandler(this.btnCriarProfessor_Click);
            // 
            // ModalProfessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(527, 255);
            this.Controls.Add(this.btnCriarProfessor);
            this.Controls.Add(this.btnAdicionarProfessor);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label111);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModalProfessor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BYOM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdicionarProfessor;
        private System.Windows.Forms.Button btnCriarProfessor;
    }
}