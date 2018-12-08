using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.GenerarRendicionComisiones
{
    public partial class Factura : Form
    {
        decimal numeroFactura;
        int cantidad;
        decimal idEmpresa;

        public Factura(int cantidad, decimal empresa)
        {
            InitializeComponent();
            this.cantidad = cantidad;
            this.idEmpresa = empresa;
            llenar_grilla();
        }

        private void llenar_grilla()
        {
            var dao = new FacturaDAO();
            int cantidadPorRendir = dao.cantidadARendir(idEmpresa);

            if (cantidadPorRendir != 0)
            {
                numeroFactura = new FacturaDAO().generarFactura(cantidad, idEmpresa);
                var dt = dao.obtenerFactura(numeroFactura);
                datagrid.DataSource = dt;
                foreach (DataGridViewColumn column in datagrid.Columns)
                {
                    column.HeaderText = column.HeaderText.Replace("fact_", "").Replace("ubic_", "").Replace("_", " ").ToUpper();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No hay ubicaciones para facturar");
                
            }
            
        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
