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
        private int usuario;

        public SeleccionRol(int usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
            actualizarRoles();
        }

        private void actualizarRoles()
        {
            //RolDAO.getRolesPorIdUsuario(usuario);
            //roles.DataSource = new DataTable();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Funcionalidad().ShowDialog();
            this.Show();
        }

    }
}
