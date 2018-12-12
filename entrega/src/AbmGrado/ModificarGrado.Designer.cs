namespace PalcoNet.AbmGrado
{
    partial class ModificarGrado
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
            this.grad_estado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.modificar = new System.Windows.Forms.Button();
            this.grad_descripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grad_porcentaje = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // grad_estado
            // 
            this.grad_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.grad_estado.FormattingEnabled = true;
            this.grad_estado.Location = new System.Drawing.Point(258, 67);
            this.grad_estado.Name = "grad_estado";
            this.grad_estado.Size = new System.Drawing.Size(75, 21);
            this.grad_estado.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Estado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Porcentaje";
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(24, 125);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(309, 43);
            this.modificar.TabIndex = 26;
            this.modificar.Text = "Guardar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // grad_descripcion
            // 
            this.grad_descripcion.Location = new System.Drawing.Point(106, 17);
            this.grad_descripcion.Name = "grad_descripcion";
            this.grad_descripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.grad_descripcion.Size = new System.Drawing.Size(227, 20);
            this.grad_descripcion.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Descripcion";
            // 
            // grad_porcentaje
            // 
            this.grad_porcentaje.Location = new System.Drawing.Point(110, 67);
            this.grad_porcentaje.Mask = "00,99";
            this.grad_porcentaje.Name = "grad_porcentaje";
            this.grad_porcentaje.Size = new System.Drawing.Size(93, 20);
            this.grad_porcentaje.TabIndex = 39;
            // 
            // ModificarGrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 193);
            this.Controls.Add(this.grad_porcentaje);
            this.Controls.Add(this.grad_estado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grad_descripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modificar);
            this.Name = "ModificarGrado";
            this.Text = "Datos Grado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox grad_estado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.TextBox grad_descripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox grad_porcentaje;
    }
}