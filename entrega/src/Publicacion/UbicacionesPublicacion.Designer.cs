namespace PalcoNet.Publicacion
{
    partial class UbicacionesPublicacion
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
            this.label2 = new System.Windows.Forms.Label();
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ubic_fila = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ubic_precio = new System.Windows.Forms.MaskedTextBox();
            this.ubic_tipo = new System.Windows.Forms.ComboBox();
            this.labelAsiento = new System.Windows.Forms.Label();
            this.ubic_asiento = new System.Windows.Forms.TextBox();
            this.labelPrecio = new System.Windows.Forms.Label();
            this.labelFila = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(418, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Se puede eliminar un registro clickeando en la fila y presionando la tecla SUPR (" +
    "o DEL)";
            // 
            // datagrid
            // 
            this.datagrid.AllowUserToAddRows = false;
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Location = new System.Drawing.Point(12, 143);
            this.datagrid.Name = "datagrid";
            this.datagrid.ReadOnly = true;
            this.datagrid.Size = new System.Drawing.Size(429, 214);
            this.datagrid.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(363, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Asiento";
            // 
            // ubic_fila
            // 
            this.ubic_fila.Location = new System.Drawing.Point(294, 24);
            this.ubic_fila.MaxLength = 3;
            this.ubic_fila.Name = "ubic_fila";
            this.ubic_fila.Size = new System.Drawing.Size(144, 20);
            this.ubic_fila.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Fila";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Tipo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Precio";
            // 
            // ubic_precio
            // 
            this.ubic_precio.Location = new System.Drawing.Point(78, 67);
            this.ubic_precio.Name = "ubic_precio";
            this.ubic_precio.Size = new System.Drawing.Size(140, 20);
            this.ubic_precio.TabIndex = 21;
            // 
            // ubic_tipo
            // 
            this.ubic_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ubic_tipo.FormattingEnabled = true;
            this.ubic_tipo.Location = new System.Drawing.Point(295, 67);
            this.ubic_tipo.Name = "ubic_tipo";
            this.ubic_tipo.Size = new System.Drawing.Size(143, 21);
            this.ubic_tipo.TabIndex = 22;
            // 
            // labelAsiento
            // 
            this.labelAsiento.AutoSize = true;
            this.labelAsiento.ForeColor = System.Drawing.Color.Coral;
            this.labelAsiento.Location = new System.Drawing.Point(105, 44);
            this.labelAsiento.Name = "labelAsiento";
            this.labelAsiento.Size = new System.Drawing.Size(81, 13);
            this.labelAsiento.TabIndex = 39;
            this.labelAsiento.Text = "Asiento inválido";
            this.labelAsiento.Visible = false;
            // 
            // ubic_asiento
            // 
            this.ubic_asiento.Location = new System.Drawing.Point(74, 24);
            this.ubic_asiento.MaxLength = 2;
            this.ubic_asiento.Name = "ubic_asiento";
            this.ubic_asiento.Size = new System.Drawing.Size(144, 20);
            this.ubic_asiento.TabIndex = 40;
            // 
            // labelPrecio
            // 
            this.labelPrecio.AutoSize = true;
            this.labelPrecio.ForeColor = System.Drawing.Color.Coral;
            this.labelPrecio.Location = new System.Drawing.Point(105, 96);
            this.labelPrecio.Name = "labelPrecio";
            this.labelPrecio.Size = new System.Drawing.Size(76, 13);
            this.labelPrecio.TabIndex = 41;
            this.labelPrecio.Text = "Monto inválido";
            this.labelPrecio.Visible = false;
            // 
            // labelFila
            // 
            this.labelFila.AutoSize = true;
            this.labelFila.ForeColor = System.Drawing.Color.Coral;
            this.labelFila.Location = new System.Drawing.Point(322, 44);
            this.labelFila.Name = "labelFila";
            this.labelFila.Size = new System.Drawing.Size(62, 13);
            this.labelFila.TabIndex = 42;
            this.labelFila.Text = "Fila inválida";
            this.labelFila.Visible = false;
            // 
            // UbicacionesPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 393);
            this.Controls.Add(this.labelFila);
            this.Controls.Add(this.labelPrecio);
            this.Controls.Add(this.ubic_asiento);
            this.Controls.Add(this.labelAsiento);
            this.Controls.Add(this.ubic_tipo);
            this.Controls.Add(this.ubic_precio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ubic_fila);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.button1);
            this.Name = "UbicacionesPublicacion";
            this.Text = "Ubicaciones de la Publicacion";
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ubic_fila;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox ubic_precio;
        private System.Windows.Forms.ComboBox ubic_tipo;
        private System.Windows.Forms.Label labelAsiento;
        private System.Windows.Forms.TextBox ubic_asiento;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.Label labelFila;
    }
}