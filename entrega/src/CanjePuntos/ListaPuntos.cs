using PalcoNet.ListadoEstadistico;
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
        int total = 0;
        Boolean datosValidos = true;

        public ListaPuntos()
        {
            InitializeComponent();
            this.ocultarLabel();
        }

        private void ocultarLabel()
        {
            puntos.Visible = false;
        }

        private void validar() 
        {
            DataTable dt = new PremioDAO().obtenerPremios(total);
            if (dt.Rows.Count == 0)
            {
                puntos.Visible = true;
                datosValidos = false;
            }
         
        }

        private void cargarGrilla()
        {
            
        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void crear_Click(object sender, EventArgs e)
        {
            datosValidos = true;
            ocultarLabel();
            this.actualizarPuntos();
            PuntosDAO dao = new PuntosDAO();
            var dt = dao.obtenerPuntos();
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("_", " ").ToUpper();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            datosValidos = true;
            ocultarLabel();
            validar();

            if (datosValidos)
            {
                this.Hide();
                new CanjePremio().ShowDialog();
                this.Show();
                this.actualizarPuntos();
            }

        }

        private void actualizarPuntos()
        {
            PuntosDAO dao = new PuntosDAO();
            total = dao.obtenerTotal();
            label3.Text = Convert.ToString(total);
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListaPuntos_Load(object sender, EventArgs e)
        {

        }

        private void premios_Click(object sender, EventArgs e)
        {
            datosValidos = true;
            ocultarLabel();
            PremioDAO dao = new PremioDAO();
            var dt = dao.obtenerPremiosCliente();
            dataGridView1.DataSource = dt;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("_", " ").Replace("canje", " ").ToUpper();
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
