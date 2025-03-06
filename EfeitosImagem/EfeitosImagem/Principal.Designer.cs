
namespace EfeitosImagem
{
    partial class Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.picImageOutput = new System.Windows.Forms.PictureBox();
            this.cboEffect = new System.Windows.Forms.ComboBox();
            this.lblEffect = new System.Windows.Forms.Label();
            this.grpMirror = new System.Windows.Forms.GroupBox();
            this.rdbMirrorNone = new System.Windows.Forms.RadioButton();
            this.rdbMirrorHorizontal = new System.Windows.Forms.RadioButton();
            this.rdbMirrorVertical = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picImageOutput)).BeginInit();
            this.grpMirror.SuspendLayout();
            this.SuspendLayout();
            // 
            // picImageOutput
            // 
            this.picImageOutput.Location = new System.Drawing.Point(23, 73);
            this.picImageOutput.Name = "picImageOutput";
            this.picImageOutput.Size = new System.Drawing.Size(745, 473);
            this.picImageOutput.TabIndex = 0;
            this.picImageOutput.TabStop = false;
            // 
            // cboEffect
            // 
            this.cboEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEffect.FormattingEnabled = true;
            this.cboEffect.Items.AddRange(new object[] {
            "Cinza",
            "Desfoque Gaussiano",
            "Negativo",
            "Normal",
            "Pixelizar",
            "Preto e Branco",
            "Sepia"});
            this.cboEffect.Location = new System.Drawing.Point(23, 34);
            this.cboEffect.Name = "cboEffect";
            this.cboEffect.Size = new System.Drawing.Size(372, 24);
            this.cboEffect.TabIndex = 1;
            this.cboEffect.SelectedIndexChanged += new System.EventHandler(this.cboEffect_SelectedIndexChanged);
            // 
            // lblEffect
            // 
            this.lblEffect.AutoSize = true;
            this.lblEffect.Location = new System.Drawing.Point(20, 14);
            this.lblEffect.Name = "lblEffect";
            this.lblEffect.Size = new System.Drawing.Size(44, 16);
            this.lblEffect.TabIndex = 2;
            this.lblEffect.Text = "Efeito:";
            // 
            // grpMirror
            // 
            this.grpMirror.Controls.Add(this.rdbMirrorVertical);
            this.grpMirror.Controls.Add(this.rdbMirrorHorizontal);
            this.grpMirror.Controls.Add(this.rdbMirrorNone);
            this.grpMirror.Location = new System.Drawing.Point(401, 14);
            this.grpMirror.Name = "grpMirror";
            this.grpMirror.Size = new System.Drawing.Size(367, 55);
            this.grpMirror.TabIndex = 4;
            this.grpMirror.TabStop = false;
            this.grpMirror.Text = "Espelhamento";
            // 
            // rdbMirrorNone
            // 
            this.rdbMirrorNone.AutoSize = true;
            this.rdbMirrorNone.Location = new System.Drawing.Point(16, 22);
            this.rdbMirrorNone.Name = "rdbMirrorNone";
            this.rdbMirrorNone.Size = new System.Drawing.Size(78, 20);
            this.rdbMirrorNone.TabIndex = 0;
            this.rdbMirrorNone.TabStop = true;
            this.rdbMirrorNone.Text = "Nenhum";
            this.rdbMirrorNone.UseVisualStyleBackColor = true;
            this.rdbMirrorNone.CheckedChanged += new System.EventHandler(this.rdbMirrorNone_CheckedChanged);
            // 
            // rdbMirrorHorizontal
            // 
            this.rdbMirrorHorizontal.AutoSize = true;
            this.rdbMirrorHorizontal.Location = new System.Drawing.Point(109, 22);
            this.rdbMirrorHorizontal.Name = "rdbMirrorHorizontal";
            this.rdbMirrorHorizontal.Size = new System.Drawing.Size(88, 20);
            this.rdbMirrorHorizontal.TabIndex = 0;
            this.rdbMirrorHorizontal.TabStop = true;
            this.rdbMirrorHorizontal.Text = "Horizontal";
            this.rdbMirrorHorizontal.UseVisualStyleBackColor = true;
            this.rdbMirrorHorizontal.CheckedChanged += new System.EventHandler(this.rdbMirrorHorizontal_CheckedChanged);
            // 
            // rdbMirrorVertical
            // 
            this.rdbMirrorVertical.AutoSize = true;
            this.rdbMirrorVertical.Location = new System.Drawing.Point(215, 22);
            this.rdbMirrorVertical.Name = "rdbMirrorVertical";
            this.rdbMirrorVertical.Size = new System.Drawing.Size(73, 20);
            this.rdbMirrorVertical.TabIndex = 0;
            this.rdbMirrorVertical.TabStop = true;
            this.rdbMirrorVertical.Text = "Vertical";
            this.rdbMirrorVertical.UseVisualStyleBackColor = true;
            this.rdbMirrorVertical.CheckedChanged += new System.EventHandler(this.rdbMirrorVertical_CheckedChanged);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 558);
            this.Controls.Add(this.grpMirror);
            this.Controls.Add(this.lblEffect);
            this.Controls.Add(this.cboEffect);
            this.Controls.Add(this.picImageOutput);
            this.Name = "Principal";
            this.Text = "Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picImageOutput)).EndInit();
            this.grpMirror.ResumeLayout(false);
            this.grpMirror.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImageOutput;
        private System.Windows.Forms.ComboBox cboEffect;
        private System.Windows.Forms.Label lblEffect;
        private System.Windows.Forms.GroupBox grpMirror;
        private System.Windows.Forms.RadioButton rdbMirrorVertical;
        private System.Windows.Forms.RadioButton rdbMirrorHorizontal;
        private System.Windows.Forms.RadioButton rdbMirrorNone;
    }
}

