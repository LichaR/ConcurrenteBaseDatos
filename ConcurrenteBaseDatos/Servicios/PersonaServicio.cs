using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas;
using ConcurrenteBaseDatos.BaseDeDatos.Excepciones;
using ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia.Condiciones;

namespace ConcurrenteBaseDatos.Servicios
{
    class PersonaServicio:IPersonaService
    {

        /// <summary>
        /// Personas recuperadas de la base de dato.
        /// Se usa para conocer su anterior dni. El bloqueo es de ambos dni(anterior y nuevo). Id->dni
        /// </summary>
        private Dictionary<long, String> personasRecuperadas = new Dictionary<long, String>();

        /// <summary>
        /// Escribe la persona en la base de datos (Agrega o modifica)
        /// <para>Puede levantar PersonaConDniYaExisteException</para>
        /// </summary>
        /// <param name="baseDeDatos">Base de datos usada</param>
        /// <param name="persona">Persona que se escribira</param>
        /// <returns>True si hubo exito, false en caso contrario</returns>
        public Boolean escribirPersona(BaseDatos baseDeDatos, Persona persona)
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
                        List<Object> condicion = new List<object>();
                        condicion.Add(persona.Dni);
                        baseDeDatos.bloquear(transaccion, 
                                            new CondicionPersona(0, persona.Dni), 
                                            BaseDeDatos.ControlConcurrencia.TipoBloqueo.BLOQUEO_ESCRITURA);

                        /*
                         * Compruebo que no exista el dni
                         */
                        Tupla tupla = baseDeDatos.buscar(new TablaPersona(), new Archivo.ComparadorTuplas(
                            delegate(Tupla t)
                            {
                                Persona p = (Persona)t;
                                return p.Dni == persona.Dni && p.Id!= persona.Id;//si es igual id, es modificacion
                            }
                            ));
                        if (tupla != null)
                        {
                            baseDeDatos.abortarTransaccion(transaccion, new PersonaConDniYaExisteException().Message);
                            throw new PersonaConDniYaExisteException();
                        }


                        baseDeDatos.escribir(transaccion, new TablaPersona(), persona);
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




        /// <summary>
        /// Busca la persona indicada, hace out de null si no estaba.
        /// El return true, especifica que no hubo error, false que si lo hubo
        /// </summary>
        /// <param name="baseDeDatos">Base de datos usada</param>
        /// <param name="dni">Dni de la persona a buscar</param>
        /// <param name="persona">Aqui se devuelve la persona</param>
        /// <returns>False si hubo error, true si no lo hubo</returns>
        public Boolean buscarPersona(BaseDatos baseDeDatos, String dni, out Persona persona)
        {
            int intentos = 5;
            persona = null;
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
                        List<Object> condicion = new List<object>();
                        condicion.Add(dni);
                        baseDeDatos.bloquear(transaccion, 
                                            new CondicionPersona(0, dni), 
                                            BaseDeDatos.ControlConcurrencia.TipoBloqueo.BLOQUEO_LECTURA);
                        Tupla tupla = baseDeDatos.buscar(new TablaPersona(), new Archivo.ComparadorTuplas(
                                delegate(Tupla t)
                                {
                                    return ((Persona)t).Dni == dni;
                                }
                            ));
                        //si no estaba, retorna null, y si se castea, quiza levante error
                        if (tupla != null)
                        {
                            persona = (Persona)tupla;
                        }
                        baseDeDatos.commit(transaccion);
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
                return false;
            }
            return false;
        }



    }
}
