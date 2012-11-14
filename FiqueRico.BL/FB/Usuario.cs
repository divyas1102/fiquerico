using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FiqueRico.BL.FB
{
    [XmlRoot("Usuario")]
    public class Usuario
    {
        [XmlElement("ID")]
        public string ID { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }

        [XmlElement("AccessToken")]
        public string AccessToken { get; set; }
    }

    [XmlRoot("UsuarioCollection")]
    public class UsuarioCollection
    {
        [XmlArray("Usuarios")]
        [XmlArrayItem("Usuario", Type = typeof(Usuario))]
        public List<Usuario> Usuarios { get; set; }

        public UsuarioCollection() { this.Usuarios = new List<Usuario>(); }
    }
}
