using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Utils;

namespace PalcoNet.Publicacion
{
    public partial class UbicacionesPublicacion : Form
    {

        public BindingList<Ubicacion> ubicaciones = new BindingList<Ubicacion>();
        private decimal idPublicacion;
        private Boolean datosValidos = true;

        public UbicacionesPublicacion(decimal idPublicacion)
        {
            this.idPublicacion = idPublicacion;
            InitializeComponent();
            datagridSetUp();
            ubic_tipo.DisplayMember = "tipo_ubic_descripcion";
            ubic_tipo.ValueMember = "tipo_ubic_id";
            ubic_tipo.DataSource = new PublicacionDAO().obtenerTiposUbicacion();
            if (idPublicacion != -1) {
               // loadUbicaciones();
            }
            datagrid.DataSource = ubicaciones;
        }

        private void datagridSetUp()
        {
            datagrid.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "ubic_fila";
            column.Name = "Fila";
            datagrid.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "ubic_asiento";
            column.Name = "Asiento";
            datagrid.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "ubic_precio";
            column.Name = "Precio";
            datagrid.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "tipo_ubic_descripcion";
            column.Name = "Tipo";
            datagrid.Columns.Add(column);

            datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void loadUbicaciones()
        {
            var dt = new PublicacionDAO().obtenerAllUbicaciones(idPublicacion);

            foreach (DataRow row in dt.Rows)
            {
                Ubicacion u = new Ubicacion(Convert.ToDecimal(row["ubic_id"]));
                u.ubic_fila = Convert.ToString(row["ubic_fila"]);
                u.ubic_asiento = Convert.ToDecimal(row["ubic_asiento"]);
                u.ubic_precio = Convert.ToDecimal(row["ubic_precio"]);
                u.ubic_tipo = Convert.ToDecimal(row["ubic_tipo"]);
                u.tipo_ubic_descripcion = Convert.ToString(row["tipo_ubic_descripcion"]);
                ubicaciones.Add(u);
            }
            datagrid.DataSource = null;
            datagrid.DataSource = ubicaciones;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.ocultarCampos();
            this.validarCampos();

            if (!datosValidos)
            {
                datosValidos = true;
                return;
            }

            try {
                Ubicacion u = new Ubicacion(-1);
                u.ubic_fila = Convert.ToString(ubic_fila.Text);
                u.ubic_asiento = Convert.ToDecimal(ubic_asiento.Text);
                u.ubic_precio = Convert.ToDecimal(ubic_precio.Text);
                u.ubic_tipo = Convert.ToDecimal(ubic_tipo.SelectedValue);
                u.tipo_ubic_descripcion = Convert.ToString(ubic_tipo.Text);
                ubicaciones.Add(u);
                datagrid.DataSource = null;
                datagrid.DataSource = ubicaciones;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void ocultarCampos()
        {
            labelAsiento.Visible = false;
            labelPrecio.Visible = false;
        }
        
        private void validarCampos() 
        {
            ValidacionInput validador = new ValidacionInput();

            if (!validador.numeroValido(ubic_asiento.Text) || Convert.ToInt32(ubic_precio.Text) < 0)
            {
                labelAsiento.Visible = true;
                datosValidos = false;
            }

            if (!validador.numeroValido(ubic_precio.Text) || Convert.ToInt32(ubic_precio.Text) < 0)
            {
                labelPrecio.Visible = true;
                datosValidos = false;
            }

            if (ubic_fila.Text.Length > 3 || ubic_fila.Text.Length <=0) {
                labelFila.Visible = true;
                datosValidos = false;
            }
        }
    }
}
