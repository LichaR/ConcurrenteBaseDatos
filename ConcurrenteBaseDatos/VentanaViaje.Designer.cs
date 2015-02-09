namespace ConcurrenteBaseDatos
{
    partial class VentanaViaje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaViaje));
            this.grupoModificar = new System.Windows.Forms.GroupBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.diaBuscar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.destinoBuscar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.viajeViewAgregar = new ConcurrenteBaseDatos.ComponentesVisuales.ViajeView();
            this.grupoModificar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // grupoModificar
            // 
            this.grupoModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grupoModificar.Controls.Add(this.botonBuscar);
            this.grupoModificar.Controls.Add(this.diaBuscar);
            this.grupoModificar.Controls.Add(this.label5);
            this.grupoModificar.Controls.Add(this.destinoBuscar);
            this.grupoModificar.Controls.Add(this.label6);
            this.grupoModificar.Controls.Add(this.tabla);
            this.grupoModificar.Location = new System.Drawing.Point(12, 273);
            this.grupoModificar.Name = "grupoModificar";
            this.grupoModificar.Size = new System.Drawing.Size(880, 289);
            this.grupoModificar.TabIndex = 1;
            this.grupoModificar.TabStop = false;
            this.grupoModificar.Text = "Modificar viaje";
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(19, 123);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(75, 23);
            this.botonBuscar.TabIndex = 12;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // diaBuscar
            // 
            this.diaBuscar.FormattingEnabled = true;
            this.diaBuscar.Location = new System.Drawing.Point(7, 96);
            this.diaBuscar.Name = "diaBuscar";
            this.diaBuscar.Size = new System.Drawing.Size(100, 21);
            this.diaBuscar.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Dia que funciona:";
            // 
            // destinoBuscar
            // 
            this.destinoBuscar.Location = new System.Drawing.Point(7, 48);
            this.destinoBuscar.Name = "destinoBuscar";
            this.destinoBuscar.Size = new System.Drawing.Size(100, 20);
            this.destinoBuscar.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Destino:";
            // 
            // tabla
            // 
            this.tabla.AllowUserToAddRows = false;
            this.tabla.AllowUserToDeleteRows = false;
            this.tabla.AllowUserToOrderColumns = true;
            this.tabla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabla.BackgroundColor = System.Drawing.SystemColors.GrayText;
            this.tabla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabla.Location = new System.Drawing.Point(125, 19);
            this.tabla.MultiSelect = false;
            this.tabla.Name = "tabla";
            this.tabla.ReadOnly = true;
            this.tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla.Size = new System.Drawing.Size(356, 253);
            this.tabla.TabIndex = 0;
            this.tabla.SelectionChanged += new System.EventHandler(this.tabla_SelectionChanged);
            // 
            // viajeViewAgregar
            // 
            this.viajeViewAgregar.BackColor = System.Drawing.SystemColors.GrayText;
            this.viajeViewAgregar.BotonCaption = "Agregar";
            this.viajeViewAgregar.Caption = "Crear Viaje";
            this.viajeViewAgregar.Location = new System.Drawing.Point(232, 12);
            this.viajeViewAgregar.Name = "viajeViewAgregar";
            this.viajeViewAgregar.Size = new System.Drawing.Size(381, 255);
            this.viajeViewAgregar.TabIndex = 2;
            this.viajeViewAgregar.Viaje = null;
            this.viajeViewAgregar.BotonClick += new ConcurrenteBaseDatos.ComponentesVisuales.ViajeView.OnClickBoton(this.viajeViewAgregar_BotonClick);
            // 
            // VentanaViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(904, 574);
            this.Controls.Add(this.viajeViewAgregar);
            this.Controls.Add(this.grupoModificar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VentanaViaje";
            this.Text = "VentanaViaje";
            this.Load += new System.EventHandler(this.VentanaViaje_Load);
            this.grupoModificar.ResumeLayout(false);
            this.grupoModificar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grupoModificar;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.ComboBox diaBuscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox destinoBuscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button botonBuscar;
        private ComponentesVisuales.ViajeView viajeViewAgregar;
    }
}