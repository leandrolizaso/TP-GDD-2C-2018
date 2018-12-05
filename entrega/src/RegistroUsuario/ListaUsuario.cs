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
    public partial class ListaUsuario : Form
    {
        public ListaUsuario()
        {
            InitializeComponent();

            var dt = new UsuarioDAO().obtenerUsuarios();
            dataGridView1.DataSource = dt;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("usua_", "").Replace("_", " ").ToUpper();
            }
            
            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            new CambiarPass(Convert.ToDecimal(dataGridView1.CurrentRow.Cells["usua_id"].Value)).ShowDialog();
        }
    }
}
