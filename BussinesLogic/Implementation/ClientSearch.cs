using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    internal class ClientSearch
    {
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Longitud total
        /// </summary>
        public int Length { get; set; }


        /// <summary>
        /// Posicion en donde se encuentra el cliente
        /// </summary>
        public int  Index { get; set; }


        /// <summary>
        /// variable encargada de la cantidad de caracteres que cumplietron con el
        /// match
        /// </summary>
        public int LengthMatch { get; set; }

    }
}
