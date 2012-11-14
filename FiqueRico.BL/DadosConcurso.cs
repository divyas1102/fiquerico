using System;
using System.Web;
using System.ComponentModel;
using System.Collections;


namespace FiqueRico.BL
{
    public class DadosConcurso
    {
        private Caixa _caixa;
        private string[] _dadosSeparados;

        /// <summary>
        /// instância a classe
        /// </summary>
        public DadosConcurso(Caixa caixa)
        { _caixa = caixa; }       


        //Vai sair daqui
        /// <summary>
        /// Obtem os dados que compõem um sorteio Caixa. 
        /// É devolvido um Array com as informações separadas dentro desta coleção de dados.
        /// </summary>
        /// <param name="tipo">Megasena, por exemplo</param>
        /// <param name="numConcurso">numero do concurso</param>
        /// <returns>Coleção contendo os dados do concurso</returns>
        //public IList ObterConcurso(TipoJogo tipo, int numConcurso)
        //{
        //    string url = _caixa.ObterSorteioNaCaixa(tipo, numConcurso);
            
        //    DesmontarUrlString(url);

        //    return _dadosSeparados;
        //}
        
        //private void DesmontarUrlString(string url) 
        //{
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder(url);
        //    _dadosSeparados = url.Split('|');

        //    if (_dadosSeparados.Length < 5)
        //        throw new ArgumentOutOfRangeException("Não existe esse concurso"); 
        //}
      
    }
}
