using PalcoNet.AbmCliente;
using PalcoNet.AbmEmpresa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.RegistroUsuario
{
    public partial class NuevoUsuario : Form
    {
        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void cliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ModificarCliente(-1, false).ShowDialog();
        }

        private void empresa_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ModificarEmpresa(-1, false).ShowDialog();
        }

    }
}
