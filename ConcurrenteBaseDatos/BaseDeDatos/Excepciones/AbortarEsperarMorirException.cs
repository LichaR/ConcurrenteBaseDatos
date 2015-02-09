using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.BaseDeDatos.Excepciones
{
    /// <summary>
    /// Indica que se aborto la transaccion debido al protocolo Esperar-Morir
    /// </summary>
    class AbortarEsperarMorirException:Exception
    {

        public AbortarEsperarMorirException(String msg)
            :base(msg)
        {

        }

        public AbortarEsperarMorirException()
            : this("La transaccion fue abortada porque intento bloquear algo y ya estaba"+
            "bloqueado por una transaccion mas vieja. Es decir, esta es mas nueva: Protocolo: ESPERAR-MORIR")
        {

        }

    }
}
