using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos
{
    [Serializable]
    public class Pasaje:Tupla
    {
        /// <summary>
        /// Usado para sincronizar el acceso a siguienteId
        /// </summary>
        private static Object semaforo_siguientiId = new Object();
        public static long siguienteId = 0;

        private long id;
        private DateTime fechaReserva;
        private int numeroAsiento;
        private Boolean cancelado;
        private long idViaje;
        private long idPersona;
        private DateTime fechaViaje;


        public Pasaje(long idViaje, long idPersona, DateTime fechaViaje, int numeroAsiento)
        {
            Cancelado = false;

            Id = -1;//id invalido, en el mensaje asignarID, se asigna uno valido
            fechaReserva = DateTime.Now;
            IdViaje = idViaje;
            IdPersona = idPersona;
            NumeroAsiento = numeroAsiento;
            FechaViaje = fechaViaje;
        }


        /// <summary>
        /// Asigna el ID a la tupla, si es que no tiene uno. Este procedimiento evita que la creacion de obj consuma ID 
        /// sin ser guardados en la BBDD
        /// <para>Este mensaje enviado por la BBDD</para>
        /// </summary>
        public void asignarID()
        {
            if (id < 0)//si es mayor a 0, ya tiene id valido
            {
                lock (semaforo_siguientiId)
                {
                    id = siguienteId;
                    siguienteId++;
                }
            }
        }


        public long getId()
        {
            return Id;
        }


        public long Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public Boolean Cancelado
        {
            get
            {
                return cancelado;
            }
            set
            {
                cancelado = value;
            }
        }

        public DateTime FechaReserva
        {
            get
            {
                return fechaReserva;
            }
            set
            {
                fechaReserva = value;
            }
        }

        public DateTime FechaViaje
        {
            get
            {
                return fechaViaje;
            }
            set
            {
                fechaViaje = value.Date;
            }
        }

        public long IdPersona
        {
            get
            {
                return idPersona;
            }
            set
            {
                idPersona = value;
            }
        }

        public long IdViaje
        {
            get
            {
                return idViaje;
            }
            set
            {
                idViaje = value;
            }
        }

        public int NumeroAsiento
        {
            get
            {
                return numeroAsiento;
            }
            set
            {
                numeroAsiento = value;
            }
        }



        public override string ToString()
        {
            return Id + "  idPersona:" + IdPersona + "  idViaje:" + IdViaje + " " + FechaViaje.ToString();
        }
    }
}
