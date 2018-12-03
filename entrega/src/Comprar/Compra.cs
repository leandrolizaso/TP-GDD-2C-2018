﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class Compra : Form
    {
        DataTable dt;
        decimal publicacion;
        string ubicaciones = "";

        public Compra(decimal idPublicacion)
        {
            
            InitializeComponent();
            publicacion = idPublicacion;
            dt = new PublicacionDAO().obtenerUbicaciones(idPublicacion);
            datagrid.DataSource = dt;
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                column.HeaderText = column.HeaderText.Replace("ubic_", "").Replace("_", " ").ToUpper();
            }
            datagrid.Columns["ubic_id"].Visible = false;
            DataGridViewCheckBoxColumn clm = new DataGridViewCheckBoxColumn();
            clm.HeaderText = "Seleccionar";
            datagrid.Columns.Add(clm);
            datagrid.Columns[0].ReadOnly = true;
            datagrid.Columns[1].ReadOnly = true;
            datagrid.Columns[2].ReadOnly = true;
            datagrid.Columns[3].ReadOnly = true;
            datagrid.AllowUserToAddRows = false;

        }


        private void comprar_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datagrid.Rows)
            {

                if (Convert.ToBoolean(row.Cells[4].Value))
                {
                    ubicaciones = ubicaciones + Convert.ToString(row.Cells[1].Value) + ", ";
                }


            }

            MessageBox.Show(ubicaciones);
            this.Close();
        }

        private void datagrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (datagrid.IsCurrentCellDirty)
            {
                datagrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
