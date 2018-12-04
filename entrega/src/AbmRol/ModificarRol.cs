using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.AbmRol
{
    public partial class ModificarRol : Form
    {
        private decimal idRol;

        public ModificarRol(decimal idRol)
        {
            this.idRol = idRol;
            InitializeComponent();
            cargarRoles();
        }

        private void cargarRoles()
        {
            var funciones = new RolDAO().obtenerAllFunciones();

            foreach (DataRow funcion in funciones.Rows)
            {
                CheckBox check = new CheckBox();
                check.Name = "button" + funcion["func_id"];
                check.Text = funcion["func_nombre"].ToString();
                check.AutoSize = true;
                panel.Controls.Add(check);
            }

            if (idRol != -1) {
                eliminar.Visible = true;
            }
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@rol_nombre", rol_nombre);

            List<Decimal> idFunciones = new List<decimal>();

            foreach(CheckBox check in panel.Controls){
                idFunciones.Add(Convert.ToInt16(check.Name));
            }

            dict.Add("@funciones", string.Join(",", idFunciones));
            new RolDAO().upsertRol(idRol, dict);
            this.Hide();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            new RolDAO().eliminarRol(idRol);
            this.Hide();
        }
    }
}
