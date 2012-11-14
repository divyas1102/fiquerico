<%@ WebService Language="C#" Class="FiqueRico.BL.Service.Concurso" %>

using System;
using System.Web.Services;

namespace FiqueRico.Web
{
    /// <summary>
    /// Retorna informações sobre concursos.
    /// Anterior e Próximo concurso.
    /// </summary>
    [WebService(Namespace = "http://www.jonatanmachado.com/fiquerico/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Concurso : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}

