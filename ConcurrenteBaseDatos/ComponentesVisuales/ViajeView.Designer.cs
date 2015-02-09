namespace ConcurrenteBaseDatos.ComponentesVisuales
{
    partial class ViajeView
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
            this.precioText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.eliminadoCheck = new System.Windows.Forms.CheckBox();
            this.cantidadAsientos = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.diaSemana = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.botonModificar = new System.Windows.Forms.Button();
            this.horaPartida = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.destinoText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadAsientos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.precioText);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.errorLabel);
            this.groupBox1.Controls.Add(this.eliminadoCheck);
            this.groupBox1.Controls.Add(this.cantidadAsientos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.diaSemana);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.botonModificar);
            this.groupBox1.Controls.Add(this.horaPartida);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.destinoText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 249);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar Viaje";
            // 
            // precioText
            // 
            this.precioText.Location = new System.Drawing.Point(132, 168);
            this.precioText.Name = "precioText";
            this.precioText.Size = new System.Drawing.Size(100, 20);
            this.precioText.TabIndex = 23;
            this.precioText.TextChanged += new System.EventHandler(this.precioText_TextChanged);
            this.precioText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.precioText_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Precio:";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(39, 25);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(52, 18);
            this.errorLabel.TabIndex = 21;
            this.errorLabel.Text = "label5";
            this.errorLabel.Visible = false;
            // 
            // eliminadoCheck
            // 
            this.eliminadoCheck.AutoSize = true;
            this.eliminadoCheck.Location = new System.Drawing.Point(132, 216);
            this.eliminadoCheck.Name = "eliminadoCheck";
            this.eliminadoCheck.Size = new System.Drawing.Size(71, 17);
            this.eliminadoCheck.TabIndex = 20;
            this.eliminadoCheck.Text = "Eliminado";
            this.eliminadoCheck.UseVisualStyleBackColor = true;
            // 
            // cantidadAsientos
            // 
            this.cantidadAsientos.Location = new System.Drawing.Point(132, 108);
            this.cantidadAsientos.Name = "cantidadAsientos";
            this.cantidadAsientos.Size = new System.Drawing.Size(100, 20);
            this.cantidadAsientos.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Cantidad de asientos:";
            // 
            // diaSemana
            // 
            this.diaSemana.FormattingEnabled = true;
            this.diaSemana.Location = new System.Drawing.Point(132, 81);
            this.diaSemana.Name = "diaSemana";
            this.diaSemana.Size = new System.Drawing.Size(100, 21);
            this.diaSemana.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Hora de partida:";
            // 
            // botonModificar
            // 
            this.botonModificar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.botonModificar.Location = new System.Drawing.Point(282, 72);
            this.botonModificar.Name = "botonModificar";
            this.botonModificar.Size = new System.Drawing.Size(76, 106);
            this.botonModificar.TabIndex = 11;
            this.botonModificar.Text = "Modificar";
            this.botonModificar.UseVisualStyleBackColor = true;
            this.botonModificar.Click += new System.EventHandler(this.botonModificar_Click);
            // 
            // horaPartida
            // 
            this.horaPartida.CustomFormat = "HH:mm";
            this.horaPartida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.horaPartida.Location = new System.Drawing.Point(132, 137);
            this.horaPartida.Name = "horaPartida";
            this.horaPartida.ShowUpDown = true;
            this.horaPartida.Size = new System.Drawing.Size(100, 20);
            this.horaPartida.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Dia que funciona:";
            // 
            // destinoText
            // 
            this.destinoText.Location = new System.Drawing.Point(132, 55);
            this.destinoText.Name = "destinoText";
            this.destinoText.Size = new System.Drawing.Size(100, 20);
            this.destinoText.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Destino:";
            // 
            // ViajeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.Controls.Add(this.groupBox1);
            this.Name = "ViajeView";
            this.Size = new System.Drawing.Size(381, 255);
            this.Load += new System.EventHandler(this.ViajeView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadAsientos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown cantidadAsientos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox diaSemana;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button botonModificar;
        private System.Windows.Forms.DateTimePicker horaPartida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox destinoText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox eliminadoCheck;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox precioText;
    }
}
