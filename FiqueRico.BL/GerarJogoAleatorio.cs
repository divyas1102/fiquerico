using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiqueRico.BL
{
    /// <summary>
    /// Gera Jogos aleatorio para os sorteios da Caixa
    ///  
    /// </summary>
    public class GerarJogoAleatorio
    {
        Random random = new Random();
        private List<int> aposta = new List<int>();
        private ApostaJogo apostaJogo = new ApostaJogo();
        private XML.FileIO file = new XML.FileIO();

        /// <summary>
        /// Gerar Jogos Aleatorios sem seguir nenhuma regra
        /// </summary>
        /// <param name="totalNumero"></param>
        /// <param name="numerosBilhete"></param>
        /// <returns></returns>
        public List<int> GerarNumeros(int totalNumero, int numerosBilhete, string tipo)
        {
            totalNumero++;
            List<int> conjuntoCompleto = new List<int>();

            for (int i = 1; i < totalNumero; i++)
                conjuntoCompleto.Add(i);

            int numeroSorteado;
            random = new Random();
            for (int i = 0; i < numerosBilhete; i++)
            {
                numeroSorteado = random.Next(totalNumero--);
                if (conjuntoCompleto.Count <= numeroSorteado)
                    numeroSorteado--;
                aposta.Add(conjuntoCompleto[numeroSorteado]);
                conjuntoCompleto.RemoveAt(numeroSorteado);
            }
            aposta.Sort();
            GravarPalpite(tipo);
            return aposta;
        }

        private void GravarPalpite(string tipo)
        {
            this.apostaJogo.Aposta = aposta;
            this.apostaJogo.NumeroConcurso = "123";

            //var xmlDoc = XML.Serializador<List<int>>.SerializeAsXML(this.apostaJogo.Aposta);
            //this.file.Gravar(xmlDoc, tipo, true, "_palpite");
            var xmlDoc = XML.Serializador<ApostaJogo>.SerializeAsXML(this.apostaJogo);
            this.file.Gravar(xmlDoc, tipo, true, "_palpite");
        }

        public ApostaJogo RecuperarPalpite(string tipo)
        {
            var xmlDoc = file.Recuperar(tipo, true);
            this.apostaJogo.Aposta = XML.Serializador<List<int>>.DeserializeFromXML(xmlDoc);

            return apostaJogo;
        }
    }
}