using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebApplication.Controllers
{
    public class ClientNewshoreServiceController : ApiController
    {

        private readonly IClientNewshoreService IServiceClientNewShore;

        public ClientNewshoreServiceController(IClientNewshoreService iServiceClientNewShore)
        {
            IServiceClientNewShore = iServiceClientNewShore;
        }

        [HttpPost]
        public HttpResponseMessage UploadFiles()
        {
            string fileNameContent = System.Configuration.ConfigurationManager.AppSettings[Constants.CONTENT_FILE_NAME];

            string fileNameRegister = System.Configuration.ConfigurationManager.AppSettings[Constants.RIGTIER_FILE_NAME];

            if (IServiceClientNewShore.UploadClientsWeb(HttpContext.Current.Request, fileNameContent, fileNameRegister, HttpContext.Current.Server.MapPath("~/")))
            {
                return Request.CreateResponse(HttpStatusCode.Created, "Created Files");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Created Error Files");
            }
        }



        [HttpPost, Route("api/ClientNewshoreService/ResultFile")]
        public HttpResponseMessage ResultFile()
        {
            string fileNameContent = System.Configuration.ConfigurationManager.AppSettings[Constants.CONTENT_FILE_NAME];

            string fileNameRegister = System.Configuration.ConfigurationManager.AppSettings[Constants.RIGTIER_FILE_NAME];

            string fileNameResult = System.Configuration.ConfigurationManager.AppSettings[Constants.RESULT_FILE_NAME];

            return IServiceClientNewShore.GetFileResult(fileNameContent, fileNameRegister, fileNameResult, HttpContext.Current.Server.MapPath("~/"));
          
        }

    }
}