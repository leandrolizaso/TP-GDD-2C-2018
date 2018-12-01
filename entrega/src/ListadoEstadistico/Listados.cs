using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.ListadoEstadistico
{   
    

    public partial class listados : Form
    {
        DateTime fechaDesde;
        DateTime fechaHasta;

        public listados(DateTime fechaDesde, DateTime fechaHasta)
        {
            InitializeComponent();
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
        }

        private void localidades_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadoEmpresas(fechaDesde, fechaHasta).ShowDialog();
            this.Show();
        }

        private void puntos_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadoPuntos(fechaDesde, fechaHasta).ShowDialog();
            this.Show();
        }

        private void compras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadoCompras(fechaDesde, fechaHasta).ShowDialog();
            this.Show();
        }

        private void listados_Load(object sender, EventArgs e)
        {

        }
    }
}
