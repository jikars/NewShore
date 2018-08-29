using DataAccess.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;
using Utilities.Enums;
using Utilities.Implementation.FileManagement.Result;
using Utilities.Interface;

namespace DataAccess.DataAccess
{
    /// <summary>
    /// Clase con la logica para resolver la busqueda de clientes
    /// basada en el contenido y los posibles clientes
    /// </summary>
    public class ClientDao : IClientDao
    {
        [Dependency]
        public IFileManager FileManager { get; set; }

        private const ExtencionFile Extencion = ExtencionFile.txt;


        /// <summary>
        /// Metodo encargado 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public IEnumerable<Client> GetClients(string path,char separator)
        {
            byte[] result =  FileManager.ReadBytesPath(path, Extencion);
            return ReadClientBytes(result, separator);
        }

        /// <summary>
        /// Metodo encargado de grabar una lista de clientes osbre un archivo
        /// </summary>
        /// <param name="clientsSave">lista de clietnes a salvar</param>
        /// <param name="fullName">nombre completo</param>
        /// <param name="separator">separador</param>
        /// <returns></returns>
        public bool SaveClients(IEnumerable<Client> clients, String fullName, char separator)
        {
            if (clients == null || clients?.Count() == 0)
            {
                return false;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(String.Join(separator.ToString(), clients.Select((c) => c.Name)));
            return  FileManager.Write(fullName, bytes, Extencion);
        }

       
        /// <summary>
        /// Metodo encargado de hacer la lectura clientes
        /// contenidos en un archivo
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public IEnumerable<Client> ReadClientBytes(byte[] bytes, char separator)
        {
            FileTxtResult result = FileManager.ReadBytes<FileTxtResult>(bytes, Extencion);
            return result.TextValue?.Trim().ToUpper().Split(separator).Select((c) => new Client() { Name = c }).ToList();
        }
    }
}
