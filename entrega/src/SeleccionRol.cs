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
            //RolDAO.getRolesPorIdUsuario(usuario);
            var dt = new DataTable();
            dt.Columns.Add("rol_id");
            dt.Columns.Add("roles");

            dt.Rows.Add(new object[] { 1, "Ejemplo1" });
            dt.Rows.Add(new object[] { 2, "Ejemplo2" });
            dt.Rows.Add(new object[] { 3, "Ejemplo3" });

            roles.ValueMember = "rol_id";
            roles.DisplayMember = "roles";
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
