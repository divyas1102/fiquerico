using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiqueRico.BL
{
    public class Sorteio
    {
        private string[] dadosSeparados;
        private FiqueRico.BL.XML.FileIO file;

        public Sorteio()
        { file = new XML.FileIO(); }

        /// <summary>
        /// Obter o sorteio no site da Caixa.
        /// </summary>
        /// <param name="numConcurso"></param>
        /// <param name="webClient">Configurações do request</param>
        /// <param name="url">URL do concurso</param>
        /// <returns></returns>
        public string[] ObterSorteio(int numConcurso, System.Net.WebClient webClient, string url)
        {            
            var retornoJson = webClient.DownloadString(url);
            DesmontarResultado(retornoJson);
            return dadosSeparados;
        }

        /// <summary>
        /// Recupera todos os jogos gravados na base
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public JogoCollection ObterTodosSorteios(string tipo)
        {
            var file = new FiqueRico.BL.XML.FileIO();
            var xmlTodosJogos = file.Recuperar(tipo, false);

            return new JogoCollection() { Concursos = XML.Serializador<List<Jogo>>.DeserializeFromXML(xmlTodosJogos) };
        }
               
        /// <summary>
        /// Recuperar o ultimo Concurso
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public Jogo RecuperarUltimoConcurso(string tipo)
        {
            Jogo ultimoJogo;
            var xmlDoc = file.Recuperar(tipo, true);
            ultimoJogo = XML.Serializador<Jogo>.DeserializeFromXML(xmlDoc);
            return ultimoJogo;
        }
        
        public void ExcluirUltimoConcurso(string tipo)
        {
            var jogo = RecuperarUltimoConcurso(tipo);
            var jogos = new JogoFactory().ObterTodosOsJogos(tipo);
            jogos.Concursos.Remove(jogo);
            var xmlDoc = XML.Serializador<List<Jogo>>.SerializeAsXML(jogos.Concursos);
            file.Gravar(xmlDoc, jogo.TipoJogo, false);
        }

        public void SalvarUltimoConcurso(Jogo ultimoJogo)
        {
            var xmlDoc = XML.Serializador<Jogo>.SerializeAsXML(ultimoJogo);
            file.Gravar(xmlDoc, ultimoJogo.TipoJogo, true);
        }

        public void SalvarConcurso(Jogo jogo)
        {
            JogoCollection jogos;
            try
            {
                jogos = ObterTodosSorteios(jogo.TipoJogo);
                jogos.Concursos.Add(jogo);
                var xmlDoc = XML.Serializador<List<Jogo>>.SerializeAsXML(jogos.Concursos);
                file.Gravar(xmlDoc, jogo.TipoJogo, false);                
            }
            catch (System.IO.FileNotFoundException ex)
            {
                jogos = new JogoCollection();
                jogos.Concursos.Add(jogo);
                var xmlDoc = XML.Serializador<List<Jogo>>.SerializeAsXML(jogos.Concursos);
                file.Gravar(xmlDoc, jogo.TipoJogo, false);
                xmlDoc = XML.Serializador<Jogo>.SerializeAsXML(jogo);
                file.Gravar(xmlDoc, jogo.TipoJogo, true);
            }
        }

        public Jogo ObterJogoCasoTenhaSidoSorteado(string[] dezenas, string tipo)
        {
            var jogos = ObterTodosSorteios(tipo);
            return jogos.ProcurarSeApostaJaSaiu(dezenas);        
        }

        /// <summary>
        /// Transforma o JSON em array de strings
        /// </summary>
        private void DesmontarResultado(string retornoJson)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(retornoJson);
            dadosSeparados = retornoJson.Split('|');

            if (dadosSeparados.Length < 5)
                throw new ArgumentOutOfRangeException("Não existe esse concurso");
        }
    }
}
