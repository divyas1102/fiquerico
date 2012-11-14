using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FiqueRico.BL
{
    [XmlRoot("UltimoConcurso")]
    public class UltimoConcurso
    {
        [XmlElement("NumeroConcurso")]
        public int NumeroConcurso { get; set; }//0      
        
        public UltimoConcurso()
        {

        }

    }
}
