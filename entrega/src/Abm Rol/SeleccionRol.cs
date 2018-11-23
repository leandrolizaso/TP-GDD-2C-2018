using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Rol
{
    public partial class SeleccionRol : Form
    {
        private Decimal usuario;

        public SeleccionRol(Decimal usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
            actualizarRoles();
        }

        private void actualizarRoles()
        {
            var dt = new RolDAO().obtenerListaRoles(usuario);

            roles.ValueMember = "rol_id";
            roles.DisplayMember = "rol_nombre";
            roles.DataSource = dt.DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Windows.Forms.MessageBox.Show(roles.Text + "(" + roles.SelectedValue+")");
            //new Funcionalidad().ShowDialog();
            this.Show();
        }

    }
}
