namespace GUI_327LG.Maestros
{
    partial class FormLibroMaestro_327LG
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
            lblISBN = new Label();
            lblTitulo = new Label();
            lblAutor = new Label();
            lblEditorial = new Label();
            lblEdicion = new Label();
            txtISBN = new TextBox();
            txtTitulo = new TextBox();
            txtAutor = new TextBox();
            txtEditorial = new TextBox();
            txtEdicion = new TextBox();
            btnCargarLibro = new Button();
            dgvLibros = new DataGridView();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnAplicar = new Button();
            btnCancelar = new Button();
            btnRefrescar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Segoe UI", 20F);
            lblTituloForm.Location = new Point(393, 9);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(187, 37);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Maestro libros";
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(12, 261);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(32, 15);
            lblISBN.TabIndex = 1;
            lblISBN.Text = "ISBN";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(118, 261);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(38, 15);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Titulo";
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.Location = new Point(224, 261);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(37, 15);
            lblAutor.TabIndex = 3;
            lblAutor.Text = "Autor";
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(330, 261);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(50, 15);
            lblEditorial.TabIndex = 4;
            lblEditorial.Text = "Editorial";
            // 
            // lblEdicion
            // 
            lblEdicion.AutoSize = true;
            lblEdicion.Location = new Point(436, 261);
            lblEdicion.Name = "lblEdicion";
            lblEdicion.Size = new Size(46, 15);
            lblEdicion.TabIndex = 5;
            lblEdicion.Text = "Edición";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(12, 279);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(100, 23);
            txtISBN.TabIndex = 6;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(118, 279);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(100, 23);
            txtTitulo.TabIndex = 7;
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(224, 279);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(100, 23);
            txtAutor.TabIndex = 8;
            // 
            // txtEditorial
            // 
            txtEditorial.Location = new Point(330, 279);
            txtEditorial.Name = "txtEditorial";
            txtEditorial.Size = new Size(100, 23);
            txtEditorial.TabIndex = 9;
            // 
            // txtEdicion
            // 
            txtEdicion.Location = new Point(436, 279);
            txtEdicion.Name = "txtEdicion";
            txtEdicion.Size = new Size(100, 23);
            txtEdicion.TabIndex = 10;
            // 
            // btnCargarLibro
            // 
            btnCargarLibro.Font = new Font("Segoe UI", 15F);
            btnCargarLibro.Location = new Point(750, 71);
            btnCargarLibro.Name = "btnCargarLibro";
            btnCargarLibro.Size = new Size(152, 55);
            btnCargarLibro.TabIndex = 11;
            btnCargarLibro.Text = "Cargar libro";
            btnCargarLibro.UseVisualStyleBackColor = true;
            btnCargarLibro.Click += btnCargarLibro_Click;
            // 
            // dgvLibros
            // 
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(12, 71);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.Size = new Size(699, 172);
            dgvLibros.TabIndex = 12;
            dgvLibros.SelectionChanged += dgvLibros_SelectionChanged;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Segoe UI", 15F);
            btnModificar.Location = new Point(750, 132);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(152, 55);
            btnModificar.TabIndex = 13;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 15F);
            btnEliminar.Location = new Point(750, 193);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(152, 55);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAplicar
            // 
            btnAplicar.Font = new Font("Segoe UI", 15F);
            btnAplicar.Location = new Point(750, 252);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(152, 50);
            btnAplicar.TabIndex = 15;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = true;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 15F);
            btnCancelar.Location = new Point(750, 308);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(152, 50);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Font = new Font("Segoe UI", 15F);
            btnRefrescar.Location = new Point(559, 260);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(152, 50);
            btnRefrescar.TabIndex = 17;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // FormLibroMaestro_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 377);
            Controls.Add(btnRefrescar);
            Controls.Add(btnCancelar);
            Controls.Add(btnAplicar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(dgvLibros);
            Controls.Add(btnCargarLibro);
            Controls.Add(txtEdicion);
            Controls.Add(txtEditorial);
            Controls.Add(txtAutor);
            Controls.Add(txtTitulo);
            Controls.Add(txtISBN);
            Controls.Add(lblEdicion);
            Controls.Add(lblEditorial);
            Controls.Add(lblAutor);
            Controls.Add(lblTitulo);
            Controls.Add(lblISBN);
            Controls.Add(lblTituloForm);
            Name = "FormLibroMaestro_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormLibroMaestro_327LG";
            Load += FormLibroMaestro_327LG_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloForm;
        private Label lblISBN;
        private Label lblTitulo;
        private Label lblAutor;
        private Label lblEditorial;
        private Label lblEdicion;
        private TextBox txtISBN;
        private TextBox txtTitulo;
        private TextBox txtAutor;
        private TextBox txtEditorial;
        private TextBox txtEdicion;
        private Button btnCargarLibro;
        private DataGridView dgvLibros;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnAplicar;
        private Button btnCancelar;
        private Button btnRefrescar;
    }
}