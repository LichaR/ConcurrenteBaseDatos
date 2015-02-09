using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.BaseDeDatos.Registros
{
    [Serializable]
    public abstract class EntradaTransaccionRegistro:EntradaRegistro
    {

        private long transaccionId;


        public EntradaTransaccionRegistro(long transaccionId)
        {
            this.transaccionId = transaccionId;
        }


        public long TransaccionId
        {
            get { return transaccionId; }
        }

    }
}
