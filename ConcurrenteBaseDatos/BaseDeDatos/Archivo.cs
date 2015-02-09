using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas;
using System.Collections;

namespace ConcurrenteBaseDatos.BaseDeDatos
{
    public class Archivo
    {
        
        private Object semaforoInsertar = new Object();

        public Archivo()
        {
            //debe buscar el maximo id de cada tabla que ha sido usado
            new TablaPersona().cargarUltimoId();
            new TablaPasaje().cargarUltimoId();
            new TablaViaje().cargarUltimoId();
        }




        public void escribir(Tabla tabla, Tupla dato)
        {
            FileStream archivo =null;
            //archivos.TryGetValue(tabla.getArchivo(), out archivo);
            archivo = new FileStream(tabla.getArchivo(),
                                        FileMode.OpenOrCreate,
                                        FileAccess.ReadWrite,
                                        FileShare.ReadWrite);
            IFormatter formatter = new BinaryFormatter();
            if(dato.getId() >= tabla.getSiguienteIdDisponible())
            {
                //es id nuevo, inserta
                lock (semaforoInsertar)
                {
                    archivo.Position = archivo.Length;
                    long posicionAnterior = archivo.Position;
                    tabla.guardarUltimoId(dato.getId());
                    formatter.Serialize(archivo, dato);
                    //cada registro ocupa un maximo (Es estatico, si no hago esto es dinamico)
                    //asi q agrego tantos byte como falten
                    long cantidadQuefalta = tabla.getCantidadBytesRegistros() - (archivo.Position - posicionAnterior);
                    archivo.Write(new byte[cantidadQuefalta], 0, (int)cantidadQuefalta);
                }
                
            }
            else
            {
                //modificacion
                Tupla t = null;
                //si o si va a estar, pues se usa borrado logico
                //pero puede no estar, si se está haciendo restauracion
                long posicion = 0;
                if (archivo.Position < archivo.Length)
                {
                    posicion = archivo.Position;
                    t = leerYavanzar(archivo, tabla);
                }
                
                while (archivo.Position<archivo.Length && t.getId() != dato.getId())
                {
                    posicion = archivo.Position;
                    t = leerYavanzar(archivo, tabla);
                }
                
                if (t==null || t.getId() != dato.getId())
                {
                    //no estaba
                    posicion = archivo.Length;
                    lock (semaforoInsertar)//lock para insertar
                    {
                        long posicionAnterior = archivo.Position;
                        formatter.Serialize(archivo, dato);
                        //cada registro ocupa un maximo (Es estatico, si no hago esto es dinamico)
                        //asi q agrego tantos byte como falten
                        long cantidadQuefalta = tabla.getCantidadBytesRegistros() -
                                            (archivo.Position - posicionAnterior);
                        archivo.Write(new byte[cantidadQuefalta], 0, (int)cantidadQuefalta);
                    }
                }
                else
                {
                    //estaba
                    archivo.Position = posicion;

                    long posicionAnterior = archivo.Position;
                    formatter.Serialize(archivo, dato);
                    //cada registro ocupa un maximo (Es estatico, si no hago esto es dinamico)
                    //asi q agrego tantos byte como falten
                    long cantidadQuefalta = tabla.getCantidadBytesRegistros() -
                                        (archivo.Position - posicionAnterior);
                    archivo.Write(new byte[cantidadQuefalta], 0, (int)cantidadQuefalta);
                }
            }
            
            archivo.Flush();
            archivo.Close();
            //archivo.Position = 0;
        }



        private Tupla leerYavanzar(FileStream archivo, Tabla tabla )
        {
            IFormatter formatter = new BinaryFormatter();
            long posAnterior = archivo.Position;
            try
            {
                Tupla t = (Tupla)formatter.Deserialize(archivo);
                long meMovi = archivo.Position - posAnterior;
                archivo.Position += tabla.getCantidadBytesRegistros() - meMovi;
                return t;
            }
            catch (SerializationException e)
            {
                //si entro aqui, estoy leyendo algo que se está escribiendo
                //asi que de seguro no es un registro que busco. Me lo garantiza
                //es control de bloqueo. Lo que yo leo, no se está modificando.

                archivo.Position = posAnterior + tabla.getCantidadBytesRegistros();//abanzo al siguiente registro
                return null;
            }
        }




        public Tupla buscar(Tabla tabla, ComparadorTuplas comparador)
        {
            FileStream archivo = null;
            //archivos.TryGetValue(tabla.getArchivo(), out archivo);
            archivo = new FileStream(tabla.getArchivo(),
                                        FileMode.OpenOrCreate,
                                        FileAccess.ReadWrite,
                                        FileShare.ReadWrite);
            IFormatter formatter = new BinaryFormatter();
            bool encontre = false;
            Tupla tupla = null;
            while (archivo.Position < archivo.Length && !encontre)
            {
                //Tupla aux = (Tupla)formatter.Deserialize(archivo);
                Tupla aux = leerYavanzar(archivo, tabla);
                if (aux!=null && comparador(aux))
                {
                    tupla = aux;
                    encontre = true;
                }
            }
            archivo.Close();
            //archivo.Position = 0;
            return tupla;
        }


        public List<Tupla> leerLista(Tabla tabla, ComparadorTuplas comparador)
        {
            FileStream archivo = null;
            //archivos.TryGetValue(tabla.getArchivo(), out archivo);
            archivo = new FileStream(tabla.getArchivo(),
                                        FileMode.OpenOrCreate,
                                        FileAccess.ReadWrite,
                                        FileShare.ReadWrite);
            IFormatter formatter = new BinaryFormatter();
            List<Tupla> lista = new List<Tupla>();
            while (archivo.Position < archivo.Length)
            {
                //Tupla aux = (Tupla)formatter.Deserialize(archivo);
                Tupla aux = leerYavanzar(archivo, tabla);
                if (aux != null && comparador(aux))
                {
                    lista.Add(aux);
                }
            }
            archivo.Close();
            //archivo.Position = 0;
            return lista;
        }




        /// <summary>
        /// Delegado para comparar personas
        /// </summary>
        /// <param name="per1"></param>
        /// <param name="per2"></param>
        /// <returns></returns>
        public delegate bool ComparadorTuplas(Tupla per2);

    }
}
