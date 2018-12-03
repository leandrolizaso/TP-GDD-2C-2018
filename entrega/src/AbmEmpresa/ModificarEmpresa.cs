using PalcoNet.AbmEmpresa;
using PalcoNet.Utils;
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
        private Boolean esABM;

        public ModificarEmpresa(Decimal idEmpresa, Boolean esABM)
        {
            this.idEmpresa = idEmpresa;
            this.esABM = esABM;
            InitializeComponent();

            empr_fecha.Value = Globales.getFechaHoy();

            empr_estado.DisplayMember = "Text";
            empr_estado.ValueMember = "Value";
            empr_estado.DataSource = new[] { 
                        new { Text = "Alta", Value = "A" }, 
                        new { Text = "Baja", Value = "B" }, 
                        new { Text = "Migrado", Value = "M" }
                    };
            empr_estado.BindingContext = new BindingContext();

            if (esABM) {
                username.ReadOnly = true;
                password.ReadOnly = true;
            } else {
                password.PasswordChar = '*';
            }

            if (idEmpresa > 0) {
                cargarCampos();
                username.Visible = false;
                password.Visible = false;
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
                } else if (control is MaskedTextBox) {
                    MaskedTextBox textbox = (MaskedTextBox)control;
                    if (!textbox.MaskCompleted) {
                        MessageBox.Show("Se requiere un dni valido");
                        textbox.Focus();
                        return;
                    }
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
                var dt = new EmpresaDAO().upsertDatosEmpresa(idEmpresa, dict);
                if (idEmpresa > 0)
                {
                    this.Hide();
                    return;
                }

                var resultado = dt.Rows[0];

                if (Convert.ToInt16(resultado["usuario"]) == -1)
                {
                    MessageBox.Show(resultado["mensaje"].ToString());
                    return;
                }

                if (username.Text == ""){
                    modificar.Enabled = false;
                    username.Text = dt.Rows[0]["username"].ToString();
                    password.Text = dt.Rows[0]["password"].ToString();
                    MessageBox.Show("El usuario y la contraseña se han generado automaticamente.\nRecuerde anotarlos y comunicarlos al usuario de la cuenta.");
                }else {
                    this.Hide();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Se produjo un error y la modificacion no se llevo a cabo:\n\n" + ex.Message);
            }

        }

    }
}
