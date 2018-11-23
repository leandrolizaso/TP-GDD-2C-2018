using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class ListaCliente : Form
    {
        public ListaCliente()
        {
            InitializeComponent();
        }

        private void buscar_Click(object sender, EventArgs e) {
            var dt = new ClienteDAO().obtenerClientes("nom", "ape", "dni", "mail");
            datagrid.DataSource = dt;

            DataGridViewButtonColumn modify = new DataGridViewButtonColumn();
            modify.Name = "button";
            modify.HeaderText = "Modificar";
            modify.Text = "Seleccionar";
            modify.UseColumnTextForButtonValue = true;
            datagrid.Columns.Add(modify);

            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.Name = "button";
            delete.HeaderText = "Borrar";
            delete.Text = "Seleccionar";
            delete.UseColumnTextForButtonValue = true;
            datagrid.Columns.Add(delete);

        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e){
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0) {
                var clie_id = senderGrid[0, e.RowIndex].Value;
                string action;
                switch(e.ColumnIndex){
                    case 3: action = "Editar";break;
                    case 4: action = "Borrar";break;
                    default: action = e.ColumnIndex.ToString(); break;
                }
                
                System.Windows.Forms.MessageBox.Show("Row:"+e.RowIndex+", Collumn:"+e.ColumnIndex+"\nID:"+clie_id+"\nAction:"+action); 
            }
        }

        
        private void datagrid_MouseClick(object sender, MouseEventArgs e) {
            //Repasar esto, salio de google
            // Al hacer click derecho sale un menu
            // Seria mejor que la accion de modificar/borrar sea con menu
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Modificar"));
                m.MenuItems.Add(new MenuItem("Eliminar"));

                int currentMouseOverRow = datagrid.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0) {
                    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                }

                m.Show(datagrid, new Point(e.X, e.Y));

            }
        }
     }
}
