
namespace ProjetoFinalBD
{
    partial class CriarInstituicao
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nome = new System.Windows.Forms.TextBox();
            this.descricao = new System.Windows.Forms.TextBox();
            this.btnApagarInstituicao = new System.Windows.Forms.Button();
            this.btnGuardarInstituicao = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cadeiras_instituicao = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label111.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label111.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label111.Location = new System.Drawing.Point(412, 26);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(169, 33);
            this.label111.TabIndex = 2;
            this.label111.Text = "INSTITUIÇÃO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label4.Location = new System.Drawing.Point(29, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nome *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label2.Location = new System.Drawing.Point(29, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Descrição *";
            // 
            // nome
            // 
            this.nome.Location = new System.Drawing.Point(131, 128);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(341, 27);
            this.nome.TabIndex = 10;
            // 
            // descricao
            // 
            this.descricao.Location = new System.Drawing.Point(131, 186);
            this.descricao.Multiline = true;
            this.descricao.Name = "descricao";
            this.descricao.Size = new System.Drawing.Size(341, 246);
            this.descricao.TabIndex = 11;
            // 
            // btnApagarInstituicao
            // 
            this.btnApagarInstituicao.Location = new System.Drawing.Point(585, 456);
            this.btnApagarInstituicao.Name = "btnApagarInstituicao";
            this.btnApagarInstituicao.Size = new System.Drawing.Size(162, 56);
            this.btnApagarInstituicao.TabIndex = 12;
            this.btnApagarInstituicao.Text = "Apagar Instituição";
            this.btnApagarInstituicao.UseVisualStyleBackColor = true;
            this.btnApagarInstituicao.Click += new System.EventHandler(this.btnApagarInstituicao_Click);
            // 
            // btnGuardarInstituicao
            // 
            this.btnGuardarInstituicao.Location = new System.Drawing.Point(764, 456);
            this.btnGuardarInstituicao.Name = "btnGuardarInstituicao";
            this.btnGuardarInstituicao.Size = new System.Drawing.Size(162, 57);
            this.btnGuardarInstituicao.TabIndex = 13;
            this.btnGuardarInstituicao.Text = "Guardar Instituição";
            this.btnGuardarInstituicao.UseVisualStyleBackColor = true;
            this.btnGuardarInstituicao.Click += new System.EventHandler(this.btnGuardarInstituicao_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Image = global::ProjetoFinalBD.Properties.Resources._1410611_200;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 47);
            this.button1.TabIndex = 40;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label1.Location = new System.Drawing.Point(537, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Cadeiras da instituição:";
            // 
            // cadeiras_instituicao
            // 
            this.cadeiras_instituicao.FormattingEnabled = true;
            this.cadeiras_instituicao.ItemHeight = 20;
            this.cadeiras_instituicao.Location = new System.Drawing.Point(537, 128);
            this.cadeiras_instituicao.Name = "cadeiras_instituicao";
            this.cadeiras_instituicao.Size = new System.Drawing.Size(389, 304);
            this.cadeiras_instituicao.TabIndex = 42;
            // 
            // CriarInstituicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(943, 528);
            this.Controls.Add(this.cadeiras_instituicao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGuardarInstituicao);
            this.Controls.Add(this.btnApagarInstituicao);
            this.Controls.Add(this.descricao);
            this.Controls.Add(this.nome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label111);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CriarInstituicao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BYOM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.TextBox descricao;
        private System.Windows.Forms.Button btnApagarInstituicao;
        private System.Windows.Forms.Button btnGuardarInstituicao;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox cadeiras_instituicao;
    }
}