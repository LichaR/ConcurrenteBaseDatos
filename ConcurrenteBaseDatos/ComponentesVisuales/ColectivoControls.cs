using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.Servicios;

namespace ConcurrenteBaseDatos.ComponentesVisuales
{
    public partial class ColectivoControls : UserControl
    {
        public const int COLUMNAS = 4;

        private List<Pasaje> pasajesReservados = new List<Pasaje>();
        private Viaje viaje;

        /// <summary>
        /// Evento que marca el click sobre un asiento
        /// </summary>
        public event HandlerClickAsiento OnClickAsiento;

        public ColectivoControls()
            :this(null, new List<Pasaje>())
        {

        }

        public ColectivoControls(Viaje viaje, List<Pasaje> pasajesReservados)
        {
            InitializeComponent();
            setearAsientosYreservados(viaje, pasajesReservados);
            
        }

        private void construirColectivo()
        {
            tableLayout.Controls.Clear();
            //agrego labels de asientos
            for(int indice=0; indice<CantidadAsientos; indice++)
            {
                Label label = new Label();
                label.Text = (indice + 1).ToString();

                label.Click += new EventHandler(asientosClick);
                label.MouseEnter += new EventHandler(label_MouseEnter);
                label.MouseLeave += new EventHandler(label_MouseLeave);

                label.Cursor = Cursors.Hand;
                label.Tag = indice + 1;
                label.BackColor = Color.Green;
                label.TextAlign = ContentAlignment.MiddleCenter;
                tableLayout.Controls.Add(label, indice % COLUMNAS, indice / COLUMNAS);
                label.Margin = new Padding(0, 3, 13, 3);
                if (tableLayout.GetColumn(label) >= 2)//columna del otro lado del pasillo
                {
                    label.Margin = new Padding(13, 3, 0, 3);
                }
            }
            //acomoda los que ya están vendidos
            foreach (Pasaje pasaje in pasajesReservados)
            {
                int indice = pasaje.NumeroAsiento - 1;
                Label label = (Label)tableLayout.GetControlFromPosition(indice % COLUMNAS, indice / COLUMNAS);
                label.BackColor = Color.Red;
            }
        }

        void label_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Margin = new Padding(0, 3, 13, 3);
            if (tableLayout.GetColumn(label) >= 2)//columna del otro lado del pasillo
            {
                label.Margin = new Padding(13, 3, 0, 3);
            }
        }

        void label_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Margin = new Padding(0, 5, 11, 0);
            if (tableLayout.GetColumn(label) >= 2)//columna del otro lado del pasillo
            {
                label.Margin = new Padding(11, 5, 0, 0);
            }
        }



        private void asientosClick(Object sender, EventArgs e)
        {
            if (OnClickAsiento != null)
            {
                OnClickAsiento(this, (int)((Label)sender).Tag, e);
            }
        }



        public void setearAsientosYreservados(Viaje viaje, List<Pasaje> pasajesReservados)
        {
            this.viaje = viaje;
            this.pasajesReservados = pasajesReservados;
            tableLayout.Controls.Clear();
            if (viaje != null)
            {
                construirColectivo();
            }
        }


        public int CantidadAsientos
        {
            get { return viaje.CantidadAsientos; }
        }

        public Viaje Viaje
        {
            get { return viaje; }
        }

        public List<Pasaje> PasajesReservados
        {
            get { return pasajesReservados; }
        }





        public delegate void HandlerClickAsiento(
            ColectivoControls colectivo,
            int numeroAsiento,
            EventArgs e);



    }
}
