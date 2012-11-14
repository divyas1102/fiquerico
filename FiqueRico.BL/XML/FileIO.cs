using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Web.Configuration;

namespace FiqueRico.BL.XML
{
    public class FileIO
    {
        string caminhoDados = WebConfigurationManager.AppSettings["dados"];
               
        /// <summary>
        /// Não usar este método, utilizar a passagem de parametro para sufixo
        /// </summary>
        /// <param name="arquivo"></param>
        /// <param name="tipo"></param>
        public void Gravar(System.Xml.XmlDocument arquivo, string tipo)
        {
            FileStream file = CriarStream(tipo);
            Gravar(arquivo, file);
        }

        /// <summary>
        /// Grava XML na base.
        /// </summary>
        /// <param name="arquivo"></param>
        /// <param name="tipo"></param>
        /// <param name="sufixo"></param>
        public void Gravar(System.Xml.XmlDocument arquivo, string tipo, bool sufixo)
        {
            Gravar(arquivo, tipo, sufixo, string.Empty);
        }

        /// <summary>
        /// Grava XML na base.
        /// </summary>
        /// <param name="arquivo"></param>
        /// <param name="tipo"></param>
        /// <param name="sufixo"></param>
        public void Gravar(System.Xml.XmlDocument arquivo, string tipo, bool sufixo, string textoSufixo)
        {
            FileStream file;

            if (sufixo)
                if (string.IsNullOrEmpty(textoSufixo))
                    file = CriarStream(tipo + "_ultimo");
                else
                    file = CriarStream(tipo + textoSufixo);
            else
                file = CriarStream(tipo);

            Gravar(arquivo, file);
        }

        private void Gravar(System.Xml.XmlDocument arquivo, FileStream file)
        {
            //Create a new Buffered stream
            BufferedStream buffered = new BufferedStream(file);

            //Use a StreamWriter to write data into the buffered stream.
            StreamWriter writer = new StreamWriter(buffered);
            writer.WriteLine(arquivo.InnerXml);
            writer.Close();
        }

        /// <summary>
        /// Abre uma Stream de conexão para criar o arquivo. 
        /// </summary>
        /// <param name="nomeArquivo"></param>
        /// <returns></returns>
        private FileStream CriarStream(string nomeArquivo)
        {
            return File.Create(HttpContext.Current.Server.MapPath(caminhoDados) + nomeArquivo + ".xml");
        }

        private FileStream AbrirStream(string nomeArquivo)
        {
            return File.OpenRead(HttpContext.Current.Server.MapPath(caminhoDados) + nomeArquivo + ".xml");
        }

        public System.Xml.XmlDocument Recuperar(string tipo, bool sufixo)
        {
            return Recuperar(tipo, sufixo, string.Empty);
        }

        public System.Xml.XmlDocument Recuperar(string tipo, bool sufixo, string textoSufixo)
        {
            string nomeArquivo;
            if (sufixo)
                if (string.IsNullOrEmpty(textoSufixo))
                    nomeArquivo = tipo + "_ultimo";
                else
                    nomeArquivo = tipo + textoSufixo;
            else
                nomeArquivo = tipo.ToString();

            System.Xml.XmlDocument arquivo = new System.Xml.XmlDocument();
            arquivo.Load(HttpContext.Current.Server.MapPath(caminhoDados) + nomeArquivo + ".xml");

            return arquivo;
        }              
    }
}
