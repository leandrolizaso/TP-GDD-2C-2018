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
        public string retorno { get; set; }   

        public Rubro()
        {
            InitializeComponent();
            retorno = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            retorno = nuevoRubro.Text;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nuevoRubro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
