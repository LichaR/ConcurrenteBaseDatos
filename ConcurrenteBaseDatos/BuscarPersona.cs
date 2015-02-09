using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConcurrenteBaseDatos.BaseDeDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.Servicios;

namespace ConcurrenteBaseDatos
{
    public partial class BuscarPersona : Form
    {
        private BaseDatos baseDeDatos;

        public BuscarPersona(BaseDatos baseDeDatos)
        {
            InitializeComponent();
            this.baseDeDatos = baseDeDatos;
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            labelError.Visible = false;
            personaView1.Visible = false;
            botonAceptar.Enabled = false;
            Persona persona;
            if (new PersonaServicio().buscarPersona(baseDeDatos, dniText.Text, out persona))
            {
                if (persona != null)
                {
                    personaView1.Persona = persona;
                    personaView1.Visible = true;
                    botonAceptar.Enabled = true;
                }
                else
                {
                    labelError.Visible = true;
                    labelError.Text = "No habia nadie";
                }
            }
            else
            {
                labelError.Visible = true;
                labelError.Text = "Error interno: reintentelo mas tarde";
            }
        }


        public Persona PersonaSeleccionada
        {
            get { return personaView1.Persona; }
        }

        private void dniText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dniText_TextChanged(object sender, EventArgs e)
        {
            botonAceptar.Enabled = false;
            personaView1.Visible = false;
        }


    }
}
