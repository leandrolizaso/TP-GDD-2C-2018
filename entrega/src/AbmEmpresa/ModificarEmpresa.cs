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

        public ModificarEmpresa() : this(-1){}

        public ModificarEmpresa(Decimal idEmpresa)
        {
            this.idEmpresa = idEmpresa;
            InitializeComponent();

            empr_estado.DisplayMember = "Text";
            empr_estado.ValueMember = "Value";
            empr_estado.DataSource = new[] { 
                        new { Text = "Alta", Value = "A" }, 
                        new { Text = "Baja", Value = "B" }, 
                        new { Text = "Migrado", Value = "M" }
                    };
            empr_estado.BindingContext = new BindingContext();

            if (idEmpresa > 0) {
                cargarCampos();
            }
        }

        private void cargarCampos()
        {
            var dt = new EmpresaDAO().obtenerDatosEmpresa(idEmpresa);

            foreach (DataColumn col in dt.Columns) {
                if(col.ColumnName == "empr_estado"){
                    ComboBox control = (ComboBox)Controls[col.ColumnName];
                    control.SelectedValue = dt.Rows[0][col.ColumnName].ToString();
                }else{
                    Control control = Controls[col.ColumnName];
                    control.Text = dt.Rows[0][col.ColumnName].ToString();
                }
                
            }

        }

        private void modificar_Click(object sender, EventArgs e) {
            var dict = new Dictionary<string, object>();

            foreach (var control in Controls) {
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
                new EmpresaDAO().upsertDatosEmpresa(idEmpresa, dict);
            }
            catch (SqlException ex) {
                MessageBox.Show("Se produjo un error y la modificacion no se llevo a cabo:\n\n" + ex.Message);
            }
            
            this.Hide();
        }

    }
}
