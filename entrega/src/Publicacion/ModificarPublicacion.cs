﻿using PalcoNet.AbmGrado;
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
       
        public ModificarPublicacion(decimal idPublicacion)
        {
            this.idPublicacion = idPublicacion;
            InitializeComponent();
            popularGrados();
            popularEstados();
            popularRubros();
            publ_fecha_publi.Value = Globales.getFechaHoy();
            formFechas = new FechasPublicacion(idPublicacion);
            formUbicaciones = new UbicacionesPublicacion(idPublicacion);
            cargarDatos();
            actualizarLabels();
        }

        private void cargarDatos()
        {
            if (idPublicacion != -1) {
                //buscar desde el dao los datos de esta publicacion
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
                //for each fecha
                //  upsert publicacion (con esa fecha)
                //  for each ubicacion: upsert ubicacion

                this.Hide();
                return;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Se produjo un error y la modificacion no se llevo a cabo:\n\n" + ex.Message);
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
                labelUbicaciones.Text = string.Format("Se cargaron {0} fecha(s).", formUbicaciones.ubicaciones.Count);
            }
            else
            {
                labelUbicaciones.Text = "Aun no se cargaron datos";
            }
        }

    }
}