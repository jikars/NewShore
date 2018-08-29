using BussinesLogic.Interfaces;
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
    public class Letters : ILetters
    {
        /// <summary>
        /// Objecto que contiene na instacia de la caba de datos
        /// para letras
        /// para clientes
        /// </summary>
        [Dependency]
        public  ILetterDao LetterDao { get; set; }

        /// <summary>
        /// Metodo encargado de leer letras a partir de un arreglo bytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public List<Letter> ReadLetters(byte[] bytes)
        {
            return LetterDao.ReadLettersBytes(bytes, Constants.SEPARETOR_FORMAT).ToList();
        }

        /// <summary>
        /// Metodo encargao de grabar letras en un archivo 
        /// </summary>
        /// <param name="clientSave"></param>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public bool SaveLetters(List<Letter> clientSave, string fullName)
        {
            return LetterDao.SaveLetters(clientSave, fullName, Constants.SEPARETOR_FORMAT);
        }
    }
}
