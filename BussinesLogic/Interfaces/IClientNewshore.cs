using Models;
using System;
using System.Collections.Generic;


namespace BussinesLogic.Interfaces
{
    /// <summary>
    /// Interface usada como contrato para resolver 
    /// la logica de negocio para los clientes newshore
    /// </summary>
    public interface IClientNewshore
    {

        /// <summary>
        /// Metodo encargado de validar la existencia de clientes
        /// </summary>
        /// <param name="contenFullName">ruta del archivo con las letras alojadas</param>
        /// <param name="pathResult">ruta de los clientes que estan posiblemente registrados</param>
        /// <returns>retrona si fue capaz de almacenar un archivo con los resultados</returns>
        Boolean ResolveClients(string contenFullName, string registerFullName, string pathResult);


        /// <summary>
        /// Metodo encargado de grabar los clientes
        /// en un archivo 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="fullName"></param>
        /// <returns></returns>
        Boolean SaveClients(List<Client> clientSave, String fullName);

       /// <summary>
       /// Hace la lectura de clientes a partir  del cotenido
       /// del arrelo bytes
       /// </summary>
       /// <param name="bytes">arreglo bytes</param>
       /// <returns>clientes</returns>
        List<Client> ReadClients(byte[] bytes);
    }
}
