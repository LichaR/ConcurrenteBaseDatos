using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas;

namespace ConcurrenteBaseDatos.BaseDeDatos.Registros
{
    [Serializable]
    class EntradaCommit : EntradaTransaccionRegistro
    {

        public EntradaCommit(Transaccion transaccion)
            :base(transaccion.Id)
        {
        }

        internal override void anotarTransaccion(Registro registro, List<long> transaccionesAnotadas,
                                                List<EntradaRegistro> entradasArecuperar)
        {
            //se anota si no alcanzo ya el checkpoint
            if (!registro.CheckpointAlcanzado)
            {
                transaccionesAnotadas.Add(TransaccionId);
            }
        }

        internal override void restaurar(Registro registro)
        {
            //es la segunda pasada
        }

        public override string ToString()
        {
            return "<COMMIT, ID: " + TransaccionId + ">";
        }

    }
}
