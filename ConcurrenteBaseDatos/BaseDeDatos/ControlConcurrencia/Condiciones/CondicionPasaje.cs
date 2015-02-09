using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;

namespace ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia.Condiciones
{
    public class CondicionPasaje : Condicion
    {

        private long idViaje;
        private DateTime fechaViaje;

        public CondicionPasaje(long idTupla, long idViaje, DateTime fechaViaje)
            :base(idTupla)
        {
            this.idViaje = idViaje;
            this.fechaViaje = fechaViaje;
        }

        public long IdViaje
        {
            get { return idViaje; }
        }

        public DateTime FechaViaje
        {
            get { return fechaViaje; }
        }


        /// <summary>
        /// Determina si esta condicion es compatible con la que viene como parametro.
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns></returns>
        internal override bool igualOmayorCondicionQue(Condicion condicion)
        {
            //distinto tipo
            if (!GetType().Equals(condicion.GetType())) { return false; }

            CondicionPasaje condCasteada = (CondicionPasaje)condicion;
            if (IdViaje != condCasteada.IdViaje || FechaViaje.Date != condCasteada.FechaViaje.Date)
            {
                //son distintos
                return false;
            }

            return true;
        }


        public override Tabla getTabla()
        {
            return new ModeloDatos.Tablas.TablaPasaje();
        }

    }
}
