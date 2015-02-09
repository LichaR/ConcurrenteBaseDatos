using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas;

namespace ConcurrenteBaseDatos.BaseDeDatos.Registros
{
    [Serializable]
    class EntradaAbort : EntradaTransaccionRegistro
    {
        private String razon="Sin expesificar";

        public EntradaAbort(Transaccion transaccion, String razon)
            :base(transaccion.Id)
        {
            this.razon = razon;
        }


        internal override void anotarTransaccion(Registro registro, List<long> transaccionesAnotadas,
                                                List<EntradaRegistro> entradasArecuperar)
        {
            //no hace nada
        }

        internal override void restaurar(Registro registro)
        {
            //es la segunda pasada
        }

        public override string ToString()
        {
            return "<ABORT, ID: " + TransaccionId + ", Razon:" + razon + ">";
        }

    }
}
