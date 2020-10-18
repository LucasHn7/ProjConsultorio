namespace ProjConsultorio
{
    partial class Sistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sistema));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.msSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.msCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.msPaciente = new System.Windows.Forms.ToolStripMenuItem();
            this.msMedico = new System.Windows.Forms.ToolStripMenuItem();
            this.msEspeciadade = new System.Windows.Forms.ToolStripMenuItem();
            this.msConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.msSair = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msSistema,
            this.msSair});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(630, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // msSistema
            // 
            this.msSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msCadastro});
            this.msSistema.Image = ((System.Drawing.Image)(resources.GetObject("msSistema.Image")));
            this.msSistema.Name = "msSistema";
            this.msSistema.Size = new System.Drawing.Size(76, 20);
            this.msSistema.Text = "Sistema";
            // 
            // msCadastro
            // 
            this.msCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msPaciente,
            this.msMedico,
            this.msEspeciadade,
            this.msConsulta});
            this.msCadastro.Image = ((System.Drawing.Image)(resources.GetObject("msCadastro.Image")));
            this.msCadastro.Name = "msCadastro";
            this.msCadastro.Size = new System.Drawing.Size(180, 22);
            this.msCadastro.Text = "Cadastros";
            // 
            // msPaciente
            // 
            this.msPaciente.Image = ((System.Drawing.Image)(resources.GetObject("msPaciente.Image")));
            this.msPaciente.Name = "msPaciente";
            this.msPaciente.Size = new System.Drawing.Size(180, 22);
            this.msPaciente.Text = "Paciente";
            this.msPaciente.Click += new System.EventHandler(this.msPaciente_Click);
            // 
            // msMedico
            // 
            this.msMedico.Image = ((System.Drawing.Image)(resources.GetObject("msMedico.Image")));
            this.msMedico.Name = "msMedico";
            this.msMedico.Size = new System.Drawing.Size(180, 22);
            this.msMedico.Text = "Medico";
            this.msMedico.Click += new System.EventHandler(this.msMedico_Click);
            // 
            // msEspeciadade
            // 
            this.msEspeciadade.Image = ((System.Drawing.Image)(resources.GetObject("msEspeciadade.Image")));
            this.msEspeciadade.Name = "msEspeciadade";
            this.msEspeciadade.Size = new System.Drawing.Size(180, 22);
            this.msEspeciadade.Text = "Especiadade";
            this.msEspeciadade.Click += new System.EventHandler(this.msEspeciadade_Click);
            // 
            // msConsulta
            // 
            this.msConsulta.Image = ((System.Drawing.Image)(resources.GetObject("msConsulta.Image")));
            this.msConsulta.Name = "msConsulta";
            this.msConsulta.Size = new System.Drawing.Size(180, 22);
            this.msConsulta.Text = "Consulta";
            this.msConsulta.Click += new System.EventHandler(this.msConsulta_Click);
            // 
            // msSair
            // 
            this.msSair.Image = ((System.Drawing.Image)(resources.GetObject("msSair.Image")));
            this.msSair.Name = "msSair";
            this.msSair.Size = new System.Drawing.Size(54, 20);
            this.msSair.Text = "Sair";
            this.msSair.Click += new System.EventHandler(this.msSair_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(627, 394);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Sistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 419);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(646, 458);
            this.MinimumSize = new System.Drawing.Size(646, 458);
            this.Name = "Sistema";
            this.Text = "Consultório";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem msSistema;
        private System.Windows.Forms.ToolStripMenuItem msCadastro;
        private System.Windows.Forms.ToolStripMenuItem msPaciente;
        private System.Windows.Forms.ToolStripMenuItem msMedico;
        private System.Windows.Forms.ToolStripMenuItem msEspeciadade;
        private System.Windows.Forms.ToolStripMenuItem msConsulta;
        private System.Windows.Forms.ToolStripMenuItem msSair;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

