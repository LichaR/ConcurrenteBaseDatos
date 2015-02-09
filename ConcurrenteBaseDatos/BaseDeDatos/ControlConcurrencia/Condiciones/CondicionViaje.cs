using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;

namespace ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia.Condiciones
{
    public class CondicionViaje : Condicion
    {

        private DiasSemana dia;
        private String destino;


        public CondicionViaje(long idTupla, DiasSemana dia, String destino)
            :base(idTupla)
        {
            this.dia = dia;
            this.destino = destino;
        }

        protected internal DiasSemana Dia
        {
            get { return dia; }
        }

        protected internal String Destino
        {
            get { return destino; }
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

            CondicionViaje condCasteada = (CondicionViaje)condicion;
            if (Dia != condCasteada.Dia || Destino != condCasteada.Destino)
            {
                //son distintos
                return false;
            }

            return true;
        }



        public override Tabla getTabla()
        {
            return new ModeloDatos.Tablas.TablaViaje();
        }

    }
}
