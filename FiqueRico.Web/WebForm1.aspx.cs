using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FiqueRico.BL;
using System.Collections;
using System.Text;

namespace FiqueRico.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Resultado _resultado;
        Jogo _jogo;

        StringBuilder jogosHTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //PreencheLoterias(1322);
                CarregaJogos();
                
            }





            //Response.Write(HttpContext.Current.Server.HtmlEncode(jogo.Dezenas.ToString()));

            /*
            Caixa caixa = new Caixa();
            DadosConcurso dados = new DadosConcurso(caixa);

            IList result;

            int countTipoJogo = Enum.GetValues(typeof(TipoJogo)).Length;

            foreach (TipoJogo item in Enum.GetValues(typeof(TipoJogo)))
            {
                Response.Write("------------------------------  Inicio da " + item + "<br>");

                try
                {
                    result = dados.ObterConcurso(item, 1314);

                    for (int i = 0; i < result.Count; i++)
                    {
                        Response.Write(i + " - " + result[i] + "<br>");
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Response.Write(ex.Message + "<br>");
                }
                finally
                {
                    Response.Write("------------------------------ fim" + item + "<br>");
                }
            }


          
            */
        }

        protected void BuscaNovoConcurso(object sender, EventArgs args)
        {
            CarregaJogos();
        }

        private void CarregaJogos()
        {
            //System.Threading.Tasks.Parallel.For(1, 9000, (i, loopState) =>
            //{

            //    jogo = _resultado.PegarUltimoConcurso(TipoJogo.Megasena);
            //    if (jogo.NumeroConcurso == numConcursoAnterior)
            //        loopState.Break();
            //    Console.WriteLine("Jogo numero: " + jogo.NumeroConcurso + " Data: " + jogo.DataConcurso.ToShortDateString());
            //    numConcursoAnterior = jogo.NumeroConcurso;

            //});

           _resultado = new Resultado();

           // _jogo = _resultado.PegarUltimoConcurso(TipoJogo.Megasena);
            PreencheLoterias();
        }

        private void PreencheLoterias()
        {
            /*
           <div class="jogo">
            <div class="tit">m
            </div>
            <div class="body">m
            </div>
            <div class="foot">m
            </div>
        </div>
             */
            this.jogosHTML = new StringBuilder();

            this.jogosHTML.Append("<div class='jogo'>");

            this.jogosHTML.Append("<div class='tit'>");
            this.jogosHTML.AppendFormat("<img src='./img/{0}.jpg' alt='resultado {0}'/>", _jogo.TipoJogo.ToString().ToLower());
            this.jogosHTML.AppendFormat("<p>{0} - {1}</p>", _jogo.NumeroConcurso.ToString(), _jogo.DataConcurso.ToShortDateString());
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("<div class='body'>");
            this.jogosHTML.Append(HttpContext.Current.Server.HtmlDecode(_jogo.Dezenas.ToString()));
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("<div class='foot'>");
            this.jogosHTML.Append("em fase de teste");
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("</div>");

            //////////////////////////////////////////

            this.jogosHTML.Append("<div class='jogo'>");

            this.jogosHTML.Append("<div class='tit'>");
            this.jogosHTML.AppendFormat("<img src='./img/{0}.jpg' alt='resultado {0}'/>", _jogo.TipoJogo.ToString().ToLower());
            this.jogosHTML.AppendFormat("<p>{0} - {1}</p>", _jogo.NumeroConcurso.ToString(), _jogo.DataConcurso.ToShortDateString());
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("<div class='body'>");
            this.jogosHTML.Append(HttpContext.Current.Server.HtmlDecode(_jogo.Dezenas.ToString()));
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("<div class='foot'>");
            this.jogosHTML.Append("em fase de teste");
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("</div>");

            //////////////////////////////////////////

            this.jogosHTML.Append("<div class='jogo'>");

            this.jogosHTML.Append("<div class='tit'>");
            this.jogosHTML.AppendFormat("<img src='./img/{0}.jpg' alt='resultado {0}'/>", _jogo.TipoJogo.ToString().ToLower());
            this.jogosHTML.AppendFormat("<p>{0} - {1}</p>", _jogo.NumeroConcurso.ToString(), _jogo.DataConcurso.ToShortDateString());
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("<div class='body'>");
            this.jogosHTML.Append(HttpContext.Current.Server.HtmlDecode(_jogo.Dezenas.ToString()));
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("<div class='foot'>");
            this.jogosHTML.Append("em fase de teste");
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("</div>");

            //////////////////////////////////////////

            this.jogosHTML.Append("<div class='jogo'>");

            this.jogosHTML.Append("<div class='tit'>");
            this.jogosHTML.AppendFormat("<img src='./img/{0}.jpg' alt='resultado {0}'/>", _jogo.TipoJogo.ToString().ToLower());
            this.jogosHTML.AppendFormat("<p>{0} - {1}</p>", _jogo.NumeroConcurso.ToString(), _jogo.DataConcurso.ToShortDateString());
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("<div class='body'>");
            this.jogosHTML.Append(HttpContext.Current.Server.HtmlDecode(_jogo.Dezenas.ToString()));
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("<div class='foot'>");
            this.jogosHTML.Append("em fase de teste");
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("</div>");

            //////////////////////////////////////////

            this.jogosHTML.Append("<div class='jogo'>");

            this.jogosHTML.Append("<div class='tit'>");
            this.jogosHTML.AppendFormat("<img src='./img/{0}.jpg' alt='resultado {0}'/>", _jogo.TipoJogo.ToString().ToLower());
            this.jogosHTML.AppendFormat("<p>{0} - {1}</p>", _jogo.NumeroConcurso.ToString(), _jogo.DataConcurso.ToShortDateString());
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("<div class='body'>");
            this.jogosHTML.Append(HttpContext.Current.Server.HtmlDecode(_jogo.Dezenas.ToString()));
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("<div class='foot'>");
            this.jogosHTML.Append("em fase de teste");
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("</div>");

            //////////////////////////////////////////

            this.jogosHTML.Append("<div class='jogo'>");

            this.jogosHTML.Append("<div class='tit'>");
            this.jogosHTML.AppendFormat("<img src='./img/{0}.jpg' alt='resultado {0}'/>", _jogo.TipoJogo.ToString().ToLower());
            this.jogosHTML.AppendFormat("<p>{0} - {1}</p>", _jogo.NumeroConcurso.ToString(), _jogo.DataConcurso.ToShortDateString());
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("<div class='body'>");
            this.jogosHTML.Append(HttpContext.Current.Server.HtmlDecode(_jogo.Dezenas.ToString()));
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("<div class='foot'>");
            this.jogosHTML.Append("em fase de teste");
            this.jogosHTML.Append("</div>");

            this.jogosHTML.Append("</div>");
            /////////////////////////////////////////

            lblJogoHTML.Text = this.jogosHTML.ToString();

            //imgTitulo.ImageUrl = "./img/" + _jogo.TipoJogo.ToString().ToLower() + ".jpg";
            //lblNumConcurso.Text = _jogo.NumeroConcurso.ToString();
            //lblInfo.Text = " - " + _jogo.DataConcurso.ToShortDateString();
            //lblNumeros.Text = HttpContext.Current.Server.HtmlDecode(_jogo.Dezenas.ToString());
            /*
            lblAcumulado.Text = jogo.JogoInfo.Acumulado + "<br>R$ " + jogo.JogoInfo.ValorAcumulado + "<br>";
            lblPremio.Text = String.Format(
                "Sena: {0}<span class=\"right\">R$ {1}</span><br>" +
                "<span class=\"left\">Quina: {2} </span><span class=\"right\">R$ {3}</span>" +
                "<span class=\"left\">Quadra: {4} </span><span class=\"right\">R$ {5}</span>",
                jogo.JogoInfo.GanhadoresSena, jogo.JogoInfo.PremioSena,
                jogo.JogoInfo.GanhadoresQuina, jogo.JogoInfo.PremioQuina,
                jogo.JogoInfo.GanhadoresQuadra, jogo.JogoInfo.PremioQuadra);
             */

        }
    }
}