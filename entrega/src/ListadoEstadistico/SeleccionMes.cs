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
    public partial class SeleccionMes : Form
    {
        int anio;
        DateTime[] periodo;

        public SeleccionMes(int anio)
        {
            InitializeComponent();
            this.anio = anio;
            this.cargarComboBox();
        }

        private void cargarComboBox()
        {
            comboMes.DisplayMember = "Text";
            comboMes.ValueMember = "Value";
            comboMes.DataSource = new[] { 
                        new { Text = "enero-marzo", Value = 1 }, 
                        new { Text = "abril-junio", Value = 2 }, 
                        new { Text = "julio-septiembre", Value = 3 }, 
                        new { Text = "octubre-diciembre", Value = 4 }
                    };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            periodo = Fechas.getRango((int)comboMes.SelectedValue, anio);
            new listados(periodo[0], periodo[1]).ShowDialog();
            this.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
