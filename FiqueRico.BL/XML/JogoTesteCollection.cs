using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FiqueRico.BL.XML
{
    [XmlRoot("JogoCollection")]
    public class JogoTesteCollection
    {
        [XmlArray("Concursos")]
        [XmlArrayItem("Jogo", Type = typeof(JogoTeste))]
        public List<JogoTeste> Concursos { get; set; }

        public JogoTesteCollection() { this.Concursos = new List<JogoTeste>(); }
    }
}
