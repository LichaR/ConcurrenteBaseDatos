using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia;

namespace ConcurrenteBaseDatos.BaseDeDatos
{
    [Serializable]
    public abstract class Tabla
    {

        protected static String extensionArchivo = ".ccbd";//concurrente base datos 

        protected abstract String getNombre();

        /// <summary>
        /// Retorna el nombre del archivo que reprenta la tabla
        /// </summary>
        /// <returns></returns>
        public String getArchivo()
        {
            return getNombre() + extensionArchivo;
        }

        public abstract Condicion crearCondicionBloqueo(List<Object> condicion);
        public abstract long getSiguienteIdDisponible();
        internal abstract long getCantidadBytesRegistros();

        /// <summary>
        /// configura el ultimo ID, se envia antes de usar la bbdd
        /// </summary>
        public abstract void cargarUltimoId();

        public abstract void guardarUltimoId(long id);

    }
}
