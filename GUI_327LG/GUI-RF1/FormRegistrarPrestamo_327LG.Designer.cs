namespace GUI_327LG.GUIRF1
{
    partial class FormRegistrarPrestamo_327LG
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
            lblTituloForm = new Label();
            dgvClientes = new DataGridView();
            lblClientes = new Label();
            btnSeleccionarLibro = new Button();
            btnRegistrarCliente = new Button();
            btnRegistrarPrestamo = new Button();
            lblTituloLibro = new Label();
            lblAutor = new Label();
            lblEditorial = new Label();
            lblEdicion = new Label();
            txtTitulo = new TextBox();
            txtAutor = new TextBox();
            txtEditorial = new TextBox();
            txtEdicion = new TextBox();
            lblLibroSel = new Label();
            btnSeleccionarCliente = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Segoe UI", 20F);
            lblTituloForm.Location = new Point(311, 9);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(240, 37);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Registrar préstamo";
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 89);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(627, 195);
            dgvClientes.TabIndex = 1;
            // 
            // lblClientes
            // 
            lblClientes.AutoSize = true;
            lblClientes.Font = new Font("Segoe UI", 14F);
            lblClientes.Location = new Point(12, 61);
            lblClientes.Name = "lblClientes";
            lblClientes.Size = new Size(185, 25);
            lblClientes.TabIndex = 2;
            lblClientes.Text = "Clientes Registrados:";
            // 
            // btnSeleccionarLibro
            // 
            btnSeleccionarLibro.Font = new Font("Segoe UI", 14F);
            btnSeleccionarLibro.Location = new Point(645, 89);
            btnSeleccionarLibro.Name = "btnSeleccionarLibro";
            btnSeleccionarLibro.Size = new Size(179, 62);
            btnSeleccionarLibro.TabIndex = 8;
            btnSeleccionarLibro.Text = "Seleccionar Libro";
            btnSeleccionarLibro.UseVisualStyleBackColor = true;
            btnSeleccionarLibro.Click += btnSeleccionarLibro_Click;
            // 
            // btnRegistrarCliente
            // 
            btnRegistrarCliente.Font = new Font("Segoe UI", 14F);
            btnRegistrarCliente.Location = new Point(645, 157);
            btnRegistrarCliente.Name = "btnRegistrarCliente";
            btnRegistrarCliente.Size = new Size(179, 62);
            btnRegistrarCliente.TabIndex = 9;
            btnRegistrarCliente.Text = "Registrar Cliente";
            btnRegistrarCliente.UseVisualStyleBackColor = true;
            btnRegistrarCliente.Click += btnRegistrarCliente_Click;
            // 
            // btnRegistrarPrestamo
            // 
            btnRegistrarPrestamo.Font = new Font("Segoe UI", 14F);
            btnRegistrarPrestamo.Location = new Point(645, 373);
            btnRegistrarPrestamo.Name = "btnRegistrarPrestamo";
            btnRegistrarPrestamo.Size = new Size(179, 62);
            btnRegistrarPrestamo.TabIndex = 10;
            btnRegistrarPrestamo.Text = "Registrar Préstamo";
            btnRegistrarPrestamo.UseVisualStyleBackColor = true;
            btnRegistrarPrestamo.Click += btnRegistrarPrestamo_Click;
            // 
            // lblTituloLibro
            // 
            lblTituloLibro.AutoSize = true;
            lblTituloLibro.Location = new Point(12, 394);
            lblTituloLibro.Name = "lblTituloLibro";
            lblTituloLibro.Size = new Size(38, 15);
            lblTituloLibro.TabIndex = 11;
            lblTituloLibro.Text = "Titulo";
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.Location = new Point(118, 394);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(37, 15);
            lblAutor.TabIndex = 12;
            lblAutor.Text = "Autor";
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(224, 394);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(50, 15);
            lblEditorial.TabIndex = 13;
            lblEditorial.Text = "Editorial";
            // 
            // lblEdicion
            // 
            lblEdicion.AutoSize = true;
            lblEdicion.Location = new Point(330, 394);
            lblEdicion.Name = "lblEdicion";
            lblEdicion.Size = new Size(46, 15);
            lblEdicion.TabIndex = 14;
            lblEdicion.Text = "Edicion";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(12, 412);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(100, 23);
            txtTitulo.TabIndex = 15;
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(118, 412);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(100, 23);
            txtAutor.TabIndex = 16;
            // 
            // txtEditorial
            // 
            txtEditorial.Location = new Point(224, 412);
            txtEditorial.Name = "txtEditorial";
            txtEditorial.Size = new Size(100, 23);
            txtEditorial.TabIndex = 17;
            // 
            // txtEdicion
            // 
            txtEdicion.Location = new Point(330, 412);
            txtEdicion.Name = "txtEdicion";
            txtEdicion.Size = new Size(100, 23);
            txtEdicion.TabIndex = 18;
            // 
            // lblLibroSel
            // 
            lblLibroSel.AutoSize = true;
            lblLibroSel.Font = new Font("Segoe UI", 12F);
            lblLibroSel.Location = new Point(12, 362);
            lblLibroSel.Name = "lblLibroSel";
            lblLibroSel.Size = new Size(142, 21);
            lblLibroSel.TabIndex = 19;
            lblLibroSel.Text = "Libro seleccionado:";
            // 
            // btnSeleccionarCliente
            // 
            btnSeleccionarCliente.Font = new Font("Segoe UI", 14F);
            btnSeleccionarCliente.Location = new Point(645, 225);
            btnSeleccionarCliente.Name = "btnSeleccionarCliente";
            btnSeleccionarCliente.Size = new Size(179, 62);
            btnSeleccionarCliente.TabIndex = 20;
            btnSeleccionarCliente.Text = "Seleccionar cliente";
            btnSeleccionarCliente.UseVisualStyleBackColor = true;
            btnSeleccionarCliente.Click += btnSeleccionarCliente_Click;
            // 
            // FormRegistrarPrestamo_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 463);
            Controls.Add(btnSeleccionarCliente);
            Controls.Add(lblLibroSel);
            Controls.Add(txtEdicion);
            Controls.Add(txtEditorial);
            Controls.Add(txtAutor);
            Controls.Add(txtTitulo);
            Controls.Add(lblEdicion);
            Controls.Add(lblEditorial);
            Controls.Add(lblAutor);
            Controls.Add(lblTituloLibro);
            Controls.Add(btnRegistrarPrestamo);
            Controls.Add(btnRegistrarCliente);
            Controls.Add(btnSeleccionarLibro);
            Controls.Add(lblClientes);
            Controls.Add(dgvClientes);
            Controls.Add(lblTituloForm);
            Name = "FormRegistrarPrestamo_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegistrarPrestamo";
            FormClosed += FormRegistrarPrestamo_327LG_FormClosed;
            Load += FormRegistrarPrestamo_327LG_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloForm;
        private DataGridView dgvClientes;
        private Label lblClientes;
        private Button btnSeleccionarLibro;
        private Button btnRegistrarCliente;
        private Button btnRegistrarPrestamo;
        private Label lblTituloLibro;
        private Label lblAutor;
        private Label lblEditorial;
        private Label lblEdicion;
        private TextBox txtTitulo;
        private TextBox txtAutor;
        private TextBox txtEditorial;
        private TextBox txtEdicion;
        private Label lblLibroSel;
        private Button btnSeleccionarCliente;
    }
}