namespace PalcoNet.AbmRol
{
    partial class ModificarRol
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
            this.rol_nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.eliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(12, 376);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(537, 43);
            this.modificar.TabIndex = 14;
            this.modificar.Text = "Guardar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // rol_nombre
            // 
            this.rol_nombre.Location = new System.Drawing.Point(105, 40);
            this.rol_nombre.Name = "rol_nombre";
            this.rol_nombre.Size = new System.Drawing.Size(292, 20);
            this.rol_nombre.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre Rol";
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(16, 77);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(532, 282);
            this.panel.TabIndex = 17;
            // 
            // eliminar
            // 
            this.eliminar.Location = new System.Drawing.Point(408, 39);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(140, 21);
            this.eliminar.TabIndex = 18;
            this.eliminar.Text = "Eliminar Rol";
            this.eliminar.UseVisualStyleBackColor = true;
            this.eliminar.Visible = false;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // ModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 431);
            this.Controls.Add(this.eliminar);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.rol_nombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modificar);
            this.Name = "ModificarRol";
            this.Text = "ModificarRol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.TextBox rol_nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel panel;
        private System.Windows.Forms.Button eliminar;
    }
}