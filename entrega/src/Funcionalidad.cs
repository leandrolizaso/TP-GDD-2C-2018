using PalcoNet.Abm_Rol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class Funcionalidad : Form
    {
        private Decimal idRol;

        public Funcionalidad(Decimal idRol)
        {
            this.idRol = idRol;
            InitializeComponent();
            displayButtons();
        }

        private void displayButtons(){
            var funciones = new RolDAO().obtenerListaFunciones(idRol);

            foreach (DataRow funcion in funciones.Rows)
            {
                Button button = new Button();
                button.Text = funcion["func_nombre"].ToString();
                button.Name = "button" + funcion["func_id"];
                button.Click += funcionElegida;
                button.AutoSize = true;
                panel.Controls.Add(button);
            }
        }

        private void funcionElegida(object sender, EventArgs e) {
            Button button = (Button)sender;
            System.Windows.Forms.MessageBox.Show("Click en "+button.Text+"("+button.Name+")");
        }

    }
}
