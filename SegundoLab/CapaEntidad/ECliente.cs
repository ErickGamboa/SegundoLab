using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidad
{
    public class ECliente
    {

        
        public string nombre { get; set; }
        public string apellidoUno { get; set; }
        public string apellidoDos { get; set; }
        public DateTime fechaNacimiento {get; set;}
        public int edad { get; set; }
        public string estado { get; set; }
        public List<string> telefonos { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public ECliente()
        {
            this.telefonos = new List<string>();
        }

        public ECliente(string nombre, string apellidoUno, string apellidoDos, DateTime fechaNacimiento, int edad, string estado, List<string> telefonos, string provincia, string canton, string distrito)
        {
            this.nombre = nombre;
            this.apellidoUno = apellidoUno;
            this.apellidoDos = apellidoDos;
            this.fechaNacimiento = fechaNacimiento;
            this.edad = edad;
            this.estado = estado;
            this.telefonos = telefonos;
            this.provincia = provincia;
            this.canton = canton;
            this.distrito = distrito;
        }
    }
}
