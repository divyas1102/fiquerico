using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FiqueRico.BL;

namespace FiqueRico.Test
{
    [TestFixture]
    public class ResultadoBLTest
    {
        Resultado _resultado = new Resultado();

        [TestCase]                
        public void Quando_Jogo_Inexistente_Retornar_Null()
        {
            //var resultado = _resultado.ObterJogo(TipoJogo.Megasena, 5900);
            //Assert.AreEqual(null, resultado);
        }

        [TestCase]
        public void Quando_Jogo_Existe_Retornar_InstanciaDeJogo()
        {
            // var resultado = _resultado.ObterJogo(TipoJogo.Megasena, 1000);
           // Assert.AreEqual(typeof(Jogo), resultado.GetType());
        }
    }
}
