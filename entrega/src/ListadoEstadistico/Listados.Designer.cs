namespace PalcoNet.ListadoEstadistico
{
    partial class listados
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
            this.localidades = new System.Windows.Forms.Button();
            this.puntos = new System.Windows.Forms.Button();
            this.compras = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // localidades
            // 
            this.localidades.Location = new System.Drawing.Point(55, 68);
            this.localidades.Name = "localidades";
            this.localidades.Size = new System.Drawing.Size(520, 66);
            this.localidades.TabIndex = 0;
            this.localidades.Text = "Empresas con mayor cantidad de localidades no vendidas";
            this.localidades.UseVisualStyleBackColor = true;
            this.localidades.Click += new System.EventHandler(this.localidades_Click);
            // 
            // puntos
            // 
            this.puntos.Location = new System.Drawing.Point(55, 171);
            this.puntos.Name = "puntos";
            this.puntos.Size = new System.Drawing.Size(520, 66);
            this.puntos.TabIndex = 1;
            this.puntos.Text = "Clientes con mayores puntos vencidos";
            this.puntos.UseVisualStyleBackColor = true;
            this.puntos.Click += new System.EventHandler(this.puntos_Click);
            // 
            // compras
            // 
            this.compras.Location = new System.Drawing.Point(55, 274);
            this.compras.Name = "compras";
            this.compras.Size = new System.Drawing.Size(520, 66);
            this.compras.TabIndex = 2;
            this.compras.Text = "Clientes con mayor cantidad de compras";
            this.compras.UseVisualStyleBackColor = true;
            this.compras.Click += new System.EventHandler(this.compras_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccionar tipo de listado";
            // 
            // listados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 375);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.compras);
            this.Controls.Add(this.puntos);
            this.Controls.Add(this.localidades);
            this.Name = "listados";
            this.Text = "Listado estadistico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button localidades;
        private System.Windows.Forms.Button puntos;
        private System.Windows.Forms.Button compras;
        private System.Windows.Forms.Label label1;
    }
}