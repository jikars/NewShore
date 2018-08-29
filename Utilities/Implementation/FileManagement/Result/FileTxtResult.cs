using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Implementation.FileManagement.Result
{
    /// <summary>
    /// Clase de respuesta para la lectura archivos planos
    /// </summary>
    public class FileTxtResult : FileResult
    {
        public String TextValue { get; set; }
    }
}
