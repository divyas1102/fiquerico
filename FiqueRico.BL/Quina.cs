using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiqueRico.BL
{
    public class Quina : Jogo
    {
        public override string sTipoJogo()
        { return this.GetType().Name.ToLower(); }

    }
}
