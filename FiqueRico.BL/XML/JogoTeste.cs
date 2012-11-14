using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections;

namespace FiqueRico.BL.XML
{
    [XmlRoot("Jogo")]
    public class JogoTeste
    {
        [XmlElement("NumeroConcurso")]
        public int NumeroConcurso { get; set; }//0      
        [XmlElement("Dezenas")]
        public string[] Dezenas { get; set; }//2
        [XmlElement("DataConcurso")]
        public DateTime DataConcurso { get; set; }//11
        [XmlElement("TipoJogo")]
        public TipoJogo TipoJogo { get; set; }

        public JogoTeste()
        {

        }
    }
}
