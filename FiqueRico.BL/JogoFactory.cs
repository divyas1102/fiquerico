using System;
using System.Web;
using System.ComponentModel;
using System.Collections;
using FiqueRico.BL.XML;
using System.Collections.Generic;

namespace FiqueRico.BL
{
    public class JogoFactory
    {
        private DadosConcurso _dadosConcurso;
        Jogo _jogo;
        FileIO file;
        JogoCollection jogos;

        //public JogoFactory()
        //{
        //    _dadosConcurso = new DadosConcurso(new Caixa());
        //    _jogo = new Jogo();
        //}

        /// <summary>
        /// Obtem jogo do site da Caixa
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="concurso"></param>
        /// <returns></returns>
        public Jogo ObterJogo(TipoJogo tipo, int concurso)
        {
            IList resultado = null;
            
               // resultado = _dadosConcurso.ObterConcurso(tipo, concurso);
                DateTime data;
                switch (tipo)
                {
                    case TipoJogo.Quina:
                        _jogo.NumeroConcurso = int.Parse(resultado[0].ToString());
                        _jogo.Dezenas = resultado[14].ToString().Substring(135);
                        _jogo.DataConcurso = DateTime.Parse(resultado[16].ToString());

                        _jogo.JogoInfo = new JogoInfo();
                        _jogo.JogoInfo.GanhadoresPrimeiroPremio = resultado[6].ToString();
                        _jogo.JogoInfo.ValorPrimeiroPremio = resultado[7].ToString();
                        _jogo.JogoInfo.GanhadoresSegundoPremio = resultado[8].ToString();
                        _jogo.JogoInfo.ValorSegundoPremio = resultado[9].ToString();
                        _jogo.JogoInfo.GanhadoresTerceiroPremio = resultado[10].ToString();
                        _jogo.JogoInfo.ValorTerceiroPremio = resultado[11].ToString();
                        _jogo.JogoInfo.CidadeSedeConcurso = resultado[2].ToString();
                        _jogo.JogoInfo.EstadoSedeConcurso = resultado[3].ToString();
                        _jogo.JogoInfo.ValorAcumulado = resultado[13].ToString();
                        _jogo.JogoInfo.DataProximoConcurso = DateTime.TryParse(resultado[18].ToString(), out data) ? DateTime.Parse(resultado[18].ToString()) : _jogo.DataConcurso;
                        

                        break;
                    case TipoJogo.DuplaSena:
                        break;
                    case TipoJogo.Lotogol:
                        break;
                    case TipoJogo.TimeMania:
                        break;
                    case TipoJogo.LotoMania:
                        break;
                    case TipoJogo.LotoFacil:
                        break;
                    default:
                        break;
                }
                return _jogo;
            


            ///// <summary>
            ///// Recupera todos os jogos gravados na base
            ///// </summary>
            ///// <param name="tipo">Tipo jogo (Megasena | Quina...)</param>
            ///// <returns></returns>
            //public JogoCollection ObterTodosOsJogos(TipoJogo tipo)
            //{
            //    file = new FileIO();
            //    var xmlTodosJogos = file.Recuperar(tipo, false);

            //    return new JogoCollection() { Concursos = XML.Serializador<List<Jogo>>.DeserializeFromXML(xmlTodosJogos) };
            //}
        }
        public JogoCollection ObterTodosOsJogos(string tipo) { return null; }
    }
}
