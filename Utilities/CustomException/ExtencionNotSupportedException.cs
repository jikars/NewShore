using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.CustomException
{
    /// <summary>
    /// Clase Excepcion para 
    /// generar un error controlado 
    /// cuando el formato del archivo no es soportado 
    /// </summary>
    [Serializable]
    public class ExtencionNotSupportedException : Exception
    {
        public ExtencionNotSupportedException()
        {
        }

        public ExtencionNotSupportedException(string message) : base(message)
        {
        }

        public ExtencionNotSupportedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExtencionNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
