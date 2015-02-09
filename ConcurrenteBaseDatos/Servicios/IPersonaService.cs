using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;

namespace ConcurrenteBaseDatos.Servicios
{
    interface IPersonaService
    {

        /// <summary>
        /// Escribe la persona en la base de datos (Agrega o modifica)
        /// </summary>
        /// <param name="baseDeDatos">Base de datos usada</param>
        /// <param name="persona">Persona que se escribira</param>
        /// <returns>True si hubo exito, false en caso contrario</returns>
        Boolean escribirPersona(BaseDatos baseDeDatos, Persona persona);



        /// <summary>
        /// Busca la persona indicada
        /// </summary>
        /// <param name="baseDeDatos">Base de datos usada</param>
        /// <param name="dni">Dni de la persona a buscar</param>
        /// <param name="persona">Aqui se devuelve la persona</param>
        /// <returns>False si hubo error, true si no lo hubo</returns>
        Boolean buscarPersona(BaseDatos baseDeDatos, String dni, out Persona persona);



    }
}
