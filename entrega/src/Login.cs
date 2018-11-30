using PalcoNet.AbmRol;
using PalcoNet.RegistroUsuario;
using PalcoNet.Utils;
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

namespace PalcoNet
{
    public partial class Login : Form
    {

        public Login(){
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal idUsuario = new LoginDAO().esUsuarioActivo(usuario.Text, pass.Text);
                this.Hide();
                new SeleccionRol(idUsuario).ShowDialog();
                this.Show();
            }
            catch (ArgumentException ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                pass.Text = ""; //Por las dudas
                pass.Focus();
                return;
            }
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.Hide();
            new NuevoUsuario().ShowDialog();
            this.Show();
        }
    }
}
