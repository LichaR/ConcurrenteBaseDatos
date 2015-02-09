namespace ConcurrenteBaseDatos
{
    partial class FormularioDebug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioDebug));
            this.buttonVerTabla = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupVerTabla = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupVerTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonVerTabla
            // 
            this.buttonVerTabla.Location = new System.Drawing.Point(9, 57);
            this.buttonVerTabla.Name = "buttonVerTabla";
            this.buttonVerTabla.Size = new System.Drawing.Size(125, 24);
            this.buttonVerTabla.TabIndex = 3;
            this.buttonVerTabla.Text = "Ver tabla";
            this.buttonVerTabla.UseVisualStyleBackColor = true;
            this.buttonVerTabla.Click += new System.EventHandler(this.buttonVerTabla_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // groupVerTabla
            // 
            this.groupVerTabla.Controls.Add(this.label2);
            this.groupVerTabla.Controls.Add(this.label1);
            this.groupVerTabla.Controls.Add(this.dataGridView1);
            this.groupVerTabla.Controls.Add(this.comboBox1);
            this.groupVerTabla.Controls.Add(this.buttonVerTabla);
            this.groupVerTabla.Location = new System.Drawing.Point(12, 12);
            this.groupVerTabla.Name = "groupVerTabla";
            this.groupVerTabla.Size = new System.Drawing.Size(791, 347);
            this.groupVerTabla.TabIndex = 11;
            this.groupVerTabla.TabStop = false;
            this.groupVerTabla.Text = "Buscar";
            this.groupVerTabla.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(161, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(624, 321);
            this.dataGridView1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Esto nunca se usa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Se agrego para ver las tablas";
            // 
            // FormularioDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(866, 502);
            this.Controls.Add(this.groupVerTabla);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormularioDebug";
            this.Text = "Formulario Debug";
            this.groupVerTabla.ResumeLayout(false);
            this.groupVerTabla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonVerTabla;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupVerTabla;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}