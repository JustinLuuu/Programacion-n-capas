using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos capaDatos = new CD_Productos();
        Producto infoProducto = new Producto();

        DataTable tabla = new DataTable();

        public DataTable MostrarProductos()
        {
            tabla.Clear();
            tabla = capaDatos.Mostrar();

            return tabla;
        }

        public void InsertarProducto(string nombre, string marca, string precio, string proveedor)
        {
            infoProducto.NOMBRE = nombre;
            infoProducto.MARCA = marca;
            infoProducto.PRECIO = Convert.ToDecimal(precio);
            infoProducto.PROVEEDOR = proveedor;

            capaDatos.Insertar(infoProducto.NOMBRE, infoProducto.MARCA, infoProducto.PRECIO, infoProducto.PROVEEDOR);
        }
       
        public void LlenarCombo( ComboBox combo)
        {
            capaDatos.LlenandoComboBox(combo);
        }

        public void LlenarTxt(TextBox txtNom, TextBox txtMarca, TextBox txtPrecio, TextBox txtProveedor, int ID)
        {
            capaDatos.LlenandoTxt(txtNom, txtMarca, txtPrecio, txtProveedor, ID);
        }

    }
}
