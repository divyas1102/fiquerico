using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiqueRico.BL
{
    public class JogoQuina : JogoCaixa
    {
        public override Jogo CriarJogo()
        { return new Jogo(); }

        /// <summary>
        /// Obter o sorteio no site da Caixa.
        /// </summary>
        /// <param name="numConcurso"></param>        
        /// <returns></returns>
        public override Jogo ObterSorteio(int numConcurso)
        {
            PrepararRequisicao(numConcurso);
            var jogo = new Jogo();
            var sorteio = new Sorteio();
            try
            {
                var resultado = sorteio.ObterSorteio(numConcurso, base.webClient, base.Url);
                jogo = ConstruirJogo(resultado);
            }
            catch (System.Exception ex)
            {
                jogo = sorteio.RecuperarUltimoConcurso("Quina");
                Console.WriteLine(ex.Message);
            }
            return jogo;
        }
        /// <summary>
        /// Construir uma instância da classe Jogo
        /// </summary>
        /// <returns></returns>
        protected override Jogo ConstruirJogo(string[] resultado)
        {
            DateTime data;
            var jogo = new Jogo();
            jogo.NumeroConcurso = int.Parse(resultado[0].ToString());
            jogo.Dezenas = resultado[14].ToString().Substring(135);
            jogo.DataConcurso = DateTime.Parse(resultado[16].ToString());

            jogo.JogoInfo = new JogoInfo();
            jogo.JogoInfo.GanhadoresPrimeiroPremio = resultado[6].ToString();
            jogo.JogoInfo.ValorPrimeiroPremio = resultado[7].ToString();
            jogo.JogoInfo.GanhadoresSegundoPremio = resultado[8].ToString();
            jogo.JogoInfo.ValorSegundoPremio = resultado[9].ToString();
            jogo.JogoInfo.GanhadoresTerceiroPremio = resultado[10].ToString();
            jogo.JogoInfo.ValorTerceiroPremio = resultado[11].ToString();
            jogo.JogoInfo.CidadeSedeConcurso = resultado[2].ToString();
            jogo.JogoInfo.EstadoSedeConcurso = resultado[3].ToString();
            jogo.JogoInfo.ValorAcumulado = resultado[13].ToString();
            jogo.JogoInfo.DataProximoConcurso = DateTime.TryParse(resultado[18].ToString(), out data) ? DateTime.Parse(resultado[18].ToString()) : jogo.DataConcurso;
            jogo.TipoJogo = "Quina";

            return jogo;
        }
        
        /// <summary>
        /// Defini qual a Url e configura o cabeçalho do request.
        /// </summary>
        protected override void PrepararRequisicao(int numConcurso)
        {
            Url = (@"http://www1.caixa.gov.br/loterias/loterias/quina/quina_pesquisa_new.asp?submeteu=sim&opcao=concurso&txtConcurso=" + numConcurso);
            webClient = new System.Net.WebClient();
            webClient.Headers.Add("Accept-Language", "en-us");
            webClient.Headers.Add("Cookie", "security=true; ASPSESSIONIDSSRSRQCA=CAJLHKOAMCHHFNDAPLLPIMIA");
            webClient.Headers.Add("Referer", "http://www1.caixa.gov.br/loterias/loterias/quina/quina_resultado.asp");
            webClient.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; InfoPath.2; OfficeLiveConnector.1.3; OfficeLivePatch.0.0)");
            webClient.Headers.Add("Accept", "*/*");
        }

        /// <summary>
        /// Recupera o ultimo concurso
        /// </summary>
        /// <returns></returns>
        public override Jogo RecuperarUltimoConcurso()
        {
            var sorteio = new Sorteio();
            return sorteio.RecuperarUltimoConcurso("Quina");
        }

        public override void ExcluirUltimoConcurso()
        {
            var sorteio = new Sorteio();
            sorteio.ExcluirUltimoConcurso("Quina");
        }
        
        public override void SalvarUltimoJogo(Jogo ultimoJogo)
        {            
            var sorteio = new Sorteio();
            sorteio.SalvarUltimoConcurso(ultimoJogo);
        }        
    }
}
