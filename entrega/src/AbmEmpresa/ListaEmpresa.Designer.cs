﻿namespace PalcoNet.AbmEmpresa
{
    partial class ListaEmpresa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.razon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cuit = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buscar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crear = new System.Windows.Forms.Button();
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // razon
            // 
            this.razon.Location = new System.Drawing.Point(120, 18);
            this.razon.Name = "razon";
            this.razon.Size = new System.Drawing.Size(368, 20);
            this.razon.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Razon Social";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "CUIT";
            // 
            // cuit
            // 
            this.cuit.Location = new System.Drawing.Point(81, 60);
            this.cuit.Name = "cuit";
            this.cuit.Size = new System.Drawing.Size(157, 20);
            this.cuit.TabIndex = 5;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(276, 60);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(212, 20);
            this.email.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mail";
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(553, 10);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(90, 70);
            this.buscar.TabIndex = 8;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(668, 10);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(90, 70);
            this.limpiar.TabIndex = 9;
            this.limpiar.Text = "Limpiar Filtro";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crear);
            this.groupBox1.Controls.Add(this.buscar);
            this.groupBox1.Controls.Add(this.limpiar);
            this.groupBox1.Controls.Add(this.razon);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.email);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cuit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(892, 93);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // crear
            // 
            this.crear.Location = new System.Drawing.Point(780, 10);
            this.crear.Name = "crear";
            this.crear.Size = new System.Drawing.Size(90, 70);
            this.crear.TabIndex = 10;
            this.crear.Text = "Crear Empresa";
            this.crear.UseVisualStyleBackColor = true;
            this.crear.Click += new System.EventHandler(this.crear_Click);
            // 
            // datagrid
            // 
            this.datagrid.AllowUserToAddRows = false;
            this.datagrid.AllowUserToDeleteRows = false;
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Location = new System.Drawing.Point(13, 121);
            this.datagrid.Name = "datagrid";
            this.datagrid.ReadOnly = true;
            this.datagrid.Size = new System.Drawing.Size(891, 357);
            this.datagrid.TabIndex = 11;
            this.datagrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_CellDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Doble click en la fila para modificar";
            // 
            // ListaEmpresa
            // 
            this.ClientSize = new System.Drawing.Size(916, 490);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListaEmpresa";
            this.Text = "ABM Empresa";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox razon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cuit;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button crear;

    }
}