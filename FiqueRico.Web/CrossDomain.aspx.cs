using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace FiqueRico.Web
{
    public partial class CrossDomain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var concurso = Request.Params["concurso"];
            var concurso = Request.QueryString["concurso"];

            if (concurso.Equals("Megasena"))
            {
                //Megasena();
            }
        }

        //private void Megasena()
        //{
        //    var jss = new JavaScriptSerializer();

        //    var concurso = new Megasena() { Numero = 12, Tipo = "Megasena" };

        //    var concursoJson = jss.Serialize(concurso);
        //    //Response.ContentType = "application/json";
        //    Response.Write(concursoJson);

        //    Response.End();
        //}
    }
}