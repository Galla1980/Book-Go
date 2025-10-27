namespace GUI_327LG.GUI_RF2
{
    partial class FormSolicitarCotizacion_327LG
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
            dgvLibros = new DataGridView();
            dgvDistribuidores = new DataGridView();
            lblEjemplares = new Label();
            lblDistribuidores = new Label();
            lblTituloForm = new Label();
            btnAgregarLibro = new Button();
            btnAgregarDistribuidor = new Button();
            lstLibros = new ListBox();
            lstDistribuidores = new ListBox();
            lblLibroSeleccionado = new Label();
            lblDistribuidorSeleccionado = new Label();
            btnGenerarSolicitud = new Button();
            btnQuitarDistribuidor = new Button();
            btnQuitarLibro = new Button();
            txtISBN = new TextBox();
            txtTitulo = new TextBox();
            txtAutor = new TextBox();
            txtEditorial = new TextBox();
            btnFiltrarLibros = new Button();
            lblISBN = new Label();
            lblTitulo = new Label();
            lblAutor = new Label();
            lblEditorial = new Label();
            lblEmpresa = new Label();
            lblCUIT = new Label();
            btnFiltrarDistribuidor = new Button();
            txtEmpresa = new TextBox();
            txtCUIT = new TextBox();
            lblEdicion = new Label();
            txtEdicion = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDistribuidores).BeginInit();
            SuspendLayout();
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AllowUserToDeleteRows = false;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(12, 102);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.Size = new Size(865, 216);
            dgvLibros.TabIndex = 0;
            dgvLibros.DataBindingComplete += dgvLibros_DataBindingComplete;
            // 
            // dgvDistribuidores
            // 
            dgvDistribuidores.AllowUserToAddRows = false;
            dgvDistribuidores.AllowUserToDeleteRows = false;
            dgvDistribuidores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDistribuidores.Location = new Point(12, 428);
            dgvDistribuidores.Name = "dgvDistribuidores";
            dgvDistribuidores.ReadOnly = true;
            dgvDistribuidores.Size = new Size(865, 216);
            dgvDistribuidores.TabIndex = 1;
            // 
            // lblEjemplares
            // 
            lblEjemplares.AutoSize = true;
            lblEjemplares.Font = new Font("Segoe UI", 14F);
            lblEjemplares.Location = new Point(12, 73);
            lblEjemplares.Name = "lblEjemplares";
            lblEjemplares.Size = new Size(207, 25);
            lblEjemplares.TabIndex = 2;
            lblEjemplares.Text = "Lista libros disponibles:";
            // 
            // lblDistribuidores
            // 
            lblDistribuidores.AutoSize = true;
            lblDistribuidores.Font = new Font("Segoe UI", 14F);
            lblDistribuidores.Location = new Point(12, 400);
            lblDistribuidores.Name = "lblDistribuidores";
            lblDistribuidores.Size = new Size(175, 25);
            lblDistribuidores.TabIndex = 3;
            lblDistribuidores.Text = "Lista distribuidores:";
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Segoe UI", 18F);
            lblTituloForm.Location = new Point(590, 19);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(212, 32);
            lblTituloForm.TabIndex = 4;
            lblTituloForm.Text = "Solicitar cotización";
            // 
            // btnAgregarLibro
            // 
            btnAgregarLibro.Font = new Font("Segoe UI", 10F);
            btnAgregarLibro.Location = new Point(898, 102);
            btnAgregarLibro.Name = "btnAgregarLibro";
            btnAgregarLibro.Size = new Size(187, 66);
            btnAgregarLibro.TabIndex = 5;
            btnAgregarLibro.Text = "Agregar libro a solicitud ------->";
            btnAgregarLibro.UseVisualStyleBackColor = true;
            btnAgregarLibro.Click += btnAgregarLibro_Click;
            // 
            // btnAgregarDistribuidor
            // 
            btnAgregarDistribuidor.Font = new Font("Segoe UI", 10F);
            btnAgregarDistribuidor.Location = new Point(898, 428);
            btnAgregarDistribuidor.Name = "btnAgregarDistribuidor";
            btnAgregarDistribuidor.Size = new Size(187, 68);
            btnAgregarDistribuidor.TabIndex = 6;
            btnAgregarDistribuidor.Text = "Agregar distribuidor a solicitud \r\n------->";
            btnAgregarDistribuidor.UseVisualStyleBackColor = true;
            btnAgregarDistribuidor.Click += btnAgregarDistribuidor_Click;
            // 
            // lstLibros
            // 
            lstLibros.FormattingEnabled = true;
            lstLibros.HorizontalScrollbar = true;
            lstLibros.ItemHeight = 15;
            lstLibros.Location = new Point(1106, 101);
            lstLibros.Name = "lstLibros";
            lstLibros.Size = new Size(379, 214);
            lstLibros.TabIndex = 7;
            // 
            // lstDistribuidores
            // 
            lstDistribuidores.FormattingEnabled = true;
            lstDistribuidores.HorizontalScrollbar = true;
            lstDistribuidores.ItemHeight = 15;
            lstDistribuidores.Location = new Point(1106, 428);
            lstDistribuidores.Name = "lstDistribuidores";
            lstDistribuidores.Size = new Size(379, 214);
            lstDistribuidores.TabIndex = 8;
            // 
            // lblLibroSeleccionado
            // 
            lblLibroSeleccionado.AutoSize = true;
            lblLibroSeleccionado.Font = new Font("Segoe UI", 14F);
            lblLibroSeleccionado.Location = new Point(1106, 73);
            lblLibroSeleccionado.Name = "lblLibroSeleccionado";
            lblLibroSeleccionado.Size = new Size(190, 25);
            lblLibroSeleccionado.TabIndex = 9;
            lblLibroSeleccionado.Text = "Libros seleccionados:";
            // 
            // lblDistribuidorSeleccionado
            // 
            lblDistribuidorSeleccionado.AutoSize = true;
            lblDistribuidorSeleccionado.Font = new Font("Segoe UI", 14F);
            lblDistribuidorSeleccionado.Location = new Point(1102, 400);
            lblDistribuidorSeleccionado.Name = "lblDistribuidorSeleccionado";
            lblDistribuidorSeleccionado.Size = new Size(257, 25);
            lblDistribuidorSeleccionado.TabIndex = 10;
            lblDistribuidorSeleccionado.Text = "Distribuidores seleccionados:";
            // 
            // btnGenerarSolicitud
            // 
            btnGenerarSolicitud.Font = new Font("Segoe UI", 12F);
            btnGenerarSolicitud.Location = new Point(656, 712);
            btnGenerarSolicitud.Name = "btnGenerarSolicitud";
            btnGenerarSolicitud.Size = new Size(221, 55);
            btnGenerarSolicitud.TabIndex = 11;
            btnGenerarSolicitud.Text = "Generar solicitud";
            btnGenerarSolicitud.UseVisualStyleBackColor = true;
            btnGenerarSolicitud.Click += btnGenerarSolicitud_Click;
            // 
            // btnQuitarDistribuidor
            // 
            btnQuitarDistribuidor.Font = new Font("Segoe UI", 10F);
            btnQuitarDistribuidor.Location = new Point(898, 576);
            btnQuitarDistribuidor.Name = "btnQuitarDistribuidor";
            btnQuitarDistribuidor.Size = new Size(187, 68);
            btnQuitarDistribuidor.TabIndex = 12;
            btnQuitarDistribuidor.Text = "Quitar distribuidor de la solicitud\r\n<-------";
            btnQuitarDistribuidor.UseVisualStyleBackColor = true;
            btnQuitarDistribuidor.Click += btnQuitarDistribuidor_Click;
            // 
            // btnQuitarLibro
            // 
            btnQuitarLibro.Font = new Font("Segoe UI", 10F);
            btnQuitarLibro.Location = new Point(898, 248);
            btnQuitarLibro.Name = "btnQuitarLibro";
            btnQuitarLibro.Size = new Size(187, 68);
            btnQuitarLibro.TabIndex = 13;
            btnQuitarLibro.Text = "Quitar libro de la solicitud\r\n<-------";
            btnQuitarLibro.UseVisualStyleBackColor = true;
            btnQuitarLibro.Click += btnQuitarLibro_Click;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(12, 353);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(100, 23);
            txtISBN.TabIndex = 14;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(132, 354);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(100, 23);
            txtTitulo.TabIndex = 15;
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(248, 353);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(100, 23);
            txtAutor.TabIndex = 16;
            // 
            // txtEditorial
            // 
            txtEditorial.Location = new Point(363, 354);
            txtEditorial.Name = "txtEditorial";
            txtEditorial.Size = new Size(100, 23);
            txtEditorial.TabIndex = 17;
            // 
            // btnFiltrarLibros
            // 
            btnFiltrarLibros.Font = new Font("Segoe UI", 9F);
            btnFiltrarLibros.Location = new Point(590, 352);
            btnFiltrarLibros.Name = "btnFiltrarLibros";
            btnFiltrarLibros.Size = new Size(91, 23);
            btnFiltrarLibros.TabIndex = 18;
            btnFiltrarLibros.Text = "Filtrar";
            btnFiltrarLibros.UseVisualStyleBackColor = true;
            btnFiltrarLibros.Click += btnFiltrarLibros_Click;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(12, 335);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(32, 15);
            lblISBN.TabIndex = 19;
            lblISBN.Text = "ISBN";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(132, 336);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(38, 15);
            lblTitulo.TabIndex = 20;
            lblTitulo.Text = "Titulo";
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.Location = new Point(248, 336);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(37, 15);
            lblAutor.TabIndex = 21;
            lblAutor.Text = "Autor";
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(363, 336);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(50, 15);
            lblEditorial.TabIndex = 22;
            lblEditorial.Text = "Editorial";
            // 
            // lblEmpresa
            // 
            lblEmpresa.AutoSize = true;
            lblEmpresa.Location = new Point(132, 664);
            lblEmpresa.Name = "lblEmpresa";
            lblEmpresa.Size = new Size(52, 15);
            lblEmpresa.TabIndex = 29;
            lblEmpresa.Text = "Empresa";
            // 
            // lblCUIT
            // 
            lblCUIT.AutoSize = true;
            lblCUIT.Location = new Point(12, 663);
            lblCUIT.Name = "lblCUIT";
            lblCUIT.Size = new Size(33, 15);
            lblCUIT.TabIndex = 28;
            lblCUIT.Text = "CUIT";
            // 
            // btnFiltrarDistribuidor
            // 
            btnFiltrarDistribuidor.Font = new Font("Segoe UI", 9F);
            btnFiltrarDistribuidor.Location = new Point(238, 682);
            btnFiltrarDistribuidor.Name = "btnFiltrarDistribuidor";
            btnFiltrarDistribuidor.Size = new Size(91, 23);
            btnFiltrarDistribuidor.TabIndex = 27;
            btnFiltrarDistribuidor.Text = "Filtrar";
            btnFiltrarDistribuidor.UseVisualStyleBackColor = true;
            btnFiltrarDistribuidor.Click += btnFiltrarDistribuidor_Click;
            // 
            // txtEmpresa
            // 
            txtEmpresa.Location = new Point(132, 682);
            txtEmpresa.Name = "txtEmpresa";
            txtEmpresa.Size = new Size(100, 23);
            txtEmpresa.TabIndex = 24;
            // 
            // txtCUIT
            // 
            txtCUIT.Location = new Point(12, 681);
            txtCUIT.Name = "txtCUIT";
            txtCUIT.Size = new Size(100, 23);
            txtCUIT.TabIndex = 23;
            // 
            // lblEdicion
            // 
            lblEdicion.AutoSize = true;
            lblEdicion.Location = new Point(479, 336);
            lblEdicion.Name = "lblEdicion";
            lblEdicion.Size = new Size(50, 15);
            lblEdicion.TabIndex = 31;
            lblEdicion.Text = "Editorial";
            // 
            // txtEdicion
            // 
            txtEdicion.Location = new Point(479, 354);
            txtEdicion.Name = "txtEdicion";
            txtEdicion.Size = new Size(100, 23);
            txtEdicion.TabIndex = 30;
            // 
            // FormSolicitarCotizacion_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1497, 796);
            Controls.Add(lblEdicion);
            Controls.Add(txtEdicion);
            Controls.Add(lblEmpresa);
            Controls.Add(lblCUIT);
            Controls.Add(btnFiltrarDistribuidor);
            Controls.Add(txtEmpresa);
            Controls.Add(txtCUIT);
            Controls.Add(lblEditorial);
            Controls.Add(lblAutor);
            Controls.Add(lblTitulo);
            Controls.Add(lblISBN);
            Controls.Add(btnFiltrarLibros);
            Controls.Add(txtEditorial);
            Controls.Add(txtAutor);
            Controls.Add(txtTitulo);
            Controls.Add(txtISBN);
            Controls.Add(btnQuitarLibro);
            Controls.Add(btnQuitarDistribuidor);
            Controls.Add(btnGenerarSolicitud);
            Controls.Add(lblDistribuidorSeleccionado);
            Controls.Add(lblLibroSeleccionado);
            Controls.Add(lstDistribuidores);
            Controls.Add(lstLibros);
            Controls.Add(btnAgregarDistribuidor);
            Controls.Add(btnAgregarLibro);
            Controls.Add(lblTituloForm);
            Controls.Add(lblDistribuidores);
            Controls.Add(lblEjemplares);
            Controls.Add(dgvDistribuidores);
            Controls.Add(dgvLibros);
            Name = "FormSolicitarCotizacion_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSolicitarCotizacion_327LG";
            FormClosed += FormSolicitarCotizacion_327LG_FormClosed;
            Load += FormSolicitarCotizacion_327LG_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDistribuidores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLibros;
        private DataGridView dgvDistribuidores;
        private Label lblEjemplares;
        private Label lblDistribuidores;
        private Label lblTituloForm;
        private Button btnAgregarLibro;
        private Button btnAgregarDistribuidor;
        private ListBox lstLibros;
        private ListBox lstDistribuidores;
        private Label lblLibroSeleccionado;
        private Label lblDistribuidorSeleccionado;
        private Button btnGenerarSolicitud;
        private Button btnQuitarDistribuidor;
        private Button btnQuitarLibro;
        private TextBox txtISBN;
        private TextBox txtTitulo;
        private TextBox txtAutor;
        private TextBox txtEditorial;
        private Button btnFiltrarLibros;
        private Label lblISBN;
        private Label lblTitulo;
        private Label lblAutor;
        private Label lblEditorial;
        private Label label1;
        private Label label2;
        private Label lblEmpresa;
        private Label lblCUIT;
        private Button btnFiltrarDistribuidor;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox txtEmpresa;
        private TextBox txtCUIT;
        private Label lblEdicion;
        private TextBox txtEdicion;
    }
}