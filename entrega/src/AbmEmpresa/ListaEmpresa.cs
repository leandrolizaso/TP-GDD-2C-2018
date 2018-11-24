using PalcoNet.AbmEmpresa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.AbmEmpresa
{
    public partial class ListaEmpresa : Form
    {
        private decimal id_clickeado;

        public ListaEmpresa()
        {
            InitializeComponent();
        }

        private void buscar_Click(object sender, EventArgs e) {
            var dt = new EmpresaDAO().obtenerEmpresas(razon.Text, cuit.Text, email.Text);
            datagrid.DataSource = dt;
            foreach( DataGridViewColumn column in datagrid.Columns){
                column.HeaderText = column.HeaderText.Replace("empr_", "").Replace("_", " ").ToUpper();
            }
        }

        private void datagrid_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                ContextMenu m = new ContextMenu();

                int currentMouseOverRow = datagrid.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0) {
                    id_clickeado = (decimal)datagrid["empr_id", currentMouseOverRow].Value;
                    var nombre = datagrid["empr_razon_social", currentMouseOverRow].Value;

                    m.MenuItems.Add(new MenuItem(string.Format("Modificar {0}", nombre), modificar));
                    m.MenuItems.Add(new MenuItem(string.Format("Eliminar {0}", nombre),eliminar));
                }

                m.Show(datagrid, new Point(e.X, e.Y));

            }
        }

        private void modificar(object sender, EventArgs e) {
            this.Hide();
            new ModificarEmpresa(id_clickeado).ShowDialog();
            this.Show();
            buscar_Click(sender,e);
        }

        private void eliminar(object sender, EventArgs e) {
            System.Windows.Forms.MessageBox.Show("Not yet " + id_clickeado);
            buscar_Click(sender, e);
        }

        private void limpiar_Click(object sender, EventArgs e) {
            razon.Text = "";
            cuit.Text = "";
            email.Text = "";
            datagrid.DataSource = null;
        }

     }

}
