using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;

namespace ConcurrenteBaseDatos.Servicios
{
    interface IPasajeService
    {


        /// <summary>
        /// Retorna la lista de pasajes como parametro de salida. El return nos dice si hubo o no error
        /// </summary>
        /// <param name="baseDeDatos">Base de datos usada</param>
        /// <param name="fecha">Fecha del pasaje reservado</param>
        /// <param name="idViaje">Id de viaje del pasaje reservado</param>
        /// <param name="pasajes">Salida, La lista de pasajes</param>
        /// <returns></returns>
        Boolean leerPasajes(BaseDatos baseDeDatos, DateTime fecha,
                            long idViaje, out List<Pasaje> pasajes);



        /// <summary>
        /// Se usa para agregar. Retorna si hubo exito o no. 
        /// Puede levantar ViajeEliminadoException
        /// </summary>
        /// <param name="baseDeDatos">Base de datos usada</param>
        /// <param name="pasaje">Pasaje a escribir</param>
        /// <param name="viaje">Viaje en la base de datos</param>
        /// <param name="persona">Persona en la base de datos</param>
        /// <returns>True si hubo exito, sino false</returns>
        Boolean escribirPasaje(BaseDatos baseDeDatos, Pasaje pasaje,
                            Viaje viaje);


    }
}
