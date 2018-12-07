using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.AbmRubro
{
    public partial class Rubro : Form
    {

        public string rubros { get; set; }

        public Rubro()
        {
            InitializeComponent();
            rubros = "";
            var dt = new RubroDAO().obtenerRubros();
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("rubr_", "").Replace("_", " ").ToUpper();
            }
            datagrid.Columns["rubr_id"].Visible = false;
            DataGridViewCheckBoxColumn clm = new DataGridViewCheckBoxColumn();
            clm.HeaderText = "Seleccionar";
            clm.Name = "Seleccionar";
            datagrid.Columns.Add(clm);
            datagrid.Columns["rubr_descripcion"].ReadOnly = true;
            datagrid.Columns["Seleccionar"].ReadOnly = false;
            datagrid.AllowUserToAddRows = false;

            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datagrid.Rows)
            {

                if (Convert.ToBoolean(row.Cells["Seleccionar"].Value) == true)
                {
                    rubros = rubros + Convert.ToString(row.Cells["rubr_id"].Value) + ", ";
                }


            }
            MessageBox.Show("Categorias seleccionadas exitosamente");
            this.Close();
        }

    }
}
