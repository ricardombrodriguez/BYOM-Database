
namespace ProjetoFinalBD
{
    partial class CriarFicheiro
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
            this.localizacao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApagarFicheiro = new System.Windows.Forms.Button();
            this.btnGuardarFicheiro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // localizacao
            // 
            this.localizacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localizacao.Location = new System.Drawing.Point(170, 186);
            this.localizacao.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.localizacao.Name = "localizacao";
            this.localizacao.Size = new System.Drawing.Size(394, 27);
            this.localizacao.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(51, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 46;
            this.label3.Text = "Localização";
            // 
            // nome
            // 
            this.nome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nome.Location = new System.Drawing.Point(170, 135);
            this.nome.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.nome.Name = "nome";
            this.nome.Size = new System.Drawing.Size(394, 27);
            this.nome.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(51, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(235, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 46);
            this.label1.TabIndex = 43;
            this.label1.Text = "FICHEIRO";
            // 
            // btnApagarFicheiro
            // 
            this.btnApagarFicheiro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnApagarFicheiro.Location = new System.Drawing.Point(234, 258);
            this.btnApagarFicheiro.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnApagarFicheiro.Name = "btnApagarFicheiro";
            this.btnApagarFicheiro.Size = new System.Drawing.Size(185, 70);
            this.btnApagarFicheiro.TabIndex = 49;
            this.btnApagarFicheiro.Text = "Apagar ficheiro";
            this.btnApagarFicheiro.UseVisualStyleBackColor = true;
            this.btnApagarFicheiro.Click += new System.EventHandler(this.btnApagarFicheiro_Click);
            // 
            // btnGuardarFicheiro
            // 
            this.btnGuardarFicheiro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardarFicheiro.Location = new System.Drawing.Point(437, 258);
            this.btnGuardarFicheiro.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnGuardarFicheiro.Name = "btnGuardarFicheiro";
            this.btnGuardarFicheiro.Size = new System.Drawing.Size(186, 70);
            this.btnGuardarFicheiro.TabIndex = 48;
            this.btnGuardarFicheiro.Text = "Guardar ficheiro";
            this.btnGuardarFicheiro.UseVisualStyleBackColor = true;
            this.btnGuardarFicheiro.Click += new System.EventHandler(this.btnGuardarFicheiro_Click);
            // 
            // CriarFicheiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(636, 349);
            this.Controls.Add(this.btnApagarFicheiro);
            this.Controls.Add(this.btnGuardarFicheiro);
            this.Controls.Add(this.localizacao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CriarFicheiro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CriarFicheiro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox localizacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApagarFicheiro;
        private System.Windows.Forms.Button btnGuardarFicheiro;
    }
}