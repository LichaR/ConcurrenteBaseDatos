using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia
{
    public class DescriptorBloqueo
    {

        private EntradaBloqueo entrada;
        private Transaccion transaccion;

        public DescriptorBloqueo(EntradaBloqueo entrada, Transaccion transaccion)
        {
            this.entrada = entrada;
            this.transaccion = transaccion;
        }

        public EntradaBloqueo Entrada
        {
            get { return entrada; }
        }

        public Transaccion Transaccion
        {
            get { return transaccion; }
        }


    }
}
