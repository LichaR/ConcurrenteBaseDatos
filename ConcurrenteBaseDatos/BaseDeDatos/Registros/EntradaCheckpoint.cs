using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas;

namespace ConcurrenteBaseDatos.BaseDeDatos.Registros
{
    [Serializable]
    class EntradaCheckpoint:EntradaRegistro
    {
        private DateTime momento = DateTime.Now;

        internal override void anotarTransaccion(
            Registro registro,
            List<long> transaccionesAnotadas, 
            List<EntradaRegistro> entradasArecuperar)
        {
            registro.alcanzoCheckpoint();
        }

        internal override void restaurar(Registro registro)
        {
            //no hace nada
        }

        public override string ToString()
        {
            return "<CHECKPOINT, " + momento + ">";
        }

    }
}
