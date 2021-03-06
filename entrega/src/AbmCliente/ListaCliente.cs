﻿using PalcoNet.AbmCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.AbmCliente
{
    public partial class ListaCliente : Form
    {

        public ListaCliente()
        {
            InitializeComponent();
        }

        private void buscar_Click(object sender, EventArgs e) {
            var dt = new ClienteDAO().obtenerClientes(nombre.Text, apellido.Text, dni.Text, email.Text);
            datagrid.DataSource = dt;

            if (dt.Rows.Count == 0) 
            {
                MessageBox.Show("No se encontraron resultados");
            }

            foreach( DataGridViewColumn column in datagrid.Columns){
                column.HeaderText = column.HeaderText.Replace("clie_", "").Replace("_", " ").ToUpper();
            }

            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void limpiar_Click(object sender, EventArgs e) {
            nombre.Text = "";
            apellido.Text = "";
            dni.Text = "";
            email.Text = "";
            datagrid.DataSource = null;
        }

        private void datagrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;
            var id_clickeado = (decimal)datagrid["clie_id", e.RowIndex].Value;
            this.Hide();
            new ModificarCliente(id_clickeado,true).ShowDialog();
            this.Show();
            buscar_Click(sender, e);
        }

        private void crear_Click(object sender, EventArgs e) {
            this.Hide();
            new ModificarCliente(-1,true).ShowDialog();
            this.Show();
            buscar_Click(sender, e);
        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

     }

}
