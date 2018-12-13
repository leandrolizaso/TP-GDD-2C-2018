using PalcoNet.AbmEmpresa;
using PalcoNet.AbmGrado;
using PalcoNet.AbmRubro;
using PalcoNet.ListadoEstadistico;
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

namespace PalcoNet.Publicacion
{
    public partial class ModificarPublicacion : Form
    {
        decimal idPublicacion;
        private FechasPublicacion formFechas;
        private UbicacionesPublicacion formUbicaciones;
        private Boolean datosValidos;
       
        public ModificarPublicacion(decimal idPublicacion)
        {
            this.idPublicacion = idPublicacion;
            InitializeComponent();
            datosValidos = true;
            this.ocultarCampos();
            popularGrados();
            popularEstados();
            popularRubros();
            publ_fecha_publi.Value = Globales.getFechaHoy();
            formFechas = new FechasPublicacion();
            formUbicaciones = new UbicacionesPublicacion(idPublicacion);
            cargarDatos();
            actualizarLabels();

        }

        private void cargarDatos()
        {
            if (idPublicacion != -1) {
                labelEvento.Visible = true;
                publ_fecha_ven.Visible = true;
                fechas.Visible = false;
                labelFechas.Visible = false;
                var dt = new PublicacionDAO().obtenerPublicacion(idPublicacion);
                var row = dt.Rows[0];
                publ_descripcion.Text = row["publ_descripcion"].ToString();
                publ_direccion.Text = row["publ_direccion"].ToString();

                publ_estado.SelectedValue = row["publ_estado"].ToString();
                publ_grado.SelectedValue = row["publ_grado"].ToString();
                publ_rubro.SelectedValue = row["publ_rubro"].ToString();

                publ_fecha_ven.Value = Convert.ToDateTime(row["publ_fecha_ven"]);
                

                ubicaciones.Visible = false;
                labelUbicaciones.Visible = false;
            }
        }

        private void popularRubros()
        {
            publ_rubro.DisplayMember = "rubr_descripcion";
            publ_rubro.ValueMember = "rubr_id";
            publ_rubro.DataSource = new RubroDAO().obtenerRubros();
        }

        private void popularEstados()
        {
            decimal idEstado;
            if (idPublicacion == -1) {
                idEstado = 1; //Borrador
            } else {
                idEstado = new PublicacionDAO().obtenerIdEstadoXIdPublicacion(idPublicacion);
            }
            publ_estado.DisplayMember = "esta_descripcion";
            publ_estado.ValueMember = "esta_id";
            publ_estado.DataSource = new PublicacionDAO().obtenerEstadosDisponiblesParaEstadoActual(idEstado); 
        }

        private void popularGrados()
        {
            publ_grado.DisplayMember = "grad_descripcion";
            publ_grado.ValueMember = "grad_id";
            publ_grado.DataSource = new GradoDAO().obtenerAllGrados();
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            this.ocultarCampos();
            this.validarCampos();

            if (!datosValidos)
            {
                datosValidos = true;
                return;
            }

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
                if (idPublicacion != -1) {
                    formFechas.fechas.Rows.Add(publ_fecha_ven.Value);
                }

                decimal idEmpresa = new EmpresaDAO().obtenerEmpresa(Globales.idUsuarioLoggeado);
                dict.Add("publ_empresa_resp", idEmpresa);
                foreach (DataRow row in formFechas.fechas.Rows) {
                    dict["publ_fecha_ven"] = Convert.ToDateTime(row[0]);
                    if (idPublicacion == -1)
                    {
                        dict["publ_id"] = new PublicacionDAO().generarIdPublicacion();
                    }
                    else {
                        dict["publ_id"] = idPublicacion;
                    }
                    new PublicacionDAO().upsertPublicacion(idPublicacion, dict);
                    foreach (var ubicacion in formUbicaciones.ubicaciones) {
                        var ubic_dict = ubicacion.asDictionary();
                        ubic_dict.Add("ubic_publ", dict["publ_id"]);
                        new PublicacionDAO().upsertUbicacion(ubic_dict);
                    }
                }

                this.Hide();
                return;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(SqlExceptionTransformer.obtenerMensajeCustom(ex));
            }
        }

        private void validarCampos()
        {
            ValidacionInput validador = new ValidacionInput();

            if (!validador.alfaNumericoYespaciosValido(publ_direccion.Text))
            {
                labelDireccion.Visible = true;
                datosValidos = false;
            }

            if (!validador.palabrasValidas(publ_descripcion.Text))
            {
                labelDescripcion.Visible = true;
                datosValidos = false;
            }

        }

        private void fechas_Click(object sender, EventArgs e)
        {
            formFechas.ShowDialog();
            actualizarLabels();
        }

        private void ubicaciones_Click(object sender, EventArgs e)
        {
            formUbicaciones.ShowDialog();
            actualizarLabels();
        }

        private void actualizarLabels()
        {
            if (formFechas.fechas.Rows.Count > 0) {
                labelFechas.Text = string.Format("Se cargaron {0} fecha(s).",formFechas.fechas.Rows.Count);
            } else {
                labelFechas.Text = "Aun no se cargaron datos";
            }


            if (formUbicaciones.ubicaciones.Count > 0)
            {
                labelUbicaciones.Text = string.Format("Se cargaron {0} ubicacion(es).", formUbicaciones.ubicaciones.Count);
            }
            else
            {
                labelUbicaciones.Text = "Aun no se cargaron datos";
            }
        }

        private void ocultarCampos()
        {
            labelDescripcion.Visible = false;
            labelDireccion.Visible = false;

        }


        private void labelNombre_Click(object sender, EventArgs e)
        {

        }

    }
}