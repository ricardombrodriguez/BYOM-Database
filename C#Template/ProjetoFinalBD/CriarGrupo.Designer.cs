
namespace ProjetoFinalBD
{
    partial class CriarGrupo
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
            this.label4 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.cadeira = new System.Windows.Forms.Label();
            this.grupo_cadeira = new System.Windows.Forms.ComboBox();
            this.grupo_nome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listboxColegas = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listboxOrientadores = new System.Windows.Forms.ListBox();
            this.addColega = new System.Windows.Forms.ComboBox();
            this.remColega = new System.Windows.Forms.Button();
            this.remOrientador = new System.Windows.Forms.Button();
            this.addOrientador = new System.Windows.Forms.ComboBox();
            this.btnApagarGrupo = new System.Windows.Forms.Button();
            this.btnGuardarGrupo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label4.Location = new System.Drawing.Point(49, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Nome";
            // 
            // label111
            // 
            this.label111.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label111.AutoSize = true;
            this.label111.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label111.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label111.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label111.Location = new System.Drawing.Point(486, 22);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(111, 33);
            this.label111.TabIndex = 20;
            this.label111.Text = "GRUPO";
            // 
            // cadeira
            // 
            this.cadeira.AutoSize = true;
            this.cadeira.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cadeira.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.cadeira.Location = new System.Drawing.Point(49, 139);
            this.cadeira.Name = "cadeira";
            this.cadeira.Size = new System.Drawing.Size(69, 20);
            this.cadeira.TabIndex = 21;
            this.cadeira.Text = "Cadeira";
            // 
            // grupo_cadeira
            // 
            this.grupo_cadeira.FormattingEnabled = true;
            this.grupo_cadeira.Location = new System.Drawing.Point(163, 136);
            this.grupo_cadeira.Name = "grupo_cadeira";
            this.grupo_cadeira.Size = new System.Drawing.Size(619, 28);
            this.grupo_cadeira.TabIndex = 22;
            // 
            // grupo_nome
            // 
            this.grupo_nome.Location = new System.Drawing.Point(163, 89);
            this.grupo_nome.Name = "grupo_nome";
            this.grupo_nome.Size = new System.Drawing.Size(619, 27);
            this.grupo_nome.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label3.Location = new System.Drawing.Point(49, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Colegas no grupo:";
            // 
            // listboxColegas
            // 
            this.listboxColegas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listboxColegas.FormattingEnabled = true;
            this.listboxColegas.ItemHeight = 20;
            this.listboxColegas.Location = new System.Drawing.Point(49, 236);
            this.listboxColegas.Name = "listboxColegas";
            this.listboxColegas.Size = new System.Drawing.Size(504, 264);
            this.listboxColegas.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label5.Location = new System.Drawing.Point(590, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Professores orientadores:";
            // 
            // listboxOrientadores
            // 
            this.listboxOrientadores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listboxOrientadores.FormattingEnabled = true;
            this.listboxOrientadores.ItemHeight = 20;
            this.listboxOrientadores.Location = new System.Drawing.Point(590, 236);
            this.listboxOrientadores.Name = "listboxOrientadores";
            this.listboxOrientadores.Size = new System.Drawing.Size(504, 264);
            this.listboxOrientadores.TabIndex = 31;
            // 
            // addColega
            // 
            this.addColega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addColega.FormattingEnabled = true;
            this.addColega.Location = new System.Drawing.Point(49, 526);
            this.addColega.Name = "addColega";
            this.addColega.Size = new System.Drawing.Size(247, 28);
            this.addColega.TabIndex = 32;
            this.addColega.Text = "Adicionar colega";
            // 
            // remColega
            // 
            this.remColega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remColega.Location = new System.Drawing.Point(302, 526);
            this.remColega.Name = "remColega";
            this.remColega.Size = new System.Drawing.Size(251, 29);
            this.remColega.TabIndex = 33;
            this.remColega.Text = "Remover colega";
            this.remColega.UseVisualStyleBackColor = true;
            // 
            // remOrientador
            // 
            this.remOrientador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remOrientador.Location = new System.Drawing.Point(843, 526);
            this.remOrientador.Name = "remOrientador";
            this.remOrientador.Size = new System.Drawing.Size(251, 29);
            this.remOrientador.TabIndex = 34;
            this.remOrientador.Text = "Remover orientador";
            this.remOrientador.UseVisualStyleBackColor = true;
            // 
            // addOrientador
            // 
            this.addOrientador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addOrientador.FormattingEnabled = true;
            this.addOrientador.Location = new System.Drawing.Point(590, 527);
            this.addOrientador.Name = "addOrientador";
            this.addOrientador.Size = new System.Drawing.Size(247, 28);
            this.addOrientador.TabIndex = 35;
            this.addOrientador.Text = "Adicionar orientador";
            // 
            // btnApagarGrupo
            // 
            this.btnApagarGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApagarGrupo.Location = new System.Drawing.Point(740, 591);
            this.btnApagarGrupo.Name = "btnApagarGrupo";
            this.btnApagarGrupo.Size = new System.Drawing.Size(169, 49);
            this.btnApagarGrupo.TabIndex = 36;
            this.btnApagarGrupo.Text = "Apagar Grupo";
            this.btnApagarGrupo.UseVisualStyleBackColor = true;
            this.btnApagarGrupo.Click += new System.EventHandler(this.btnApagarGrupo_Click);
            // 
            // btnGuardarGrupo
            // 
            this.btnGuardarGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarGrupo.Location = new System.Drawing.Point(922, 591);
            this.btnGuardarGrupo.Name = "btnGuardarGrupo";
            this.btnGuardarGrupo.Size = new System.Drawing.Size(172, 49);
            this.btnGuardarGrupo.TabIndex = 37;
            this.btnGuardarGrupo.Text = "Guardar Grupo";
            this.btnGuardarGrupo.UseVisualStyleBackColor = true;
            this.btnGuardarGrupo.Click += new System.EventHandler(this.btnGuardarGrupo_Click);
            // 
            // CriarGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1130, 666);
            this.Controls.Add(this.btnGuardarGrupo);
            this.Controls.Add(this.btnApagarGrupo);
            this.Controls.Add(this.addOrientador);
            this.Controls.Add(this.remOrientador);
            this.Controls.Add(this.remColega);
            this.Controls.Add(this.addColega);
            this.Controls.Add(this.listboxOrientadores);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listboxColegas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grupo_cadeira);
            this.Controls.Add(this.cadeira);
            this.Controls.Add(this.label111);
            this.Controls.Add(this.grupo_nome);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CriarGrupo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CriarGrupo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.Label cadeira;
        private System.Windows.Forms.ComboBox grupo_cadeira;
        private System.Windows.Forms.TextBox grupo_nome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listboxColegas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listboxOrientadores;
        private System.Windows.Forms.ComboBox addColega;
        private System.Windows.Forms.Button remColega;
        private System.Windows.Forms.Button remOrientador;
        private System.Windows.Forms.ComboBox addOrientador;
        private System.Windows.Forms.Button btnApagarGrupo;
        private System.Windows.Forms.Button btnGuardarGrupo;
    }
}