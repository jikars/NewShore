using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    /// <summary>
    /// Interface usada como contrato para resolver 
    /// la logica de negocio para los clientes newshore
    /// </summary>
    public interface IClientDao
    {
        /// <summary>
        /// Metodo encargado de obtener tdos los clientes
        /// </summary>
        /// <param name="path">ruta donde se encuentra el archivo de cleintes</param>
        /// <returns></returns>
        IEnumerable<Client> GetClients(String path, char separator);

        /// <summary>
        /// Metodo encargado de grabar una colleccion de cleintes en el archivo
        /// correspodniente
        /// </summary>
        /// <param name="ClientsSave">colleccion de clientes a grabar</param>
        /// <param name="separator">archivo a grabar</param>
        /// <returns></returns>
        Boolean SaveClients(IEnumerable<Client> clients,String fullName, char separator);


        /// <summary>
        /// Lee las clientes desde un arreglo bytes que contiene la inforamcion
        /// </summary>
        /// <param name="bytes">arreglo de bytes</param>
        /// <param name="separator">separador</param>
        /// <returns></returns>
        IEnumerable<Client> ReadClientBytes(byte[] bytes, char separator);

    }
}
