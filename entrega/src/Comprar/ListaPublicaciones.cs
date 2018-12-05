using PalcoNet.EditarPublicacion;
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

namespace PalcoNet.Comprar
{
    public partial class ListaPublicaciones : Form
    {

        string rubros;
        private int pagina = 1;
        private int ultimaPagina = 1;
        private bool esEmpresa;

        public ListaPublicaciones(bool esEmpr)
        {
            InitializeComponent();
            esEmpresa = esEmpr;
            rubros = "";
            fecha_desde.Value = Globales.getFechaHoy();
            fecha_hasta.Value = Globales.getFechaHoy();
            pag.Text = Convert.ToString(pagina);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rubrosForm = new Rubro();
            rubrosForm.ShowDialog();
            rubros = rubrosForm.rubros;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            rubros = "";
            nombre.Text = "";
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            ultimaPagina = Convert.ToInt32(Math.Ceiling((new PublicacionDAO().totalPaginas(rubros, nombre.Text, fecha_desde.Value, fecha_hasta.Value)) / 10));                                                                
            this.llenar_grilla();

        }

        private void llenar_grilla()
        {   
            pag.Text = Convert.ToString(pagina);
            DataTable dt;

            if (esEmpresa)
            {
                dt = new PublicacionDAO().obtenerPublicacionesEmpresa(rubros, nombre.SelectedText, fecha_desde.Value, fecha_hasta.Value, pagina);
            }
            else 
            {
                dt = new PublicacionDAO().obtenerPublicaciones(rubros, nombre.SelectedText, fecha_desde.Value, fecha_hasta.Value, pagina);
                
            }
            
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("publ_", "").Replace("fecha_ven","Dia - horario").Replace("_", " ").ToUpper();
            }

        }

        private void Rubros_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void datagrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (esEmpresa)
            {
                string publicacion = datagrid.CurrentRow.Cells[0].Value.ToString();
                new EditarPublicacionForm(new PublicacionDAO().obtenerPublicacion(publicacion)).ShowDialog();
          
            }
            else 
            {
                string publicacion = datagrid.CurrentRow.Cells[0].Value.ToString();
                new Compra(new PublicacionDAO().obtenerPublicacion(publicacion)).ShowDialog();
          
            }
           
            
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

    }
}
