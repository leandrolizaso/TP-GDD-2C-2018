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

        private void datagrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id_clickeado = (decimal)datagrid["empr_id", e.RowIndex].Value;
            this.Hide();
            new ModificarEmpresa(id_clickeado).ShowDialog();
            this.Show();
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
