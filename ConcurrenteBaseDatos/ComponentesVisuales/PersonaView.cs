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
    public partial class PersonaView : UserControl
    {
        private Persona persona;


        /// <summary>
        /// Evento que ocurre al hacer click en el boton
        /// </summary>
        [Description("Evento que ocurre cuando se hace click en el botón"),
        Category("Events"),
        Browsable(true)]
        public event OnClickBotonDelegate OnClickBoton;

        public PersonaView()
        {
            InitializeComponent();
        }

        public PersonaView(Persona persona)
            :this()
        {
            
            actualizarVista();
        }


        //permite el ingreso de solo numeros en el dni
        private void dniText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void actualizarVista()
        {
            nombreText.Text = "";
            apellidoText.Text = "";
            dniText.Text = "";
            dniText.ReadOnly = false;
            if (Persona != null)
            {
                nombreText.Text = Persona.Nombre;
                apellidoText.Text = Persona.Apellido;
                dniText.Text = Persona.Dni;
                //es modificacion
                dniText.ReadOnly = true;
            }
        }


        [Browsable(false)]
        public Persona Persona
        {
            get { return persona; }
            set { persona = value; actualizarVista(); }
        }


        [Description("Caption del control"),
        Category("Values"),
        DefaultValue("Persona"),
        Browsable(true)]
        public String Caption
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }

        [Description("Caption del boton"),
         Category("Values"),
         DefaultValue("Boton"),
         Browsable(true)]
        public String BotonCaption
        {
            set { button1.Text = value; }
            get { return button1.Text; }
        }


        [Description("Indica si debe mostrarse el boton"),
         Category("Values"),
         DefaultValue(true),
         Browsable(true)]
        public Boolean MostrarBoton
        {
            set { button1.Visible = value; }
            get { return button1.Visible; }
        }

        [Description("Indica si los componentes son de solo lectura o no"),
         Category("Values"),
         DefaultValue(false),
         Browsable(true)]
        public Boolean SoloLectura
        {
            set {
                nombreText.ReadOnly = true;
                dniText.ReadOnly = true;
                apellidoText.ReadOnly = true;
            }
            get { return nombreText.ReadOnly; }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if ( datosValidos() && OnClickBoton != null) { OnClickBoton(this, e); }
        }


        /// <summary>
        /// Esto solo es necesario en una alta. Porque el objeto no existe y no se validaban los datos
        /// </summary>
        /// <returns></returns>
        private bool datosValidos()
        {
            errorLabel.Visible = false;
            if (Persona != null) { return true; }//ya estan validados a medida que se modificaban
            try
            {
                Persona = new Persona(nombreText.Text, apellidoText.Text, dniText.Text);
                return true;
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
                errorLabel.Visible = true;
            }
            return false;
        }


        public delegate void OnClickBotonDelegate(PersonaView personaView, EventArgs e);

        private void nombreText_TextChanged(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            try
            {
                if (Persona != null) { Persona.Nombre = nombreText.Text; }
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
                errorLabel.Visible = true;
            }
            
        }

        private void apellidoText_TextChanged(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            try
            {
                if (Persona != null) { Persona.Apellido = apellidoText.Text; }
            }
            catch (Exception ex)
            {
                errorLabel.Text = ex.Message;
                errorLabel.Visible = true;
            }
        }


    }
}
