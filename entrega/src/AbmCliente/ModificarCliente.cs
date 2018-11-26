using PalcoNet.AbmCliente;
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
                var label = new Label();
                label.Text = col.ToString().Replace("clie_", "").Replace("_", " ").ToUpper();
                panel.Controls.Add(label);

                Control input;

                if (col.DataType.Name == "DateTime") {
                    input = new DateTimePicker();
                    input.Text = dt.Rows[0][col.ToString()].ToString();
                }else if(col.ColumnName == "clie_estado"){
                    var comboBox = new ComboBox();
                    comboBox.DisplayMember = "Text";
                    comboBox.ValueMember = "Value";
                    comboBox.DataSource = new[] { 
                        new { Text = "Alta", Value = "A" }, 
                        new { Text = "Baja", Value = "B" }, 
                        new { Text = "Migrado", Value = "M" }
                    };
                    comboBox.BindingContext = new BindingContext();
                    comboBox.SelectedValue = dt.Rows[0][col.ToString()].ToString();
                    input = comboBox;
                }else {
                    input = new TextBox();
                    input.Text = dt.Rows[0][col.ToString()].ToString();
                }

                input.Name = col.ToString(); ;
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
                } else if (control is DateTimePicker) {
                    DateTimePicker datepicker = (DateTimePicker)control;
                    dict.Add(datepicker.Name, datepicker.Value);
                } else if (control is ComboBox) {
                    ComboBox comboBox = (ComboBox)control;
                    dict.Add(comboBox.Name, comboBox.SelectedValue);
                }
            }

            try
            {
                new ClienteDAO().actualizarDatosCliente(idCliente, dict);
            }
            catch (SqlException ex) {
                MessageBox.Show("Se produjo un error y la modificacion no se llevo a cabo:\n\n" + ex.Message);
            }
            
            this.Hide();
        }
    }
}
