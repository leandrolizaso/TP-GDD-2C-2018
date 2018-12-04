namespace PalcoNet.EditarPublicacion
{
    partial class EditarPublicacionForm
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
            this.publ_fecha_ven = new System.Windows.Forms.DateTimePicker();
            this.publ_estado = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(22, 281);
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
            this.label1.Location = new System.Drawing.Point(20, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Descripción";
            // 
            // publ_descripcion
            // 
            this.publ_descripcion.Location = new System.Drawing.Point(104, 57);
            this.publ_descripcion.Name = "publ_descripcion";
            this.publ_descripcion.Size = new System.Drawing.Size(541, 20);
            this.publ_descripcion.TabIndex = 28;
            this.publ_descripcion.TextChanged += new System.EventHandler(this.publ_descripcion_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Dirección";
            // 
            // publ_direccion
            // 
            this.publ_direccion.Location = new System.Drawing.Point(104, 158);
            this.publ_direccion.Name = "publ_direccion";
            this.publ_direccion.Size = new System.Drawing.Size(199, 20);
            this.publ_direccion.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(348, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Grado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(348, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Fecha Vencimiento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(348, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Rubro";
            // 
            // publ_grado
            // 
            this.publ_grado.FormattingEnabled = true;
            this.publ_grado.Location = new System.Drawing.Point(446, 108);
            this.publ_grado.Name = "publ_grado";
            this.publ_grado.Size = new System.Drawing.Size(199, 21);
            this.publ_grado.TabIndex = 39;
            this.publ_grado.SelectedIndexChanged += new System.EventHandler(this.publ_grado_SelectedIndexChanged);
            // 
            // publ_rubro
            // 
            this.publ_rubro.FormattingEnabled = true;
            this.publ_rubro.Location = new System.Drawing.Point(446, 220);
            this.publ_rubro.Name = "publ_rubro";
            this.publ_rubro.Size = new System.Drawing.Size(199, 21);
            this.publ_rubro.TabIndex = 40;
            this.publ_rubro.SelectedIndexChanged += new System.EventHandler(this.publ_rubro_SelectedIndexChanged);
            // 
            // publ_fecha_ven
            // 
            this.publ_fecha_ven.Location = new System.Drawing.Point(446, 162);
            this.publ_fecha_ven.Name = "publ_fecha_ven";
            this.publ_fecha_ven.Size = new System.Drawing.Size(199, 20);
            this.publ_fecha_ven.TabIndex = 41;
            // 
            // publ_estado
            // 
            this.publ_estado.FormattingEnabled = true;
            this.publ_estado.Location = new System.Drawing.Point(104, 106);
            this.publ_estado.Name = "publ_estado";
            this.publ_estado.Size = new System.Drawing.Size(199, 21);
            this.publ_estado.TabIndex = 42;
            this.publ_estado.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // EditarPublicacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 380);
            this.Controls.Add(this.publ_estado);
            this.Controls.Add(this.publ_fecha_ven);
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
            this.Name = "EditarPublicacionForm";
            this.Text = "EditarPublicacion";
            this.Load += new System.EventHandler(this.EditarPublicacionForm_Load);
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
        private System.Windows.Forms.DateTimePicker publ_fecha_ven;
        private System.Windows.Forms.ComboBox publ_estado;



    }
}