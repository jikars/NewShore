using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services.Interface
{
    public interface IClientNewshoreService
    {
       /// <summary>
       /// Metodo encargado de grabar los archivos
       /// que contienen las listas de letras com las listar de
       /// clientes
       /// </summary>
       /// <param name="request">rquest http</param>
       /// <param name="fileNameContent">nombre del archivo a esperar para contenido</param>
       /// <param name="fileNameRegister">nombre del archivo a esperar para los registros</param>
       /// <param name="pathBase">ruta local donde se almacenaran los recursos</param>
       /// <returns>retorna si fue capaz de grabar los archivos necesarios o no </returns>
       bool UploadClientsWeb(HttpRequest request, string fileNameContent, string fileNameRegister,string pathBase);


        /// <summary>
        /// Metodo encargado de obtener el archivo de resultados
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
       HttpResponseMessage GetFileResult(string fileNameContent, string fileNameRegister, string pathResult, string pathBase);
        
    }
}
