using BussinesLogic.Implementation;
using BussinesLogic.Interfaces;
using DataAccess.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogicUnitTest
{
    /// <summary>
    /// Clase encarga de hacer test unitario de la capa de negocio 
    /// para la logica de cleinte newshore
    /// </summary>
    [TestClass]
    public class ClientNewshoreTest
    {

        [TestMethod]
        public void ResolveClientFromContent()
        {
            IClientNewshore clientNewshore = new ClientNewshore();
            String path = "";
            if (clientNewshore.ResolveClients("CONTENIDO.txt", "REGISTRADOS.txt", "D:\\LambdaCode\\TestDavidHerrera\\WebApplication\\"))
            {
                path = "D:\\LambdaCode\\TestDavidHerrera\\WebApplication\\RESULTADOS.txt";
            }
            Assert.IsTrue(File.Exists(path));
        }
    }
}
