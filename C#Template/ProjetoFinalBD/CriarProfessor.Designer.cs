
namespace ProjetoFinalBD
{
    partial class CriarProfessor
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
            this.email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nome = new System.Windows.Forms.TextBox();
            this.btnGuardarProfessor = new System.Windows.Forms.Button();
            this.btnApagarProfessor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(156, 151);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(350, 27);
            this.email.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label4.Location = new System.Drawing.Point(-88, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Título";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label111.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label111.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label111.Location = new System.Drawing.Point(185, 43);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(162, 33);
            this.label111.TabIndex = 18;
            this.label111.Text = "PROFESSOR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label1.Location = new System.Drawing.Point(48, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Email *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label2.Location = new System.Drawing.Point(48, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nome *";
            // 
            // nome
            // 
            this.nome.Location = new System.Drawing.Point(156, 208);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(350, 27);
            this.nome.TabIndex = 22;
            // 
            // btnGuardarProfessor
            // 
            this.btnGuardarProfessor.Location = new System.Drawing.Point(348, 286);
            this.btnGuardarProfessor.Name = "btnGuardarProfessor";
            this.btnGuardarProfessor.Size = new System.Drawing.Size(158, 60);
            this.btnGuardarProfessor.TabIndex = 25;
            this.btnGuardarProfessor.Text = "Guardar professor";
            this.btnGuardarProfessor.UseVisualStyleBackColor = true;
            this.btnGuardarProfessor.Click += new System.EventHandler(this.btnGuardarProfessor_Click);
            // 
            // btnApagarProfessor
            // 
            this.btnApagarProfessor.Location = new System.Drawing.Point(156, 286);
            this.btnApagarProfessor.Name = "btnApagarProfessor";
            this.btnApagarProfessor.Size = new System.Drawing.Size(158, 59);
            this.btnApagarProfessor.TabIndex = 24;
            this.btnApagarProfessor.Text = "Apagar professor";
            this.btnApagarProfessor.UseVisualStyleBackColor = true;
            this.btnApagarProfessor.Click += new System.EventHandler(this.btnApagarProfessor_Click);
            // 
            // CriarProfessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(561, 387);
            this.Controls.Add(this.btnGuardarProfessor);
            this.Controls.Add(this.btnApagarProfessor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label111);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CriarProfessor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BYOM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.Button btnGuardarProfessor;
        private System.Windows.Forms.Button btnApagarProfessor;
    }
}