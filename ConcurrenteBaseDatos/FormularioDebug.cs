using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using ConcurrenteBaseDatos.BaseDeDatos.Registros;
using ConcurrenteBaseDatos.BaseDeDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia;
using ConcurrenteBaseDatos.BaseDeDatos.Excepciones;
using ConcurrenteBaseDatos.BaseDeDatos.ComponentesVisuales;

namespace ConcurrenteBaseDatos
{
    public partial class FormularioDebug : Form
    {
        Registro registro = new Registro();
        ControladorTransaccion controlTransaccion = new ControladorTransaccion();
        ControladorConcurrencia concurrencia = new ControladorConcurrencia();

        BaseDatos baseDeDatos;

        public FormularioDebug(BaseDatos baseDeDatos)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.baseDeDatos = baseDeDatos;
            comboBox1.Items.Add(new TablaPasaje());
            comboBox1.Items.Add(new TablaPersona());
            comboBox1.Items.Add(new TablaViaje());
            comboBox1.SelectedIndex=0;

            ControladorTransaccionesView v = new ControladorTransaccionesView(baseDeDatos);
            Controls.Add(v);
            v.Top = groupVerTabla.Height + groupVerTabla.Top + 5;

            RegistroView regView = new RegistroView(baseDeDatos.Registro);
            Controls.Add(regView);
            regView.Dock = DockStyle.Right;
        }

        

        private void button2_Click(object sender, EventArgs e)
        {

            registro.restaurarDesdeRegistro();

        }


        private void buttonVerTabla_Click(object sender, EventArgs e)
        {
            Tabla tabla = (Tabla)comboBox1.SelectedItem;
            FileStream s = new FileStream(tabla.getArchivo(), FileMode.OpenOrCreate,
                                                            FileAccess.Read,
                                                            FileShare.ReadWrite);
            List<Tupla> objetos = new List<Tupla>();
            IFormatter formatter = new BinaryFormatter();
            while (s.Position < s.Length)
            {
                long posAnterior = s.Position;
                objetos.Add((Tupla)formatter.Deserialize(s));
                
                long meMovi = s.Position - posAnterior;
                s.Position += tabla.getCantidadBytesRegistros() - meMovi;
            }
            s.Close();
            if (tabla.GetType() == new TablaPersona().GetType())
            {
                dataGridView1.DataSource = objetos.ConvertAll(new Converter<Tupla, Persona>(delegate(Tupla t)
                    {
                        return (Persona)t;
                    }));
            }
            else
            {
                if (tabla.GetType() == new TablaPasaje().GetType())
                {
                    dataGridView1.DataSource = objetos.ConvertAll(new Converter<Tupla, Pasaje>(delegate(Tupla t)
                    {
                        return (Pasaje)t;
                    }));
                }
                else
                {
                    dataGridView1.DataSource = objetos.ConvertAll(new Converter<Tupla, Viaje>(delegate(Tupla t)
                    {
                        return (Viaje)t;
                    }));
                }
            }
        }

    }
}
