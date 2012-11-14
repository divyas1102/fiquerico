using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FiqueRico.BL;

namespace FiqueRico.Test
{
    [TestFixture]
    public class CaixaBLTest
    {
        Caixa _caixa = new Caixa();

        [TestCase]                
        public void Passar_TipoJogoMegasena_E_ConcursoUM_Retornar_Jogo_ComHeader_UM()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.Megasena, 1);
            Assert.AreEqual("1", resultado.Substring(0,1));
        }

        [TestCase]
        public void Passar_TipoJogoMegasena_E_ConcursoInexistente_Retornar_Jogo_ComHeader_Pipe()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.Megasena, 0);
            Assert.AreEqual("|", resultado.Substring(0, 1));
        }

        [TestCase]
        public void Passar_TipoJogoMegasena_E_ConcursoExistente_Retornar_Jogo_ComHeader_NumeroConcurso()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.Megasena, 1314);
            Assert.AreEqual("1314", resultado.Substring(0, 4));
        }

        [TestCase]
        public void Passar_TipoJogoMegasena_E_ConcursoVinteMil_Retornar_Jogo_ComHeader_Pipe()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.Megasena, 20000);
            Assert.AreEqual("|", resultado.Substring(0, 1));
        }


        [TestCase]
        [Ignore]
        public void Passar_TipoJogoQuina_E_ConcursoUM_Retornar_Jogo_ComHeader_UM()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.Quina, 1);
            Assert.AreEqual("1", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoQuina_E_ConcursoInexistente_Retornar_Jogo_ComHeader_Pipe()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.Quina, 0);
            Assert.AreEqual("|", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoQuina_E_ConcursoVinteMil_Retornar_Jogo_ComHeader_Pipe()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.Quina, 20000);
            Assert.AreEqual("|", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoDuplaSena_E_ConcursoUM_Retornar_Jogo_ComHeader_UM()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.DuplaSena, 1);
            Assert.AreEqual("1", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoDuplaSena_E_ConcursoInexistente_Retornar_Jogo_ComHeader_Pipe()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.DuplaSena, 0);
            Assert.AreEqual("|", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoDuplaSena_E_ConcursoVinteMil_Retornar_Jogo_ComHeader_Pipe()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.DuplaSena, 20000);
            Assert.AreEqual("|", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoLotogol_E_ConcursoUM_Retornar_Jogo_ComHeader_UM()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.Lotogol, 1);
            Assert.AreEqual("1", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoLotogol_E_ConcursoInexistente_Retornar_Jogo_ComHeader_Pipe()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.Lotogol, 0);
            Assert.AreEqual("|", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoLotogol_E_ConcursoVinteMil_Retornar_Jogo_ComHeader_Pipe()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.Lotogol, 20000);
            Assert.AreEqual("|", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoTimeMania_E_ConcursoUM_Retornar_Jogo_ComHeader_UM()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.TimeMania, 1);
            Assert.AreEqual("1", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoTimeMania_E_ConcursoInexistente_Retornar_Jogo_ComHeader_Pipe()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.TimeMania, 0);
            Assert.AreEqual("|", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoTimeMania_E_ConcursoVinteMil_Retornar_Jogo_ComHeader_Pipe()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.TimeMania, 20000);
            Assert.AreEqual("|", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoLotoMania_E_ConcursoUM_Retornar_Jogo_ComHeader_UM()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.LotoMania, 1);
            Assert.AreEqual("1", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoLotoMania_E_ConcursoInexistente_Retornar_Jogo_ComHeader_Pipe()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.LotoMania, 0);
            Assert.AreEqual("|", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoLotoMania_E_ConcursoVinteMil_Retornar_Jogo_ComHeader_Pipe()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.LotoMania, 20000);
            Assert.AreEqual("|", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoLotoFacil_E_ConcursoUM_Retornar_Jogo_ComHeader_UM()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.LotoFacil, 1);
            Assert.AreEqual("1", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoLotoFacil_E_ConcursoInexistente_Retornar_Jogo_ComHeader_Pipe()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.LotoFacil, 0);
            Assert.AreEqual("|", resultado.Substring(0, 1));
        }

        [TestCase]
        [Ignore]
        public void Passar_TipoJogoLotoFacil_E_ConcursoVinteMil_Retornar_Jogo_ComHeader_Pipe()
        {
            var resultado = _caixa.ObterSorteioNaCaixa(TipoJogo.LotoFacil, 20000);
            Assert.AreEqual("|", resultado.Substring(0, 1));
        }

    }
}
