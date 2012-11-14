using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;
using System.Xml;


namespace FiqueRico.BL
{
    /// <summary>
    /// Responsável pela integração com as camadas de apresentação.
    /// Todas as chamadas tem que passar por essa Classe.
    /// </summary>
    public class Resultado
    {
        //private System.Collections.Generic.ICollection<Jogo> _jogos;
        private JogoFactory _factory;
        JogoCollection jogos = new JogoCollection();
        XML.FileIO file;
        System.Xml.XmlDocument xml;
       
        /// <summary>
        /// Montar o jogo aleatorio e grava na base para futura comparação.
        /// *Tendencia a postar no perfil o resultado*
        /// </summary>
        /// <param name="totalConcurso"></param>
        /// <param name="numApostaBilhete"></param>
        /// <returns></returns>
        public string CriarJogoAleatorio(int totalNumerosConcurso, int numApostaBilhete, string tipo)
        {
            GerarJogoAleatorio jogoAleatorio = new GerarJogoAleatorio();
            var palpite = jogoAleatorio.GerarNumeros(totalNumerosConcurso, numApostaBilhete, tipo);

            return MontarHTMLJogoAleatorio(palpite);
        }

        /// <summary>
        /// Monta o HTML necessário para que a lista de números sai formatada em tela
        /// </summary>
        /// <param name="jogoAleatorio"></param>
        /// <returns></returns>
        private string MontarHTMLJogoAleatorio(ICollection<int> jogoAleatorio)
        {
            System.Text.StringBuilder jogoHTML = new System.Text.StringBuilder();

            jogoHTML.Append("<span class=\"num_sorteio\"><ul>");

            foreach (var item in jogoAleatorio)
                jogoHTML.AppendFormat("<li>{0}</li>", item);

            jogoHTML.Append("</ul></span>");

            return jogoHTML.ToString();
        }

        public string RecuperarJogoAleatorio(string tipo)
        {
            GerarJogoAleatorio jogoAleatorio = new GerarJogoAleatorio();
            var palpite = jogoAleatorio.RecuperarPalpite(tipo);
            return "";
        }

        ///// <summary>
        ///// Obtem o ultimo concurso gravado na base.
        ///// </summary>
        ///// <param name="tipo"></param>
        ///// <returns></returns>
        //public Jogo PegarUltimoConcurso(TipoJogo tipo)
        //{
        //    file = new XML.FileIO();
        //    Jogo ultimoJogo;
        //    try
        //    {
        //        this.xml = file.Recuperar(tipo, true);
        //        ultimoJogo = XML.Serializador<Jogo>.DeserializeFromXML(this.xml);
        //    }
        //    catch (System.IO.FileNotFoundException ex)
        //    {
        //        ultimoJogo = new Jogo()
        //        {
        //            DataConcurso = DateTime.Parse("01/01/1990"),
        //            NumeroConcurso = 0,
        //            TipoJogo = tipo
        //        };

        //        if (tipo == TipoJogo.Quina)
        //        {
        //            ultimoJogo.NumeroConcurso = 28;
        //            ultimoJogo.DataConcurso = DateTime.Parse("26/06/1994");
        //        }

        //        this.xml = XML.Serializador<Jogo>.SerializeAsXML(ultimoJogo);
        //        file.Gravar(this.xml, tipo, true);
        //    }

        //    if (ultimoJogo.JogoInfo.GanhadoresTerceiroPremio.Equals("0"))
        //    {
        //        _factory = new JogoFactory();
        //        ExcluirConcurso(ultimoJogo);
        //        ultimoJogo = _factory.ObterJogo(TipoJogo.Megasena, ultimoJogo.NumeroConcurso);
        //    }

        //    return ultimoJogo;
        //}

        /// <summary>
        /// Recuperar jogo gravado na base
        /// </summary>
        /// <param name="tipo">Megasena, Quina...</param>
        /// <param name="numConcurso">numero do Concurso</param>
        /// <returns></returns>
        public Jogo PegarConcursoLocal(string tipo, int numConcurso)
        {
            file = new XML.FileIO();
            Jogo jogo = null;// = new Jogo();

            try
            {
                this.xml = file.Recuperar(tipo, false);
                this.jogos.Concursos = XML.Serializador<List<Jogo>>.DeserializeFromXML(this.xml);
                jogo = this.jogos.ObterJogo(numConcurso);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                //jogo = PegarUltimoConcurso(tipo);
            }

            return jogo;
        }

        /// <summary>
        /// Exclui concurso da base
        /// </summary>
        /// <param name="jogo"></param>
        public void ExcluirConcurso(Jogo jogo)
        {

            jogos = new JogoFactory().ObterTodosOsJogos(jogo.TipoJogo);

            jogos.Concursos.Remove(jogo);
            var xmlDoc = XML.Serializador<List<Jogo>>.SerializeAsXML(jogos.Concursos);

            file = new XML.FileIO();

            //gravar
            file.Gravar(xmlDoc, jogo.TipoJogo, false);
        }

        
    }
}
