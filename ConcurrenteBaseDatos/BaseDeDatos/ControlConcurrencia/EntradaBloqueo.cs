using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia.Condiciones;

namespace ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia
{
    public class EntradaBloqueo
    {

        private TipoBloqueo tipo;
        private Boolean bloqueado = false;
        private Condicion condicion;
        private ControladorConcurrencia controladorConcurrencia;
        
        /// <summary>
        /// Lista de transacciones que bloquean la entrada
        /// </summary>
        private List<Transaccion> bloqueados = new List<Transaccion>();//si es lectura, puede tener mas de 1
        /// <summary>
        /// Lista de transacciones que esperan por el bloqueo
        /// </summary>
        private List<Transaccion> colaEspera = new List<Transaccion>();


        private EntradaBloqueo(){}

        internal EntradaBloqueo(ControladorConcurrencia controladorConcurrencia,
                                TipoBloqueo tipo, Condicion condicion)
        {
            this.controladorConcurrencia = controladorConcurrencia;
            this.tipo = tipo;
            this.condicion = condicion;
        }


        internal Boolean Bloqueado
        {
            get { return bloqueado; }
        }

        internal Condicion Condicion
        {
            get { return condicion; }
        }
        internal TipoBloqueo Tipo
        {
            get { return tipo; }
        }

        internal Boolean igualCondicion(Condicion condicion)
        {
            return Condicion.igualOmayorCondicionQue(condicion);
        }

        internal List<Transaccion> ColaEspera
        {
            get { return colaEspera; }
        }



        /// <summary>
        /// Retorna la transaccion mas antigua de las que estan bloqueando.
        /// Puede Haber mas de una si se bloqueo en lectura, por eso la mas antigua
        /// </summary>
        /// <returns></returns>
        private Transaccion getMasAntigua()
        {
            bloqueados.Sort(delegate(Transaccion t1, Transaccion t2)
            {
                return t1.CompareTo(t2);
            }
            );
            return bloqueados.ElementAt(0);
        }


        internal Boolean permiteBloqueo(Condicion condicion, TipoBloqueo tipo)
        {
            if (igualCondicion(condicion) && Bloqueado)
            {
                //si alguno de los 2 es de escritura, no se puede
                if (this.Tipo == TipoBloqueo.BLOQUEO_ESCRITURA || tipo == TipoBloqueo.BLOQUEO_ESCRITURA )
                {
                    return false;
                }
            }
            //distina condicion, o ambos de lectura
            return true;
        }


        internal void encolarBloqueo(Transaccion transaccion)
        {
            //el parametro debe ser mas viejo para poder bloquear y esperar
            //PROTOCOLO: ESPERAR-MORIR
            if (transaccion.CompareTo(getMasAntigua()) >= 0 )
            {
                //no me permite bloquear, asi q hay q abortar
                
                transaccion.abortar(new Excepciones.AbortarEsperarMorirException().Message);
                throw new Excepciones.AbortarEsperarMorirException();
            }
            ColaEspera.Add(transaccion);
        }

        internal Boolean desencolarSiEsElSiguiente(Transaccion transaccion)
        {

            if (ColaEspera.ElementAt(0).Equals(transaccion))
            {
                ColaEspera.Remove(transaccion);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Bloquea para esa transaccion, debe controlarse antes de llamar a este mensaje
        /// </summary>
        /// <param name="transaccion"></param>
        internal DescriptorBloqueo bloquear(Transaccion transaccion, TipoBloqueo tipo)
        {
            //este control es por las dudas
            if (Tipo == TipoBloqueo.BLOQUEO_ESCRITURA && 
                Bloqueado) { throw new Exception("Ya estaba bloqueado como escritura"); }

            bloqueado = true;
            this.tipo = tipo;
            bloqueados.Add(transaccion);
            DescriptorBloqueo descriptor = new DescriptorBloqueo(this, transaccion);
            transaccion.agregarBloqueado(descriptor);
            return descriptor;

        }


        internal void desbloquear(Transaccion transaccion)
        {
            if (!Bloqueado) { throw new Exception("No estaba bloqueado"); }
            if (!bloqueados.Remove(transaccion))
            {
                //no estaba
                throw new Exception("Alguien que no debe ("
                                    +transaccion.ToString()+
                                    ") ha desbloqueado esto");
            }


            if (Tipo == TipoBloqueo.BLOQUEO_LECTURA)
            {
                if (bloqueados.Count == 0)//no hay nadie en espera
                {
                    bloqueado = false;
                    if (ColaEspera.Count == 0)
                    {
                        //remover de la tabla
                        controladorConcurrencia.Entradas.Remove(this);
                    }
                    else
                    {
                        //pull all
                        Monitor.PulseAll(controladorConcurrencia.Entradas);
                    }
                }
            }
            else
            {
                //bloqueo_escritura
                bloqueado = false;
                if (ColaEspera.Count == 0)
                {
                    //remover de la tabla
                    controladorConcurrencia.Entradas.Remove(this);
                }
                else
                {
                    //pull all
                    Monitor.PulseAll(controladorConcurrencia.Entradas);
                }
            }

        }


    }
}
