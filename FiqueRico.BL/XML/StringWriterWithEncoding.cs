using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiqueRico.BL.XML
{
    /// <summary>
    /// Wrapper para mudar o valor do Encoding para gerar o XML em UTF-8
    /// </summary>
    public class StringWriterWithEncoding : System.IO.StringWriter
    {
        Encoding encoding;

        public StringWriterWithEncoding(StringBuilder builder, Encoding encoding)
            : base(builder)
        {
            this.encoding = encoding;
        }

        public override Encoding Encoding { get { return encoding; } }

    }
}

