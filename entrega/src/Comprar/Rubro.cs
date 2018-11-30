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
    public partial class Rubro : Form
    {

        public decimal id { get; set; }
        public string texto { get; set; }

        public Rubro()
        {
            InitializeComponent();
            texto = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dt = new RubroDAO().buscarRubroPorDescripcion(nuevoRubro.Text);
            id = Convert.ToDecimal(dt.Rows[0]["rubr_id"]);
            texto = dt.Rows[0]["rubr_descripcion"].ToString();
            this.Close();
        }

    }
}
