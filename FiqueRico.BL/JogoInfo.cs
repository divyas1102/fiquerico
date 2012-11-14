using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FiqueRico.BL
{
    //Os comentarios são relativos a Megasena
    [XmlRoot("JogoInfo")]
    public class JogoInfo
    {       

        [XmlElement("ValorAcumulado")]
        public string ValorAcumulado { get; set; }//1
        [XmlElement("GanhadoresPrimeiroPremio")]
        public string GanhadoresPrimeiroPremio { get; set; }//3
        [XmlElement("ValorPrimeiroPremio")]
        public string ValorPrimeiroPremio { get; set; }//4
        [XmlElement("GanhadoresSegundoPremio")]
        public string GanhadoresSegundoPremio { get; set; }//5
        [XmlElement("ValorSegundoPremio")]
        public string ValorSegundoPremio { get; set; }//6
        [XmlElement("GanhadoresTerceiroPremio")]
        public string GanhadoresTerceiroPremio { get; set; }//7
        [XmlElement("ValorTerceiroPremio")]
        public string ValorTerceiroPremio { get; set; }//8
        [XmlElement("GanhadoresQuartoPremio")]
        public string GanhadoresQuartoPremio { get; set; }//3
        [XmlElement("ValorQuartoPremio")]
        public string ValorQuartoPremio { get; set; }//4
        [XmlElement("GanhadoresQuintoPremio")]
        public string GanhadoresQuintoPremio { get; set; }//3
        [XmlElement("ValorQuintoPremio")]
        public string ValorQuintoPremio { get; set; }//4
        [XmlElement("CidadeSedeConcurso")]
        public string CidadeSedeConcurso { get; set; }//12
        [XmlElement("EstadoSedeConcurso")]
        public string EstadoSedeConcurso { get; set; }//13
        [XmlElement("NumeroConcursoFinalCinco")]
        public string NumeroConcursoFinalCinco { get; set; }//16
        [XmlElement("PremioFinalCinco")]
        public string PremioFinalCinco { get; set; }//18
        [XmlElement("DetalhesGanhadoresSena")]
        public string DetalhesGanhadoresSena { get; set; }//19
        [XmlElement("PremioProximoConcurso")]
        public string PremioProximoConcurso { get; set; }//21
        [XmlElement("DataProximoConcurso")]
        public DateTime DataProximoConcurso { get; set; }//22
        [XmlElement("PremioMegaDaVirada")]
        public string PremioMegaDaVirada { get; set; }//23
        [XmlElement("Acumulado")]
        public string Acumulado { get { return GanhadoresPrimeiroPremio.Equals("0") ? "ACUMULOU" : "SAIU"; } }

    }
}
