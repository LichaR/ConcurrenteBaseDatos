using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.BaseDeDatos.Excepciones
{
    /// <summary>
    /// Espesifica que se reinicio una transaccion que no estaba abortada
    /// </summary>
    class TransaccionNoAbortadaException:Exception
    {


        public TransaccionNoAbortadaException(String msg)
            :base(msg)
        {

        }

        public TransaccionNoAbortadaException()
            : this("La transaccion se quiere reiniciar, pero no esta abortada")
        {

        }

    }
}
