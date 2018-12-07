namespace PalcoNet.AbmGrado
{
    partial class ListaGrado
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
            this.label5 = new System.Windows.Forms.Label();
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pcnt_to = new System.Windows.Forms.TextBox();
            this.crear = new System.Windows.Forms.Button();
            this.buscar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.pcnt_from = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Doble click en la fila para modificar";
            // 
            // datagrid
            // 
            this.datagrid.AllowUserToAddRows = false;
            this.datagrid.AllowUserToDeleteRows = false;
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Location = new System.Drawing.Point(12, 120);
            this.datagrid.Name = "datagrid";
            this.datagrid.ReadOnly = true;
            this.datagrid.Size = new System.Drawing.Size(603, 231);
            this.datagrid.TabIndex = 15;
            this.datagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_CellContentClick);
            this.datagrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pcnt_to);
            this.groupBox1.Controls.Add(this.crear);
            this.groupBox1.Controls.Add(this.buscar);
            this.groupBox1.Controls.Add(this.limpiar);
            this.groupBox1.Controls.Add(this.pcnt_from);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nombre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 93);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "~";
            // 
            // pcnt_to
            // 
            this.pcnt_to.Location = new System.Drawing.Point(155, 62);
            this.pcnt_to.Name = "pcnt_to";
            this.pcnt_to.Size = new System.Drawing.Size(56, 20);
            this.pcnt_to.TabIndex = 11;
            // 
            // crear
            // 
            this.crear.Location = new System.Drawing.Point(537, 15);
            this.crear.Name = "crear";
            this.crear.Size = new System.Drawing.Size(61, 63);
            this.crear.TabIndex = 10;
            this.crear.Text = "Crear Grado";
            this.crear.UseVisualStyleBackColor = true;
            this.crear.Click += new System.EventHandler(this.crear_Click);
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(365, 19);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(61, 63);
            this.buscar.TabIndex = 8;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(432, 30);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(48, 41);
            this.limpiar.TabIndex = 9;
            this.limpiar.Text = "Limpiar Filtro";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // pcnt_from
            // 
            this.pcnt_from.Location = new System.Drawing.Point(79, 62);
            this.pcnt_from.Name = "pcnt_from";
            this.pcnt_from.Size = new System.Drawing.Size(56, 20);
            this.pcnt_from.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Rango%";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(79, 27);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(254, 20);
            this.nombre.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre";
            // 
            // ListaGrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 375);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListaGrado";
            this.Text = "ABM Grado";
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button crear;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pcnt_to;
        private System.Windows.Forms.TextBox pcnt_from;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label3;
    }
}