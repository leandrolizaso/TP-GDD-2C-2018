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
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // datagrid
            // 
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Location = new System.Drawing.Point(12, 12);
            this.datagrid.Name = "datagrid";
            this.datagrid.Size = new System.Drawing.Size(612, 324);
            this.datagrid.TabIndex = 18;
            this.datagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_CellContentClick);
            // 
            // siguiente
            // 
            this.siguiente.Location = new System.Drawing.Point(326, 342);
            this.siguiente.Name = "siguiente";
            this.siguiente.Size = new System.Drawing.Size(28, 28);
            this.siguiente.TabIndex = 19;
            this.siguiente.Text = ">";
            this.siguiente.UseVisualStyleBackColor = true;
            this.siguiente.Click += new System.EventHandler(this.siguiente_Click);
            // 
            // ultimo
            // 
            this.ultimo.Location = new System.Drawing.Point(368, 342);
            this.ultimo.Name = "ultimo";
            this.ultimo.Size = new System.Drawing.Size(28, 28);
            this.ultimo.TabIndex = 20;
            this.ultimo.Text = ">>";
            this.ultimo.UseVisualStyleBackColor = true;
            this.ultimo.Click += new System.EventHandler(this.ultimo_Click);
            // 
            // anterior
            // 
            this.anterior.Location = new System.Drawing.Point(281, 342);
            this.anterior.Name = "anterior";
            this.anterior.Size = new System.Drawing.Size(28, 28);
            this.anterior.TabIndex = 21;
            this.anterior.Text = "<";
            this.anterior.UseVisualStyleBackColor = true;
            this.anterior.Click += new System.EventHandler(this.anterior_Click);
            // 
            // primera
            // 
            this.primera.Location = new System.Drawing.Point(237, 342);
            this.primera.Name = "primera";
            this.primera.Size = new System.Drawing.Size(28, 28);
            this.primera.TabIndex = 22;
            this.primera.Text = "<<";
            this.primera.UseVisualStyleBackColor = true;
            this.primera.Click += new System.EventHandler(this.primera_Click);
            // 
            // HistorialCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 375);
            this.Controls.Add(this.primera);
            this.Controls.Add(this.anterior);
            this.Controls.Add(this.ultimo);
            this.Controls.Add(this.siguiente);
            this.Controls.Add(this.datagrid);
            this.Name = "HistorialCliente";
            this.Text = "Historial";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.Button siguiente;
        private System.Windows.Forms.Button ultimo;
        private System.Windows.Forms.Button anterior;
        private System.Windows.Forms.Button primera;
    }
}