using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FiqueRico.BL;

namespace FiqueRico.Web
{
    public partial class Quinascript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JogoCaixa jogo = new JogoQuina();
            var ultimoJogo = jogo.RecuperarUltimoConcurso();
            
            ultimoJogo.DataConcurso = ultimoJogo.DataConcurso.AddDays(1);

            DateTime proxSorteio = new DateTime(ultimoJogo.DataConcurso.Year,
                    ultimoJogo.DataConcurso.Month,
                    ultimoJogo.DataConcurso.Day,
                    21, 0, 0);

            if (DateTime.Now > proxSorteio)                
                ultimoJogo = jogo.ObterSorteio(ultimoJogo.NumeroConcurso + 1);

            //Quando a Caixa disponibiliza o resultado incompleto, fico buscando até obter o resultado completo.
            while (ultimoJogo.JogoInfo.GanhadoresTerceiroPremio.Equals("0"))
            {
                System.Threading.Thread.Sleep(300000);
                jogo.ExcluirUltimoConcurso();
                ultimoJogo = jogo.ObterSorteio(ultimoJogo.NumeroConcurso);
            }

            jogo.SalvarJogo(ultimoJogo);
            jogo.SalvarUltimoJogo(ultimoJogo);
            
            /*
            --Resultado resultado = new Resultado();
            --JogoFactory factory = new JogoFactory();
            --var ultimoJogo = resultado.PegarUltimoConcurso(TipoJogo.Quina);
            --var ultimoJogo = ;// new Jogo();
            --ultimoJogo.DataConcurso = ultimoJogo.DataConcurso.AddDays(1);
            DateTime proxSorteio = new DateTime(ultimoJogo.DataConcurso.Year,
                    ultimoJogo.DataConcurso.Month,
                    ultimoJogo.DataConcurso.Day,
                    21, 0, 0);

            if (DateTime.Now > proxSorteio)
                ultimoJogo = factory.ObterJogo(TipoJogo.Quina, ultimoJogo.NumeroConcurso + 1);

            while (ultimoJogo.JogoInfo.GanhadoresTerceiroPremio.Equals("0"))
            {
                System.Threading.Thread.Sleep(300000);
                resultado.ExcluirConcurso(ultimoJogo);
                ultimoJogo = factory.ObterJogo(TipoJogo.Quina, ultimoJogo.NumeroConcurso);
            }
             */ 
        }
    }
}