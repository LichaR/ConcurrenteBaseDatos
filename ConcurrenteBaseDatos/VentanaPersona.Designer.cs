namespace ConcurrenteBaseDatos
{
    partial class VentanaPersona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPersona));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelError = new System.Windows.Forms.Label();
            this.personaViewModificar = new ConcurrenteBaseDatos.ComponentesVisuales.PersonaView();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.dniText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.personaViewAgregar = new ConcurrenteBaseDatos.ComponentesVisuales.PersonaView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelError);
            this.groupBox1.Controls.Add(this.personaViewModificar);
            this.groupBox1.Controls.Add(this.botonBuscar);
            this.groupBox1.Controls.Add(this.dniText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 254);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(93, 88);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(115, 18);
            this.labelError.TabIndex = 3;
            this.labelError.Text = "Error si lo hay";
            this.labelError.Visible = false;
            // 
            // personaViewModificar
            // 
            this.personaViewModificar.BackColor = System.Drawing.SystemColors.GrayText;
            this.personaViewModificar.BotonCaption = "Modificar";
            this.personaViewModificar.Caption = "Modificar persona";
            this.personaViewModificar.Location = new System.Drawing.Point(322, 31);
            this.personaViewModificar.Name = "personaViewModificar";
            this.personaViewModificar.Persona = null;
            this.personaViewModificar.Size = new System.Drawing.Size(377, 171);
            this.personaViewModificar.TabIndex = 2;
            this.personaViewModificar.Visible = false;
            this.personaViewModificar.OnClickBoton += new ConcurrenteBaseDatos.ComponentesVisuales.PersonaView.OnClickBotonDelegate(this.personaViewModificar_OnClickBoton);
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(214, 107);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(102, 23);
            this.botonBuscar.TabIndex = 2;
            this.botonBuscar.Text = "Buscar -->";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // dniText
            // 
            this.dniText.Location = new System.Drawing.Point(88, 109);
            this.dniText.MaxLength = 8;
            this.dniText.Name = "dniText";
            this.dniText.Size = new System.Drawing.Size(120, 20);
            this.dniText.TabIndex = 1;
            this.dniText.TextChanged += new System.EventHandler(this.dniText_TextChanged);
            this.dniText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dniText_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el dni";
            // 
            // personaViewAgregar
            // 
            this.personaViewAgregar.BackColor = System.Drawing.SystemColors.GrayText;
            this.personaViewAgregar.BotonCaption = "Agregar";
            this.personaViewAgregar.Caption = "Alta de persona";
            this.personaViewAgregar.Location = new System.Drawing.Point(180, 12);
            this.personaViewAgregar.Name = "personaViewAgregar";
            this.personaViewAgregar.Persona = null;
            this.personaViewAgregar.Size = new System.Drawing.Size(401, 171);
            this.personaViewAgregar.TabIndex = 0;
            this.personaViewAgregar.OnClickBoton += new ConcurrenteBaseDatos.ComponentesVisuales.PersonaView.OnClickBotonDelegate(this.personaView1_OnClickBoton);
            // 
            // VentanaPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(750, 519);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.personaViewAgregar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VentanaPersona";
            this.Text = "Ventana Persona";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentesVisuales.PersonaView personaViewAgregar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dniText;
        private System.Windows.Forms.Button botonBuscar;
        private ComponentesVisuales.PersonaView personaViewModificar;
        private System.Windows.Forms.Label labelError;





    }
}