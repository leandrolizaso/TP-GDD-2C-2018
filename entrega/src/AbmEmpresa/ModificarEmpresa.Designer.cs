namespace PalcoNet.AbmEmpresa
{
    partial class ModificarEmpresa
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
            this.empr_razon_social = new System.Windows.Forms.TextBox();
            this.empr_telefono = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.empr_direccion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.empr_mail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.empr_estado = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.empr_cuit = new System.Windows.Forms.MaskedTextBox();
            this.empr_fecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.empr_codigo_postal = new System.Windows.Forms.TextBox();
            this.ciudad = new System.Windows.Forms.Label();
            this.empr_ciudad = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(72, 353);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(537, 43);
            this.modificar.TabIndex = 1;
            this.modificar.Text = "Guardar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Razon Social";
            // 
            // empr_razon_social
            // 
            this.empr_razon_social.Location = new System.Drawing.Point(153, 31);
            this.empr_razon_social.Name = "empr_razon_social";
            this.empr_razon_social.Size = new System.Drawing.Size(455, 20);
            this.empr_razon_social.TabIndex = 3;
            // 
            // empr_telefono
            // 
            this.empr_telefono.Location = new System.Drawing.Point(153, 132);
            this.empr_telefono.Name = "empr_telefono";
            this.empr_telefono.Size = new System.Drawing.Size(162, 20);
            this.empr_telefono.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Telefono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "CUIT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(363, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Estado";
            // 
            // empr_direccion
            // 
            this.empr_direccion.Location = new System.Drawing.Point(447, 132);
            this.empr_direccion.Name = "empr_direccion";
            this.empr_direccion.Size = new System.Drawing.Size(162, 20);
            this.empr_direccion.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(363, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Direccion";
            // 
            // empr_mail
            // 
            this.empr_mail.Location = new System.Drawing.Point(447, 82);
            this.empr_mail.Name = "empr_mail";
            this.empr_mail.Size = new System.Drawing.Size(162, 20);
            this.empr_mail.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(363, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Mail";
            // 
            // empr_estado
            // 
            this.empr_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empr_estado.FormattingEnabled = true;
            this.empr_estado.Location = new System.Drawing.Point(449, 227);
            this.empr_estado.Name = "empr_estado";
            this.empr_estado.Size = new System.Drawing.Size(161, 21);
            this.empr_estado.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(70, 294);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Username";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(447, 291);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(162, 20);
            this.password.TabIndex = 1;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(153, 291);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(162, 20);
            this.username.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(363, 291);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Password";
            // 
            // empr_cuit
            // 
            this.empr_cuit.Location = new System.Drawing.Point(153, 82);
            this.empr_cuit.Mask = "00-00000000-0";
            this.empr_cuit.Name = "empr_cuit";
            this.empr_cuit.Size = new System.Drawing.Size(162, 20);
            this.empr_cuit.TabIndex = 27;
            // 
            // empr_fecha
            // 
            this.empr_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.empr_fecha.Location = new System.Drawing.Point(153, 228);
            this.empr_fecha.Name = "empr_fecha";
            this.empr_fecha.Size = new System.Drawing.Size(160, 20);
            this.empr_fecha.TabIndex = 28;
            this.empr_fecha.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Código postal";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // empr_codigo_postal
            // 
            this.empr_codigo_postal.Location = new System.Drawing.Point(447, 180);
            this.empr_codigo_postal.Name = "empr_codigo_postal";
            this.empr_codigo_postal.Size = new System.Drawing.Size(162, 20);
            this.empr_codigo_postal.TabIndex = 32;
            // 
            // ciudad
            // 
            this.ciudad.AutoSize = true;
            this.ciudad.Location = new System.Drawing.Point(70, 180);
            this.ciudad.Name = "ciudad";
            this.ciudad.Size = new System.Drawing.Size(40, 13);
            this.ciudad.TabIndex = 33;
            this.ciudad.Text = "Ciudad";
            // 
            // empr_ciudad
            // 
            this.empr_ciudad.Location = new System.Drawing.Point(153, 180);
            this.empr_ciudad.Name = "empr_ciudad";
            this.empr_ciudad.Size = new System.Drawing.Size(162, 20);
            this.empr_ciudad.TabIndex = 34;
            // 
            // ModificarEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 418);
            this.Controls.Add(this.empr_ciudad);
            this.Controls.Add(this.ciudad);
            this.Controls.Add(this.empr_codigo_postal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.empr_fecha);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.empr_cuit);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.empr_estado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.empr_direccion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.empr_mail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.empr_telefono);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.empr_razon_social);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modificar);
            this.Name = "ModificarEmpresa";
            this.Text = "Datos Empresa";
            this.Load += new System.EventHandler(this.ModificarEmpresa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox empr_razon_social;
        private System.Windows.Forms.TextBox empr_telefono;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox empr_direccion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox empr_mail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox empr_estado;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox empr_cuit;
        private System.Windows.Forms.DateTimePicker empr_fecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox empr_codigo_postal;
        private System.Windows.Forms.Label ciudad;
        private System.Windows.Forms.TextBox empr_ciudad;
    }
}