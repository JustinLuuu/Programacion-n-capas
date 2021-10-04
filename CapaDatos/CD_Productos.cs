using LibreriaConexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
   public class CD_Productos
    {
        ConexionRapida conectarRapido = new ConexionRapida("ProductosNCapas"); 
        SqlDataReader lector;
        ComboBox combo = new ComboBox();
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conectarRapido.Conectar();
            comando.CommandText = "sp_Mostrar";
            comando.CommandType = CommandType.StoredProcedure;
            lector = comando.ExecuteReader();

            tabla.Load(lector);

            conectarRapido.Desconectar();

            return tabla;
        }

        public void Insertar(string nombre, string marca, decimal precio, string proveedor)
        {
            if (Revisar(nombre, marca) == true)
            {
                MessageBox.Show($"Ya existe un producto con el nombre [{nombre}] y la marca [{marca}]  ");
            }

            else
            {
                comando.Parameters.Clear();    // limpiar parametros del comando y agregar nuevos, dado a que nos daba error por una sobrecarga de parametros
                comando.Connection = conectarRapido.Conectar();
                comando.CommandText = "sp_Insertar";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Marca", marca);
                comando.Parameters.AddWithValue("@Precio", precio);
                comando.Parameters.AddWithValue("@Proveedor", proveedor);

                comando.ExecuteNonQuery();
                conectarRapido.Desconectar();
                MessageBox.Show("Producto insertado con exito");
            }
          
        }
            
        private bool Revisar(string nombreProducto, string marcaProducto)
        {
            comando.Parameters.Clear();   // limpiar parametros del comando y agregar nuevos, dado a que nos daba error por una sobrecarga de parametros
            comando.Connection = conectarRapido.Conectar();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from dbo.Productos where Nombre= @NombreProducto and Marca= @MarcaProducto";           
            comando.Parameters.AddWithValue("@NombreProducto", nombreProducto);
            comando.Parameters.AddWithValue("@MarcaProducto", marcaProducto);
            lector = comando.ExecuteReader();

            if(lector.Read() == true)
            {
                conectarRapido.Desconectar();
                return true;
            }

            else
            {
                conectarRapido.Desconectar();
                return false;
            }

        }

        public void LlenandoComboBox(ComboBox combo)
        {
            combo.Items.Clear();
            comando.Connection = conectarRapido.Conectar();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select Id, Nombre from dbo.Productos";
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                combo.Items.Add($" ID [ {lector["Id"].ToString()} ]  {lector["Nombre"].ToString()} ");
            }

            conectarRapido.Desconectar();
            
        }

        public void LlenandoTxt(TextBox txtNom, TextBox txtMarca, TextBox txtPrecio, TextBox txtProveedor, int ID)
        {
            comando.Parameters.Clear();
            comando.Connection = conectarRapido.Conectar();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from dbo.Productos where ID = @ID";
            comando.Parameters.AddWithValue("@ID", ID);
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                txtNom.Text = lector["Nombre"].ToString();
                txtMarca.Text = lector["Marca"].ToString();
                txtPrecio.Text = lector["Precio"].ToString();
                txtProveedor.Text = lector["Proveedor"].ToString();
            }

            conectarRapido.Desconectar();

        }

   }
}
