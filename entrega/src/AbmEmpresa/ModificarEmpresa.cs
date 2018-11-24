using PalcoNet.AbmEmpresa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.AbmEmpresa
{
    public partial class ModificarEmpresa : Form
    {
        private decimal idEmpresa;

        public ModificarEmpresa(Decimal idEmpresa)
        {
            this.idEmpresa = idEmpresa;
            InitializeComponent();
            cargarCampos();
        }

        private void cargarCampos()
        {
            var dt = new EmpresaDAO().obtenerDatosEmpresa(idEmpresa);

            var newline = false;

            foreach (DataColumn col in dt.Columns) {
                var label = new Label();
                label.Text = col.ToString().Replace("clie_", "").Replace("_", " ").ToUpper();
                panel.Controls.Add(label);

                Control input;

                if (col.DataType.Name == "DateTime") {
                    input = new DateTimePicker();
                } else {
                    input = new TextBox();
                }

                input.Name = col.ToString(); ;
                input.Text = dt.Rows[0][col.ToString()].ToString();
                input.Width = 200;

                panel.Controls.Add(input);
                if (newline){
                    panel.SetFlowBreak(input, true);
                }
                newline = !newline;
            }
        }

        private void modificar_Click(object sender, EventArgs e) {
            var dict = new Dictionary<string, object>();

            foreach (var control in panel.Controls) {
                if (control is TextBox) { 
                    TextBox textbox = (TextBox) control;
                    dict.Add(textbox.Name, textbox.Text);
                }
            }

            try
            {
                new EmpresaDAO().actualizarDatosEmpresa(idEmpresa, dict);
            }
            catch (SqlException ex) {
                MessageBox.Show("Se produjo un error y la modificacion no se llevo a cabo:\n\n" + ex.Message);
            }
            
            this.Hide();
        }
    }
}
