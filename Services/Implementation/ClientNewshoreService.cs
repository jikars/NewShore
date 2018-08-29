using BussinesLogic.Interfaces;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Unity.Attributes;

namespace Services.Implementation
{
    public class ClientNewshoreService : IClientNewshoreService
    {
        [Dependency]
        public ILetters LettersLogic { get; set; }
        
        [Dependency]
        public IClientNewshore ClientNewshoreSLogic { get; set; }


        /// <summary>
        /// Metodo encargado de subir dos ficheros 
        /// con el contenido del texto 
        /// y el cotnedio de los clientes
        /// </summary>
        /// <param name="request"></param>
        /// <param name="fileNameContent"></param>
        /// <param name="fileNameRegister"></param>
        /// <param name="pathBase"></param>
        /// <returns></returns>
        public bool UploadClientsWeb(HttpRequest request, string fileNameContent, string fileNameRegister, string pathBase)
        {
            int countFileCondition = 0;
            if (request.Files.Count > 0)
            {
                int index = 0;
                foreach (string file in request.Files)
                {
                    var postedFile = request.Files.Get(index);
                    byte[] buffer = new byte[postedFile.ContentLength];
                    postedFile.InputStream.Read(buffer, 0, postedFile.ContentLength);
                    String fullName = String.Concat(pathBase, "//", postedFile.FileName);
                    Boolean saveItem = false;
                    if (postedFile.FileName.ToUpper() == fileNameContent.ToUpper())
                    {
                        var lisletters = LettersLogic.ReadLetters(buffer);
                        fileNameContent = fullName;
                        saveItem = lisletters != null && lisletters?.Count() > 0 && LettersLogic.SaveLetters(lisletters, fullName);                  
                    }
                    else if(postedFile.FileName.ToUpper() == fileNameRegister.ToUpper())
                    {
                        var listClients = ClientNewshoreSLogic.ReadClients(buffer);
                        fileNameRegister = fullName;
                        saveItem = listClients != null && listClients?.Count() > 0 && ClientNewshoreSLogic.SaveClients(listClients, fullName);
                    }

                    if (saveItem)
                    {
                        countFileCondition++;
                    }
                    index++;
                }
            }
            return countFileCondition == 2;
        }


        /// <summary>
        /// Metodo para obtener el resultado
        /// </summary>
        /// <param name="fileNameContent"></param>
        /// <param name="fileNameRegister"></param>
        /// <param name="pathResult"></param>
        /// <param name="pathBase"></param>
        /// <returns></returns>
        public HttpResponseMessage GetFileResult(string fileNameContent, string fileNameRegister,string pathResult, string pathBase)
        {
           String  path= String.Concat(pathBase, pathResult);
            if (ClientNewshoreSLogic.ResolveClients(String.Concat(pathBase, "//", fileNameContent), String.Concat(pathBase, "//", fileNameRegister), path) && File.Exists(path))
            {
                Stream fileStream = File.Open(path, FileMode.Open);
                long fileLength = new FileInfo(path).Length;
                var response = new HttpResponseMessage
                {
                    Content = new StreamContent(fileStream)
                };
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = pathResult
                };
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response.Content.Headers.ContentLength = fileLength;
                return response;
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound
            };
        }
    }
}
