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
using ConcurrenteBaseDatos.Servicios;
using ConcurrenteBaseDatos.ComponentesVisuales;
using System.Threading;

namespace ConcurrenteBaseDatos
{
    public partial class VentanaPrincipal : Form
    {
        private BaseDatos baseDeDatos;
        /// <summary>
        /// Ultima fecha por la que se ha buscado, asi si se modifica el timePicker, no se pierde
        /// </summary>
        private DateTime ultimaFechaBuscada;

        /// <summary>
        /// <para>Indica si es el primer form que se ha creado.</para>
        /// <para>Este detiene los demas threads y desconecta la BBDD</para>
        /// </summary>
        private Boolean esVentanaPrincipal = false;

        private List<Thread> hiloActivos = new List<Thread>();

        public VentanaPrincipal(BaseDatos baseDeDatos)
        {
            InitializeComponent();
            this.baseDeDatos = baseDeDatos;
            //Text += " Threads:" + Thread.CurrentThread.ManagedThreadId;
        }

        public VentanaPrincipal()
            :this(new BaseDatos())
        {
            //es la primer ventana que se crea, esta permite crear las otras
            botonDebug.Visible = true;//boton que abre la ventana de debug
            nuevaInstanciaToolStripMenuItem.Enabled = true;
            ventanaPruebaConcurenciaToolStripMenuItem.Enabled = true;
            //Text += " Threads principal. Si cierra esta, cierra todo";
            esVentanaPrincipal = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormularioDebug(baseDeDatos).ShowDialog();
        }

        private void botonBuscarViaje_Click(object sender, EventArgs e)
        {
            DiasSemana dia = getDiaSemana(fechaPicker.Value);
            ultimaFechaBuscada = fechaPicker.Value;
            List<Viaje> viajes;
            errorLabel.Visible = false;
            if (new ViajeServicio().buscarLista(baseDeDatos, destinoText.Text,
                                                dia, false, out viajes))
            {
                tablaViaje.DataSource = viajes;
            }
            else
            {
                tablaViaje.DataSource = viajes;//la deja vacia
                errorLabel.Text = "Error interno, vuelva a probar";
                errorLabel.Visible = true;
            }

            
        }

        public static DiasSemana getDiaSemana(DateTime fecha)
        {
            DiasSemana dia = DiasSemana.Domingo;
            if ((int)fecha.DayOfWeek > 0)
            {
                dia = (DiasSemana)((int)fecha.DayOfWeek);
            }
            return dia;
        }

        private void botonAbrirViaje_Click(object sender, EventArgs e)
        {
            new VentanaViaje(baseDeDatos).ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonPersona_Click(object sender, EventArgs e)
        {
            new VentanaPersona(baseDeDatos).ShowDialog();
        }

        private void destinoText_TextChanged(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            botonBuscarViaje.Enabled = true;
            if (destinoText.Text.Length == 0)
            {
                errorLabel.Text = "Especifique un destino";
                errorLabel.Visible = true;
                botonBuscarViaje.Enabled = false;
            }
        }

        private void tablaViaje_SelectionChanged(object sender, EventArgs e)
        {
            colectivo.Visible = false;
            try
            {
                if (tablaViaje.SelectedRows.Count>0 && tablaViaje.SelectedRows[0] != null)
                {
                    List<Pasaje> pasajes;
                    Viaje viaje = (Viaje)tablaViaje.SelectedRows[0].DataBoundItem;
                    if(new PasajeServicio().leerPasajes(baseDeDatos, ultimaFechaBuscada,
                                                        viaje.Id, out pasajes))
                    {
                        colectivo.Visible = true;
                        colectivo.setearAsientosYreservados(viaje, pasajes);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }


        private void colectivo_OnClickAsiento(ColectivoControls colectivo, int numeroAsiento, EventArgs e)
        {
            List<Pasaje> pasajes = colectivo.PasajesReservados;
            Pasaje pasajeReservado = pasajes.Find(new Predicate<Pasaje>(delegate(Pasaje pasaje)
                {
                    return pasaje.NumeroAsiento == numeroAsiento;
                }));
            Boolean cambio = false;
            if (pasajeReservado == null)
            {
                //nuevo pasaje
                BuscarPersona ventanaSeleccionPersona = new BuscarPersona(baseDeDatos);
                if (ventanaSeleccionPersona.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        Pasaje pasaje = new Pasaje(colectivo.Viaje.Id, ventanaSeleccionPersona.PersonaSeleccionada.Id,
                                        ultimaFechaBuscada, numeroAsiento);
                        if (new PasajeServicio().escribirPasaje(baseDeDatos, pasaje,
                                                                colectivo.Viaje))
                        {
                            MessageBox.Show("Exito al reservar");
                            colectivo.PasajesReservados.Add(pasaje);
                            cambio = true;
                        }
                        else
                        {
                            MessageBox.Show("Error interno. Reintentelo");
                        }
                    }
                    catch (ViajeEliminadoException ex)
                    {
                        MessageBox.Show("El viaje fue eliminado. Refresque la busqueda de viajes");
                    }
                    catch (PasajeEstabaReservadoException)
                    {
                        MessageBox.Show("El asiento ya está reservado, refresque la busqueda");
                    }
                    catch (AsientoNoExistenteException)
                    {
                        MessageBox.Show("El asiento no existe. Refresque la busqueda");
                    }
                }
            }
            else
            {
                //cancelar reserva del pasaje
                if(MessageBox.Show("¿Desea cancelar la reserva del pasaje?","Cancelar",MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        pasajeReservado.Cancelado = true;
                        if (new PasajeServicio().escribirPasaje(baseDeDatos, pasajeReservado,
                                                            colectivo.Viaje))
                        {
                            MessageBox.Show("Cancelado");
                            cambio = true;
                            colectivo.PasajesReservados.Remove(pasajeReservado);
                        }
                        else
                        {
                            MessageBox.Show("Error interno. Reintentelo");
                            pasajeReservado.Cancelado = false;
                        }
                    }
                    catch (ViajeEliminadoException ex)
                    {
                        MessageBox.Show("El viaje fue eliminado. Refresque la busqueda de viajes");
                    }
                }
            }
            if (cambio)
            {
                colectivo.setearAsientosYreservados(colectivo.Viaje, colectivo.PasajesReservados);
            }
        }

        private void nuevaInstanciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread hilo = new Thread(
                    new ParameterizedThreadStart(
                        delegate(Object baseDatos)
                        {
                            BaseDatos b = (BaseDatos)baseDatos;
                            new VentanaPrincipal(b).ShowDialog();
                        }
                        )
                );
            hiloActivos.Add(hilo);
            hilo.Start(baseDeDatos);
        }

        private void ventanaPruebaConcurenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new VentanaMultiplesReservas(baseDeDatos).ShowDialog();
        }

        private void VentanaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (esVentanaPrincipal)
            {
                foreach (Thread t in hiloActivos)
                {
                    try
                    {
                        t.Abort();
                    }
                    catch (ThreadStateException)
                    {

                    }
                }
                baseDeDatos.desconectar();
            }
        }

        private void tablaViaje_DataSourceChanged(object sender, EventArgs e)
        {
            labelNoHayResultados.Visible = false;
            if (tablaViaje.RowCount <= 0)
            {
                labelNoHayResultados.Visible = true;
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AcercaDeForm().ShowDialog();
        }

        

    }
}
