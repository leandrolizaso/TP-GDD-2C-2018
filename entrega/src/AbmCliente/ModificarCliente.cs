using PalcoNet.AbmCliente;
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

namespace PalcoNet.AbmCliente
{
    public partial class ModificarCliente : Form
    {
        private decimal idCliente;
        private Boolean esABM;
        private Boolean datosValidos;

        public ModificarCliente(Decimal idCliente, Boolean esABM)
        {
            this.idCliente = idCliente;
            this.esABM = esABM;
            InitializeComponent();

            datosValidos = true;

            clie_fecha_crea.Value = Globales.getFechaHoy();
            clie_fecha_nac.Value = Globales.getFechaHoy();

            clie_estado.DisplayMember = "Text";
            clie_estado.ValueMember = "Value";
            clie_estado.DataSource = new[] { 
                        new { Text = "Alta", Value = "A" }, 
                        new { Text = "Baja", Value = "B" }, 
                        new { Text = "Migrado", Value = "M" }
                    };
            clie_estado.BindingContext = new BindingContext();

            if (esABM) {
                username.ReadOnly = true;
                password.ReadOnly = true;
            } else {
                password.PasswordChar = '*';
                clie_estado.Visible = false;
                labelEstado.Visible = false;
            }

            if (idCliente > 0) {
                cargarCampos();
                username.Visible = false;
                password.Visible = false;
                labelUser.Visible = false;
                labelPass.Visible = false;
            }

            this.ocultarCampos();
        }

        private void ocultarCampos()
        {
            labelNombre.Visible = false;
            labelTelefono.Visible = false;
            labelMail.Visible = false;
            labelApellido.Visible = false;
            labelCodigo.Visible = false;
            labelPassword.Visible = false;
            labelUsername.Visible = false;
            labelTarjeta.Visible = false;
            labelDireccion.Visible = false;

        }

        private void cargarCampos()
        {
            var dt = new ClienteDAO().obtenerDatosCliente(idCliente);

            foreach (DataColumn col in dt.Columns) {
                if(col.ColumnName == "clie_estado"){
                    ComboBox control = (ComboBox)Controls[col.ColumnName];
                    control.SelectedValue = dt.Rows[0][col.ColumnName].ToString();
                }else{
                    Control control = Controls[col.ColumnName];
                    control.Text = dt.Rows[0][col.ColumnName].ToString();
                }
                
            }

        }

        private void modificar_Click(object sender, EventArgs e) {

            this.ocultarCampos();
            this.validarCampos();

            if (!datosValidos) 
            {
                datosValidos = true;
                return;
            }

            var dict = new Dictionary<string, object>();

            foreach (var control in Controls) {
                if (control is TextBox ) { 
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

                var dt = new ClienteDAO().upsertDatosCliente(idCliente, dict);
                if (idCliente > 0) {
                    this.Hide();
                    return;
                }

                var resultado = dt.Rows[0];

                if (Convert.ToInt16(resultado["usuario"]) == -1) {
                    MessageBox.Show(resultado["mensaje"].ToString());
                    return;
                }

                if (username.Text == "") {
                    modificar.Enabled = false;
                    username.Text = dt.Rows[0]["username"].ToString();
                    password.Text = dt.Rows[0]["password"].ToString();
                    MessageBox.Show("El usuario y la contraseña se han generado automaticamente.\nRecuerde anotarlos y comunicarlos al usuario de la cuenta.");
                } else {
                    this.Hide();
                }
            }
            catch (SqlException ex) {
                MessageBox.Show("Se produjo un error y la modificacion no se llevo a cabo:\n\n" + ex.Message);
            }
            
        }

        private void validarCampos()
        {
            ValidacionInput validador = new ValidacionInput();

            if(!validador.palabrasValidas(clie_nombre.Text))
            {
                labelNombre.Visible = true;
                datosValidos = false;
            }

            if(!validador.palabrasValidas(clie_apellido.Text))
            {
                labelApellido.Visible = true;
                datosValidos = false;
            }

            if(!validador.mailValido(clie_mail.Text))
            {
                labelMail.Visible = true;
                datosValidos = false;
            }

            if(!validador.numeroValido(clie_telefono.Text))
            {
                labelTelefono.Visible = true;
                datosValidos = false;
            }

            if (!validador.numeroValido(clie_codigo_postal.Text))
            {
                labelCodigo.Visible = true;
                datosValidos = false;
            }

            if (!validador.alfaNumericoYespaciosValido(clie_direccion.Text))
            {
                labelDireccion.Visible = true;
                datosValidos = false;
            }

            if (!validador.alfaNumericoYespaciosValido(clie_datos_tarjeta.Text))
            {
                labelTarjeta.Visible = true;
                datosValidos = false;
            }

            if (!validador.alfaNumericoValido(username.Text) && !username.ReadOnly)
            {
                labelUsername.Visible = true;
                datosValidos = false;
            }

            if (!validador.alfaNumericoValido(password.Text) && !username.ReadOnly)
            {
                labelPassword.Visible = true;
                datosValidos = false;
            }
            
            
            
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
