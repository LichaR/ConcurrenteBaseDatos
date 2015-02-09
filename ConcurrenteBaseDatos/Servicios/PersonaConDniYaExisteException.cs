using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.Servicios
{
    class PersonaConDniYaExisteException:Exception
    {

        public PersonaConDniYaExisteException()
            :base("Ya hay una persona con ese DNI")
        {

        }

    }
}
