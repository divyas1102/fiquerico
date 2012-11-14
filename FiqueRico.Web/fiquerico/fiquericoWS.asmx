<%@ WebService Language="C#" Class="FiqueRico.Web.fiquerico.fiquericoWS" %>

using System;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using FiqueRico.BL;

namespace FiqueRico.Web.fiquerico
{
    [WebService(Namespace = "http://www.jonatanmachado.com/fiquerico/fiquerico/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class fiquericoWS : System.Web.Services.WebService
    {
        Jogo jogo = new BL.Jogo();
        Resultado resultado = new BL.Resultado();

        [WebMethod]
        public string DataHora()
        {
            return DateTime.Now.ToString();
        }
        
        [WebMethod]
        public Jogo HelloWorld()
        {
            this.jogo = this.resultado.PegarUltimoConcurso(TipoJogo.Megasena);
            return this.jogo;
            //CarregarMegasena();
            //return new System.Collections.Generic.List<string>() { "fds", "ss", "aaa", "gg" };
            //return "HelloWorld";
        }
        [WebMethod()]
        [ScriptMethod(UseHttpGet = true,  ResponseFormat = ResponseFormat.Json)]
        public Jogo RecuperarConcurso(string tipoJogo, string numConcurso)
        {
            //string tipoJogo = HttpContext.Current.Request.QueryString["tipoJogo"];
            //string numConcurso = HttpContext.Current.Request.QueryString["numConcurso"];
             
            if (string.IsNullOrEmpty(tipoJogo))
                return null;

            //TipoJogo tipo = (TipoJogo)Enum.Parse(typeof(TipoJogo), tipoJogo, true);
            TipoJogo tipo;
            if (!Enum.TryParse<TipoJogo>(tipoJogo, true, out tipo))
                return null;

            if (string.IsNullOrEmpty(numConcurso) || numConcurso.Equals("0"))
                return this.resultado.PegarUltimoConcurso(tipo);

            int num;
            if (int.TryParse(numConcurso, out num))
                return this.resultado.PegarConcursoLocal(tipo, num);

            return null;
        }

        [WebMethod]
        public Jogo Teste()
        {
            string tipoJogo = "megasena";
            System.Threading.Thread.Sleep(4000);
            TipoJogo tipo = (TipoJogo)Enum.Parse(typeof(TipoJogo), tipoJogo, true);
            this.jogo = this.resultado.PegarUltimoConcurso(tipo);
            return this.jogo;
        }
    }
}