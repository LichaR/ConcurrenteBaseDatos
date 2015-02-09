using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.BaseDeDatos;
using ConcurrenteBaseDatos.BaseDeDatos.Excepciones;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas;
using ConcurrenteBaseDatos.ComponentesVisuales;
using ConcurrenteBaseDatos.Servicios;

namespace ConcurrenteBaseDatos
{
    public partial class VentanaViaje : Form
    {
        private BaseDatos baseDeDatos;
        private ViajeView viajeView;

        public VentanaViaje(BaseDatos baseDeDatos)
        {
            InitializeComponent();
            this.baseDeDatos = baseDeDatos;

            viajeView = new ViajeView();
            viajeView.BotonClick += new ViajeView.OnClickBoton(modificarClick);
            viajeView.Top = tabla.Top;
            viajeView.Left = tabla.Left + tabla.Width + 10;
            viajeView.Visible = false;
            grupoModificar.Controls.Add(viajeView);

        }

        private void VentanaViaje_Load(object sender, EventArgs e)
        {
            List<DiasSemana> dias = new List<DiasSemana>();
            

            dias = new List<DiasSemana>();
            dias.Add(DiasSemana.Domingo);
            dias.Add(DiasSemana.Lunes);
            dias.Add(DiasSemana.Martes);
            dias.Add(DiasSemana.Miercoles);
            dias.Add(DiasSemana.Jueves);
            dias.Add(DiasSemana.Viernes);
            dias.Add(DiasSemana.Sabado);
            diaBuscar.DataSource = dias;      
            diaBuscar.SelectedItem = dias.ElementAt(2);
        }


        private void botonBuscar_Click(object sender, EventArgs e)
        {
            viajeView.Visible = false;
            if (diaBuscar.SelectedItem != null && destinoBuscar.Text != "")
            {
                DiasSemana dia = (DiasSemana)diaBuscar.SelectedItem;

                List<Viaje> viajes = null;
                if (new ViajeServicio().buscarLista(baseDeDatos, destinoBuscar.Text, dia, true, out viajes))
                {
                    tabla.DataSource = viajes;
                }
                else
                {
                    MessageBox.Show("Reintente mas tarde");
                }
            }
        }

        private void tabla_SelectionChanged(object sender, EventArgs e)
        {
            viajeView.Visible = false;
            try
            {
                if (tabla.SelectedRows[0] != null)
                {
                    Viaje viaje = (Viaje)tabla.SelectedRows[0].DataBoundItem;
                    viajeView.Viaje = viaje;
                    viajeView.Visible = true;
                }
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }




        private void modificarClick(object sender, EventArgs e)
        {
            //si llega aqui, el modificar tubo exito, es decir
            //los datos son validos, y el objeto original fue modificado
            Viaje viaje = ((ViajeView)sender).Viaje;
            
            if ( new ViajeServicio().escribirViaje(baseDeDatos, viaje) )
            {
                MessageBox.Show("Exito al modificar el viaje");
            }
            else
            {
                MessageBox.Show("No se pudo realizar la modificacion");
            }

        }

        private void viajeViewAgregar_BotonClick(ViajeView viajeView, EventArgs e)
        {
            //los datos son valios
            Viaje viaje = viajeView.Viaje;
            if (viaje != null)
            {
                //inicio el proceso de alta
                if (new ViajeServicio().escribirViaje(baseDeDatos, viaje))
                {
                    MessageBox.Show("Exito al agregar el viaje");
                    //pongo el siguiente para agregar mas tarde
                    viajeView.Viaje = null;//sino los campos son read only
                }
                else
                {
                    MessageBox.Show("Reintente mas tarde");
                }
            }
        }



    }
}
