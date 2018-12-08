using PalcoNet.AbmGrado;
using PalcoNet.AbmRubro;
using PalcoNet.ListadoEstadistico;
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

namespace PalcoNet.Publicacion
{
    public partial class EditarPublicacionForm : Form
    {
        decimal publicacion;

        public EditarPublicacionForm(decimal publ)
        {
            InitializeComponent();

            publicacion = publ;

            //cargo grados

            DataTable dtGrado = new GradoDAO().obtenerAllGrados();
            publ_grado.DisplayMember = "grad_descripcion";
            publ_grado.ValueMember = "grad_id";
            publ_grado.DataSource = dtGrado;

            //cargo estados
            decimal idEstado = new EditarPublicacionDAO().obtenerEstado(publ);
            DataTable dtEstado = new EditarPublicacionDAO().obtenerEstados(idEstado);
            publ_estado.DisplayMember = "esta_descripcion";
            publ_estado.ValueMember = "esta_id";
            publ_estado.DataSource = dtEstado;

            //cargo rubros

            DataTable dtRubro = new RubroDAO().obtenerRubros();
            publ_rubro.DisplayMember = "rubr_descripcion";
            publ_rubro.ValueMember = "rubr_id";
            publ_rubro.DataSource = dtRubro;

        }

        private void modificar_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object>();

            foreach (var control in Controls)
            {
                if (control is TextBox)
                {
                    TextBox textbox = (TextBox)control;
                    dict.Add(textbox.Name, textbox.Text);
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
                    new EditarPublicacionDAO().updatePublicacion(publicacion, dict);
                    MessageBox.Show("Update exitoso");
                    this.Hide();
                    return;
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Se produjo un error y la modificacion no se llevo a cabo:\n\n" + ex.Message);
            }
        }

        private void publ_fecha_ven_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditarPublicacionForm_Load(object sender, EventArgs e)
        {

        }

        private void publ_estado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void publ_grado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void publ_rubro_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void publ_descripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}