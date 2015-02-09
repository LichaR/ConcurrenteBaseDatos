using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos;
using ConcurrenteBaseDatos.BaseDeDatos.ModeloDatos.Tablas;

namespace ConcurrenteBaseDatos.BaseDeDatos.Registros
{
    [Serializable]
    public class EntradaEscribir : EntradaTransaccionRegistro
    {
        private Tabla tabla;
        private Tupla dato;

        public EntradaEscribir(Transaccion transaccion, Tabla tabla, Tupla dato)
            :base(transaccion.Id)
        {
            this.tabla = tabla;
            this.dato = dato;
        }

        internal override void restaurar(Registro registro)
        {
            registro.Archivo.escribir(Tabla, Dato);
        }


        internal override void anotarTransaccion(Registro registro, List<long> transaccionesAnotadas, 
                                                List<EntradaRegistro> entradasArecuperar)
        {
            if (transaccionesAnotadas.Exists(x => x == TransaccionId))
            {
                entradasArecuperar.Insert(0, this);
            }
        }


        public Tabla Tabla
        {
            get { return tabla; }
        }

        public Tupla Dato
        {
            get { return dato; }
        }


        public override string ToString()
        {
            return "<ESCRIBIR, ID: " + TransaccionId +", TABLA:"+tabla.ToString()+
                ", DATO_ID:" + dato.getId() + ">";
        }


    }
}
