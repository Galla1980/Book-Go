namespace GUI_327LG.Reportes
{
    partial class FormReporteFactura_327LG
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
            dgvFacturas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            SuspendLayout();
            // 
            // dgvFacturas
            // 
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Location = new Point(58, 63);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.Size = new Size(658, 283);
            dgvFacturas.TabIndex = 0;
            dgvFacturas.CellDoubleClick += dgvFacturas_CellDoubleClick;
            // 
            // FormReporteFactura_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 417);
            Controls.Add(dgvFacturas);
            Name = "FormReporteFactura_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormReporteFactura_327LG";
            Load += FormReporteFactura_327LG_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvFacturas;
    }
}