using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConcurrenteBaseDatos.BaseDeDatos.ComponentesVisuales
{
    public partial class RegistroView : UserControl
    {
        private Registros.Registro registro;

        public RegistroView(Registros.Registro registro)
        {
            InitializeComponent();
            this.registro = registro;
            listBox1.DataSource = registro.EntradasRegistro;
        }



    }
}
