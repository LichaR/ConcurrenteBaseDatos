using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos.Registros;
using ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia;

namespace ConcurrenteBaseDatos.BaseDeDatos
{

    public class Transaccion: IComparable<Transaccion>
    {

        private long id;
        private EstadoTransaccion estado;
        private List<EntradaEscribir> entradas;
        private BaseDatos baseDatos;
        /// <summary>
        /// Contiene los descriptores de los bloqueos que se han pedido y realizado
        /// </summary>
        private List<DescriptorBloqueo> bloqueosRealizados = new List<DescriptorBloqueo>();

        public Transaccion(long id, BaseDatos baseDatos)
        {
            this.id = id;
            this.baseDatos = baseDatos;

            estado = EstadoTransaccion.Activa;
            entradas = new List<EntradaEscribir>();
        }



        /// <summary>
        /// Compara por tiempo ambas tranacciones.
        /// -1, this es mas vieja que el parametro ... 0, iguales  .... +1, this es mas joven que el parametro
        /// </summary>
        /// <param name="transaccion"></param>
        /// <returns>-1, this es mas vieja que el parametro ... 0, iguales  .... +1, this es mas joven que el parametro</returns>
        public int CompareTo(Transaccion transaccion)
        {
            return Id.CompareTo(transaccion.Id);
        }

        public long Id
        {
            get { return id; }
        }

        public EstadoTransaccion Estado
        {
            get { return estado; }
        }


        internal void agregarBloqueado(DescriptorBloqueo bloqueo)
        {
            bloqueosRealizados.Add(bloqueo);
        }

        /// <summary>
        /// realiza los cambios en el disco
        /// </summary>
        /// <param name="archivo"></param>
        public void guardarEn(Archivo archivo)
        {
            foreach (EntradaEscribir entr in entradas)
            {
                archivo.escribir(entr.Tabla, entr.Dato);
            }
        }
        


        public void agregarEntradaDeRegistro(EntradaEscribir entrada)
        {
            entradas.Add(entrada);
        }


        /// <summary>
        /// Este se envia por la base de datos
        /// </summary>
        /// <param name="razon">Motivo por el que se ha abortado</param>
        internal void abortar(Registro registro, String razon)
        {
            estado = EstadoTransaccion.Abortada;
            finalizarTransaccion();
            registro.abortar(this, razon);
            desbloquearTodo();
        }

        /// <summary>
        /// Este se envia por las EntradaBloqueo.
        /// <para>Este metodo termina llamando a #abortar(Registro, String)</para>
        /// </summary>
        /// <param name="razon">Motivo por el que se ha abortado</param>
        internal void abortar( String razon)
        {
            baseDatos.abortarTransaccion(this, razon);
        }



        /// <summary>
        /// Este se envia por la base de datos
        /// </summary>
        /// <param name="registro"></param>
        internal void commit(Registro registro)
        {
            estado = EstadoTransaccion.Commited;
            finalizarTransaccion();
            registro.commit(this);//guarda los cambios
            desbloquearTodo();
        }


        private void finalizarTransaccion()
        {
            baseDatos.finalizarTransaccion(this);
        }


        /// <summary>
        /// Desbloquea los elementos de la base de datos que se han bloqueado
        /// </summary>
        private void desbloquearTodo()
        {
            foreach (DescriptorBloqueo descriptor in bloqueosRealizados)
            {
                baseDatos.desbloquear(descriptor);
            }
            bloqueosRealizados.Clear();//es necesario si se aborto, y mas tarde se reinicia
        }




        public Boolean estaAbortada()
        {
            return Estado == EstadoTransaccion.Abortada;
        }

        public override string ToString()
        {
            return Id+" ->"+Estado;
        }

        internal void reiniciar()
        {
            if (Estado != EstadoTransaccion.Abortada)
            {
                throw new Excepciones.TransaccionNoAbortadaException();
            }
            //bloqueosRealizados se puso en null al abortarse
            //asi q no necesita limpiarse aqui
            estado = EstadoTransaccion.Activa;
        }


    }


    public enum EstadoTransaccion
    {
        Activa = 10,
        Abortada = 20,
        Commited = 30,
    }
}
