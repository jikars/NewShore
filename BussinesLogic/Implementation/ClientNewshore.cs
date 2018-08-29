using BussinesLogic.Interfaces;
using DataAccess.Implementation;
using DataAccess.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;


namespace BussinesLogic.Implementation
{
    /// <summary>
    /// Clase con la logica para resolver la busqueda de clientes
    /// basada en el contenido y los posibles clientes
    /// </summary>
    public class ClientNewshore : IClientNewshore
    {
        /// <summary>
        /// Objeto que contiene una instacia de la caba de datos
        /// para clientes
        /// </summary>
        [Dependency]
        public IClientDao ClientDao { get; set; }

        /// <summary>
        /// Objecto que contiene na instacia de la caba de datos
        /// para letras
        /// para clientes
        /// </summary>
        [Dependency]
        public ILetterDao LetterDao { get; set; }

        /// <summary>
        /// Metodo encargado de validar la existencia de clientes
        /// </summary>
        /// <param name="content">contenido del archivo con las letras alojadas</param>
        /// <param name="registedClient">contendio de los clientes que estan posiblemente registrados</param>
        /// <returns>retorna los clientes ya filtrados</returns>
        private List<Client> ResolveClientFromContent(IEnumerable<Client> clients, IEnumerable<Letter> letters)
        {
            List<char> letterCurrentMatch = new List<char>();
            var listClientsProccess = clients?.Select((c,index) => new ClientSearch() { Length = c.Name.Trim().Length, Name = c.Name.Trim(), Index = index }).ToList();
            List<Client> listResultMatch = null;

            if (listClientsProccess?.Count >0)
            {
                listResultMatch = new List<Client>(listClientsProccess.Count);
                listClientsProccess.ForEach(it => {
                    var arrayLetters = it.Name.ToList();
                    var resultMatch = "";
                    arrayLetters.ForEach(l =>
                    {
                        if (!letterCurrentMatch.Contains(l) && letters.Any(item => item.Value == l ))
                        {
                            it.LengthMatch = it.LengthMatch + it.Name.Count(x => x == l);
                            letterCurrentMatch.Add(l);
                        }
                    });
                   
                    resultMatch = it.LengthMatch == it.Length ? Constants.SYMBOL_RESULT_OK : Constants.SYMBOL_RESULT_ERROR;
                    listResultMatch.Insert(it.Index, new Client() { Name = String.Concat(it.Name, resultMatch) });
                });
                return listResultMatch;
            }

            return listResultMatch;
        }


        /// <summary>
        /// MEtodo encargado de leer y grabar un archivo 
        /// localmente
        /// </summary>
        /// <param name="contentPath"></param>
        /// <param name="registerPath"></param>
        /// <returns></returns>
        public Boolean ResolveClients(string contenFullName, string registerFullName,string pathResult)
        {
            
            if (!String.IsNullOrEmpty(contenFullName) && !String.IsNullOrEmpty(registerFullName) && !String.IsNullOrEmpty(pathResult))
            {
                var clients = ClientDao.GetClients(registerFullName, Constants.SEPARETOR_FORMAT);
                var letters = LetterDao.GetLetters(contenFullName, Constants.SEPARETOR_FORMAT);
                if (clients != null && letters != null)
                {
                    var clientResult = ResolveClientFromContent(clients, letters);
                    return SaveClients(clientResult, pathResult);
                }
            }
            return false;
        }

     

        /// <summary>
        /// Metodo encargado de grabar los clientes
        /// </summary>
        /// <param name="clientSave">clientes a grabar</param>
        /// <param name="fullName">nombre del archivo donde se va almacenar</param>
        /// <returns></returns>
        public bool SaveClients(List<Client> clientSave, string fullName)
        {
            return ClientDao.SaveClients(clientSave, fullName, Constants.SEPARETOR_FORMAT);
        }

        /// <summary>
        /// Hace la lectura de clientes a partir de un arreglo bytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public List<Client> ReadClients(byte[] bytes)
        {
            return ClientDao.ReadClientBytes(bytes, Constants.SEPARETOR_FORMAT).ToList();
        }
    }
}
