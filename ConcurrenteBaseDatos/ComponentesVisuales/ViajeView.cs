using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;

namespace ConcurrenteBaseDatos.ComponentesVisuales
{
    public partial class ViajeView : UserControl
    {
        private Viaje viaje;

        /// <summary>
        /// Evento que ocurre al hacer click en modificar
        /// </summary>
        public event OnClickBoton BotonClick;

        public ViajeView()
        {
            InitializeComponent();
            List<DiasSemana> dias = new List<DiasSemana>();
            dias.Add(DiasSemana.Lunes);
            dias.Add(DiasSemana.Martes);
            dias.Add(DiasSemana.Miercoles);
            dias.Add(DiasSemana.Jueves);
            dias.Add(DiasSemana.Viernes);
            dias.Add(DiasSemana.Sabado);
            dias.Add(DiasSemana.Domingo);
            diaSemana.DataSource = dias;
            diaSemana.SelectedItem = dias.ElementAt(0);
        }

        public ViajeView(Viaje viaje)
            :this()
        {
            Viaje = viaje;
        }

        private void ViajeView_Load(object sender, EventArgs e)
        {
            recargarDatos();
        }

        private void recargarDatos()
        {
            destinoText.Text = "";
            cantidadAsientos.Value = 0;
            horaPartida.Value = new DateTime(2001, 1, 1,
                    1,
                    0,
                    0);
            diaSemana.SelectedIndex = 0;
            precioText.Text = "0";
            destinoText.ReadOnly = false;
            diaSemana.Enabled = true;
            eliminadoCheck.Visible = false;// se muestra si hay algo para eliminar, es decir, Viaje!=null
            if (viaje != null)
            {
                destinoText.Text = Viaje.Destino;
                cantidadAsientos.Value = Viaje.CantidadAsientos;
                horaPartida.Value = new DateTime(2001, 1, 1,
                    Viaje.HoraPartida.Hours,
                    Viaje.HoraPartida.Minutes,
                    Viaje.HoraPartida.Seconds);
                diaSemana.SelectedIndex = (int)Viaje.Dia-1;
                eliminadoCheck.Checked = viaje.Eliminado;
                precioText.Text = Viaje.Precio.ToString();
                destinoText.ReadOnly = true;
                diaSemana.Enabled = false;
                eliminadoCheck.Visible = true;
            }
            
        }


        public Viaje Viaje
        {
            get { return viaje; }
            set { viaje = value; recargarDatos(); }
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            bool exito = true;
            try
            {
                if (Viaje == null)
                {
                    //creacion
                    Viaje = new Viaje((int)cantidadAsientos.Value,
                                    horaPartida.Value.TimeOfDay,
                                    (DiasSemana)diaSemana.SelectedValue,
                                    float.Parse(precioText.Text),
                                    destinoText.Text);
                }
                else
                {
                    //modificacion
                    Viaje.Destino = destinoText.Text;
                    Viaje.CantidadAsientos = (int)cantidadAsientos.Value;
                    Viaje.HoraPartida = horaPartida.Value.TimeOfDay;
                    Viaje.Dia = (DiasSemana)diaSemana.SelectedValue;
                    Viaje.Eliminado = eliminadoCheck.Checked;
                    Viaje.Precio = float.Parse(precioText.Text);
                }
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
                exito = false;
                errorLabel.Visible = true;
            }
            if (exito && BotonClick != null)
            {
                BotonClick(this, e);
            }
        }


        [Description("Caption del control"),
        Category("Values"),
        DefaultValue("Viaje"),
        Browsable(true)]
        public String Caption
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }

        [Description("Caption del boton de accion"),
        Category("Values"),
        DefaultValue("Botón"),
        Browsable(true)]
        public String BotonCaption
        {
            get { return botonModificar.Text; }
            set { botonModificar.Text = value; }
        }


        
        public delegate void OnClickBoton(ViajeView viajeView, EventArgs e);


        private void precioText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == ','
                && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void precioText_TextChanged(object sender, EventArgs e)
        {
            if (precioText.Text == "")
            {
                precioText.Text = "0";
            }
        }



    }
}
