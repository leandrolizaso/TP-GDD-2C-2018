using PalcoNet.AbmRol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class SeleccionRol : Form
    {
        private Decimal usuario;

        public SeleccionRol(Decimal usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }
        private void onLoad(object sender, EventArgs e)
        {
            var dt = new RolDAO().obtenerListaRoles(usuario);

            if (dt.Rows.Count == 1)
            {
                decimal idRol = Convert.ToDecimal(dt.Rows[0]["rol_id"]);
                new Funcionalidad(idRol).ShowDialog();

                //No se puede llamar this.Hide() en un metodo 
                //durante construccion del objeto
                //Se delega en una llamada asincronica
                BeginInvoke(new MethodInvoker(delegate{Hide();}));
                return;
            }

            roles.ValueMember = "rol_id";
            roles.DisplayMember = "rol_nombre";
            roles.DataSource = dt.DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Decimal idRol = (Decimal) roles.SelectedValue;
            new Funcionalidad(idRol).ShowDialog();
        }



    }
}
