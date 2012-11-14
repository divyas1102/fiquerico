using System;
using System.Web;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;

namespace FiqueRico.BL
{
    [XmlRoot("Jogo")]
    public class Jogo
    {
        [XmlElement("NumeroConcurso")]
        public int NumeroConcurso { get; set; }//0      
        [XmlElement("Dezenas")]
        public string Dezenas { get; set; }//20
        [XmlElement("DataConcurso")]
        public DateTime DataConcurso { get; set; }//11
        [XmlElement("TipoJogo")]
        public string TipoJogo { get; set; }

        [XmlElement("JogoInfo")]
        public JogoInfo JogoInfo { get; set; }

        public string sDezenas
        {
            get { return HttpContext.Current.Server.HtmlDecode(this.Dezenas); }
        }
        public string sDataConcurso
        {
            get { return DataConcurso.ToString("dd/MM/yyyy"); }
        }

        public Jogo() { }
        public virtual string sTipoJogo() { return this.GetType().Name; }

        public bool Equals(Jogo jogo)
        { return this.NumeroConcurso.Equals(jogo.NumeroConcurso); }

        public virtual string[] RetirarHTMLDezenas()
        {
            string dezenas = this.Dezenas;
            dezenas = dezenas.Replace("<span class=\"num_sorteio\"><ul>", "");
            dezenas = dezenas.Replace("</ul></span>", "");
            dezenas = dezenas.Replace("<li>", "");
            dezenas = dezenas.Replace("</li>", "|");

            return dezenas.Remove(dezenas.Length - 1, 1).Split(new char[]{'|'});
        }
    }
}
