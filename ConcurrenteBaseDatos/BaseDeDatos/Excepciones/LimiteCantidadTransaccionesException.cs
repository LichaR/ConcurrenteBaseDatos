using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.BaseDeDatos.Excepciones
{
    class LimiteCantidadTransaccionesException:Exception
    {
        private String mensage;

        public LimiteCantidadTransaccionesException(String msg)
            :base(msg)
        {
        }

        public LimiteCantidadTransaccionesException()
            :this("Limite de transacciones activas alcanzado")
        {

        }

    }
}
