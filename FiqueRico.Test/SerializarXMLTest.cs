using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FiqueRico.BL;
using FiqueRico.BL.XML;
using System.Xml;

namespace FiqueRico.Test
{
    [TestFixture]
    public class SerializarXMLTest
    {
        [TestCase]                
        public void Passar_JogoTeste_Retornar_XmlDocument()
        {
            JogoTeste jogo = new JogoTeste()
            {
                DataConcurso = DateTime.Now,
                Dezenas = new string[] { "", "" },
                NumeroConcurso = 123,
                TipoJogo = BL.TipoJogo.Megasena
            };

            JogoTesteCollection list = new JogoTesteCollection();
            
            list.Concursos.Add(jogo);

            var resultado = Serializador<List<JogoTeste>>.SerializeAsXML(list.Concursos);

            Assert.AreEqual(typeof(XmlDocument), resultado);
        }
    }
}
