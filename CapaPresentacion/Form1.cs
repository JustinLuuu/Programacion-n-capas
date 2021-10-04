using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos capaNegocio = new CN_Productos();  // instancia de la capa de Negocios
     
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {         
            MostrarProductos();
            LlenarComboBox();
        }


        void MostrarProductos()
        {
            CN_Productos mostrar = new CN_Productos();
            dgvProductos.DataSource = mostrar.MostrarProductos();
        }


        void LlenarComboBox()
        {
            CN_Productos llenar = new CN_Productos();
            llenar.LlenarCombo( cmbProductos);
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == string.Empty || txtMarca.Text == string.Empty || txtPrecio.Text == string.Empty || txtProveedor.Text == string.Empty)
            {
                MessageBox.Show("IMPOSIBLE AGREGAR PRODUCTO CON CAMPOS VACIOS !");
            }

            else
            {
                try
                {
                    capaNegocio.InsertarProducto(txtNombre.Text, txtMarca.Text, txtPrecio.Text, txtProveedor.Text);                   
                    MostrarProductos();
                    LlenarComboBox();
                }
                catch(Exception err)
                {
                    MessageBox.Show("No se pudo insertar el producto por: " + err.Message);
                }
            
            }
        }


        private void cmbProductos_SelectedValueChanged(object sender, EventArgs e)
        {
            int id;
            string[] separador = cmbProductos.Text.Split(' ');
            id = Convert.ToInt32(separador[3]);

            capaNegocio.LlenarTxt(txtNombre, txtMarca, txtPrecio, txtProveedor, id);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTodo clearAll = new LimpiarTodo();
            clearAll.Limpia(this);
        }
    }
}
