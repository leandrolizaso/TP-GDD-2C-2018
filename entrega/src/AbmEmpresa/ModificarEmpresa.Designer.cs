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
            this.labelEstado = new System.Windows.Forms.Label();
            this.empr_direccion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.empr_mail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.empr_estado = new System.Windows.Forms.ComboBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.empr_cuit = new System.Windows.Forms.MaskedTextBox();
            this.empr_fecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.empr_codigo_postal = new System.Windows.Forms.TextBox();
            this.ciudad = new System.Windows.Forms.Label();
            this.empr_ciudad = new System.Windows.Forms.TextBox();
            this.labelRazon = new System.Windows.Forms.Label();
            this.labelMail = new System.Windows.Forms.Label();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.labelCiudad = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelDireccion = new System.Windows.Forms.Label();
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
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(363, 227);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(40, 13);
            this.labelEstado.TabIndex = 24;
            this.labelEstado.Text = "Estado";
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
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(70, 294);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(55, 13);
            this.labelUser.TabIndex = 28;
            this.labelUser.Text = "Username";
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
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(363, 291);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(53, 13);
            this.labelPass.TabIndex = 30;
            this.labelPass.Text = "Password";
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
            // labelRazon
            // 
            this.labelRazon.AutoSize = true;
            this.labelRazon.ForeColor = System.Drawing.Color.Coral;
            this.labelRazon.Location = new System.Drawing.Point(161, 54);
            this.labelRazon.Name = "labelRazon";
            this.labelRazon.Size = new System.Drawing.Size(107, 13);
            this.labelRazon.TabIndex = 35;
            this.labelRazon.Text = "Razon social invalida";
            this.labelRazon.Visible = false;
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.ForeColor = System.Drawing.Color.Coral;
            this.labelMail.Location = new System.Drawing.Point(457, 105);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(65, 13);
            this.labelMail.TabIndex = 38;
            this.labelMail.Text = "Mail invalido";
            this.labelMail.Visible = false;
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.ForeColor = System.Drawing.Color.Coral;
            this.labelTelefono.Location = new System.Drawing.Point(161, 155);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(88, 13);
            this.labelTelefono.TabIndex = 39;
            this.labelTelefono.Text = "Telefono invalido";
            this.labelTelefono.Visible = false;
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.ForeColor = System.Drawing.Color.Coral;
            this.labelCodigo.Location = new System.Drawing.Point(457, 203);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(110, 13);
            this.labelCodigo.TabIndex = 40;
            this.labelCodigo.Text = "Código postal invalido";
            this.labelCodigo.Visible = false;
            // 
            // labelCiudad
            // 
            this.labelCiudad.AutoSize = true;
            this.labelCiudad.ForeColor = System.Drawing.Color.Coral;
            this.labelCiudad.Location = new System.Drawing.Point(161, 203);
            this.labelCiudad.Name = "labelCiudad";
            this.labelCiudad.Size = new System.Drawing.Size(79, 13);
            this.labelCiudad.TabIndex = 41;
            this.labelCiudad.Text = "Ciudad invalida";
            this.labelCiudad.Visible = false;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.ForeColor = System.Drawing.Color.Coral;
            this.labelUsername.Location = new System.Drawing.Point(161, 314);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(94, 13);
            this.labelUsername.TabIndex = 42;
            this.labelUsername.Text = "Username invalido";
            this.labelUsername.Visible = false;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.ForeColor = System.Drawing.Color.Coral;
            this.labelPassword.Location = new System.Drawing.Point(457, 314);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(92, 13);
            this.labelPassword.TabIndex = 43;
            this.labelPassword.Text = "Password invalido";
            this.labelPassword.Visible = false;
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.ForeColor = System.Drawing.Color.Coral;
            this.labelDireccion.Location = new System.Drawing.Point(457, 155);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(91, 13);
            this.labelDireccion.TabIndex = 44;
            this.labelDireccion.Text = "Direccion invalida";
            this.labelDireccion.Visible = false;
            // 
            // ModificarEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 418);
            this.Controls.Add(this.labelDireccion);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelCiudad);
            this.Controls.Add(this.labelCodigo);
            this.Controls.Add(this.labelTelefono);
            this.Controls.Add(this.labelMail);
            this.Controls.Add(this.labelRazon);
            this.Controls.Add(this.empr_ciudad);
            this.Controls.Add(this.ciudad);
            this.Controls.Add(this.empr_codigo_postal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.empr_fecha);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.empr_cuit);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.empr_estado);
            this.Controls.Add(this.labelEstado);
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
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.TextBox empr_direccion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox empr_mail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox empr_estado;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.MaskedTextBox empr_cuit;
        private System.Windows.Forms.DateTimePicker empr_fecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox empr_codigo_postal;
        private System.Windows.Forms.Label ciudad;
        private System.Windows.Forms.TextBox empr_ciudad;
        private System.Windows.Forms.Label labelRazon;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.Label labelCiudad;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelDireccion;
    }
}