using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    class LimpiarTodo
    {
        public void Limpia(Form formulario)
        {
            foreach(Control control in formulario.Controls)
            {
                if(control is TextBox)
                {
                    ((TextBox)control).Clear(); 
                }

            }

        }




    }
}
