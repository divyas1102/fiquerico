using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiqueRico.BL
{
    public abstract class JogoCaixa
    {        
        public abstract Jogo CriarJogo();        

        public string Url { get; set; }
        public System.Net.WebClient webClient { get; set; }

        abstract public Jogo ObterSorteio(int numConcurso);
        abstract protected Jogo ConstruirJogo(string[] resultado);
        public virtual void SalvarJogo(Jogo jogo)
        {
            var sorteio = new Sorteio();
            sorteio.SalvarConcurso(jogo); 
        }
        public virtual void SalvarUltimoJogo(Jogo ultimoJogo)
        {
            var sorteio = new Sorteio();
            sorteio.SalvarUltimoConcurso(ultimoJogo);
        }
        

        /// <summary>
        /// Defini qual a Url e configura o cabeçalho do request.
        /// </summary>        
        /// <param name="numConcurso"></param>
        abstract protected void PrepararRequisicao(int numConcurso);
        abstract public Jogo RecuperarUltimoConcurso();
        abstract public void ExcluirUltimoConcurso();
        public virtual Jogo ObterJogoCasoSorteado(string[] dezenas, string tipo)
        {
            var sorteio = new Sorteio();
            return sorteio.ObterJogoCasoTenhaSidoSorteado(dezenas, tipo);
        }
     
    }
}
