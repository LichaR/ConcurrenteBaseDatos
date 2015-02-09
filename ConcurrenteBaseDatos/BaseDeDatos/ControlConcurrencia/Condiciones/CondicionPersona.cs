using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;

namespace ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia.Condiciones
{
    public class CondicionPersona : Condicion
    {

        private String dni;

        public CondicionPersona(long idTupla, String dni)
            :base(idTupla)
        {
            this.dni = dni;
        }

        public String Dni
        {
            get { return dni; }
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

            CondicionPersona condCasteada = (CondicionPersona)condicion;
            if (Dni != condCasteada.Dni )
            {
                //son distintos
                return false;
            }

            return true;
        }


        public override Tabla getTabla()
        {
            return new ModeloDatos.Tablas.TablaPersona();
        }


    }
}
