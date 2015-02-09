namespace ConcurrenteBaseDatos.ComponentesVisuales
{
    partial class PersonaView
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
            this.errorLabel = new System.Windows.Forms.Label();
            this.apellidoText = new System.Windows.Forms.TextBox();
            this.nombreText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dniText = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dniText);
            this.groupBox1.Controls.Add(this.errorLabel);
            this.groupBox1.Controls.Add(this.apellidoText);
            this.groupBox1.Controls.Add(this.nombreText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 208);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Persona";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(64, 16);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(232, 18);
            this.errorLabel.TabIndex = 7;
            this.errorLabel.Text = "Error, se muestra si hay error";
            this.errorLabel.Visible = false;
            // 
            // apellidoText
            // 
            this.apellidoText.Location = new System.Drawing.Point(84, 75);
            this.apellidoText.Name = "apellidoText";
            this.apellidoText.Size = new System.Drawing.Size(139, 20);
            this.apellidoText.TabIndex = 5;
            this.apellidoText.TextChanged += new System.EventHandler(this.apellidoText_TextChanged);
            // 
            // nombreText
            // 
            this.nombreText.Location = new System.Drawing.Point(84, 39);
            this.nombreText.Name = "nombreText";
            this.nombreText.Size = new System.Drawing.Size(139, 20);
            this.nombreText.TabIndex = 4;
            this.nombreText.TextChanged += new System.EventHandler(this.nombreText_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "DNI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(332, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 189);
            this.button1.TabIndex = 0;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dniText
            // 
            this.dniText.Location = new System.Drawing.Point(84, 108);
            this.dniText.MaxLength = 8;
            this.dniText.Name = "dniText";
            this.dniText.Size = new System.Drawing.Size(139, 20);
            this.dniText.TabIndex = 8;
            this.dniText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dniText_KeyPress);
            // 
            // PersonaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.Controls.Add(this.groupBox1);
            this.Name = "PersonaView";
            this.Size = new System.Drawing.Size(401, 214);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox apellidoText;
        private System.Windows.Forms.TextBox nombreText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.TextBox dniText;
    }
}
