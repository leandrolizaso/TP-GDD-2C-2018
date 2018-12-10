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

        public ModificarRol(decimal idRol, string nombreRol)
        {
            this.idRol = idRol;
            InitializeComponent();
            cargarRoles();
            rol_nombre.Text = nombreRol;    
            if (idRol != -1) {
                cargarDatosDB();
            }
        }

        private void cargarRoles()
        {
            var funciones = new RolDAO().obtenerAllFunciones();

            foreach (DataRow funcion in funciones.Rows)
            {
                CheckBox check = new CheckBox();
                check.Name = funcion["func_id"].ToString();
                check.Text = funcion["func_nombre"].ToString();
                check.AutoSize = true;
                panel.Controls.Add(check);
            }

        }

        private void cargarDatosDB() {
            eliminar.Visible = true;
            var funcionesActivas = new RolDAO().obtenerListaFunciones(idRol);
            foreach (DataRow funcion in funcionesActivas.Rows)
            {
                var check = (CheckBox)panel.Controls[funcion["func_id"].ToString()];
                check.Checked = true;
            }
            
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@rol_id", idRol);
            dict.Add("@rol_nombre", rol_nombre.Text);

            List<Decimal> idFunciones = new List<decimal>();

            foreach(CheckBox check in panel.Controls){
                if (check.Checked) {
                    idFunciones.Add(Convert.ToInt16(check.Name));
                }
            }

            dict.Add("@funciones", string.Join(",", idFunciones));
            new RolDAO().upsertRol(idRol, dict);
            this.Hide();
            MessageBox.Show("Se ha modificado el rol.\nSi el usuario actual pertenece al rol, por favor vuelva a iniciar sesion para ver los cambios en los accesos");
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            new RolDAO().eliminarRol(idRol);
            this.Hide();
        }
    }
}
