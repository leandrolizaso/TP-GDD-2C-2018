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

namespace PalcoNet.Publicacion
{
    public partial class FechasPublicacion : Form
    {

        public DataTable fechas { get; private set; }

        public FechasPublicacion()
        {
            InitializeComponent();
            fecha.MinDate = Globales.getFechaHoy();
            fecha.Value = Globales.getFechaHoy();
            hora.Value = Globales.getFechaHoy();

            fechas = new DataTable();
            fechas.Columns.Add("Fecha Publicacion");

            datagrid.DataSource = fechas;
            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fechaMin = maximaFechaCargada();
            DateTime nuevaFecha = fecha.Value.Date + hora.Value.TimeOfDay;
            if (DateTime.Compare(nuevaFecha,fechaMin) > 0)
            {
                fechas.Rows.Add(nuevaFecha);
                datagrid.DataSource = null;
                datagrid.DataSource = fechas;
            } else {
                MessageBox.Show("Las fechas deben cargarse de manera incremental");
            }
            
        }

        private DateTime maximaFechaCargada()
        {
            DateTime maxfecha = Globales.getFechaHoy().AddDays(-1);
            foreach (DataGridViewRow row in datagrid.Rows) {
                DateTime fechafila = DateTime.Parse(row.Cells[0].Value.ToString());
                if (fechafila.CompareTo(maxfecha) > 0)
                {
                    maxfecha = fechafila;
                }
            }
            return maxfecha;
        }
    }
}
