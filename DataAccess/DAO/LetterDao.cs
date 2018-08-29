using DataAccess.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Attributes;
using Utilities.Enums;
using Utilities.Implementation.FileManagement.Result;
using Utilities.Interface;

namespace DataAccess.DataAccess
{
    public class LetterDao : ILetterDao
    {
        [Dependency]
        public IFileManager FileManager { get; set; }

        private const ExtencionFile Extencion = ExtencionFile.txt;



        /// <summary>
        /// Metodo encargado de obtener las letras
        /// </summary>
        /// <param name="path"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public IEnumerable<Letter> GetLetters(string path, char separator)
        {
            byte[] result = FileManager.ReadBytesPath(path, Extencion);
            return ReadLettersBytes(result, separator);
        }

        /// <summary>
        /// Metodo encardo de grabar una coleccion de letras en un archivo
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="fullName"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public bool SaveLetters(IEnumerable<Letter> letters, string fullName, char separator)
        {
            if (letters == null || letters?.Count() == 0)
            {
                return false;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(String.Join(separator.ToString(), letters.Select((c) => c.Value.ToString()).ToList()));
            return FileManager.Write(fullName, bytes, Extencion);
        }


        /// <summary>
        /// Metodo encargado leer letras desde un arreglo de bytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public IEnumerable<Letter> ReadLettersBytes(byte[] bytes, char separator)
        {
            FileTxtResult result = FileManager.ReadBytes<FileTxtResult>(bytes, Extencion);
            return result.TextValue?.Trim().ToUpper().Replace(separator.ToString(), "").Select((c) => new Letter() { Value = c }).ToList();
        }
    }
}
