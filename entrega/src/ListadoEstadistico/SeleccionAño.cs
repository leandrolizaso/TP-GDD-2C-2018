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

namespace PalcoNet.ListadoEstadistico
{
    public partial class SeleccionAño : Form
    {
        public SeleccionAño()
        {
            InitializeComponent();
            this.cargarComboBox();
        }

        private void cargarComboBox()
        {
            int anio = Globales.getFechaHoy().Year;

            for (int i = 0; i < 25; i++)
            {
                comboAnio.Text = Convert.ToString(anio -i);  
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void SeleccionAño_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SeleccionMes(Int32.Parse(comboAnio.SelectedText)).ShowDialog();
            this.Show();
        }
    }
}
