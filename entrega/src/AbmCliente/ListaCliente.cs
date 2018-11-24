using PalcoNet.AbmCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.AbmCliente
{
    public partial class ListaCliente : Form
    {
        private decimal clie_id_clickeado;

        public ListaCliente()
        {
            InitializeComponent();
        }

        private void buscar_Click(object sender, EventArgs e) {
            var dt = new ClienteDAO().obtenerClientes(nombre.Text, apellido.Text, dni.Text, email.Text);
            datagrid.DataSource = dt;
            foreach( DataGridViewColumn column in datagrid.Columns){
                column.HeaderText = column.HeaderText.Replace("clie_", "").Replace("_", " ").ToUpper();
            }
        }

        private void datagrid_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                ContextMenu m = new ContextMenu();

                int currentMouseOverRow = datagrid.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0) {
                    clie_id_clickeado = (decimal)datagrid["clie_id", currentMouseOverRow].Value;
                    var nombre = datagrid["clie_nombre", currentMouseOverRow].Value;
                    var apellido = datagrid["clie_apellido", currentMouseOverRow].Value;

                    m.MenuItems.Add(new MenuItem(string.Format("Modificar {0} {1}", nombre, apellido), modificar));
                    m.MenuItems.Add(new MenuItem(string.Format("Eliminar {0} {1}", nombre, apellido),eliminar));
                }

                m.Show(datagrid, new Point(e.X, e.Y));

            }
        }

        private void modificar(object sender, EventArgs e) {
            this.Hide();
            new ModificarCliente(clie_id_clickeado).ShowDialog();
            this.Show();
            buscar_Click(sender,e);
        }

        private void eliminar(object sender, EventArgs e) {
            System.Windows.Forms.MessageBox.Show("Not yet" + clie_id_clickeado);
            buscar_Click(sender, e);
        }

        private void limpiar_Click(object sender, EventArgs e) {
            nombre.Text = "";
            apellido.Text = "";
            dni.Text = "";
            email.Text = "";
            datagrid.DataSource = null;
        }

     }

}
