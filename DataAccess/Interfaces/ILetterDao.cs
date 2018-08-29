using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ILetterDao
    {
        /// <summary>
        /// Metodo encargdo de obtener todas las letras
        /// para la busqueda de registro de clientes
        /// </summary>
        /// <param name="path"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        IEnumerable<Letter> GetLetters(String path, char separator);


        /// <summary>
        /// Metodo encargado de grabar una colleccion de letras en el archivo
        /// correspodniente
        /// </summary>
        /// <param name="ClientsSave">colleccion de clientes a grabar</param>
        /// <param name="separator">archivo a grabar</param>
        /// <returns></returns>
        Boolean SaveLetters(IEnumerable<Letter> letters, String fullName, char separator);


        /// <summary>
        /// Lee las letras desde un arreglo bytes que contiene la inforamcion
        /// </summary>
        /// <param name="bytes">arreglo de bytes</param>
        /// <param name="separator">separador</param>
        /// <returns></returns>
        IEnumerable<Letter> ReadLettersBytes(byte[] bytes, char separator);
    }
}
