namespace ConcurrenteBaseDatos.ComponentesVisuales
{
    partial class ReservaView
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.fechaPicker = new System.Windows.Forms.DateTimePicker();
            this.destinoText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.labelViaje = new System.Windows.Forms.Label();
            this.groupPasaje = new System.Windows.Forms.GroupBox();
            this.panelPersonaExiste = new System.Windows.Forms.Panel();
            this.botonComprobarPersona = new System.Windows.Forms.Button();
            this.dniText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.asiento = new System.Windows.Forms.NumericUpDown();
            this.labelResultadoReserva = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupPasaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.asiento)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.botonBuscar);
            this.groupBox1.Controls.Add(this.fechaPicker);
            this.groupBox1.Controls.Add(this.destinoText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar viaje";
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(91, 64);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(75, 23);
            this.botonBuscar.TabIndex = 6;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // fechaPicker
            // 
            this.fechaPicker.Location = new System.Drawing.Point(32, 36);
            this.fechaPicker.Name = "fechaPicker";
            this.fechaPicker.Size = new System.Drawing.Size(220, 20);
            this.fechaPicker.TabIndex = 5;
            this.fechaPicker.ValueChanged += new System.EventHandler(this.fechaPicker_ValueChanged);
            // 
            // destinoText
            // 
            this.destinoText.Location = new System.Drawing.Point(81, 10);
            this.destinoText.Name = "destinoText";
            this.destinoText.Size = new System.Drawing.Size(111, 20);
            this.destinoText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Destino:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(269, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(119, 95);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // labelViaje
            // 
            this.labelViaje.AutoSize = true;
            this.labelViaje.Location = new System.Drawing.Point(6, 21);
            this.labelViaje.Name = "labelViaje";
            this.labelViaje.Size = new System.Drawing.Size(100, 13);
            this.labelViaje.TabIndex = 2;
            this.labelViaje.Text = "Asientos maximo 10";
            this.labelViaje.TextChanged += new System.EventHandler(this.labelViaje_TextChanged);
            // 
            // groupPasaje
            // 
            this.groupPasaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPasaje.Controls.Add(this.panelPersonaExiste);
            this.groupPasaje.Controls.Add(this.botonComprobarPersona);
            this.groupPasaje.Controls.Add(this.dniText);
            this.groupPasaje.Controls.Add(this.label2);
            this.groupPasaje.Controls.Add(this.asiento);
            this.groupPasaje.Controls.Add(this.labelViaje);
            this.groupPasaje.Location = new System.Drawing.Point(397, 3);
            this.groupPasaje.Name = "groupPasaje";
            this.groupPasaje.Size = new System.Drawing.Size(282, 95);
            this.groupPasaje.TabIndex = 3;
            this.groupPasaje.TabStop = false;
            this.groupPasaje.Text = "Pasaje";
            // 
            // panelPersonaExiste
            // 
            this.panelPersonaExiste.BackColor = System.Drawing.Color.Red;
            this.panelPersonaExiste.Location = new System.Drawing.Point(239, 39);
            this.panelPersonaExiste.Name = "panelPersonaExiste";
            this.panelPersonaExiste.Size = new System.Drawing.Size(27, 26);
            this.panelPersonaExiste.TabIndex = 7;
            // 
            // botonComprobarPersona
            // 
            this.botonComprobarPersona.Location = new System.Drawing.Point(191, 45);
            this.botonComprobarPersona.Name = "botonComprobarPersona";
            this.botonComprobarPersona.Size = new System.Drawing.Size(42, 20);
            this.botonComprobarPersona.TabIndex = 6;
            this.botonComprobarPersona.Text = "->";
            this.botonComprobarPersona.UseVisualStyleBackColor = true;
            this.botonComprobarPersona.Click += new System.EventHandler(this.botonComprobarPersona_Click);
            // 
            // dniText
            // 
            this.dniText.Location = new System.Drawing.Point(85, 46);
            this.dniText.MaxLength = 8;
            this.dniText.Name = "dniText";
            this.dniText.Size = new System.Drawing.Size(100, 20);
            this.dniText.TabIndex = 5;
            this.dniText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.dniText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dni Persona:";
            // 
            // asiento
            // 
            this.asiento.Location = new System.Drawing.Point(112, 19);
            this.asiento.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.asiento.Name = "asiento";
            this.asiento.Size = new System.Drawing.Size(52, 20);
            this.asiento.TabIndex = 3;
            this.asiento.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelResultadoReserva
            // 
            this.labelResultadoReserva.AutoSize = true;
            this.labelResultadoReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultadoReserva.ForeColor = System.Drawing.Color.Red;
            this.labelResultadoReserva.Location = new System.Drawing.Point(188, 101);
            this.labelResultadoReserva.Name = "labelResultadoReserva";
            this.labelResultadoReserva.Size = new System.Drawing.Size(46, 18);
            this.labelResultadoReserva.TabIndex = 4;
            this.labelResultadoReserva.Text = "label3";
            this.labelResultadoReserva.Visible = false;
            // 
            // ReservaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.labelResultadoReserva);
            this.Controls.Add(this.groupPasaje);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReservaView";
            this.Size = new System.Drawing.Size(682, 120);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupPasaje.ResumeLayout(false);
            this.groupPasaje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.asiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox destinoText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.DateTimePicker fechaPicker;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label labelViaje;
        private System.Windows.Forms.GroupBox groupPasaje;
        private System.Windows.Forms.NumericUpDown asiento;
        private System.Windows.Forms.TextBox dniText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button botonComprobarPersona;
        private System.Windows.Forms.Panel panelPersonaExiste;
        private System.Windows.Forms.Label labelResultadoReserva;
    }
}
