using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FiqueRico.BL;

namespace FiqueRico.Test
{
    [TestFixture]
    public class JogoCollectionsTest
    {
        [TestCase]
        public void PassarUmNumeroRetornarConcursoMegasena()
        {
            var jogos = new JogoFactory().ObterTodosOsJogos("Megasena");
            string[] entrada = { "12" };
            var resultado = jogos.ProcurarSeApostaJaSaiu(entrada);
            Assert.IsNull(resultado);
        }
    }
}
