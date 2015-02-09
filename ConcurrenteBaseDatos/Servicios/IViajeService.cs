using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;

namespace ConcurrenteBaseDatos.Servicios
{
    public interface IViajeService
    {

        /// <summary>
        /// Escribe el viaje en la base de datos. Se usa para agregar o modificar
        /// </summary>
        /// <param name="baseDeDatos">Base de datos usada</param>
        /// <param name="viaje">Objeto a escribir</param>
        /// <returns>Retorna tru si hubo exito, sino false</returns>
        bool escribirViaje(BaseDatos baseDeDatos, Viaje viaje);


        /// <summary>
        /// Busca los viajes en la bbdd
        /// </summary>
        /// <param name="baseDeDatos">Base de datos usada</param>
        /// <param name="destino">Destino a buscar</param>
        /// <param name="dia">Dia de la semana</param>
        /// <returns>La lista de los viajes</returns>
        Boolean buscarLista(BaseDatos baseDeDatos, String destino,
            DiasSemana dia, Boolean incluirEliminados, out List<Viaje> viajes);





    }
}
