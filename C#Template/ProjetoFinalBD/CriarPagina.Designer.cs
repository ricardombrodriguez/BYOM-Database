
namespace ProjetoFinalBD
{
    partial class CriarPagina
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
            this.btnGuardarPagina = new System.Windows.Forms.Button();
            this.btnApagarPagina = new System.Windows.Forms.Button();
            this.texto = new System.Windows.Forms.TextBox();
            this.titulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cadeira = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnGuardarPagina
            // 
            this.btnGuardarPagina.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarPagina.Location = new System.Drawing.Point(895, 640);
            this.btnGuardarPagina.Name = "btnGuardarPagina";
            this.btnGuardarPagina.Size = new System.Drawing.Size(158, 60);
            this.btnGuardarPagina.TabIndex = 20;
            this.btnGuardarPagina.Text = "Guardar Página";
            this.btnGuardarPagina.UseVisualStyleBackColor = true;
            this.btnGuardarPagina.Click += new System.EventHandler(this.btnGuardarPagina_Click);
            // 
            // btnApagarPagina
            // 
            this.btnApagarPagina.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApagarPagina.Location = new System.Drawing.Point(703, 640);
            this.btnApagarPagina.Name = "btnApagarPagina";
            this.btnApagarPagina.Size = new System.Drawing.Size(158, 59);
            this.btnApagarPagina.TabIndex = 19;
            this.btnApagarPagina.Text = "Apagar Página";
            this.btnApagarPagina.UseVisualStyleBackColor = true;
            this.btnApagarPagina.Click += new System.EventHandler(this.btnApagarPagina_Click);
            // 
            // texto
            // 
            this.texto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.texto.Location = new System.Drawing.Point(103, 160);
            this.texto.Multiline = true;
            this.texto.Name = "texto";
            this.texto.Size = new System.Drawing.Size(950, 458);
            this.texto.TabIndex = 18;
            // 
            // titulo
            // 
            this.titulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titulo.Location = new System.Drawing.Point(103, 102);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(400, 27);
            this.titulo.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label2.Location = new System.Drawing.Point(33, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Texto:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label4.Location = new System.Drawing.Point(33, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Título";
            // 
            // label111
            // 
            this.label111.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label111.AutoSize = true;
            this.label111.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label111.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label111.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label111.Location = new System.Drawing.Point(483, 25);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(119, 33);
            this.label111.TabIndex = 14;
            this.label111.Text = "PÁGINA";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label1.Location = new System.Drawing.Point(616, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Cadeira";
            // 
            // cadeira
            // 
            this.cadeira.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cadeira.FormattingEnabled = true;
            this.cadeira.Location = new System.Drawing.Point(716, 101);
            this.cadeira.Name = "cadeira";
            this.cadeira.Size = new System.Drawing.Size(337, 28);
            this.cadeira.TabIndex = 22;
            // 
            // CriarPagina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1088, 723);
            this.Controls.Add(this.cadeira);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardarPagina);
            this.Controls.Add(this.btnApagarPagina);
            this.Controls.Add(this.texto);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label111);
            this.Name = "CriarPagina";
            this.Text = "CriarPagina";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardarPagina;
        private System.Windows.Forms.Button btnApagarPagina;
        private System.Windows.Forms.TextBox texto;
        private System.Windows.Forms.TextBox titulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cadeira;
    }
}