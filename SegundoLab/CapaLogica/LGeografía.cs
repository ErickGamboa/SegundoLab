using CapaServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using Newtonsoft.Json;

namespace CapaLogica
{
   public class LGeografía
    {
        public class NGeografía
        {
            SGeografía geografia = new SGeografía();
            List<EGeografía> listProvincia = new List<EGeografía>();
            List<EGeografía> listCanton = new List<EGeografía>();
            List<EGeografía> listDistrito = new List<EGeografía>();

            public List<EGeografía> listadoProvincia(int tipo, int provincia = 1)
            {
                listProvincia.Clear();
                string respuesta = geografia.obtenerGeografía(tipo, provincia);
                var dicProvincia = JsonConvert.DeserializeObject<Dictionary<string, string>>(respuesta);
                foreach (var dp in dicProvincia)
                {
                    listProvincia.Add(new EGeografía(dp.Key, dp.Value));
                }
                return listProvincia;

            }

            public List<EGeografía> listadoCanton(int tipo, int provincia = 1)
            {
                listCanton.Clear();
                string respuesta = geografia.obtenerGeografía(tipo, provincia);
                var dicCanton = JsonConvert.DeserializeObject<Dictionary<string, string>>(respuesta);
                foreach (var dc in dicCanton)
                {
                    listCanton.Add(new EGeografía(dc.Key, dc.Value));
                }
                return listCanton;

            }

            public List<EGeografía> listadoDistrito(int tipo, int provincia = 1, int canton =1)
            {
                listDistrito.Clear();
                string respuesta = geografia.obtenerGeografía(tipo, provincia, canton);
                var dicDistrito = JsonConvert.DeserializeObject<Dictionary<string, string>>(respuesta);
                foreach (var dc in dicDistrito)
                {
                    listDistrito.Add(new EGeografía(dc.Key, dc.Value));
                }
                return listDistrito;

            }


        }

    }
}
