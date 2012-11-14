using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace FiqueRico.Web
{
    public partial class testescript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FileStream file = File.Create(HttpContext.Current.Server.MapPath(@"/fiquerico/App_Data/") + "testescript" + ".xml");
            //Create a new Buffered stream
            BufferedStream buffered = new BufferedStream(file);

            //Use a StreamWriter to write data into the buffered stream.
            StreamWriter writer = new StreamWriter(buffered);
            writer.WriteLine("vai gravar");
            writer.Close();
        }
    }
}