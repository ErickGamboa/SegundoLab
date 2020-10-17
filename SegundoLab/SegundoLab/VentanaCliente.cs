using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapaLogica.LGeografía;
using CapaEntidad;

namespace SegundoLab
{
    public partial class VentanaCliente : Form

        
    {
        public List<ECliente> listaClientes;
        public List<string> listaNumeros;

        public VentanaCliente()
        {
            InitializeComponent();
            listaClientes = new List<ECliente>();
            this.listaNumeros = new List<string>();   
        }

        NGeografía geografía = new NGeografía();

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VentanaPrincipal ventanaP = new VentanaPrincipal();
            ventanaP.Show(this);
            this.Hide();
        }

        private void cbxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LProvincias()
        {
            List<EGeografía> provincia = geografía.listadoProvincia(1);
            cbxProvincia.DataSource = provincia;
            cbxProvincia.ValueMember = "id";
            cbxProvincia.DisplayMember = "nombre";
        }
        private void LCanton()
        {
            cbxCanton.DataSource = null;
            string provincia = cbxProvincia.SelectedValue.ToString();
            int dato = int.Parse(provincia);
            List<EGeografía> canton = geografía.listadoCanton(2, dato);
            cbxCanton.DataSource = canton;
            cbxCanton.ValueMember = "id";
            cbxCanton.DisplayMember = "nombre";

        }
        private void LDistrito()
        {
            cbxDistrito.DataSource = null;
            string canton = cbxCanton.SelectedValue.ToString();
            int cantonn = int.Parse(canton);
            string provincia = cbxProvincia.SelectedValue.ToString();
            int provinciaa = int.Parse(provincia);
            List<EGeografía> distrito = geografía.listadoDistrito(3,provinciaa,cantonn);
            cbxDistrito.DataSource = distrito;
            cbxDistrito.ValueMember = "id";
            cbxDistrito.DisplayMember = "nombre";

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void cbxProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LCanton();
        }

        private void cbxCanton_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LDistrito();
        }

        private void cbxDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            ECliente cliente = new ECliente();

            if (cbxDistrito.SelectedIndex != -1 & cliente!=null)
            {
                cliente.nombre = txtNombre.Text;
                cliente.apellidoUno = txtApellido1.Text;
                cliente.apellidoDos = txtApellido2.Text;
                cliente.fechaNacimiento = Convert.ToDateTime(cbxfechaNacido.Value);
                cliente.estado = cbxestado.Text;
                cliente.edad =  DateTime.Now.Year - cliente.fechaNacimiento.Year ;
                cliente.provincia = cbxProvincia.Text;
                cliente.canton = cbxCanton.Text;
                cliente.distrito = cbxDistrito.Text;
                cliente.telefonos = this.listaNumeros;
                this.listaClientes.Add(cliente);
                limpiarDatos();
                
            }
            else
            {
                lblMensaje.Text = "Debe ingresar la totalidad de los datos (Intenta revisar los datos de dirección)";
            }
        }

        private void VentanaCliente_Load(object sender, EventArgs e)
        {
            LProvincias();
        }

        private void cbxCanton_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarNum_Click(object sender, EventArgs e)
        {
            this.listaNumeros.Add(txtTelefono.Text);
            cargarNumeros();
        }

        

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        public void cargarNumeros() {
            this.LimpiarList();
            foreach (string item in this.listaNumeros)
            {
                lstTelefonos.Items.Add(item);
            }
            
        }

        public void limpiarDatos() {
            LimpiarList();
            txtNombre.Text = "";
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtTelefono.Text = "";
            
                this.listaNumeros.RemoveRange(0, (this.listaNumeros.Count));
        }

        public void LimpiarList()
        {
            foreach (string item in this.listaNumeros)
            {
                lstTelefonos.Items.Remove(item);
            }
        }

        private void btnMostrarClientes_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = this.listaClientes;
            
        }

        private void eClienteBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
