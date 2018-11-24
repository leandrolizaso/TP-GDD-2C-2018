using PalcoNet.AbmCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.AbmCliente
{
    public partial class ModificarCliente : Form
    {
        private decimal idCliente;

        public ModificarCliente(Decimal idCliente)
        {
            this.idCliente = idCliente;
            InitializeComponent();
            cargarCampos();
        }

        private void cargarCampos()
        {
            var dt = new ClienteDAO().obtenerDatosCliente(idCliente);

            var newline = false;

            foreach (DataColumn col in dt.Columns) {
                var nombre = col.ToString().Replace("clie_", "").Replace("_", " ").ToUpper();

                var label = new Label();
                label.Text = nombre;
                panel.Controls.Add(label);

                var textbox = new TextBox();
                textbox.Name = nombre;
                textbox.Text = dt.Rows[0][col.ToString()].ToString();
                textbox.Width = 200;

                panel.Controls.Add(textbox);
                if (newline){
                    panel.SetFlowBreak(textbox, true);
                }
                newline = !newline;
            }
        }
    }
}
