using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.Servicios
{
    class AsientoNoExistenteException:Exception
    {

        public AsientoNoExistenteException()
            :base("El viaje no tiene tantos asientos")
        {
        }

    }
}
