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

namespace PalcoNet.AbmGrado
{
    public partial class ModificarGrado : Form
    {
        private decimal idGrado;

        public ModificarGrado() : this(-1) { }

        public ModificarGrado(Decimal idGrado)
        {
            this.idGrado = idGrado;
            InitializeComponent();

            grad_descripcion.Text = "";

            grad_estado.DisplayMember = "Text";
            grad_estado.ValueMember = "Value";
            grad_estado.DataSource = new[] { 
                        new { Text = "Alta", Value = "A" }, 
                        new { Text = "Baja", Value = "B" }
                    };
            grad_estado.BindingContext = new BindingContext();

            if (idGrado > 0)
            {
                cargarCampos();
            }
        }

        private void cargarCampos()
        {
            var dt = new GradoDAO().obtenerDatosGrado(idGrado);

            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName == "grad_estado")
                {
                    ComboBox control = (ComboBox)Controls[col.ColumnName];
                    control.SelectedValue = dt.Rows[0][col.ColumnName].ToString();
                }
                else
                {
                    Control control = Controls[col.ColumnName];
                    control.Text = dt.Rows[0][col.ColumnName].ToString();
                }

            }

        }

        private void modificar_Click(object sender, EventArgs e)
        {
            if (grad_descripcion.Text != "")
            {
                var dict = new Dictionary<string, object>();

                foreach (var control in Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox textbox = (TextBox)control;
                        dict.Add(textbox.Name, textbox.Text);
                    }
                    else if (control is MaskedTextBox)
                    {
                        MaskedTextBox masked = (MaskedTextBox)control;
                        if (!masked.MaskCompleted)
                        {
                            MessageBox.Show("El porcentaje esta incompleto.\nLos 2 numeros a la izquierda de la coma son obligatorios");
                            masked.Focus();
                            return;
                        }
                        dict.Add(masked.Name, masked.Text);
                    }
                    else if (control is DateTimePicker)
                    {
                        DateTimePicker datepicker = (DateTimePicker)control;
                        dict.Add(datepicker.Name, datepicker.Value);
                    }
                    else if (control is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)control;
                        dict.Add(comboBox.Name, comboBox.SelectedValue);
                    }
                }

                try
                {
                    new GradoDAO().upsertDatosGrado(idGrado, dict);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Se produjo un error y la modificacion no se llevo a cabo:\n\n" + ex.Message);
                }

                this.Hide();
            }
            else 
            {
                MessageBox.Show("Ingrese una descripción");
            }
            
        }

    }
}
