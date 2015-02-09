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
    public partial class ControladorTransaccionesView : UserControl
    {
        private ControladorTransaccion controlador;

        public ControladorTransaccionesView(BaseDatos baseDatos)
        {
            InitializeComponent();
            this.controlador = baseDatos.ControladorDeTransacciones;
            labelTransaccionesAbortadas.Text = controlador.CantidadAbortadas.ToString();
            labelTransaccionesActivas.Text = controlador.CantidadActivas.ToString();
            labelTransaccionesCommiteadas.Text = controlador.CantidadCommiteadas.ToString();
        }
    }
}
