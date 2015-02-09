using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.BaseDeDatos
{
    public interface Tupla
    {

        long getId();

        /// <summary>
        /// Asigna el ID a la tupla, si es que no tiene uno. Este procedimiento evita que la creacion de obj consuma ID 
        /// sin ser guardados en la BBDD
        /// <para>Este mensaje enviado por la BBDD</para>
        /// </summary>
        void asignarID();
    }
}
