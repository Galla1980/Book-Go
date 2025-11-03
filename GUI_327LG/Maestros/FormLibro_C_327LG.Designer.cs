namespace GUI_327LG
{
    partial class FormLibro_C_327LG
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
            dgvLibro_C = new DataGridView();
            lblTitulo = new Label();
            lblISBN = new Label();
            lblFechaInicio = new Label();
            lblFechaFin = new Label();
            lblTituloLibro = new Label();
            txtTitulo = new TextBox();
            txtISBN = new TextBox();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            lblAutor = new Label();
            txtAutor = new TextBox();
            txtEdicion = new TextBox();
            txtEditorial = new TextBox();
            lblEdicion = new Label();
            lblEditorial = new Label();
            btnFiltrar = new Button();
            btnLimpiar = new Button();
            btnActivar = new Button();
            chkFecha = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvLibro_C).BeginInit();
            SuspendLayout();
            // 
            // dgvLibro_C
            // 
            dgvLibro_C.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibro_C.Location = new Point(12, 83);
            dgvLibro_C.Name = "dgvLibro_C";
            dgvLibro_C.Size = new Size(963, 246);
            dgvLibro_C.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(408, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(208, 30);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Bitacora de cambios";
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(12, 338);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(32, 15);
            lblISBN.TabIndex = 2;
            lblISBN.Text = "ISBN";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(12, 396);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(70, 15);
            lblFechaInicio.TabIndex = 3;
            lblFechaInicio.Text = "Fecha inicio";
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(118, 396);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(55, 15);
            lblFechaFin.TabIndex = 4;
            lblFechaFin.Text = "Fecha fin";
            // 
            // lblTituloLibro
            // 
            lblTituloLibro.AutoSize = true;
            lblTituloLibro.Location = new Point(118, 338);
            lblTituloLibro.Name = "lblTituloLibro";
            lblTituloLibro.Size = new Size(38, 15);
            lblTituloLibro.TabIndex = 5;
            lblTituloLibro.Text = "Titulo";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(118, 356);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(100, 23);
            txtTitulo.TabIndex = 6;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(12, 356);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(100, 23);
            txtISBN.TabIndex = 7;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Enabled = false;
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(12, 414);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(100, 23);
            dtpFechaInicio.TabIndex = 8;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Enabled = false;
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(118, 414);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(100, 23);
            dtpFechaFin.TabIndex = 9;
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.Location = new Point(234, 338);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(37, 15);
            lblAutor.TabIndex = 10;
            lblAutor.Text = "Autor";
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(234, 356);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(100, 23);
            txtAutor.TabIndex = 11;
            // 
            // txtEdicion
            // 
            txtEdicion.Location = new Point(453, 356);
            txtEdicion.Name = "txtEdicion";
            txtEdicion.Size = new Size(100, 23);
            txtEdicion.TabIndex = 15;
            // 
            // txtEditorial
            // 
            txtEditorial.Location = new Point(347, 356);
            txtEditorial.Name = "txtEditorial";
            txtEditorial.Size = new Size(100, 23);
            txtEditorial.TabIndex = 14;
            // 
            // lblEdicion
            // 
            lblEdicion.AutoSize = true;
            lblEdicion.Location = new Point(453, 338);
            lblEdicion.Name = "lblEdicion";
            lblEdicion.Size = new Size(46, 15);
            lblEdicion.TabIndex = 13;
            lblEdicion.Text = "Edición";
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(347, 338);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(50, 15);
            lblEditorial.TabIndex = 12;
            lblEditorial.Text = "Editorial";
            // 
            // btnFiltrar
            // 
            btnFiltrar.Font = new Font("Segoe UI", 12F);
            btnFiltrar.Location = new Point(617, 345);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(102, 34);
            btnFiltrar.TabIndex = 16;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Segoe UI", 12F);
            btnLimpiar.Location = new Point(747, 345);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(102, 34);
            btnLimpiar.TabIndex = 17;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnActivar
            // 
            btnActivar.Font = new Font("Segoe UI", 12F);
            btnActivar.Location = new Point(873, 345);
            btnActivar.Name = "btnActivar";
            btnActivar.Size = new Size(102, 34);
            btnActivar.TabIndex = 18;
            btnActivar.Text = "Activar";
            btnActivar.UseVisualStyleBackColor = true;
            btnActivar.Click += btnActivar_Click;
            // 
            // chkFecha
            // 
            chkFecha.AutoSize = true;
            chkFecha.Location = new Point(224, 414);
            chkFecha.Name = "chkFecha";
            chkFecha.Size = new Size(88, 19);
            chkFecha.TabIndex = 19;
            chkFecha.Text = "Filtrar fecha";
            chkFecha.UseVisualStyleBackColor = true;
            chkFecha.CheckedChanged += chkFecha_CheckedChanged;
            // 
            // FormLibro_C_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 449);
            Controls.Add(chkFecha);
            Controls.Add(btnActivar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnFiltrar);
            Controls.Add(txtEdicion);
            Controls.Add(txtEditorial);
            Controls.Add(lblEdicion);
            Controls.Add(lblEditorial);
            Controls.Add(txtAutor);
            Controls.Add(lblAutor);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(txtISBN);
            Controls.Add(txtTitulo);
            Controls.Add(lblTituloLibro);
            Controls.Add(lblFechaFin);
            Controls.Add(lblFechaInicio);
            Controls.Add(lblISBN);
            Controls.Add(lblTitulo);
            Controls.Add(dgvLibro_C);
            Name = "FormLibro_C_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormLibro_C_327LG";
            FormClosed += FormLibro_C_327LG_FormClosed;
            Load += FormLibro_C_327LG_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLibro_C).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLibro_C;
        private Label lblTitulo;
        private Label lblISBN;
        private Label lblFechaInicio;
        private Label lblFechaFin;
        private Label lblTituloLibro;
        private TextBox txtTitulo;
        private TextBox txtISBN;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Label lblAutor;
        private TextBox txtAutor;
        private TextBox txtEdicion;
        private TextBox txtEditorial;
        private Label lblEdicion;
        private Label lblEditorial;
        private Button btnFiltrar;
        private Button btnLimpiar;
        private Button btnActivar;
        private CheckBox chkFecha;
    }
}