using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class ListaPublicaciones : Form
    {

        List<decimal> rubros;

        public ListaPublicaciones()
        {
            InitializeComponent();
            rubros = new List<decimal>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var rubroForm = new Rubro())
            {
                rubroForm.ShowDialog();
                Label label = new Label();
                label.Text = rubroForm.texto;
                label.AutoSize = true;
                label.BorderStyle = BorderStyle.Fixed3D;
                rubros.Add(rubroForm.id);
                Rubros.Controls.Add(label);
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            //era una linea, pero mejor 3 para legibilidad
            //MessageBox.Show(string.Format("Los rubros seleccionados son: {0}", string.Join(",", rubros)));

            string rubroStr = string.Join(",", rubros);
            string mensaje = string.Format("Los rubros seleccionados son: {0}", rubroStr); 
            MessageBox.Show(mensaje);
        }

    }
}
