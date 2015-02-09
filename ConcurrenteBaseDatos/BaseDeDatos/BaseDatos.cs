using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia;
using ConcurrenteBaseDatos.BaseDeDatos.Registros;

namespace ConcurrenteBaseDatos.BaseDeDatos
{
    public class BaseDatos
    {

        private ControladorConcurrencia controladorConcurrencia;
        private ControladorTransaccion controlTransacciones;
        private Archivo archivo;
        private Registro registro;


        /// <summary>
        /// Crea la instancia de la bbdd, y se conecta
        /// </summary>
        public BaseDatos()
        {
            //no es necesario soncronizar este constructor,
            //hasta que la instancia no se construya, no podra ser usada
                controlTransacciones = new ControladorTransaccion();
                controladorConcurrencia = new ControladorConcurrencia();
                archivo = new Archivo();
                registro = new Registro();
                registro.restaurarDesdeRegistro();
        }


        /// <summary>
        /// <para>Guada los bufferes, detiene los threads y cierra todo</para>
        /// <para>Llame a este metodo antes de cerrar la aplicacion, o pueden quedar threads activos</para>
        /// </summary>
        public void desconectar()
        {
            registro.finalizar();
            
        }



        /// <summary>
        /// Puede levantar AbortarEsperarMorirException debido al protocolo Esperar-Morir
        /// <para>Esto indica que la transaccion se abortó</para>
        /// </summary>
        /// <param name="transaccion"></param>
        /// <param name="tabla"></param>
        /// <param name="condicion"></param>
        /// <param name="tipoBloque"></param>
        /// <returns></returns>
        public void bloquear(Transaccion transaccion,
            Condicion condicion, TipoBloqueo tipoBloque)
        {
            controladorConcurrencia.bloquear(transaccion, condicion, tipoBloque);
        }



        /// <summary>
        /// El usuario no desbloquea, lo hacen las transacciones al abortar o commitear
        /// <para>Este mensaje solo lo envia internamente al abortar o comitear</para>
        /// </summary>
        /// <param name="descriptor"></param>
        internal void desbloquear(DescriptorBloqueo descriptor)
        {
            controladorConcurrencia.desbloquear(descriptor);
        }


        /// <summary>
        /// Llamar a este metodo, antes de operar con la base de datos. Puede levantar LimiteCantidadTransaccionesException
        /// </summary>
        /// <returns>Descriptor de la transaccion</returns>
        public Transaccion crearTransaccion()
        {
            Transaccion transaccion = controlTransacciones.crearTransaccion(this);
            registro.iniciarTransaccion(transaccion);
            return transaccion;
        }



        /// <summary>
        /// Llamar a este metodo para reiniciar la transaccion. Puede levantar TransaccionNoAbortadaException
        /// </summary>
        /// <param name="transaccion">Transaccion que debe reiniciarse. Esta debe estar abortada</param>
        public void reiniciarTransaccin(Transaccion transaccion)
        {
            controlTransacciones.reiniciarTransaccion(transaccion);
            registro.iniciarTransaccion(transaccion);//registra el reinicio
        }


        public Tupla buscar(Tabla tabla, Archivo.ComparadorTuplas comparador)
        {
            return archivo.buscar(tabla, comparador);
        }

        public List<Tupla> leerLista(Tabla tabla, Archivo.ComparadorTuplas comparador)
        {
            return archivo.leerLista(tabla, comparador);
        }

        public void escribir(Transaccion transaccion, Tabla tabla, Tupla dato)
        {
            dato.asignarID();
            registro.escribirEnRegistro(transaccion, tabla, dato);
        }



        /// <summary>
        /// Notifica el final de la transaccion y guarda los cambios en disco
        /// </summary>
        /// <param name="transaccion">Transaccion a commitear</param>
        public void commit(Transaccion transaccion)
        {
            transaccion.commit(registro);
        }



        /// <summary>
        /// Notifica que la transaccion debe abortarse
        /// </summary>
        /// <param name="transaccion">Transaccion a abortar</param>
        /// <param name="razon">Razon por la que se abortó</param>
        public void abortarTransaccion(Transaccion transaccion, String razon)
        {
            transaccion.abortar(registro, razon);
        }



        /// <summary>
        /// Esto es enviado por la transaccion cuando quiere finalizarse
        /// </summary>
        /// <param name="transaccion"></param>
        internal void finalizarTransaccion(Transaccion transaccion)
        {
            controlTransacciones.transaccionFinalizada(transaccion);
        }


        internal ControladorTransaccion ControladorDeTransacciones
        {
            get { return controlTransacciones; }
        }


        internal Registro Registro
        {
            get { return registro; }
        }

    }
}
