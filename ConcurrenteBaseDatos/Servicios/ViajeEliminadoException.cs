using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.Servicios
{
    class ViajeEliminadoException:Exception
    {

        public ViajeEliminadoException()
            :base("El viaje estaba eliminado")
        {

        }

    }
}
