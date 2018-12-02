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
        private int pagina = 1;
        private int ultimaPagina = 1;

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

            ultimaPagina = Convert.ToInt32(Math.Ceiling((new PublicacionDAO().totalPaginas("1,2,3,", nombre.SelectedText, fecha_desde.Value, fecha_hasta.Value)) / 10));
                                                                                   //hardcode de id de rubros 1,2,3 y 4
            this.llenar_grilla();

            //era una linea, pero mejor 3 para legibilidad
            //MessageBox.Show(string.Format("Los rubros seleccionados son: {0}", string.Join(",", rubros)));

            //string rubroStr = string.Join(",", rubros);
            //string mensaje = string.Format("Los rubros seleccionados son: {0}", rubroStr); 
            //MessageBox.Show(mensaje);
        }

        private void llenar_grilla()
        {
            pag.Text = Convert.ToString(pagina);
            var dt = new PublicacionDAO().obtenerPublicaciones("1,2,3,", nombre.SelectedText, fecha_desde.Value, fecha_hasta.Value, pagina);
                                                               //hardcode de id de rubros 1,2,3 y 4
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("publ_", "").Replace("_", " ").ToUpper();
            }
        }

        private void Rubros_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ultimo_Click(object sender, EventArgs e)
        {
            if (ultimaPagina == 0)
            {
                pagina = 1;
            }
            else
            {
                pagina = ultimaPagina;
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

        private void anterior_Click(object sender, EventArgs e)
        {
            if (pagina > 1)
            {
                pagina -= 1;
            }
            this.llenar_grilla();
        }

        private void primera_Click(object sender, EventArgs e)
        {
            pagina = 1;
            this.llenar_grilla();
        }

    }
}
