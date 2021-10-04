using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaConexion
{
    public class ConexionRapida
    {
        private SqlConnection conexion = new SqlConnection();

        public ConexionRapida(string database)
        {
            FuenteDeConexion(database);
        }

        private void FuenteDeConexion(string baseDeDatos)
        {
            SqlConnectionStringBuilder cadenaConexion = new SqlConnectionStringBuilder();

            cadenaConexion.DataSource = "localhost\\SQLEXPRESS";
            cadenaConexion.InitialCatalog = baseDeDatos;
            cadenaConexion.IntegratedSecurity = true;

            conexion.ConnectionString = cadenaConexion.ConnectionString;            
        }


        public SqlConnection Conectar()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }

            return conexion;
        }

        public SqlConnection Desconectar()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }

            return conexion;
        }

    }
}
