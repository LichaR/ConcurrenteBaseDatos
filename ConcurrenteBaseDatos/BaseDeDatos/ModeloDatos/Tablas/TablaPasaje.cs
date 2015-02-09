using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ConcurrenteBaseDatos.BaseDeDatos.ControlConcurrencia;

namespace ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas
{
    [Serializable]
    public class TablaPasaje:Tabla
    {
        private static long siguienteIdDisponible;
        private const String NOMBRE_ARCHIVO_CONFIGURACION = "configuracionPasaje.conf";
        /// <summary>
        /// Cada persona guardada debe ocupar esta cantidad de Bytes
        /// </summary>
        public const long TAMANIO_REGISTRO = 500;

        protected override string getNombre()
        {
            return "pasajeTabla";
        }


        public override long getSiguienteIdDisponible()
        {
            return siguienteIdDisponible;
        }

        internal override long getCantidadBytesRegistros()
        {
            return TAMANIO_REGISTRO;
        }


        /// <summary>
        /// Crea el objeto condicion a partir de sus parametros
        /// </summary>
        /// <param name="condicion">idViaje, fecha</param>
        /// <returns></returns>
        public override Condicion crearCondicionBloqueo(List<object> condicion)
        {
            return new ControlConcurrencia.Condiciones.CondicionPasaje(
                0, 
                (long)condicion.ElementAt(0), 
                (DateTime)condicion.ElementAt(1));
        }


        public override void cargarUltimoId()
        {
            FileStream archivo = null;
            IFormatter formatter = new BinaryFormatter();
            int intentos = 0;
            bool exito = false;
            while (intentos < 4 && !exito)
            {
                try
                {
                    archivo = new FileStream(
                            NOMBRE_ARCHIVO_CONFIGURACION,
                            FileMode.Open,
                            FileAccess.Read,
                            FileShare.Read);
                    exito = true;
                }
                catch (FileNotFoundException)
                {
                    archivo = new FileStream(
                            NOMBRE_ARCHIVO_CONFIGURACION,
                            FileMode.Create,
                            FileAccess.Write,
                            FileShare.None);
                    long id = 0;
                    formatter.Serialize(archivo, id);
                    archivo.Close();
                }
                if (intentos >= 4) { throw new Exception("No se puede cargar el archivo"); }
                intentos++;
            }
            siguienteIdDisponible = (long)formatter.Deserialize(archivo);
            Pasaje.siguienteId = siguienteIdDisponible;
            archivo.Close();
        }



        public override void guardarUltimoId(long id)
        {
            //aca debe estar sincronizado el acceso
            FileStream archivo = new FileStream(
                            NOMBRE_ARCHIVO_CONFIGURACION,
                            FileMode.Create,
                            FileAccess.Write,
                            FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(archivo, id+1);//se guarda el siguiente disponible
            archivo.Close();
            siguienteIdDisponible = id+1;
        }




        public override string ToString()
        {
            return "Tabla pasaje";
        }


    }
}
