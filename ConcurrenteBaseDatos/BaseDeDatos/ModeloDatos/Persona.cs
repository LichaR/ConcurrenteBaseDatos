using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos
{
    [Serializable]
    public class Persona:Tupla
    {
        /// <summary>
        /// Usado para sincronizar el acceso a siguienteId
        /// </summary>
        private static Object semaforo_siguientiId = new Object();
        public static long siguienteId = 0;

        private String nombre;
        private String apellido;
        private String dni;
        private long id;


        public Persona(String nombre, String apellido, String dni)
        {
            
            Nombre = nombre;
            Apellido = apellido;
            //Dni = dni;
            setDni(dni);

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


        public String Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (value == null || value == "") { throw new Exception("Especifique un nombre valido"); }
                nombre = value;
            }
        }

        public String Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                if (value == null || value == "") { throw new Exception("Especifique un apellido valido"); }
                apellido = value;
            }
        }

        public String Dni
        {
            get
            {
                return dni;
            }
            /*set
            {
                if (value == null || value == "") { throw new Exception("Especifique un DNI valido"); }
                if (value.Length != 8) { throw new Exception("Especifique un DNI con 8 dijitos"); }
                if (!esNumerico(value)) { throw new Exception("El DNI debe ser numerico"); }
                dni = value;
            }*/
        }

        private void setDni(String value)
        {
            if (value == null || value == "") { throw new Exception("Especifique un DNI valido"); }
            if (value.Length != 8) { throw new Exception("Especifique un DNI con 8 dijitos"); }
            if (!esNumerico(value)) { throw new Exception("El DNI debe ser numerico"); }
            dni = value;
        }

        private bool esNumerico(String dniValue)
        {
            foreach (Char caracter in dniValue)
            {
                int valor;
                if (!int.TryParse(caracter.ToString(), out valor))
                {
                    return false;
                }
            }
            return true;
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


        public override string ToString()
        {
            return Id+" "+Nombre+" "+Apellido+" "+Dni;
        }


    }
}
