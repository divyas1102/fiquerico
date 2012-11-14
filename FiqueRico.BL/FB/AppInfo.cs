using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;



namespace FiqueRico.BL.FB
{

    public class AppInfo
    {
        public readonly string Id = "205162109517014";
        public readonly string Secret = "d6eccc05bb324c08b10f9ebff939d679";
        public readonly string AuthorizeUrl;
        private string accessToken;
        private FiqueRico.BL.XML.FileIO file;

        public AppInfo(string accessToken)
        {
            this.accessToken = accessToken.Split(new char[] { '|' })[0];
            this.file = new XML.FileIO();
        }
        /*
        public dynamic GetClient()
        {
            return new FacebookClient(this.accessToken).Get("me", new { fields = "id, name, email" }); ;
        }

        public dynamic GetData()
        {
            string[] split = this.accessToken.Split(new char[] { '|' });
            var user = new FacebookClient(split[0]).Get("me");

            return user;
        }
        
        public void SaveUser()
        {
            dynamic user = GetClient();
            UsuarioCollection usuarios;
            System.Xml.XmlDocument xmlUsuarios;
            Usuario usuario = new Usuario()
                {
                    ID = user["id"],
                    Name = user["name"],
                    Email = user["email"],
                    AccessToken = this.accessToken
                };

            try
            {
                xmlUsuarios = file.Recuperar("Usuarios", false);
                usuarios = new UsuarioCollection() { Usuarios = XML.Serializador<List<Usuario>>.DeserializeFromXML(xmlUsuarios) };

                if (!usuarios.Usuarios.Any(u => u.ID.Equals(usuario.ID)))
                {
                    usuarios.Usuarios.Add(usuario);
                    file.Gravar(xmlUsuarios, "Usuarios", false);
                }
            }
            catch (System.Exception)
            {
                usuarios = new UsuarioCollection();
                usuarios.Usuarios.Add(usuario);
                xmlUsuarios = XML.Serializador<List<Usuario>>.SerializeAsXML(usuarios.Usuarios);
                file.Gravar(xmlUsuarios, "Usuarios", false);
            }

        }*/
    }
}
