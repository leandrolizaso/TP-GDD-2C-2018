namespace PalcoNet.RegistroUsuario
{
    partial class NuevoUsuario
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
            this.cliente = new System.Windows.Forms.Button();
            this.empresa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cliente
            // 
            this.cliente.Location = new System.Drawing.Point(10, 8);
            this.cliente.Name = "cliente";
            this.cliente.Size = new System.Drawing.Size(112, 70);
            this.cliente.TabIndex = 0;
            this.cliente.Text = "Cliente";
            this.cliente.UseVisualStyleBackColor = true;
            this.cliente.Click += new System.EventHandler(this.cliente_Click);
            // 
            // empresa
            // 
            this.empresa.Location = new System.Drawing.Point(116, 8);
            this.empresa.Name = "empresa";
            this.empresa.Size = new System.Drawing.Size(112, 70);
            this.empresa.TabIndex = 1;
            this.empresa.Text = "Empresa";
            this.empresa.UseVisualStyleBackColor = true;
            this.empresa.Click += new System.EventHandler(this.empresa_Click);
            // 
            // NuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 89);
            this.Controls.Add(this.empresa);
            this.Controls.Add(this.cliente);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuevoUsuario";
            this.Text = "Registro de... ?";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cliente;
        private System.Windows.Forms.Button empresa;
    }
}