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
    public partial class ListadosSeleccionAnio : Form
    {
        public ListadosSeleccionAnio()
        {
            InitializeComponent();
            this.cargarComboBox();
            
        }

        private void cargarComboBox()
        {
            int anio = Globales.getFechaHoy().Year;
            
            for (int i = 0; i < 25; i++)
            {
                comboAnio.Items.Add(anio-i);  
            }

            //comboAnio.BindingContext = new BindingContext();
            comboAnio.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            int anio = Convert.ToInt16(comboAnio.SelectedItem);
            new ListadosSeleccionMes(anio).ShowDialog();
        }

    }
}
