using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConcurrenteBaseDatos
{
    public partial class AcercaDeForm : Form
    {
        public AcercaDeForm()
        {
            InitializeComponent();
            labelVersion.Text = "Version: "+
                System.Diagnostics.FileVersionInfo.GetVersionInfo(
                System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            Close();
            
        }
    }
}
