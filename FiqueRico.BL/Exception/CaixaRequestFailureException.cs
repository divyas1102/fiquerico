using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiqueRico.BL.Exception
{
    public class CaixaRequestFailureException : System.Exception
    {
        public CaixaRequestFailureException() : base("Não foi possivel obter o concurso pois o servidor da caixa não esta respondendo") { }
    }

    /// <summary>
    /// Não houve ganhadores no último prêmio, aconteceu um erro na montagem.
    /// </summary>
    public class ConcursoIncompletoException : System.Exception
    {
        public ConcursoIncompletoException() : base("Número de ganhadores do último prêmio é menor ou igual a zero.") { }
    }
}
