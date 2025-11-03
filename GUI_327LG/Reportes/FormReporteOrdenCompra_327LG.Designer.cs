namespace GUI_327LG.Reportes
{
    partial class FormReporteOrdenCompra_327LG
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
            dgvOrdenes = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).BeginInit();
            SuspendLayout();
            // 
            // dgvOrdenes
            // 
            dgvOrdenes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrdenes.Location = new Point(23, 63);
            dgvOrdenes.Name = "dgvOrdenes";
            dgvOrdenes.Size = new Size(583, 251);
            dgvOrdenes.TabIndex = 0;
            dgvOrdenes.CellContentDoubleClick += this.dgvOrdenes_CellContentDoubleClick_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(112, 9);
            label1.Name = "label1";
            label1.Size = new Size(383, 37);
            label1.TabIndex = 1;
            label1.Text = "Reporte de ordenes de compra";
            // 
            // FormReporteOrdenCompra_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 341);
            Controls.Add(label1);
            Controls.Add(dgvOrdenes);
            Name = "FormReporteOrdenCompra_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormReporteOrdenCompra";
            Load += FormReporteOrdenCompra_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvOrdenes;
        private Label label1;
    }
}