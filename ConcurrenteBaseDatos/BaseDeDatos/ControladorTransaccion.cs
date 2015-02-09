using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos.Excepciones;

namespace ConcurrenteBaseDatos.BaseDeDatos
{
    public class ControladorTransaccion
    {

        private long siguienteId = 1;
        private const int CANTIDAD_MAXIMA = 10;
        private List<Transaccion> transaccionesActivas = new List<Transaccion>();

        private int cantidadAbortadas = 0;
        private int cantidadCommiteadas = 0;


        
        internal Transaccion crearTransaccion(BaseDatos baseDeDatos)
        {
            Transaccion transaccion;
            lock (transaccionesActivas)
            {
                if (transaccionesActivas.Count >= CANTIDAD_MAXIMA)
                {
                    //esta al tope
                    throw new LimiteCantidadTransaccionesException();
                }
                transaccion = new Transaccion(siguienteId, baseDeDatos);
                transaccionesActivas.Add(transaccion);
                siguienteId++;
            }
            return transaccion;
        }



        internal void transaccionFinalizada(Transaccion transaccion)
        {
            lock (transaccionesActivas)
            {
                transaccionesActivas.Remove(transaccion);
                if (transaccion.estaAbortada())
                {
                    cantidadAbortadas++;
                }
                else
                {
                    cantidadCommiteadas++;
                }
            }
        }

        internal void reiniciarTransaccion(Transaccion transaccion)
        {
            lock (transaccionesActivas)
            {
                if (transaccionesActivas.Count > CANTIDAD_MAXIMA)
                {
                    throw new LimiteCantidadTransaccionesException("ya supero el limite de transacciones");
                }
                transaccion.reiniciar(); //no necesita nuevo id
                transaccionesActivas.Add(transaccion);
            }
        }


        /// <summary>
        /// Cantidad de transacciones abortadas hasta el momento. Este bloquea la lista
        /// <para>Si se reiniciaron, aun asi se cuentan</para>
        /// </summary>
        internal int CantidadAbortadas
        {
            get {
                lock (transaccionesActivas)
                {
                    return cantidadAbortadas;
                }
            }
        }

        /// <summary>
        /// Cantidad de transacciones commiteadas hasta el momento. Este bloquea la lista
        /// </summary>
        internal int CantidadCommiteadas
        {
            get
            {
                lock (transaccionesActivas)
                {
                    return cantidadCommiteadas;
                }
            }
        }

        /// <summary>
        /// Cantidad de transacciones activas hasta el momento. Este bloquea la lista
        /// </summary>
        internal int CantidadActivas
        {
            get 
            { 
                lock (transaccionesActivas)
                    {
                        return transaccionesActivas.Count;
                    }
            }
        }


    }
}
