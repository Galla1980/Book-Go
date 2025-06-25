namespace GUI_327LG.GUIRF1
{
    partial class FormRegDevolucion_327LG
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
            lblPrestamos = new Label();
            dgvPrestamos = new DataGridView();
            lblDNICliente = new Label();
            txtDNICliente = new TextBox();
            btnFiltrar = new Button();
            lblEstadoLibro = new Label();
            cmbEstadoLibro = new ComboBox();
            btnRegistrarDevolucion = new Button();
            lblTituloForm = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            SuspendLayout();
            // 
            // lblPrestamos
            // 
            lblPrestamos.AutoSize = true;
            lblPrestamos.Font = new Font("Segoe UI", 15F);
            lblPrestamos.Location = new Point(12, 56);
            lblPrestamos.Name = "lblPrestamos";
            lblPrestamos.Size = new Size(200, 28);
            lblPrestamos.TabIndex = 0;
            lblPrestamos.Text = "Prestamos del cliente:";
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestamos.Location = new Point(12, 87);
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.Size = new Size(574, 169);
            dgvPrestamos.TabIndex = 1;
            // 
            // lblDNICliente
            // 
            lblDNICliente.AutoSize = true;
            lblDNICliente.Location = new Point(26, 270);
            lblDNICliente.Name = "lblDNICliente";
            lblDNICliente.Size = new Size(68, 15);
            lblDNICliente.TabIndex = 2;
            lblDNICliente.Text = "DNI cliente:";
            // 
            // txtDNICliente
            // 
            txtDNICliente.Location = new Point(26, 288);
            txtDNICliente.Name = "txtDNICliente";
            txtDNICliente.Size = new Size(115, 23);
            txtDNICliente.TabIndex = 3;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(147, 288);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(121, 25);
            btnFiltrar.TabIndex = 4;
            btnFiltrar.Text = "Filtrar prestamos";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // lblEstadoLibro
            // 
            lblEstadoLibro.AutoSize = true;
            lblEstadoLibro.Location = new Point(351, 270);
            lblEstadoLibro.Name = "lblEstadoLibro";
            lblEstadoLibro.Size = new Size(88, 15);
            lblEstadoLibro.TabIndex = 5;
            lblEstadoLibro.Text = "Estado del libro";
            // 
            // cmbEstadoLibro
            // 
            cmbEstadoLibro.FormattingEnabled = true;
            cmbEstadoLibro.Location = new Point(351, 288);
            cmbEstadoLibro.Name = "cmbEstadoLibro";
            cmbEstadoLibro.Size = new Size(121, 23);
            cmbEstadoLibro.TabIndex = 6;
            cmbEstadoLibro.Text = "Dañado";
            cmbEstadoLibro.SelectedIndexChanged += cmbEstadoLibro_SelectedIndexChanged;
            // 
            // btnRegistrarDevolucion
            // 
            btnRegistrarDevolucion.Font = new Font("Segoe UI", 14F);
            btnRegistrarDevolucion.Location = new Point(220, 347);
            btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            btnRegistrarDevolucion.Size = new Size(130, 60);
            btnRegistrarDevolucion.TabIndex = 7;
            btnRegistrarDevolucion.Text = "Registrar devolución";
            btnRegistrarDevolucion.UseVisualStyleBackColor = true;
            btnRegistrarDevolucion.Click += btnRegistrarDevolucion_Click;
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Segoe UI", 20F);
            lblTituloForm.Location = new Point(177, 9);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(262, 37);
            lblTituloForm.TabIndex = 8;
            lblTituloForm.Text = "Registrar Devolución";
            // 
            // FormRegDevolucion_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 450);
            Controls.Add(lblTituloForm);
            Controls.Add(btnRegistrarDevolucion);
            Controls.Add(cmbEstadoLibro);
            Controls.Add(lblEstadoLibro);
            Controls.Add(btnFiltrar);
            Controls.Add(txtDNICliente);
            Controls.Add(lblDNICliente);
            Controls.Add(dgvPrestamos);
            Controls.Add(lblPrestamos);
            Name = "FormRegDevolucion_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegDevolucion";
            Load += FormRegDevolucion_327LG_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPrestamos;
        private DataGridView dgvPrestamos;
        private Label lblDNICliente;
        private TextBox txtDNICliente;
        private Button btnFiltrar;
        private Label lblEstadoLibro;
        private ComboBox cmbEstadoLibro;
        private Button btnRegistrarDevolucion;
        private Label lblTituloForm;
    }
}