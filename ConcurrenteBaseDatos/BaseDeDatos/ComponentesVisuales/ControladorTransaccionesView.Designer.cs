namespace ConcurrenteBaseDatos.BaseDeDatos.ComponentesVisuales
{
    partial class ControladorTransaccionesView
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTransaccionesAbortadas = new System.Windows.Forms.Label();
            this.labelTransaccionesActivas = new System.Windows.Forms.Label();
            this.labelTransaccionesCommiteadas = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelTransaccionesAbortadas);
            this.groupBox2.Controls.Add(this.labelTransaccionesActivas);
            this.groupBox2.Controls.Add(this.labelTransaccionesCommiteadas);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 115);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transacciones";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(277, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Transacciones abortadas (Pudieron reiniciarse más tarde)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Transacciones commiteadas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Transacciones activas";
            // 
            // labelTransaccionesAbortadas
            // 
            this.labelTransaccionesAbortadas.AutoSize = true;
            this.labelTransaccionesAbortadas.BackColor = System.Drawing.Color.Red;
            this.labelTransaccionesAbortadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransaccionesAbortadas.Location = new System.Drawing.Point(289, 85);
            this.labelTransaccionesAbortadas.Name = "labelTransaccionesAbortadas";
            this.labelTransaccionesAbortadas.Size = new System.Drawing.Size(16, 18);
            this.labelTransaccionesAbortadas.TabIndex = 2;
            this.labelTransaccionesAbortadas.Text = "0";
            // 
            // labelTransaccionesActivas
            // 
            this.labelTransaccionesActivas.AutoSize = true;
            this.labelTransaccionesActivas.BackColor = System.Drawing.Color.Yellow;
            this.labelTransaccionesActivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransaccionesActivas.Location = new System.Drawing.Point(289, 58);
            this.labelTransaccionesActivas.Name = "labelTransaccionesActivas";
            this.labelTransaccionesActivas.Size = new System.Drawing.Size(16, 18);
            this.labelTransaccionesActivas.TabIndex = 1;
            this.labelTransaccionesActivas.Text = "0";
            // 
            // labelTransaccionesCommiteadas
            // 
            this.labelTransaccionesCommiteadas.AutoSize = true;
            this.labelTransaccionesCommiteadas.BackColor = System.Drawing.Color.Lime;
            this.labelTransaccionesCommiteadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransaccionesCommiteadas.Location = new System.Drawing.Point(289, 25);
            this.labelTransaccionesCommiteadas.Name = "labelTransaccionesCommiteadas";
            this.labelTransaccionesCommiteadas.Size = new System.Drawing.Size(16, 18);
            this.labelTransaccionesCommiteadas.TabIndex = 0;
            this.labelTransaccionesCommiteadas.Text = "0";
            // 
            // ControladorTransaccionesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.Controls.Add(this.groupBox2);
            this.Name = "ControladorTransaccionesView";
            this.Size = new System.Drawing.Size(372, 127);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTransaccionesAbortadas;
        private System.Windows.Forms.Label labelTransaccionesActivas;
        private System.Windows.Forms.Label labelTransaccionesCommiteadas;
    }
}
