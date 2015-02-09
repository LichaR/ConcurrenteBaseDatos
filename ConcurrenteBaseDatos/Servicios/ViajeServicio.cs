using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.BaseDeDatos;
using ConcurrenteBaseDatos.BaseDeDatos.Excepciones;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas;
using ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia.Condiciones;

namespace ConcurrenteBaseDatos.Servicios
{
    public class ViajeServicio:IViajeService
    {

        /// <summary>
        /// Escribe el viaje en la base de datos. Se usa para agregar o modificar
        /// </summary>
        /// <param name="baseDeDatos">Base de datos usada</param>
        /// <param name="viaje">Objeto a escribir</param>
        /// <returns>Retorna tru si hubo exito, sino false</returns>
        public bool escribirViaje(BaseDatos baseDeDatos, Viaje viaje)
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
                        baseDeDatos.bloquear(transaccion,
                                            new CondicionViaje(0, viaje.Dia, viaje.Destino), 
                                            BaseDeDatos.ControlConcurrencia.TipoBloqueo.BLOQUEO_ESCRITURA);
                        baseDeDatos.escribir(transaccion, new TablaViaje(), viaje);
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
                if (exito)
                {
                    return true;
                }                
            }
            return false;
        }




        /// <summary>
        /// Busca los viajes en la bbdd
        /// </summary>
        /// <param name="baseDeDatos">Base de datos usada</param>
        /// <param name="destino">Destino a buscar</param>
        /// <param name="dia">Dia de la semana</param>
        /// <param name="viajes">Esta lista se llenara con los resultados</param>
        /// <returns>Si es false, hubo un error; si es true, se realizo correctamente</returns>

        public Boolean buscarLista(BaseDatos baseDeDatos, String destino, 
            DiasSemana dia, Boolean incluirEliminados, out List<Viaje> viajes)
        {
            viajes = new List<Viaje>();
            int intentos = 5;
            Transaccion transaccion = null;
            while (transaccion==null && intentos > 0)
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
                        List<Object> condicion = new List<object>();
                        condicion.Add(dia);
                        condicion.Add(destino);

                        baseDeDatos.bloquear(transaccion, 
                            new CondicionViaje(0, dia, destino), 
                            BaseDeDatos.ControlConcurrencia.TipoBloqueo.BLOQUEO_LECTURA);
                        List<Tupla> lista = baseDeDatos.leerLista(new TablaViaje(),
                            new Archivo.ComparadorTuplas(delegate(Tupla tupla)
                            {
                                Viaje elemento = (Viaje)tupla;
                                return elemento.Destino == destino && elemento.Dia == dia
                                        && (!elemento.Eliminado || incluirEliminados) ;
                            }
                                ));
                        baseDeDatos.commit(transaccion);
                        
                        viajes.AddRange(
                            lista.ConvertAll<Viaje>(new Converter<Tupla, Viaje>
                                                    (delegate(Tupla t) { return (Viaje)t; })
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

    }
}
