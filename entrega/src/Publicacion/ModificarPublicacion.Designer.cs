namespace PalcoNet.Publicacion
{
    partial class ModificarPublicacion
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
            this.modificar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.publ_descripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.publ_direccion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.publ_grado = new System.Windows.Forms.ComboBox();
            this.publ_rubro = new System.Windows.Forms.ComboBox();
            this.publ_fecha_publi = new System.Windows.Forms.DateTimePicker();
            this.publ_estado = new System.Windows.Forms.ComboBox();
            this.fechas = new System.Windows.Forms.Button();
            this.ubicaciones = new System.Windows.Forms.Button();
            this.labelFechas = new System.Windows.Forms.Label();
            this.labelUbicaciones = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(22, 358);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(623, 43);
            this.modificar.TabIndex = 26;
            this.modificar.Text = "Guardar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Descripción";
            // 
            // publ_descripcion
            // 
            this.publ_descripcion.Location = new System.Drawing.Point(104, 26);
            this.publ_descripcion.Name = "publ_descripcion";
            this.publ_descripcion.Size = new System.Drawing.Size(541, 20);
            this.publ_descripcion.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Dirección";
            // 
            // publ_direccion
            // 
            this.publ_direccion.Location = new System.Drawing.Point(104, 131);
            this.publ_direccion.Name = "publ_direccion";
            this.publ_direccion.Size = new System.Drawing.Size(199, 20);
            this.publ_direccion.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Grado";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(360, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 35);
            this.label9.TabIndex = 35;
            this.label9.Text = "Fecha Publicacion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Rubro";
            // 
            // publ_grado
            // 
            this.publ_grado.FormattingEnabled = true;
            this.publ_grado.Location = new System.Drawing.Point(104, 78);
            this.publ_grado.Name = "publ_grado";
            this.publ_grado.Size = new System.Drawing.Size(199, 21);
            this.publ_grado.TabIndex = 39;
            // 
            // publ_rubro
            // 
            this.publ_rubro.FormattingEnabled = true;
            this.publ_rubro.Location = new System.Drawing.Point(104, 189);
            this.publ_rubro.Name = "publ_rubro";
            this.publ_rubro.Size = new System.Drawing.Size(199, 21);
            this.publ_rubro.TabIndex = 40;
            // 
            // publ_fecha_publi
            // 
            this.publ_fecha_publi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.publ_fecha_publi.Location = new System.Drawing.Point(446, 131);
            this.publ_fecha_publi.Name = "publ_fecha_publi";
            this.publ_fecha_publi.Size = new System.Drawing.Size(199, 20);
            this.publ_fecha_publi.TabIndex = 41;
            // 
            // publ_estado
            // 
            this.publ_estado.FormattingEnabled = true;
            this.publ_estado.Location = new System.Drawing.Point(446, 78);
            this.publ_estado.Name = "publ_estado";
            this.publ_estado.Size = new System.Drawing.Size(199, 21);
            this.publ_estado.TabIndex = 42;
            // 
            // fechas
            // 
            this.fechas.Location = new System.Drawing.Point(28, 232);
            this.fechas.Name = "fechas";
            this.fechas.Size = new System.Drawing.Size(274, 49);
            this.fechas.TabIndex = 43;
            this.fechas.Text = "Administrar Fechas de Espectaculo";
            this.fechas.UseVisualStyleBackColor = true;
            this.fechas.Click += new System.EventHandler(this.fechas_Click);
            // 
            // ubicaciones
            // 
            this.ubicaciones.Location = new System.Drawing.Point(371, 232);
            this.ubicaciones.Name = "ubicaciones";
            this.ubicaciones.Size = new System.Drawing.Size(274, 49);
            this.ubicaciones.TabIndex = 44;
            this.ubicaciones.Text = "Administrar Ubicaciones";
            this.ubicaciones.UseVisualStyleBackColor = true;
            this.ubicaciones.Click += new System.EventHandler(this.ubicaciones_Click);
            // 
            // labelFechas
            // 
            this.labelFechas.AutoSize = true;
            this.labelFechas.Location = new System.Drawing.Point(25, 284);
            this.labelFechas.Name = "labelFechas";
            this.labelFechas.Size = new System.Drawing.Size(129, 13);
            this.labelFechas.TabIndex = 45;
            this.labelFechas.Text = "Aun no se cargaron datos";
            // 
            // labelUbicaciones
            // 
            this.labelUbicaciones.AutoSize = true;
            this.labelUbicaciones.Location = new System.Drawing.Point(368, 284);
            this.labelUbicaciones.Name = "labelUbicaciones";
            this.labelUbicaciones.Size = new System.Drawing.Size(129, 13);
            this.labelUbicaciones.TabIndex = 46;
            this.labelUbicaciones.Text = "Aun no se cargaron datos";
            // 
            // ModificarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 449);
            this.Controls.Add(this.labelUbicaciones);
            this.Controls.Add(this.labelFechas);
            this.Controls.Add(this.ubicaciones);
            this.Controls.Add(this.fechas);
            this.Controls.Add(this.publ_estado);
            this.Controls.Add(this.publ_fecha_publi);
            this.Controls.Add(this.publ_rubro);
            this.Controls.Add(this.publ_grado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.publ_direccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.publ_descripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modificar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ModificarPublicacion";
            this.Text = "Datos Publicacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox publ_descripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox publ_direccion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox publ_grado;
        private System.Windows.Forms.ComboBox publ_rubro;
        private System.Windows.Forms.DateTimePicker publ_fecha_publi;
        private System.Windows.Forms.ComboBox publ_estado;
        private System.Windows.Forms.Button fechas;
        private System.Windows.Forms.Button ubicaciones;
        private System.Windows.Forms.Label labelFechas;
        private System.Windows.Forms.Label labelUbicaciones;



    }
}