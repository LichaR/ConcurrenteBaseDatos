using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ConcurrenteBaseDatos.Servicios;
using ConcurrenteBaseDatos.BaseDeDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.ComponentesVisuales;

namespace ConcurrenteBaseDatos
{
    public partial class VentanaMultiplesReservas : Form
    {
        public const int CANTIDAD_RESERVAS = 10;

        private SynchronizationContext contexto = SynchronizationContext.Current;
        private BaseDatos baseDatos;
        private ReservaView[] reservas = new ReservaView[CANTIDAD_RESERVAS];

        public VentanaMultiplesReservas(BaseDatos baseDatos)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.baseDatos = baseDatos;
            for (int i = 0; i < reservas.Length; i++)
            {
                reservas[i] = new ReservaView(baseDatos);
                reservas[i].Dock = DockStyle.Top;
                tableLayoutPanel1.Controls.Add(reservas[i], i%2, i/2);
            }
            foreach( RowStyle style in tableLayoutPanel1.RowStyles )
            {
                style.SizeType = SizeType.AutoSize;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread[] hilos = new Thread[CANTIDAD_RESERVAS];
            for (int i = 0; i < reservas.Length; i++ )
            {
                hilos[i] = new Thread(new ParameterizedThreadStart(cuerpoThreads));
                List<Object> parametros = new List<object>();
                parametros.Add(baseDatos);
                parametros.Add(reservas.ElementAt(i));
                parametros.Add(contexto);
                hilos[i].Start(parametros);
            }
            
        }



        /// <summary>
        /// Cuerpo del threads que atiende la solicitud
        /// </summary>
        /// <param name="parametros">baseDeDatos, ReservaView, contextoDeSincronizacion</param>
        private void cuerpoThreads(Object parametros)
        {
            BaseDatos bbdd = (BaseDatos)((List<Object>)parametros).ElementAt(0);
            ReservaView view = (ReservaView)((List<Object>)parametros).ElementAt(1);
            SynchronizationContext context = (SynchronizationContext)((List<Object>)parametros).ElementAt(2);
            if (view.Habilitado)
            {

                mostrarMensaje(context, view, "Comenzando");

                try
                {
                    Pasaje pasaje = new Pasaje(view.Viaje.Id, view.Persona.Id,
                                    view.Fecha, view.NumeroAsiento);
                    if (new PasajeServicio().escribirPasaje(bbdd, pasaje,
                                                           view.Viaje))
                    {
                        mostrarMensaje(context, view, "Exito al reservar");
                    }
                    else
                    {
                        mostrarMensaje(context, view, "Error interno. Reintentelo");
                    }
                }
                catch (ViajeEliminadoException ex)
                {
                    mostrarMensaje(context, view, "El viaje fue eliminado. Refresque la busqueda de viajes");
                }
                catch (PasajeEstabaReservadoException)
                {
                    mostrarMensaje(context, view, "El asiento ya está reservado, refresque la busqueda");
                }
                catch (AsientoNoExistenteException)
                {
                    mostrarMensaje(context, view, "El asiento no existe. Refresque la busqueda");
                }
            }
            else
            {
                mostrarMensaje(context, view, "Datos invalidos");
            }

        }

        /// <summary>
        /// <para>Usado por los threads para mostrar el mensage en el label del ReservaView.</para>
        /// <para>Esto lo hace de forma sincronizada con el threads del form</para>
        /// </summary>
        /// <param name="view"></param>
        /// <param name="msg"></param>
        private void mostrarMensaje(SynchronizationContext c, ReservaView view, String msg)
        {
            c.Send(new SendOrPostCallback(delegate(Object vista)
            {
                ((ReservaView)vista).Resultado = msg;
            }), view);
        }


    }
}
