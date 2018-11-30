using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.CanjePuntos
{
    public partial class ListaPuntos : Form
    {
        public ListaPuntos()
        {
            InitializeComponent();
        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void crear_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CanjePremio().ShowDialog();
            this.Show();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListaPuntos_Load(object sender, EventArgs e)
        {

        }
    }
}
