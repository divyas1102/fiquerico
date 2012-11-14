using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FiqueRico.BL
{
    [XmlRoot("ApostaJogo")]
    public class ApostaJogo
    {
        [XmlArray("Aposta")]
        [XmlArrayItem("Dezena", Type = typeof(int))]
        public List<int> Aposta { get; set; }

        [XmlElement("NumeroConcurso")]
        public string NumeroConcurso { get; set; }

        [XmlElement("IsAcertou")]
        public bool IsAcertou { get; set; }

        public ApostaJogo() { this.Aposta = new List<int>(); }

    }
}
