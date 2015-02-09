using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConcurrenteBaseDatos.BaseDeDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.Servicios;

namespace ConcurrenteBaseDatos.ComponentesVisuales
{
    public partial class ReservaView : UserControl
    {
        private BaseDatos baseDeDatos;
        private Viaje viaje;
        private Persona persona;
        private int tamañoOriginal;

        public ReservaView(BaseDatos baseDeDatos)
        {
            InitializeComponent();
            tamañoOriginal = Height;
            this.baseDeDatos = baseDeDatos;
        }


        private void labelViaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            List<Viaje> viajes = new List<Viaje>();
            listBox1.DataSource = viajes;
            groupPasaje.Visible = false;
            if (new ViajeServicio().buscarLista(
                baseDeDatos, destinoText.Text, VentanaPrincipal.getDiaSemana(fechaPicker.Value),
                false, out viajes
                ))
            {
                listBox1.DataSource = viajes;
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue != null)
            {
                viaje = (Viaje)listBox1.SelectedValue;
                groupPasaje.Visible = true;
                labelViaje.Text = "Asiento maximo " + viaje.CantidadAsientos;
                asiento.Value = 1;
                asiento.Maximum = viaje.CantidadAsientos;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            botonComprobarPersona.Enabled = false;
            panelPersonaExiste.BackColor = Color.Gray;
            if (dniText.Text.Length == 8)
            {
                botonComprobarPersona.Enabled = true;
            }
        }

        private void botonComprobarPersona_Click(object sender, EventArgs e)
        {
            Persona per;
            panelPersonaExiste.BackColor = Color.Red;
            if (new PersonaServicio().buscarPersona(baseDeDatos, dniText.Text, out per))
            {
                if (per != null)
                {
                    persona = per;
                    panelPersonaExiste.BackColor = Color.Green;
                    
                }
            }
        }


        private void fechaPicker_ValueChanged(object sender, EventArgs e)
        {
            groupPasaje.Visible = false;
            List<Viaje> viajes = new List<Viaje>();
            listBox1.DataSource = viajes;
            panelPersonaExiste.BackColor = Color.Gray;
        }



        /// <summary>
        /// Determina que las condiciones estan dadas para que se reserve el pasaje
        /// </summary>
        public Boolean Habilitado
        {
            get
            {
                return panelPersonaExiste.BackColor == Color.Green
                      && groupPasaje.Visible && Viaje!=null && Persona!=null;
            }
        }

        public Viaje Viaje
        {
            get { return viaje; }
        }
        public Persona Persona
        {
            get { return persona; }
        }

        public String Resultado
        {
            set { labelResultadoReserva.Text = value; labelResultadoReserva.Visible = true; }
            get { return labelResultadoReserva.Text; }
        }

        public DateTime Fecha
        {
            get { return fechaPicker.Value; }
        }

        public int NumeroAsiento
        {
            get { return (int)asiento.Value; }
        }

    }
}
