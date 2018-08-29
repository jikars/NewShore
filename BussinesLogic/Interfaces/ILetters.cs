using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Interfaces
{
    public interface ILetters
    {

        /// <summary>
        /// Metodo encargado de grabar los letras
        /// en un archivo 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="fullName"></param>
        /// <returns></returns>
        Boolean SaveLetters(List<Letter> clientSave, String fullName);

        /// <summary>
        /// Hace la lectura de letras a partir  del cotenido
        /// del arrelo bytes
        /// </summary>
        /// <param name="bytes">arreglo bytes</param>
        /// <returns>clientes</returns>
        List<Letter> ReadLetters(byte[] bytes);
    }
}
