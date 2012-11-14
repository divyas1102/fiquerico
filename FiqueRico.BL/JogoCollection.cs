using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FiqueRico.BL
{
    [XmlRoot("JogoCollection")]
    public class JogoCollection
    {
        private Jogo jogo;

        [XmlArray("Concursos")]
        [XmlArrayItem("Jogo", Type = typeof(Jogo))]
        public List<Jogo> Concursos { get; set; }

        public JogoCollection() { this.Concursos = new List<Jogo>(); }
        public JogoCollection(Jogo _jogo)
            : base()
        { this.jogo = _jogo; }

        /// <summary>
        /// Recupera jogo já gravado na base.
        /// </summary>
        /// <param name="numConcurso">número do concurso</param>
        /// <returns></returns>
        public Jogo ObterJogo(int numConcurso)
        {
            //Jogo this.jogo = new Jogo() { NumeroConcurso = numConcurso };
            this.jogo.NumeroConcurso = numConcurso;
            try
            {
                if (this.Concursos[this.jogo.NumeroConcurso - 1].Equals(this.jogo))
                    this.jogo = this.Concursos[this.jogo.NumeroConcurso - 1];
                else
                    throw new NullReferenceException("Concurso não obedece a regra. Não foram buscados todos os concursos.");
            }
            catch (System.Exception)
            {
                for (int i = this.jogo.NumeroConcurso - 50; i < this.Concursos.Count; i++)
                {
                    if (this.Concursos[i].Equals(this.jogo))
                    {
                        this.jogo = this.Concursos[i];
                        break;
                    }
                }
            }

            return this.jogo;
        }

        /// <summary>
        /// Procura se uma determinada aposta já foi sorteada alguma vez e caso tenha saído mais de uma vez, retorna o sorteio mais recente
        /// Caso já tenha sido, retorna o concurso, se não, retorna null
        /// </summary>
        /// <param name="aposta">números para procurar</param>
        /// <returns></returns>
        public Jogo ProcurarSeApostaJaSaiu(string[] aposta)
        {
            Jogo jogo = null;
            int acertosMax = 0;
            for (int i = this.Concursos.Count - 1; i >= 0; i--)
            {
                string[] dezenas = this.Concursos[i].RetirarHTMLDezenas();                 
                int acertos = 0;
                for (int c = 0; c < aposta.Length; c++)
                {
                    for (int j = 0; j < dezenas.Length; j++)
                    {
                        if (dezenas[j] == aposta[c])
                        {
                            acertos++;
                            break;
                        }
                    }
                }
                if (acertos == aposta.Length)
                {
                    acertosMax = acertos;
                    jogo = this.Concursos[i];
                }
            }

            return jogo;
        }

        /// <summary>
        /// Procura se uma determinada aposta já foi sorteada alguma vez, ou que chegou mais próximo do prémio 
        /// Caso já tenha sido, retorna o concurso, se não, retorna null
        /// </summary>
        /// <param name="aposta">números para procurar</param>
        /// <returns></returns>
        public Jogo ObterJogoCasoSorteadoOuComMaisAcertos(string[] aposta)
        {
            Jogo jogo = null;
            int acertosMax = 0;
            for (int i = this.Concursos.Count - 1; i >= 0; i--)
            {
                string[] dezenas = this.Concursos[i].RetirarHTMLDezenas();
                int acertos = 0;
                for (int c = 0; c < aposta.Length; c++)
                {
                    for (int j = 0; j < dezenas.Length; j++)
                    {
                        if (dezenas[j] == aposta[c])
                        {
                            acertos++;
                            break;
                        }

                    }
                }
                if (acertos > acertosMax)
                {
                    acertosMax = acertos;
                    jogo = this.Concursos[i];
                }
            }

            return jogo;
        }
    }
}
