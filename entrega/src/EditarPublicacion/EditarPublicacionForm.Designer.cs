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
            this.publ_estado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.publ_fecha_ven = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.publ_direccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.publ_descripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.modificar = new System.Windows.Forms.Button();
            this.publ_grado = new System.Windows.Forms.ComboBox();
            this.publ_rubro = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // publ_estado
            // 
            this.publ_estado.FormattingEnabled = true;
            this.publ_estado.Location = new System.Drawing.Point(138, 133);
            this.publ_estado.Margin = new System.Windows.Forms.Padding(4);
            this.publ_estado.Name = "publ_estado";
            this.publ_estado.Size = new System.Drawing.Size(213, 24);
            this.publ_estado.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(418, 274);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 37;
            this.label7.Text = "Rubro";
            // 
            // publ_fecha_ven
            // 
            this.publ_fecha_ven.Location = new System.Drawing.Point(530, 194);
            this.publ_fecha_ven.Margin = new System.Windows.Forms.Padding(4);
            this.publ_fecha_ven.Name = "publ_fecha_ven";
            this.publ_fecha_ven.Size = new System.Drawing.Size(215, 22);
            this.publ_fecha_ven.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(394, 197);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 17);
            this.label9.TabIndex = 35;
            this.label9.Text = "Fecha Vencimiento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(418, 137);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 17);
            this.label10.TabIndex = 33;
            this.label10.Text = "Grado";
            // 
            // publ_direccion
            // 
            this.publ_direccion.Location = new System.Drawing.Point(138, 194);
            this.publ_direccion.Margin = new System.Windows.Forms.Padding(4);
            this.publ_direccion.Name = "publ_direccion";
            this.publ_direccion.Size = new System.Drawing.Size(215, 22);
            this.publ_direccion.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 198);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Dirección";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Estado";
            // 
            // publ_descripcion
            // 
            this.publ_descripcion.Location = new System.Drawing.Point(138, 70);
            this.publ_descripcion.Margin = new System.Windows.Forms.Padding(4);
            this.publ_descripcion.Name = "publ_descripcion";
            this.publ_descripcion.Size = new System.Drawing.Size(605, 22);
            this.publ_descripcion.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Descripción";
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(30, 346);
            this.modificar.Margin = new System.Windows.Forms.Padding(4);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(716, 53);
            this.modificar.TabIndex = 26;
            this.modificar.Text = "Guardar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // publ_grado
            // 
            this.publ_grado.FormattingEnabled = true;
            this.publ_grado.Location = new System.Drawing.Point(530, 134);
            this.publ_grado.Margin = new System.Windows.Forms.Padding(4);
            this.publ_grado.Name = "publ_grado";
            this.publ_grado.Size = new System.Drawing.Size(213, 24);
            this.publ_grado.TabIndex = 39;
            // 
            // publ_rubro
            // 
            this.publ_rubro.FormattingEnabled = true;
            this.publ_rubro.Location = new System.Drawing.Point(530, 274);
            this.publ_rubro.Margin = new System.Windows.Forms.Padding(4);
            this.publ_rubro.Name = "publ_rubro";
            this.publ_rubro.Size = new System.Drawing.Size(213, 24);
            this.publ_rubro.TabIndex = 40;
            // 
            // EditarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 468);
            this.Controls.Add(this.publ_rubro);
            this.Controls.Add(this.publ_grado);
            this.Controls.Add(this.publ_estado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.publ_fecha_ven);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.publ_direccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.publ_descripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modificar);
            this.Name = "EditarPublicacion";
            this.Text = "EditarPublicacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox publ_estado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox publ_fecha_ven;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox publ_direccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox publ_descripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.ComboBox publ_grado;
        private System.Windows.Forms.ComboBox publ_rubro;
    }
}