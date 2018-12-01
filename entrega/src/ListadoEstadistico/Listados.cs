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
        string fechaDesde;
        string fechaHasta;

        public listados(string fechaDesde, string fechaHasta)
        {
            InitializeComponent();
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
        }

        private void localidades_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadoEmpresas(fechaDesde).ShowDialog();
                                //Pongo una sola porque se supone que es por un solo mes
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
    }
}
