using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    class Producto
    {
        private string nombre;
        private string marca;
        private decimal precio;
        private string proveedor;

        public string NOMBRE
        {
            get { return nombre; }
            set { nombre = value.ToUpper(); }
        }

        public string MARCA
        {
            get { return marca; }
            set { marca = value.ToUpper(); }
        }

        public decimal PRECIO
        {
            get { return precio; }
            set { precio = value; }
        }

        public string PROVEEDOR
        {
            get { return proveedor; }
            set { proveedor = value.ToUpper(); }
        }

    }
}
