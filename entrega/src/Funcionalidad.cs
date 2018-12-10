using PalcoNet.AbmCliente;
using PalcoNet.AbmEmpresa;
using PalcoNet.AbmGrado;
using PalcoNet.AbmRol;
using PalcoNet.CanjePuntos;
using PalcoNet.Comprar;
using PalcoNet.Publicacion;
using PalcoNet.GenerarRendicionComisiones;
using PalcoNet.HistorialCliente;
using PalcoNet.ListadoEstadistico;
using PalcoNet.RegistroUsuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Utils;

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
            Button cambiarPass = new Button();
            cambiarPass.Text = "CAMBIAR CONTRASEÑA";
            cambiarPass.AutoSize = true;
            cambiarPass.Click += cambiarPass_Click;
            panel.Controls.Add(cambiarPass);
        }

        private void cambiarPass_Click(object sender, EventArgs e)
        {

            if (new RolDAO().esAdmin(Globales.idUsuarioLoggeado))
            {
                new ListaUsuario().ShowDialog();
            }
            else
            {
                new CambiarPass(0).ShowDialog();
            }
        }

        private void funcionElegida(object sender, EventArgs e) {

            Button button = (Button)sender;

            Form proximaPantalla = null;

            try
            {
                switch (button.Name.Substring(6))
                {
                    case "1":  //roles
                        proximaPantalla = new ListaRol();
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
                        System.Windows.Forms.MessageBox.Show("CATEGORIA??????");
                        break;
                    case "6":
                        proximaPantalla = new ListaPublicaciones(false);
                        break;
                    case "7":
                        proximaPantalla = new ListaPuntos();
                        break;
                    case "8":
                        proximaPantalla = new ModificarPublicacion(-1);
                        break;
                    case "9":
                        proximaPantalla = new ListaPublicaciones(true);
                        break;
                    case "10":
                        proximaPantalla = new MostrarHistorialCliente();
                        break;
                    case "11":
                        proximaPantalla = new GenerarRendicion();
                        break;
                    case "12":
                        proximaPantalla = new ListadosSeleccionAnio();
                        break;
                    default:
                        System.Windows.Forms.MessageBox.Show(string.Format("La funcionalidad id:{0} \"{}\" no esta implementada.", button.Name.Substring(6), button.Text));
                        break;
                }

                if (proximaPantalla != null)
                {
                    this.Hide();
                    proximaPantalla.ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                this.Show();
                MessageBox.Show(ex.Message, "Se produjo el siguiente error");
            }
                           
        }

    }
}
