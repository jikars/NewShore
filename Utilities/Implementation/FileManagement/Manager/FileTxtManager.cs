using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.CustomException;
using Utilities.Enums;
using Utilities.Implementation.FileManagement.Result;
using Utilities.Interface;

namespace Utilities.Implementation.FileManagement.Manager
{
    /// <summary>
    /// Clase encargada de la lectura y escritura de archivos planos
    /// </summary>
    public class FileTxtManager : IFileManager
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="extencion"></param>
        /// <returns>retorna el objeto de repuesta</returns>
        public T Read<T>(string fullName, ExtencionFile extencion) where T : FileResult
        {
            if (typeof(T) != typeof(FileTxtResult))
            {
                throw new CofingTypeNotSupportedException();     
            }

            if (!fullName.EndsWith(extencion.ToString()))
            {
                throw new ExtencionNotSupportedException();
            }

            using (StreamReader sr = new StreamReader(fullName))
            {
                String line = sr.ReadToEnd();
                return new FileTxtResult() { Path = fullName, Extencion = extencion, TextValue = line } as T;
            }
        }

        /// <summary>
        /// Metodo encarado de hacer la lectura del texto 
        /// a partir de arreglo de bytes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <param name="extencion"></param>
        /// <returns></returns>
        public T ReadBytes<T>(byte[] bytes, ExtencionFile extencion) where T : FileResult
        {

            if (typeof(T) != typeof(FileTxtResult))
            {
                throw new CofingTypeNotSupportedException();
            }

            string line = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

            return new FileTxtResult() { Path = "", Extencion = extencion, TextValue = line } as T;
            
        }

        /// <summary>
        /// Metodo sobre escrito pero no implmentado
        /// </summary>
        /// <param name="path"></param>
        /// <param name="extencion"></param>
        /// <returns></returns>
        public byte[] ReadBytesPath(string path, ExtencionFile extencion)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Metoto encargado de grabar un archivo plano
        /// </summary>
        /// <param name="fullName">nombre completo donde sera almacenado el archivo</param>
        /// <param name="bytes">arreglo de bytes que se almacenaran</param>
        /// <param name="extencion">extencion de archivo a almacenar</param>
        /// <returns>retorna si fue o no capas de grabar</returns>
        public bool Write(string fullName, byte[] bytes, ExtencionFile extencion)
        {
            if (!fullName.EndsWith(extencion.ToString()))
            {
                throw new ExtencionNotSupportedException();
            }

            String str = Encoding.Default.GetString(bytes);
            if (!String.IsNullOrEmpty(str))
            {
                using (StreamWriter file = new StreamWriter(fullName))
                {
                    file.Write(str);
                    return true;
                }
            }
            return false;
        }
    }
}
