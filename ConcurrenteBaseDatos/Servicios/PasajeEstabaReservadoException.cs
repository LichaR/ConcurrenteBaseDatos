using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.Servicios
{
    public class PasajeEstabaReservadoException:Exception
    {

        public PasajeEstabaReservadoException()
            :base("El pasaje ya estaba reservado")
        {
        }

    }
}
