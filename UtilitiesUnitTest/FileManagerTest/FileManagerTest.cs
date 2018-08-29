using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities.Enums;
using Utilities.Implementation.FileManagement.Result;
using Utilities.Interface;
using Utilities.Implementation.FileManagement;

namespace UtilitiesUnitTest.FileManagerTest
{
    /// <summary>
    /// Clase de prubea unitaria para el manejo de archivos de 
    /// la libreria utilitaria de la aplicacion
    /// </summary>
    [TestClass]
    public class FileManagerTest
    {
        /// <summary>
        /// Metodo para hacer test la escritura y guardado  un archivo 
        /// sobre la librerai utilitaria
        /// </summary>
        [TestMethod]
        public void Write()
        {
            IFileManager FileManager = new FileManager();
            String fileName = "";
            byte[] arrayBytes = File.ReadAllBytes(fileName);
            String fileNameDestination = "";
            ExtencionFile extencionFile = ExtencionFile.txt;
            Assert.IsTrue(FileManager.Write(fileNameDestination, arrayBytes, extencionFile));
        }

        /// <summary>
        /// Metodo para hacer test la escritura y guardado  un archivo 
        /// sobre la librerai utilitaria
        /// </summary>
        [TestMethod]
        public void Read()
        {
            IFileManager FileManager = new FileManager();
            String fileName = "";
            ExtencionFile extencionFile = ExtencionFile.txt;
            //Manejo de genericos para el objeto de respuesta
            FileTxtResult fileResult = FileManager.Read<FileTxtResult>(fileName, extencionFile);
            Assert.IsNotNull(fileResult);
        }
    }
}
