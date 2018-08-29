using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Enums;
using Utilities.Implementation.FileManagement.Manager;
using Utilities.Implementation.FileManagement.Result;
using Utilities.Interface;

namespace Utilities.Implementation.FileManagement
{
    /// <summary>
    /// Clase encargad de resolver la logica para 
    /// el manejo de archivos
    /// </summary>
    public class FileManager : IFileManager
    {

        /// <summary>
        /// Dicionario que contiene el tipo para ser instanciado 
        /// con ayuda de reflection segun el enumerable que lelgue
        /// </summary>
        private static Dictionary<ExtencionFile, Type> dictionaryResolveFile = new Dictionary<ExtencionFile, Type>()
        {
            { ExtencionFile.txt,typeof(FileTxtManager) }
        };

        /// <summary>
        /// Metodo encargado de la lectura de archivos resuleve
        /// el objeto de respuesta por medio de generics
        /// </summary>
        /// <typeparam name="T">objeto de respuesta </typeparam>
        /// <param name="fullName">name file donde se encuentra el archivo</param>
        /// <param name="extencion">extencio de archvio que se va a trabajar</param>
        /// <returns></returns>
        public T Read<T>(string fullName, ExtencionFile extencion) where T : FileResult
        {
            if (File.Exists(fullName) && dictionaryResolveFile.TryGetValue(extencion, out Type type))
            {
                //Se cra una instancia de objeto al partir del tipo 
                Object obj = Activator.CreateInstance(type);
                if (obj is IFileManager)
                {
                    return (obj as IFileManager).Read<T>(fullName, extencion);
                }
            }
            return null;
        }

        /// <summary>
        /// Metodo encargado de la lectura de un arreglo de bytes
        /// para comprender su respuesta
        /// </summary>
        /// <typeparam name="T">retorna un objeto de respuesta</typeparam>
        /// <param name="bytes"></param>
        /// <param name="extencion"></param>
        /// <returns></returns>
        public T ReadBytes<T>(byte[] bytes, ExtencionFile extencion) where T : FileResult
        {
            if (dictionaryResolveFile.TryGetValue(extencion, out Type type))
            {
                Object obj = Activator.CreateInstance(type);
                if (obj is IFileManager)
                {
                    return (obj as IFileManager).ReadBytes<T>(bytes, extencion);
                }
            }
            return null;
        }

        /// <summary>
        /// Metodo encargado de hacer la lectura de un arreglo bytes
        /// a partir de un ruta de archivo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="extencion"></param>
        /// <returns></returns>
        public byte[] ReadBytesPath(string path, ExtencionFile extencion)
        {
            byte[] arrayBytes = null;
            if (File.Exists(path) &&  dictionaryResolveFile.ContainsKey(extencion) && path.ToUpper().EndsWith(extencion.ToString().ToUpper()))
            {
                return File.ReadAllBytes(path);
            }
            return arrayBytes;
        }


        /// <summary>
        /// Graba en un archivo y resuelve la clase a implementar segun 
        /// la extencion del archivo
        /// </summary>
        /// <param name="fullName">nombre completo del archivo donde se almacenara</param>
        /// <param name="bytes">arreglo de bytes a grabar</param>
        /// <param name="extencion">extencion a grabar</param>
        /// <returns></returns>
        public bool Write(string fullName, byte[] bytes, ExtencionFile extencion)
        {
            if (dictionaryResolveFile.TryGetValue(extencion, out Type type))
            {
                Object obj = Activator.CreateInstance(type);
                if (obj is IFileManager)
                {
                    return (obj as IFileManager).Write(fullName, bytes, extencion);
                }
            }
            return false;
        }

       

        
    }
}
