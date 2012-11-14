using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FiqueRico.BL;

namespace FiqueRico.Web
{
    public partial class MegaSenascript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            JogoCaixa jogo = new JogoMegasena();
            var ultimoJogo = jogo.RecuperarUltimoConcurso();            

            if ((DateTime.Now - ultimoJogo.DataConcurso).Days > 2)                           
                ultimoJogo = jogo.ObterSorteio(ultimoJogo.NumeroConcurso + 1);

            //Quando a Caixa disponibiliza o resultado incompleto, fico buscando até obter o resultado completo.
            while(ultimoJogo.JogoInfo.GanhadoresTerceiroPremio.Equals("0"))
            {
                System.Threading.Thread.Sleep(300000);
                jogo.ExcluirUltimoConcurso();
                ultimoJogo = jogo.ObterSorteio(ultimoJogo.NumeroConcurso);
            }
            jogo.SalvarJogo(ultimoJogo);
            jogo.SalvarUltimoJogo(ultimoJogo);
        }
    }
}