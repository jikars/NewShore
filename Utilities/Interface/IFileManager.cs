using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;
using Utilities.Implementation.FileManagement.Result;

namespace Utilities.Interface
{

    /// <summary>
    /// Interface contrato para exponer los metodos del 
    /// manejo de archivos
    /// </summary>
    public interface IFileManager
    {
        T Read<T>(String fullName, ExtencionFile extencion) where T : FileResult;
        Boolean Write(String fullName, byte[] bytes, ExtencionFile extencion);
        T ReadBytes<T>(byte[] bytes, ExtencionFile extencion) where T : FileResult;
        byte[] ReadBytesPath(string path, ExtencionFile extencion);
    }
}
