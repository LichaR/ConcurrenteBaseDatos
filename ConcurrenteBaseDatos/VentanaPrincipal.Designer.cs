namespace ConcurrenteBaseDatos
{
    partial class VentanaPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPrincipal));
            this.botonDebug = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelNoHayResultados = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fechaPicker = new System.Windows.Forms.DateTimePicker();
            this.destinoText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.botonBuscarViaje = new System.Windows.Forms.Button();
            this.tablaViaje = new System.Windows.Forms.DataGridView();
            this.botonAbrirViaje = new System.Windows.Forms.Button();
            this.buttonPersona = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaInstanciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ventanaPruebaConcurenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colectivo = new ConcurrenteBaseDatos.ComponentesVisuales.ColectivoControls();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaViaje)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonDebug
            // 
            this.botonDebug.Location = new System.Drawing.Point(12, 42);
            this.botonDebug.Name = "botonDebug";
            this.botonDebug.Size = new System.Drawing.Size(86, 29);
            this.botonDebug.TabIndex = 0;
            this.botonDebug.Text = "Debug";
            this.botonDebug.UseVisualStyleBackColor = true;
            this.botonDebug.Visible = false;
            this.botonDebug.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.labelNoHayResultados);
            this.groupBox1.Controls.Add(this.errorLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.fechaPicker);
            this.groupBox1.Controls.Add(this.destinoText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.botonBuscarViaje);
            this.groupBox1.Controls.Add(this.tablaViaje);
            this.groupBox1.Location = new System.Drawing.Point(12, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 401);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vender pasaje";
            // 
            // labelNoHayResultados
            // 
            this.labelNoHayResultados.AutoSize = true;
            this.labelNoHayResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoHayResultados.ForeColor = System.Drawing.Color.Red;
            this.labelNoHayResultados.Location = new System.Drawing.Point(164, 262);
            this.labelNoHayResultados.Name = "labelNoHayResultados";
            this.labelNoHayResultados.Size = new System.Drawing.Size(203, 25);
            this.labelNoHayResultados.TabIndex = 7;
            this.labelNoHayResultados.Text = "No hay resultados";
            this.labelNoHayResultados.Visible = false;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(206, 80);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(199, 18);
            this.errorLabel.TabIndex = 6;
            this.errorLabel.Text = "Error: se ve si hubo error";
            this.errorLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha del viaje";
            // 
            // fechaPicker
            // 
            this.fechaPicker.Location = new System.Drawing.Point(312, 49);
            this.fechaPicker.Name = "fechaPicker";
            this.fechaPicker.Size = new System.Drawing.Size(220, 20);
            this.fechaPicker.TabIndex = 4;
            // 
            // destinoText
            // 
            this.destinoText.Location = new System.Drawing.Point(42, 49);
            this.destinoText.Name = "destinoText";
            this.destinoText.Size = new System.Drawing.Size(213, 20);
            this.destinoText.TabIndex = 3;
            this.destinoText.TextChanged += new System.EventHandler(this.destinoText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Destino";
            // 
            // botonBuscarViaje
            // 
            this.botonBuscarViaje.Enabled = false;
            this.botonBuscarViaje.Location = new System.Drawing.Point(260, 101);
            this.botonBuscarViaje.Name = "botonBuscarViaje";
            this.botonBuscarViaje.Size = new System.Drawing.Size(93, 29);
            this.botonBuscarViaje.TabIndex = 1;
            this.botonBuscarViaje.Text = "Buscar Viaje";
            this.botonBuscarViaje.UseVisualStyleBackColor = true;
            this.botonBuscarViaje.Click += new System.EventHandler(this.botonBuscarViaje_Click);
            // 
            // tablaViaje
            // 
            this.tablaViaje.AllowUserToAddRows = false;
            this.tablaViaje.AllowUserToDeleteRows = false;
            this.tablaViaje.AllowUserToOrderColumns = true;
            this.tablaViaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaViaje.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaViaje.BackgroundColor = System.Drawing.SystemColors.GrayText;
            this.tablaViaje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tablaViaje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaViaje.Location = new System.Drawing.Point(27, 136);
            this.tablaViaje.Name = "tablaViaje";
            this.tablaViaje.ReadOnly = true;
            this.tablaViaje.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaViaje.Size = new System.Drawing.Size(504, 249);
            this.tablaViaje.TabIndex = 0;
            this.tablaViaje.DataSourceChanged += new System.EventHandler(this.tablaViaje_DataSourceChanged);
            this.tablaViaje.SelectionChanged += new System.EventHandler(this.tablaViaje_SelectionChanged);
            // 
            // botonAbrirViaje
            // 
            this.botonAbrirViaje.Location = new System.Drawing.Point(104, 42);
            this.botonAbrirViaje.Name = "botonAbrirViaje";
            this.botonAbrirViaje.Size = new System.Drawing.Size(100, 29);
            this.botonAbrirViaje.TabIndex = 2;
            this.botonAbrirViaje.Text = "Viaje";
            this.botonAbrirViaje.UseVisualStyleBackColor = true;
            this.botonAbrirViaje.Click += new System.EventHandler(this.botonAbrirViaje_Click);
            // 
            // buttonPersona
            // 
            this.buttonPersona.Location = new System.Drawing.Point(272, 42);
            this.buttonPersona.Name = "buttonPersona";
            this.buttonPersona.Size = new System.Drawing.Size(100, 29);
            this.buttonPersona.TabIndex = 3;
            this.buttonPersona.Text = "Persona";
            this.buttonPersona.UseVisualStyleBackColor = true;
            this.buttonPersona.Click += new System.EventHandler(this.buttonPersona_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accionesToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(839, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accionesToolStripMenuItem
            // 
            this.accionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaInstanciaToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ventanaPruebaConcurenciaToolStripMenuItem});
            this.accionesToolStripMenuItem.Name = "accionesToolStripMenuItem";
            this.accionesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.accionesToolStripMenuItem.Text = "Acciones";
            // 
            // nuevaInstanciaToolStripMenuItem
            // 
            this.nuevaInstanciaToolStripMenuItem.Enabled = false;
            this.nuevaInstanciaToolStripMenuItem.Name = "nuevaInstanciaToolStripMenuItem";
            this.nuevaInstanciaToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.nuevaInstanciaToolStripMenuItem.Text = "Nueva instancia";
            this.nuevaInstanciaToolStripMenuItem.Click += new System.EventHandler(this.nuevaInstanciaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(222, 6);
            // 
            // ventanaPruebaConcurenciaToolStripMenuItem
            // 
            this.ventanaPruebaConcurenciaToolStripMenuItem.Enabled = false;
            this.ventanaPruebaConcurenciaToolStripMenuItem.Name = "ventanaPruebaConcurenciaToolStripMenuItem";
            this.ventanaPruebaConcurenciaToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.ventanaPruebaConcurenciaToolStripMenuItem.Text = "Ventana prueba concurencia";
            this.ventanaPruebaConcurenciaToolStripMenuItem.Click += new System.EventHandler(this.ventanaPruebaConcurenciaToolStripMenuItem_Click);
            // 
            // colectivo
            // 
            this.colectivo.BackColor = System.Drawing.Color.Silver;
            this.colectivo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colectivo.Dock = System.Windows.Forms.DockStyle.Right;
            this.colectivo.Location = new System.Drawing.Point(621, 24);
            this.colectivo.Name = "colectivo";
            this.colectivo.Size = new System.Drawing.Size(218, 478);
            this.colectivo.TabIndex = 4;
            this.colectivo.Visible = false;
            this.colectivo.OnClickAsiento += new ConcurrenteBaseDatos.ComponentesVisuales.ColectivoControls.HandlerClickAsiento(this.colectivo_OnClickAsiento);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(839, 502);
            this.Controls.Add(this.colectivo);
            this.Controls.Add(this.buttonPersona);
            this.Controls.Add(this.botonAbrirViaje);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.botonDebug);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VentanaPrincipal";
            this.Text = "Venta de pasajes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VentanaPrincipal_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaViaje)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonDebug;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button botonBuscarViaje;
        private System.Windows.Forms.DataGridView tablaViaje;
        private System.Windows.Forms.Button botonAbrirViaje;
        private System.Windows.Forms.Button buttonPersona;
        private System.Windows.Forms.TextBox destinoText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fechaPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label errorLabel;
        private ComponentesVisuales.ColectivoControls colectivo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaInstanciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ventanaPruebaConcurenciaToolStripMenuItem;
        private System.Windows.Forms.Label labelNoHayResultados;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
    }
}

