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
    public partial class GenerarRendicion : Form
    {
        public GenerarRendicion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GenerarRendicion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Factura(Int32.Parse(cantidad.Text)).ShowDialog();
            this.Show();
        }
    }
}
