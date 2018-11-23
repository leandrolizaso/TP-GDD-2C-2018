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
            //obtener los clientes con un procedure
            var dt = new DataTable();
            dt.Columns.Add("clie_id");
            dt.Columns.Add("clie_nombre");
            dt.Columns.Add("clie_apellido");
            
            dt.Rows.Add(new object[] { 1, "Juan","Perez" });
            dt.Rows.Add(new object[] { 2, "Pedro","Egûez" });
            dt.Rows.Add(new object[] { 3, "Miguel","Lizaso" });

            //hacemos magia despues
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
     }
}
