using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiqueRico.BL
{
    public class Megasena : Jogo
    {
        public override string sTipoJogo()
        { return this.GetType().Name.ToLower(); }
    }
}
