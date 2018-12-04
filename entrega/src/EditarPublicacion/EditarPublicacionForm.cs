using PalcoNet.ListadoEstadistico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.EditarPublicacion
{
    public partial class EditarPublicacionForm : Form
    {

        public EditarPublicacionForm()
        {
            InitializeComponent();

            //cargo grados

            DataTable dt = new EmpresasDAO().obtenerDatosGrados();
            grado.DisplayMember = "grad_descripcion";
            grado.ValueMember = "grad_id";
            grado.DataSource = dt;
        }

        private void modificar_Click(object sender, EventArgs e)
        {

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
    }
}