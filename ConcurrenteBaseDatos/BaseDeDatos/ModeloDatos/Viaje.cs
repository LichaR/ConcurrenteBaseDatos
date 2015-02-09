using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos
{
    [Serializable]
    public class Viaje:Tupla
    {
        /// <summary>
        /// Usado para sincronizar el acceso a siguienteId
        /// </summary>
        private static Object semaforo_siguientiId = new Object();
        public static long siguienteId;

        private long id;
        private int cantidadAsientos;
        private TimeSpan horaPartida;
        private DiasSemana dia;
        private String destino;
        private float precio;
        private Boolean eliminado;


        public Viaje(int cantidadAsientos, TimeSpan horaPartida, DiasSemana dia, float precio,
                            String destino) 
        {
            CantidadAsientos = cantidadAsientos;
            HoraPartida = horaPartida;
            Dia = dia;
            Destino = destino;
            Precio = precio;
            Eliminado = false;
            Id = -1;//id invalido, en el mensaje asignarID, se asigna uno valido
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

        public int CantidadAsientos
        {
            get
            {
                return cantidadAsientos;
            }
            set
            {
                if (value < 0) { throw new Exception("La cantidad de asientos debe ser positivo"); }
                cantidadAsientos = value;
            }
        }

        public String Destino
        {
            get
            {
                return destino;
            }
            set
            {
                if (value == null || value =="") { throw new Exception("Debe tener un destino valido"); }
                destino = value;
            }
        }


        public float Precio
        {
            set {
               if(value < 0)
                {
                    throw new Exception("El precio debe ser positivo");
                }
                precio = value; 
            }
            get { return precio; }
        }

        public DiasSemana Dia
        {
            get
            {
                return dia;
            }
            set
            {
                if (value == null) { throw new Exception("Debe tener un dia valido"); }
                dia = value;
            }
        }

        internal Boolean Eliminado
        {
            get
            {
                return eliminado;
            }
            set
            {
                eliminado = value;
            }
        }


        public TimeSpan HoraPartida
        {
            get
            {
                return horaPartida;
            }
            set
            {
                if (value == null) { throw new Exception("Debe tener una hora valida"); }
                horaPartida = value;
            }
        }


        internal long Id
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



        public override string ToString()
        {
            return Id + " " + Destino + " " + Dia.ToString() + " " + HoraPartida.ToString();
        }
    }
}
