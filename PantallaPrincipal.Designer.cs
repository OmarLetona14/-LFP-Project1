namespace Project1
{
    partial class PantallaPrincipal
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarCómoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualDeLaAplicaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.btnGenerarPDF = new System.Windows.Forms.Button();
            this.detailsContainer = new System.Windows.Forms.SplitContainer();
            this.poblacionPaisLbl = new System.Windows.Forms.Label();
            this.nombrePaisLbl = new System.Windows.Forms.Label();
            this.banderaPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailsContainer)).BeginInit();
            this.detailsContainer.Panel2.SuspendLayout();
            this.detailsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Location = new System.Drawing.Point(13, 31);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(620, 631);
            this.tabControl.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.acerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1464, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPestañaToolStripMenuItem,
            this.abrirArchivoToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarCómoToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevaPestañaToolStripMenuItem
            // 
            this.nuevaPestañaToolStripMenuItem.Name = "nuevaPestañaToolStripMenuItem";
            this.nuevaPestañaToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.nuevaPestañaToolStripMenuItem.Text = "Nueva Pestaña";
            this.nuevaPestañaToolStripMenuItem.Click += new System.EventHandler(this.NuevaPestañaToolStripMenuItem_Click);
            // 
            // abrirArchivoToolStripMenuItem
            // 
            this.abrirArchivoToolStripMenuItem.Name = "abrirArchivoToolStripMenuItem";
            this.abrirArchivoToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.abrirArchivoToolStripMenuItem.Text = "Abrir Archivo";
            this.abrirArchivoToolStripMenuItem.Click += new System.EventHandler(this.AbrirArchivoToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.GuardarToolStripMenuItem_Click);
            // 
            // guardarCómoToolStripMenuItem
            // 
            this.guardarCómoToolStripMenuItem.Name = "guardarCómoToolStripMenuItem";
            this.guardarCómoToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.guardarCómoToolStripMenuItem.Text = "Guardar Cómo";
            this.guardarCómoToolStripMenuItem.Click += new System.EventHandler(this.GuardarCómoToolStripMenuItem_Click);
            // 
            // acerToolStripMenuItem
            // 
            this.acerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem,
            this.manualDeLaAplicaciónToolStripMenuItem});
            this.acerToolStripMenuItem.Name = "acerToolStripMenuItem";
            this.acerToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.acerToolStripMenuItem.Text = "Ayuda";
            this.acerToolStripMenuItem.Click += new System.EventHandler(this.AcerToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.acercaDeToolStripMenuItem.Text = "Acerca De";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.AcercaDeToolStripMenuItem_Click);
            // 
            // manualDeLaAplicaciónToolStripMenuItem
            // 
            this.manualDeLaAplicaciónToolStripMenuItem.Name = "manualDeLaAplicaciónToolStripMenuItem";
            this.manualDeLaAplicaciónToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.manualDeLaAplicaciónToolStripMenuItem.Text = "Manual de la aplicación";
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Enabled = false;
            this.btnAnalizar.Location = new System.Drawing.Point(668, 32);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(124, 58);
            this.btnAnalizar.TabIndex = 2;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.BtnAnalizar_Click);
            // 
            // btnGenerarPDF
            // 
            this.btnGenerarPDF.Enabled = false;
            this.btnGenerarPDF.Location = new System.Drawing.Point(668, 110);
            this.btnGenerarPDF.Name = "btnGenerarPDF";
            this.btnGenerarPDF.Size = new System.Drawing.Size(124, 57);
            this.btnGenerarPDF.TabIndex = 3;
            this.btnGenerarPDF.Text = "Generar PDF";
            this.btnGenerarPDF.UseVisualStyleBackColor = true;
            this.btnGenerarPDF.Click += new System.EventHandler(this.BtnGenerarPDF_Click);
            // 
            // detailsContainer
            // 
            this.detailsContainer.Location = new System.Drawing.Point(823, 32);
            this.detailsContainer.Name = "detailsContainer";
            this.detailsContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // detailsContainer.Panel2
            // 
            this.detailsContainer.Panel2.Controls.Add(this.poblacionPaisLbl);
            this.detailsContainer.Panel2.Controls.Add(this.nombrePaisLbl);
            this.detailsContainer.Panel2.Controls.Add(this.banderaPanel);
            this.detailsContainer.Size = new System.Drawing.Size(613, 630);
            this.detailsContainer.SplitterDistance = 427;
            this.detailsContainer.TabIndex = 4;
            // 
            // poblacionPaisLbl
            // 
            this.poblacionPaisLbl.AutoSize = true;
            this.poblacionPaisLbl.Location = new System.Drawing.Point(14, 112);
            this.poblacionPaisLbl.Name = "poblacionPaisLbl";
            this.poblacionPaisLbl.Size = new System.Drawing.Size(0, 17);
            this.poblacionPaisLbl.TabIndex = 2;
            // 
            // nombrePaisLbl
            // 
            this.nombrePaisLbl.AutoSize = true;
            this.nombrePaisLbl.Location = new System.Drawing.Point(14, 17);
            this.nombrePaisLbl.Name = "nombrePaisLbl";
            this.nombrePaisLbl.Size = new System.Drawing.Size(0, 17);
            this.nombrePaisLbl.TabIndex = 1;
            // 
            // banderaPanel
            // 
            this.banderaPanel.Location = new System.Drawing.Point(276, 17);
            this.banderaPanel.Name = "banderaPanel";
            this.banderaPanel.Size = new System.Drawing.Size(315, 165);
            this.banderaPanel.TabIndex = 0;
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 693);
            this.Controls.Add(this.detailsContainer);
            this.Controls.Add(this.btnGenerarPDF);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "PantallaPrincipal";
            this.Text = "MainWindow";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.detailsContainer.Panel2.ResumeLayout(false);
            this.detailsContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailsContainer)).EndInit();
            this.detailsContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaPestañaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarCómoToolStripMenuItem;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Button btnGenerarPDF;
        private System.Windows.Forms.SplitContainer detailsContainer;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualDeLaAplicaciónToolStripMenuItem;
        private System.Windows.Forms.Panel banderaPanel;
        private System.Windows.Forms.Label poblacionPaisLbl;
        private System.Windows.Forms.Label nombrePaisLbl;
    }
}

