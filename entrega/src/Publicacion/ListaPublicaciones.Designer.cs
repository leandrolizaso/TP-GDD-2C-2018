namespace PalcoNet.Publicacion
{
    partial class ListaPublicaciones
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.fecha_hasta = new System.Windows.Forms.DateTimePicker();
            this.limpiar = new System.Windows.Forms.Button();
            this.fecha_desde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.buscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.pag = new System.Windows.Forms.Label();
            this.primera = new System.Windows.Forms.Button();
            this.anterior = new System.Windows.Forms.Button();
            this.ultimo = new System.Windows.Forms.Button();
            this.siguiente = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.fecha_hasta);
            this.groupBox1.Controls.Add(this.limpiar);
            this.groupBox1.Controls.Add(this.fecha_desde);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buscar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nombre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 102);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 50);
            this.button1.TabIndex = 30;
            this.button1.Text = "Seleccionar categorias";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fecha_hasta
            // 
            this.fecha_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_hasta.Location = new System.Drawing.Point(191, 59);
            this.fecha_hasta.Name = "fecha_hasta";
            this.fecha_hasta.Size = new System.Drawing.Size(102, 20);
            this.fecha_hasta.TabIndex = 29;
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(411, 27);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(55, 50);
            this.limpiar.TabIndex = 9;
            this.limpiar.Text = "Limpiar Filtro";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // fecha_desde
            // 
            this.fecha_desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_desde.Location = new System.Drawing.Point(63, 59);
            this.fecha_desde.Name = "fecha_desde";
            this.fecha_desde.Size = new System.Drawing.Size(102, 20);
            this.fecha_desde.TabIndex = 28;
            this.fecha_desde.ValueChanged += new System.EventHandler(this.fecha_desde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "~";
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(485, 19);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(113, 63);
            this.buscar.TabIndex = 8;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Periodo";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(63, 27);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(230, 20);
            this.nombre.TabIndex = 5;
            this.nombre.TextChanged += new System.EventHandler(this.nombre_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre";
            // 
            // datagrid
            // 
            this.datagrid.AllowUserToAddRows = false;
            this.datagrid.AllowUserToDeleteRows = false;
            this.datagrid.AllowUserToOrderColumns = true;
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Location = new System.Drawing.Point(21, 132);
            this.datagrid.Name = "datagrid";
            this.datagrid.ReadOnly = true;
            this.datagrid.Size = new System.Drawing.Size(603, 284);
            this.datagrid.TabIndex = 16;
            this.datagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_CellDoubleClick);
            // 
            // pag
            // 
            this.pag.AutoSize = true;
            this.pag.Location = new System.Drawing.Point(303, 430);
            this.pag.Name = "pag";
            this.pag.Size = new System.Drawing.Size(25, 13);
            this.pag.TabIndex = 28;
            this.pag.Text = "pag";
            // 
            // primera
            // 
            this.primera.Location = new System.Drawing.Point(212, 422);
            this.primera.Name = "primera";
            this.primera.Size = new System.Drawing.Size(28, 28);
            this.primera.TabIndex = 27;
            this.primera.Text = "<<";
            this.primera.UseVisualStyleBackColor = true;
            this.primera.Click += new System.EventHandler(this.primera_Click);
            // 
            // anterior
            // 
            this.anterior.Location = new System.Drawing.Point(256, 422);
            this.anterior.Name = "anterior";
            this.anterior.Size = new System.Drawing.Size(28, 28);
            this.anterior.TabIndex = 26;
            this.anterior.Text = "<";
            this.anterior.UseVisualStyleBackColor = true;
            this.anterior.Click += new System.EventHandler(this.anterior_Click);
            // 
            // ultimo
            // 
            this.ultimo.Location = new System.Drawing.Point(377, 422);
            this.ultimo.Name = "ultimo";
            this.ultimo.Size = new System.Drawing.Size(28, 28);
            this.ultimo.TabIndex = 25;
            this.ultimo.Text = ">>";
            this.ultimo.UseVisualStyleBackColor = true;
            this.ultimo.Click += new System.EventHandler(this.ultimo_Click);
            // 
            // siguiente
            // 
            this.siguiente.Location = new System.Drawing.Point(334, 422);
            this.siguiente.Name = "siguiente";
            this.siguiente.Size = new System.Drawing.Size(28, 28);
            this.siguiente.TabIndex = 24;
            this.siguiente.Text = ">";
            this.siguiente.UseVisualStyleBackColor = true;
            this.siguiente.Click += new System.EventHandler(this.siguiente_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Doble click en la fila seleccionar";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // ListaPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 462);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pag);
            this.Controls.Add(this.primera);
            this.Controls.Add(this.anterior);
            this.Controls.Add(this.ultimo);
            this.Controls.Add(this.siguiente);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListaPublicaciones";
            this.Text = "Publicaciones";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.DateTimePicker fecha_hasta;
        private System.Windows.Forms.DateTimePicker fecha_desde;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label pag;
        private System.Windows.Forms.Button primera;
        private System.Windows.Forms.Button anterior;
        private System.Windows.Forms.Button ultimo;
        private System.Windows.Forms.Button siguiente;
        private System.Windows.Forms.Label label5;
    }
}