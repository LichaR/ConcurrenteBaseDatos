using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas;

namespace ConcurrenteBaseDatos.BaseDeDatos.Registros
{
    [Serializable]
    public class EntradaInicio : EntradaTransaccionRegistro
    {

        public EntradaInicio(Transaccion transaccion)
            :base(transaccion.Id)
        {
        }

        internal override void restaurar(Registro registro)
        {
            //no restaura nada, es una entrada de control, no de operacion
        }

        internal override void anotarTransaccion(Registro registro, List<long> transaccionesAnotadas,
                                                List<EntradaRegistro> entradasArecuperar)
        {
            //aqui comenzo la transaccion, asi q lo que sigue no pertenece a esta transaccion
            //pero puede ser igual id, si la transaccion se reinicio alguna vez
            transaccionesAnotadas.Remove(TransaccionId);
        }

        public override string ToString()
        {
            return "<INICIO, ID: " + TransaccionId + ">";
        }

    }
}
