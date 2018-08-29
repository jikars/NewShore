using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.CustomException
{
    /// <summary>
    /// Clase excepcion customizada para notificar
    /// una confituracion erronea pra iniclaizar una clase
    /// </summary>
    [Serializable]
    public class CofingTypeNotSupportedException : Exception
    {
        public CofingTypeNotSupportedException()
        {
        }

        public CofingTypeNotSupportedException(string message) : base(message)
        {
        }

        public CofingTypeNotSupportedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CofingTypeNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
