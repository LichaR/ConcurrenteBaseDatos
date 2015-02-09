using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConcurrenteBaseDatos.BaseDeDatos;
using ConcurrenteBaseDatos.Servicios;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;

namespace ConcurrenteBaseDatos
{
    public partial class VentanaPersona : Form
    {
        private BaseDatos baseDeDatos;

        public VentanaPersona(BaseDatos baseDeDatos)
        {
            InitializeComponent();
            this.baseDeDatos = baseDeDatos;
        }

        private void personaView1_OnClickBoton(ComponentesVisuales.PersonaView personaView, EventArgs e)
        {
            try
            {
                if (new PersonaServicio().escribirPersona(baseDeDatos,
                                                    personaView.Persona))
                {
                    MessageBox.Show("Exito al agregar");
                }
                else
                {
                    MessageBox.Show("Error al agregar");
                }
            }
            catch (PersonaConDniYaExisteException ex)
            {
                MessageBox.Show(ex.Message);
            }
            personaView.Persona = null;//esto evita que se combierta en un modificar
        }

        private void dniText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            labelError.Visible = false;
            personaViewModificar.Visible = false;
            Persona persona;
            if( new PersonaServicio().buscarPersona(baseDeDatos, dniText.Text ,out persona ))
            {
                if (persona != null)
                {
                    personaViewModificar.Persona = persona;
                    personaViewModificar.Visible = true;
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

        private void dniText_TextChanged(object sender, EventArgs e)
        {
            labelError.Visible = false;
            if (dniText.Text.Length != 8)
            {
                labelError.Visible = true;
                labelError.Text = "Debe ser de 8 dijitos";
                botonBuscar.Enabled = false;
            }
            else
            {
                botonBuscar.Enabled = true;
            }
        }

        private void personaViewModificar_OnClickBoton(ComponentesVisuales.PersonaView personaView, EventArgs e)
        {
            if (new PersonaServicio().escribirPersona(baseDeDatos,
                                                personaView.Persona))
            {
                MessageBox.Show("Exito al modificar");
            }
            else
            {
                MessageBox.Show("Error al modificar");
            }
        }

    }
}
