using PalcoNet.AbmCliente;
using PalcoNet.AbmEmpresa;
using PalcoNet.AbmGrado;
using PalcoNet.AbmRol;
using PalcoNet.ListadoEstadistico;
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

            Form proximaPantalla = null;
            
            switch(button.Name.Substring(6)) {
                case "1":  //roles
                    System.Windows.Forms.MessageBox.Show("ROLES"); 
                    break;
                case "2": 
                    proximaPantalla = new ListaCliente();
                    break;
                case "3":
                    proximaPantalla = new ListaEmpresa();
                    break;
                case "4":
                    proximaPantalla = new ListaGrado();
                    break;
                case "5": 
                    System.Windows.Forms.MessageBox.Show("CATEGORIA"); 
                    break;
                case "12":
                    proximaPantalla = new ListadosSeleccionAnio();
                    break;
                default: 
                    System.Windows.Forms.MessageBox.Show("Ay.. nose."); 
                    break;
            }

            if (proximaPantalla != null) {
                this.Hide();
                proximaPantalla.ShowDialog();
                this.Show();
            }
        }

    }
}
