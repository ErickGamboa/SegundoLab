using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicio
{
   public class SGeografía
    {
        private string urlGeografía;

        public string obtenerGeografía(int tipo, int provincia = 1, int canton = 1)
        {

            if (tipo == 1)
            {
                urlGeografía = "https://ubicaciones.paginasweb.cr/provincias.json";
            }
            if (tipo == 2)
            {
                urlGeografía = "https://ubicaciones.paginasweb.cr/provincia/" + provincia + "/cantones.json";
            }
            if (tipo == 3) {

                urlGeografía = "https://ubicaciones.paginasweb.cr/provincia/" + provincia + "/canton/"+canton+ "/distritos.json";

            }

            WebRequest solicitud = WebRequest.Create(this.urlGeografía);
            WebResponse respuesta = solicitud.GetResponse();
            StreamReader sr = new StreamReader(respuesta.GetResponseStream());
            return sr.ReadToEnd().ToString();


        }
    }
}
