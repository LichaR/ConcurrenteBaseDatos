using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas;

namespace ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia
{
    internal class ControladorConcurrencia
    {

        private List<EntradaBloqueo> entradas = new List<EntradaBloqueo>();



        /// <summary>
        /// Puede levantar AbortarEsperarMorirException debido al protocolo Esperar-Morir
        /// </summary>
        /// <param name="transaccion">Transaccion que solicita el bloqueo</param>
        /// <param name="condiciones">Condiciones por la que bloquear</param>
        /// <param name="tipoBloqueo">Tipo de bloqueo que solicita</param>
        /// <returns></returns>
        internal DescriptorBloqueo bloquear(Transaccion transaccion,
                                Condicion condicion, TipoBloqueo tipoBloqueo)
        {
            lock (Entradas)
            {
                foreach (EntradaBloqueo entrada in Entradas)
                {
                    if (entrada.igualCondicion(condicion))
                    {
                        if (entrada.permiteBloqueo(condicion, tipoBloqueo))
                        {
                            return entrada.bloquear(transaccion, tipoBloqueo);
                        }
                        entrada.encolarBloqueo(transaccion); //-> aqui puede leventar exception por protocolo esperar morir
                        while ((entrada.Bloqueado
                            && !entrada.permiteBloqueo(condicion, tipoBloqueo))
                            || !entrada.desencolarSiEsElSiguiente(transaccion))
                        {
                            Monitor.Wait(entradas);
                        }
                        if (tipoBloqueo == TipoBloqueo.BLOQUEO_LECTURA)
                        {
                            Monitor.PulseAll(entradas);//porque no eran los primeros, se volvieron a bloquear
                        }
                        return entrada.bloquear(transaccion, tipoBloqueo);
                    }
                }
                //no estaba la entrada
                EntradaBloqueo nuevaEntrada = new EntradaBloqueo(this, tipoBloqueo, condicion);
                Entradas.Add(nuevaEntrada);
                return nuevaEntrada.bloquear(transaccion, tipoBloqueo);
            }
        }



        internal void desbloquear(DescriptorBloqueo descriptorBloqueo)
        {
            lock (Entradas)
            {
                descriptorBloqueo.Entrada.desbloquear(descriptorBloqueo.Transaccion);
            }
        }


        internal List<EntradaBloqueo> Entradas
        {
            get { return entradas; }
        }


    }
}
