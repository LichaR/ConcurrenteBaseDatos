namespace ConcurrenteBaseDatos
{
    partial class BuscarPersona
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
            this.label1 = new System.Windows.Forms.Label();
            this.dniText = new System.Windows.Forms.TextBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.botonAceptar = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.personaView1 = new ConcurrenteBaseDatos.ComponentesVisuales.PersonaView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dni";
            // 
            // dniText
            // 
            this.dniText.Location = new System.Drawing.Point(66, 31);
            this.dniText.MaxLength = 8;
            this.dniText.Name = "dniText";
            this.dniText.Size = new System.Drawing.Size(140, 20);
            this.dniText.TabIndex = 1;
            this.dniText.TextChanged += new System.EventHandler(this.dniText_TextChanged);
            this.dniText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dniText_KeyPress);
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(239, 23);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(88, 35);
            this.botonBuscar.TabIndex = 2;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // botonAceptar
            // 
            this.botonAceptar.AllowDrop = true;
            this.botonAceptar.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.botonAceptar.Enabled = false;
            this.botonAceptar.Location = new System.Drawing.Point(214, 241);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(88, 34);
            this.botonAceptar.TabIndex = 4;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            // 
            // botonCancelar
            // 
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.No;
            this.botonCancelar.Location = new System.Drawing.Point(62, 241);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(88, 34);
            this.botonCancelar.TabIndex = 5;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(156, 9);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(52, 18);
            this.labelError.TabIndex = 6;
            this.labelError.Text = "label2";
            // 
            // personaView1
            // 
            this.personaView1.BackColor = System.Drawing.SystemColors.GrayText;
            this.personaView1.BotonCaption = "Agregar";
            this.personaView1.Location = new System.Drawing.Point(25, 64);
            this.personaView1.MostrarBoton = false;
            this.personaView1.Name = "personaView1";
            this.personaView1.Persona = null;
            this.personaView1.Size = new System.Drawing.Size(336, 155);
            this.personaView1.SoloLectura = true;
            this.personaView1.TabIndex = 3;
            this.personaView1.Visible = false;
            // 
            // BuscarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(384, 287);
            this.ControlBox = false;
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.botonCancelar);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.personaView1);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.dniText);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "BuscarPersona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elegir persona";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dniText;
        private System.Windows.Forms.Button botonBuscar;
        private ComponentesVisuales.PersonaView personaView1;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Label labelError;
    }
}