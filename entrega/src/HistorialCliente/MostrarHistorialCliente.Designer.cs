namespace PalcoNet.HistorialCliente
{
    partial class MostrarHistorialCliente
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
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.siguiente = new System.Windows.Forms.Button();
            this.ultimo = new System.Windows.Forms.Button();
            this.anterior = new System.Windows.Forms.Button();
            this.primera = new System.Windows.Forms.Button();
            this.pag = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // datagrid
            // 
            this.datagrid.AllowUserToAddRows = false;
            this.datagrid.AllowUserToDeleteRows = false;
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Location = new System.Drawing.Point(12, 12);
            this.datagrid.Name = "datagrid";
            this.datagrid.ReadOnly = true;
            this.datagrid.Size = new System.Drawing.Size(546, 248);
            this.datagrid.TabIndex = 18;
            this.datagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_CellContentClick);
            // 
            // siguiente
            // 
            this.siguiente.Location = new System.Drawing.Point(298, 272);
            this.siguiente.Name = "siguiente";
            this.siguiente.Size = new System.Drawing.Size(28, 28);
            this.siguiente.TabIndex = 19;
            this.siguiente.Text = ">";
            this.siguiente.UseVisualStyleBackColor = true;
            this.siguiente.Click += new System.EventHandler(this.siguiente_Click);
            // 
            // ultimo
            // 
            this.ultimo.Location = new System.Drawing.Point(341, 272);
            this.ultimo.Name = "ultimo";
            this.ultimo.Size = new System.Drawing.Size(28, 28);
            this.ultimo.TabIndex = 20;
            this.ultimo.Text = ">>";
            this.ultimo.UseVisualStyleBackColor = true;
            this.ultimo.Click += new System.EventHandler(this.ultimo_Click);
            // 
            // anterior
            // 
            this.anterior.Location = new System.Drawing.Point(220, 272);
            this.anterior.Name = "anterior";
            this.anterior.Size = new System.Drawing.Size(28, 28);
            this.anterior.TabIndex = 21;
            this.anterior.Text = "<";
            this.anterior.UseVisualStyleBackColor = true;
            this.anterior.Click += new System.EventHandler(this.anterior_Click);
            // 
            // primera
            // 
            this.primera.Location = new System.Drawing.Point(176, 272);
            this.primera.Name = "primera";
            this.primera.Size = new System.Drawing.Size(28, 28);
            this.primera.TabIndex = 22;
            this.primera.Text = "<<";
            this.primera.UseVisualStyleBackColor = true;
            this.primera.Click += new System.EventHandler(this.primera_Click);
            // 
            // pag
            // 
            this.pag.AutoSize = true;
            this.pag.Location = new System.Drawing.Point(267, 280);
            this.pag.Name = "pag";
            this.pag.Size = new System.Drawing.Size(25, 13);
            this.pag.TabIndex = 23;
            this.pag.Text = "pag";
            // 
            // MostrarHistorialCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 312);
            this.Controls.Add(this.pag);
            this.Controls.Add(this.primera);
            this.Controls.Add(this.anterior);
            this.Controls.Add(this.ultimo);
            this.Controls.Add(this.siguiente);
            this.Controls.Add(this.datagrid);
            this.Name = "MostrarHistorialCliente";
            this.Text = "Historial";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.Button siguiente;
        private System.Windows.Forms.Button ultimo;
        private System.Windows.Forms.Button anterior;
        private System.Windows.Forms.Button primera;
        private System.Windows.Forms.Label pag;
    }
}