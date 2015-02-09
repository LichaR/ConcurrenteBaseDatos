using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia
{
    /// <summary>
    /// Representa la condicion de bloqueo de la tabla
    /// </summary>
    public abstract class Condicion
    {

        private long idTupla;

        private Condicion() { }

        public Condicion(long idTupla)
        {
            this.idTupla = idTupla;
        }

        public long IdTupla
        {
            get { return idTupla; }
        }


        /// <summary>
        /// Determina si esta condicion es compatible con la que viene como parametro.
        /// Por ahora, sin id
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns></returns>
        internal abstract bool igualOmayorCondicionQue(Condicion condicion);

        public abstract Tabla getTabla();

    }
}
