using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FiqueRico.BL;
using FiqueRico.BL.FB;

namespace FiqueRico.Web
{
    public partial class Default : System.Web.UI.Page
    {
        System.Text.StringBuilder resultadosHTML = new System.Text.StringBuilder();
        Resultado resultado = new Resultado();
               
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                /*
                JogoFactory factory = new JogoFactory();
                var jogos = factory.ObterTodosOsJogos(TipoJogo.Megasena);
                string[] t = {"05","16"};
                Jogo jogo = jogos.ProcurarSeApostaJaSaiu(t);
                 */
                CarregarUltimosConcursos();
             
                //AppInfo t = new AppInfo(hdnAccessToken.Value);
               
                //dynamic user = t.GetData();
                //var a = user["id"];

                //t.SaveUser();

                //CarregarPalpite();
            }


        }
        
        protected void ConsultarSeConcursoSaiu(object sender, EventArgs e)
        {
            var jogo = new JogoMegasena();
            if (!string.IsNullOrEmpty(dataAgenda.Value) && !string.IsNullOrEmpty(rblOpcoes.SelectedValue))
            {
                var dezenas = dataAgenda.Value.Split(new char[] { '-' });

                Jogo jogoSorteado = null;

                switch (rblOpcoes.SelectedValue)
                {
                    case "1":
                        {
                            jogoSorteado = jogo.ObterJogoCasoSorteado(dezenas, ddlConcurso.SelectedItem.Text);
                            break;
                        }
                    default:
                        break;
                }

                if (jogoSorteado != null)
                {
                    MontarHTMLConcurso(jogoSorteado);
                    switch (jogoSorteado.TipoJogo)
                    {
                        case "Megasena":
                            {
                                lblMegasena.Text = resultadosHTML.ToString();
                                break;
                            }
                        case "Quina":
                            {
                                lblQuina.Text = resultadosHTML.ToString();
                                break;
                            }
                    }
                    lblResultado.InnerText = HttpContext.Current.Server.HtmlDecode("Jogo Já sorteado, veja o box da " + jogoSorteado.TipoJogo);
                }
                else
                {
                    lblResultado.InnerText = "Jogo não encontrado";
                }
            }

            GravarDadosDoUsuario();
        }
        private void CarregarUltimosConcursos()
        {
            JogoCaixa jogo = new JogoMegasena();
            MontarHTMLConcurso(jogo.RecuperarUltimoConcurso());
            lblMegasena.Text = resultadosHTML.ToString();
            jogo = new JogoQuina();
            MontarHTMLConcurso(jogo.RecuperarUltimoConcurso());
            lblQuina.Text = resultadosHTML.ToString();
        }

        private void GravarDadosDoUsuario()
        {
            if (!string.IsNullOrEmpty(hdnAccessToken.Value))
            {
                AppInfo app = new AppInfo(hdnAccessToken.Value);
                //app.SaveUser();
            }
        }

        private void MontarHTMLConcurso(Jogo jogo)
        {
            resultadosHTML.Clear();
            resultadosHTML.AppendFormat("<p>{0} <span class=\"{1}\">{2}</span></p>", jogo.TipoJogo.ToString(), jogo.JogoInfo.Acumulado.ToLower(), jogo.JogoInfo.Acumulado);
            resultadosHTML.AppendFormat("<p>{0} - {1}</p>", jogo.DataConcurso.ToShortDateString(), jogo.NumeroConcurso);
            resultadosHTML.Append("<p class=\"line\">&nbsp;</p>");
            resultadosHTML.AppendFormat("<p>{0}</p>", HttpContext.Current.Server.HtmlDecode(jogo.Dezenas.ToString()));
            resultadosHTML.Append("<p class=\"line\">&nbsp;</p>");
            resultadosHTML.Append("<p>Ganhadores</p>");
            if (jogo.TipoJogo.Equals("Megasena"))
            {
                resultadosHTML.AppendFormat("<p>Sena: {0} - {1}</p>", jogo.JogoInfo.GanhadoresPrimeiroPremio, jogo.JogoInfo.ValorPrimeiroPremio);
                resultadosHTML.AppendFormat("<p>Quina: {0} - {1}</p>", jogo.JogoInfo.GanhadoresSegundoPremio, jogo.JogoInfo.ValorSegundoPremio);
                resultadosHTML.AppendFormat("<p>Quadra: {0} - {1}</p>", jogo.JogoInfo.GanhadoresTerceiroPremio, jogo.JogoInfo.ValorTerceiroPremio);
            }
            else
            {
                resultadosHTML.AppendFormat("<p>Quina: {0} - {1}</p>", jogo.JogoInfo.GanhadoresPrimeiroPremio, jogo.JogoInfo.ValorPrimeiroPremio);
                resultadosHTML.AppendFormat("<p>Quadra: {0} - {1}</p>", jogo.JogoInfo.GanhadoresSegundoPremio, jogo.JogoInfo.ValorSegundoPremio);
                resultadosHTML.AppendFormat("<p>Terno: {0} - {1}</p>", jogo.JogoInfo.GanhadoresTerceiroPremio, jogo.JogoInfo.ValorTerceiroPremio);
            }
            resultadosHTML.AppendFormat("<p class=\"line\">&nbsp;</p><p>Acumulado: {0}</p>", jogo.JogoInfo.ValorAcumulado);
        }

        private void CarregarPalpite()
        {
            //lblPalpiteMegasena.Text = HttpContext.Current.Server.HtmlDecode(this.resultado.CriarJogoAleatorio(60, 6, TipoJogo.Megasena));
            //lblPalpiteQuina.Text = HttpContext.Current.Server.HtmlDecode(this.resultado.CriarJogoAleatorio(80, 5, TipoJogo.Quina));
        }
    }
}