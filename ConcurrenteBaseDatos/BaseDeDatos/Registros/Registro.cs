using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConcurrenteBaseDatos.BaseDeDatos.Registros
{
    public class Registro
    {
        /// <summary>
        /// Intervalo en milisegundos para poner checkpoints
        /// </summary>
        public const int INTERVALO_ENTRE_CHECKPOINT = 10000;

        /// <summary>
        /// <para>Nombre del archivo de registro original</para>
        /// </summary>
        public const String NOMBRE_ARCHIVO=  "archivoRegistro.Registro";

        /// <summary>
        /// <para>Nombre con el que se guarda el registro probisoriamente</para>
        /// <para>Luego se elimina el otro, y este se renombra como NOMBRE_ARCHIVO</para>
        /// </summary>
        public const String NOMBRE_RESPALO = Registro.NOMBRE_ARCHIVO + "-back";

        private List<EntradaRegistro> entradas = new List<EntradaRegistro>();

        private Boolean checkpointAlcanzado = false;
        private Archivo archivo = new Archivo();

        private Thread hiloAgregaCheckpoint;

        public void escribirEnRegistro(Transaccion transaccion, Tabla tabla, Tupla dato)
        {
            lock (entradas)
            {
                EntradaRegistro ent = new EntradaEscribir(transaccion, tabla, dato);
                entradas.Add(ent);

                transaccion.agregarEntradaDeRegistro((EntradaEscribir)ent);

            }
        }

        /// <summary>
        /// Agrega la entrada de Checkpoint
        /// </summary>
        public void agregarCheckpoint()
        {
            lock (entradas)
            {
                //si el ultimo fue un checkpoint, no agrego otro, porque seria en bano
                if (entradas.Count>0 && !entradas.ElementAt(entradas.Count - 1).GetType().Equals(new EntradaCheckpoint().GetType()))
                {
                    entradas.Add(new EntradaCheckpoint());
                    limpiarRegistro();
                    bajarAdisco();
                }
            }
        }


        /// <summary>
        /// Borra las entradas q no son necesarias
        /// </summary>
        private void limpiarRegistro()
        {
            
        }



        public void commit(Transaccion transaccion)
        {
            lock (entradas)
            {
                entradas.Add(new EntradaCommit(transaccion));
                bajarAdisco();
                //evita q se agreguen checkpoint antes de que se baje
                //por eso está dentro del bloque
                guardarTransaccion(transaccion);
            }    
        }


        /// <summary>
        /// Agrega la entrada de abortar
        /// </summary>
        /// <param name="transaccion"></param>
        /// <param name="razon">Motvo del aborto de la transaccion</param>
        public void abortar(Transaccion transaccion, String razon)
        {
            lock (entradas)
            {
                entradas.Add(new EntradaAbort(transaccion, razon));
                bajarAdisco();
                
            }   
        }


        /// <summary>
        /// Agrega la entrada de inicio de transaccion
        /// </summary>
        /// <param name="transaccion"></param>
        public void iniciarTransaccion(Transaccion transaccion)
        {
            lock (entradas)
            {
                entradas.Add(new EntradaInicio(transaccion));
            }
        }


        /// <summary>
        /// Baja a disco el archivo Registro. Debe sincronizarse este metodo
        /// </summary>
        private void bajarAdisco()
        {
            FileStream sw = null;
            int intentos = 0;
            bool exito = false;
            while (!exito && intentos < 5)
            {
                bool abierto = false;
                try
                {
                    //baja a disco en un archivo de respaldo
                    sw = new FileStream(Registro.NOMBRE_RESPALO, FileMode.Create);//pisa el archivo, si existe
                    abierto = true;
                    IFormatter formatter = new BinaryFormatter();

                    formatter.Serialize(sw, entradas);
                    exito = true;
                }
                catch (IOException ex)
                {
                    intentos++;
                    if (intentos >= 5) { throw ex; }
                }
                finally 
                {
                    if (abierto) { sw.Close(); }
                }
            }
            //ahora borra el original, y renombra el nuevo
            try
            {
                if (File.Exists(Registro.NOMBRE_ARCHIVO))
                {
                    File.Delete(Registro.NOMBRE_ARCHIVO);
                }
                File.Move(Registro.NOMBRE_RESPALO, Registro.NOMBRE_ARCHIVO);
            }
            catch (IOException e)
            {
            }
        }




        private void guardarTransaccion(Transaccion transaccion)
        {
            transaccion.guardarEn(Archivo);
        }






        /// <summary>
        /// <para>Aqui no sincronizo, porque esto se hace antes de que arranque la base de datos</para>
        /// <para>La base de datos se encarga de que esté sincronizado</para>
        /// </summary>
        public void restaurarDesdeRegistro()
        {
            levantarDesdeDisco();//carga el registro
            int indice = entradas.Count - 1;
            checkpointAlcanzado = false;

            //si la transaccion se reinicio, debe considerarse el ultimo intento
            //asi q los primeros intentos (Abortados), deben ignorarse
            List<EntradaRegistro> entradasArecuperar = new List<EntradaRegistro>();
            List<long> transaccionesAnotadas = new List<long>();

            //hay que alcanzar la entrada de inicio de cada transaccion
            while(indice >=0 && (!checkpointAlcanzado || transaccionesAnotadas.Count>0))
            {
                entradas.ElementAt(indice).anotarTransaccion(this, transaccionesAnotadas, entradasArecuperar);
                indice--;
            }

            //ahora restaura
            indice=0;//inicia
            while (indice < entradasArecuperar.Count)
            {
                entradasArecuperar.ElementAt(indice).restaurar(this);

                indice++;
            }
            //Ahora debe borrarse el registro de la ram,
            //para q no haya transacciones con == id
            entradas.Clear();
            arrancarHilo();//arranca el threads que genera checkpoints
        }


        internal Archivo Archivo
        {
            get { return archivo; }
        }


        private void levantarDesdeDisco()
        {
            String nombre = getNombreArchivoAlevantar();
            if (nombre != "")
            {
                FileStream file = null;
                bool abierto = false;
                try
                {
                    file = new FileStream(nombre, FileMode.Open, FileAccess.Read);
                    abierto = true;
                    IFormatter formatter = new BinaryFormatter();

                    entradas = (List<EntradaRegistro>)formatter.Deserialize(file);
                }
                catch (IOException e)
                {
                }
                finally
                {
                    if (abierto) { file.Close(); }
                }
            }
        }



        /// <summary>
        /// Devuelve el nombre del archivo de registro, o vacio en caso de no existir
        /// </summary>
        /// <returns>Nombre del archivo, vacio en caso de no haber</returns>
        private String getNombreArchivoAlevantar()
        {
            String nombreArchivo = "";
            //intenta levantar el original, sono el backup, sino no levanta ninguno
            //el backup existe solo en el momento en que se baja el registro,
            //si se corta la luz en ese momento, solo se utiliza el original,
            //por si el backup esta corrupto
            if (File.Exists(Registro.NOMBRE_ARCHIVO))
            {
                nombreArchivo = Registro.NOMBRE_ARCHIVO;
            }
            else
            {
                if (File.Exists(Registro.NOMBRE_RESPALO))
                {
                    nombreArchivo = Registro.NOMBRE_RESPALO;
                    File.Move(Registro.NOMBRE_RESPALO, Registro.NOMBRE_ARCHIVO);//lo renombra como principal
                }
            }
            return nombreArchivo;
        }



        /// <summary>
        /// Usado por la entrada checkpoint para cortar el loop de la restauracion
        /// </summary>
        internal void alcanzoCheckpoint()
        {
            checkpointAlcanzado = true;
        }


        /// <summary>
        /// Detiene el threads y baja el registro a disco
        /// </summary>
        internal void finalizar()
        {
            hiloAgregaCheckpoint.Abort();
            hiloAgregaCheckpoint.Join();//espero a que aborte por completo
            lock (entradas)
            {
                bajarAdisco();
            }
        }

        internal Boolean CheckpointAlcanzado
        {
            get { return checkpointAlcanzado; }
        }



        #region ThreadsQueAgregaCheckpoint

        private void arrancarHilo()
        {
            hiloAgregaCheckpoint = new Thread(new ParameterizedThreadStart(
                delegate(Object parametro)
                {
                    try
                    {
                        Registro registro = (Registro)parametro;
                        while (true)
                        {
                            Thread.Sleep(INTERVALO_ENTRE_CHECKPOINT);
                            registro.agregarCheckpoint();
                        }
                    }
                    catch (ThreadAbortException)
                    {
                        //se aborta, no hace nada
                    }
                }

                ));
            hiloAgregaCheckpoint.Start(this);//envio el registro
        }

        #endregion



        /// <summary>
        /// Retorna una copia de las entradas hasta el momento.
        /// <para>Este metodo bloque "entradas"</para>
        /// <para>Solo lo llama el Registro view</para>
        /// </summary>
        public List<EntradaRegistro> EntradasRegistro
        {
            get
            {
                lock (entradas)
                {
                    return new List<EntradaRegistro>(entradas);//retorna una copia
                }
            }

        }






    }
}
