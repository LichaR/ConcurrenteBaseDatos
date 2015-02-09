using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.BaseDeDatos.Excepciones;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas;
using ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia.Condiciones;

namespace ConcurrenteBaseDatos.Servicios
{
    public class PasajeServicio:IPasajeService
    {

        /// <summary>
        /// Retorna la lista de pasajes como parametro de salida. El return nos dice si hubo o no error
        /// </summary>
        /// <param name="baseDeDatos">Base de datos usada</param>
        /// <param name="idPersona">Id de persona del pasaje reservado</param>
        /// <param name="idViaje">Id de viaje del pasaje reservado</param>
        /// <param name="pasajes">Salida, La lista de pasajes</param>
        /// <returns></returns>
        public Boolean leerPasajes(BaseDatos baseDeDatos, DateTime fecha,
                            long idViaje, out List<Pasaje> pasajes)
        {
            pasajes = new List<Pasaje>();
            int intentos = 5;
            Transaccion transaccion = null;
            while (transaccion == null && intentos > 0)
            {
                try
                {
                    transaccion = baseDeDatos.crearTransaccion();
                }
                catch (LimiteCantidadTransaccionesException)
                {
                    intentos--;
                }
            }
            if (transaccion != null)
            {
                bool exito = false;
                intentos = 5;
                while (intentos > 0 && !exito)
                {
                    try
                    {
                        baseDeDatos.bloquear(transaccion,
                            new CondicionPasaje(0, idViaje, fecha),
                            BaseDeDatos.ControlConcurrencia.TipoBloqueo.BLOQUEO_LECTURA);
                        List<Tupla> lista = baseDeDatos.leerLista(new TablaPasaje(),
                            new Archivo.ComparadorTuplas(delegate(Tupla tupla)
                            {
                                Pasaje elemento = (Pasaje)tupla;
                                return elemento.FechaViaje.Date == fecha.Date &&
                                        elemento.IdViaje == idViaje &&
                                        !elemento.Cancelado;
                            }
                                ));
                        baseDeDatos.commit(transaccion);

                        pasajes.AddRange(
                            lista.ConvertAll<Pasaje>(new Converter<Tupla, Pasaje>
                                                    (delegate(Tupla t) { return (Pasaje)t; })
                                                    )
                            );
                        return true;

                    }
                    catch (AbortarEsperarMorirException)
                    {
                        intentos--;
                        if (intentos > 0)
                        {
                            baseDeDatos.reiniciarTransaccin(transaccion);
                        }
                    }
                }
            }
            return false;
        }



        /// <summary>
        /// Se usa para agregar o modificar. Retorna si hubo exito o no. 
        /// <para>Puede levantar:</para>
        /// <para>ViajeEliminadoException</para>
        /// <para>AsientoNoExistenteException</para>
        /// <para>PasajeEstabaReservadoException</para>
        /// </summary>
        /// <param name="baseDeDatos">Base de datos usada</param>
        /// <param name="pasaje">Pasaje a escribir</param>
        /// <returns>True si hubo exito, sino false</returns>
        public Boolean escribirPasaje(BaseDatos baseDeDatos, Pasaje pasaje,
                                    Viaje viaje)
        {
            int intentos = 5;
            Transaccion transaccion = null;
            while (transaccion == null && intentos > 0)
            {
                try
                {
                    transaccion = baseDeDatos.crearTransaccion();
                }
                catch (LimiteCantidadTransaccionesException)
                {
                    intentos--;
                }
            }
            if (transaccion != null)
            {
                intentos = 5;
                bool exito = false;
                while (intentos > 0 && !exito)
                {
                    try
                    {
                        /*
                         * Bloqueo del viaje
                         */
                        baseDeDatos.bloquear(transaccion, 
                                            new CondicionViaje(0,viaje.Dia, viaje.Destino), 
                                            BaseDeDatos.ControlConcurrencia.TipoBloqueo.BLOQUEO_LECTURA);
                        //me fijo si está (deberia estar la persona)
                        Viaje viajeEnLaBase = (Viaje)baseDeDatos.buscar(new TablaViaje(),
                                            new Archivo.ComparadorTuplas(delegate(Tupla t)
                                            {
                                                return ((Viaje)t).Id == viaje.Id;
                                            })
                                                );
                        //si no estaba o estaba eliminado. Borrado logico
                        if (viajeEnLaBase == null || viajeEnLaBase.Eliminado)
                        {
                            baseDeDatos.abortarTransaccion(transaccion, new ViajeEliminadoException().Message);
                            throw new ViajeEliminadoException();
                        }
                        else
                        {
                            //viajeEnLaBase es != de null aqui
                            if (viajeEnLaBase.CantidadAsientos < pasaje.NumeroAsiento
                                || pasaje.NumeroAsiento <=0)
                            {
                                baseDeDatos.abortarTransaccion(transaccion, new AsientoNoExistenteException().Message);
                                throw new AsientoNoExistenteException();
                            }
                        }

                        baseDeDatos.bloquear(transaccion, 
                                            new CondicionPasaje(0, pasaje.IdViaje, pasaje.FechaViaje), 
                                            BaseDeDatos.ControlConcurrencia.TipoBloqueo.BLOQUEO_ESCRITURA);

                        /*
                         * Conrol de que no este reservado el pasaje
                         */
                        List<Tupla> tuplas = baseDeDatos.leerLista(new TablaPasaje(), new Archivo.ComparadorTuplas(
                                delegate(Tupla t)
                                {
                                    return ((Pasaje)t).NumeroAsiento == pasaje.NumeroAsiento;
                                }
                            ));
                        if (tuplas.Find(new Predicate<Tupla>(
                                                            delegate(Tupla t)
                                                                {
                                                                    //si es igual id, es una modificacion
                                                                    Pasaje p = ((Pasaje)t);
                                                                    return p.FechaViaje.Date == pasaje.FechaViaje.Date && p.IdViaje == pasaje.IdViaje &&
                                                                        !p.Cancelado && p.Id != pasaje.Id;
                                                                }
                             )) != null)
                        {
                            //el asiento estaba reservado
                            baseDeDatos.abortarTransaccion(transaccion, new PasajeEstabaReservadoException().Message);
                            throw new PasajeEstabaReservadoException();
                        }
                        baseDeDatos.escribir(transaccion, new TablaPasaje(), pasaje);
                        baseDeDatos.commit(transaccion);
                        exito = true;
                    }
                    catch (AbortarEsperarMorirException)
                    {
                        intentos--;
                        if (intentos > 0)
                        {
                            baseDeDatos.reiniciarTransaccin(transaccion);
                        }
                    }
                }
                return exito;
            }
            return false;
        }

    }
}
