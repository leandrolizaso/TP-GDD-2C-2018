using PalcoNet.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.HistorialCliente
{
    public partial class MostrarHistorialCliente : Form
    {
        private int pagina = 1;
        private int ultimaPagina;
        private decimal idCliente;

        public MostrarHistorialCliente()
        {
            InitializeComponent();
            idCliente = Globales.idUsuarioLoggeado;
            ultimaPagina = Convert.ToInt32(Math.Ceiling((new HistorialDAO().totalPaginas(idCliente)) / 10));
            this.llenar_grilla();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void llenar_grilla()
        {      
            var dt = new HistorialDAO().obtenerHistorial(1, pagina);
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("compr_", "").Replace("_", " ").ToUpper();
            }
        }

        private void primera_Click(object sender, EventArgs e)
        {
            pagina = 1;
            this.llenar_grilla();

        }

        private void anterior_Click(object sender, EventArgs e)
        {
            if (pagina > 1)
            {
                pagina -= 1;
            }
            this.llenar_grilla();
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            if (pagina < ultimaPagina)
            {
                pagina += 1;
            }
            this.llenar_grilla();
        }

        private void ultimo_Click(object sender, EventArgs e)
        {
            pagina = ultimaPagina;
            this.llenar_grilla();
        }
    }
}
