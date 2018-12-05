using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.RegistroUsuario
{
    public partial class CambiarPass : Form
    {
        decimal user;

        public CambiarPass(decimal user)
        {
            InitializeComponent();
            this.user = user;
            pass.Text = "";
            pass.PasswordChar = '*';
            
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            //if user==0 -> el usuario esta cambiendo la pass, sino es el admin
            if (user == 0)
            {
                new LoginDAO().cambiarPass(Globales.idUsuarioLoggeado, pass.Text, false);
            }
            else 
            {
                new LoginDAO().cambiarPass(user, pass.Text, true);
            }

            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CambiarPass_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void CambiarPass_Load(object sender, EventArgs e)
        {

        }
    }
}
