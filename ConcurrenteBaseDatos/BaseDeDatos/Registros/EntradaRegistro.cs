using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcurrenteBaseDatos.BaseDeDatos.Registros
{
    [Serializable]
    public abstract class EntradaRegistro
    {

        /// <summary>
        /// Restaura la entrada
        /// Se envia en la segunda pasada de la restauracion
        /// Si se envia el mensage, si o si debe restaurarse
        /// </summary>
        /// <param name="registro"></param>
        internal abstract void restaurar(Registro registro);

        /// <summary>
        /// Si es commit, debe anotarse en el registro para restaurarse, al igual que si es escribir
        /// Se envia en la primera pasada sobre el registro
        /// </summary>
        internal abstract void anotarTransaccion(Registro registro, List<long> transaccionesAnotadas, 
                                                List<EntradaRegistro> entradasArecuperar);

    }
}
