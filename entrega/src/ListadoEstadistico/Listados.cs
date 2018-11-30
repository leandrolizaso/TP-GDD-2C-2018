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
        public listados()
        {
            InitializeComponent();
        }

        private void localidades_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadoEmpresas().ShowDialog();
            this.Show();
        }

        private void puntos_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadoPuntos().ShowDialog();
            this.Show();
        }

        private void compras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadoCompras().ShowDialog();
            this.Show();
        }
    }
}
