namespace GUI_327LG.GUIRF1
{
    partial class FormSeleccionarLibro_327LG
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
            dgvLibro = new DataGridView();
            lblLibros = new Label();
            lblTitulo = new Label();
            lblAutor = new Label();
            lblEditorial = new Label();
            lblEdicion = new Label();
            txtTitulo = new TextBox();
            txtAutor = new TextBox();
            txtEditorial = new TextBox();
            txtEdicion = new TextBox();
            lblLibroSel = new Label();
            lblDisponibles = new Label();
            lblDañados = new Label();
            lblDesaparecidos = new Label();
            lblPrestados = new Label();
            txtDisponibles = new TextBox();
            txtDañados = new TextBox();
            txtDesaparecidos = new TextBox();
            txtPrestados = new TextBox();
            btnTomarPrestado = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLibro).BeginInit();
            SuspendLayout();
            // 
            // dgvLibro
            // 
            dgvLibro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibro.Location = new Point(12, 42);
            dgvLibro.Name = "dgvLibro";
            dgvLibro.Size = new Size(421, 213);
            dgvLibro.TabIndex = 0;
            // 
            // lblLibros
            // 
            lblLibros.AutoSize = true;
            lblLibros.Font = new Font("Segoe UI", 16F);
            lblLibros.Location = new Point(12, 9);
            lblLibros.Name = "lblLibros";
            lblLibros.Size = new Size(191, 30);
            lblLibros.TabIndex = 1;
            lblLibros.Text = "Libros disponibles:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(12, 289);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(37, 15);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Título";
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.Location = new Point(121, 289);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(37, 15);
            lblAutor.TabIndex = 3;
            lblAutor.Text = "Autor";
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(227, 289);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(50, 15);
            lblEditorial.TabIndex = 4;
            lblEditorial.Text = "Editorial";
            // 
            // lblEdicion
            // 
            lblEdicion.AutoSize = true;
            lblEdicion.Location = new Point(333, 289);
            lblEdicion.Name = "lblEdicion";
            lblEdicion.Size = new Size(46, 15);
            lblEdicion.TabIndex = 5;
            lblEdicion.Text = "Edición";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(12, 307);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(100, 23);
            txtTitulo.TabIndex = 6;
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(121, 307);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(100, 23);
            txtAutor.TabIndex = 7;
            // 
            // txtEditorial
            // 
            txtEditorial.Location = new Point(227, 307);
            txtEditorial.Name = "txtEditorial";
            txtEditorial.Size = new Size(100, 23);
            txtEditorial.TabIndex = 8;
            // 
            // txtEdicion
            // 
            txtEdicion.Location = new Point(333, 307);
            txtEdicion.Name = "txtEdicion";
            txtEdicion.Size = new Size(100, 23);
            txtEdicion.TabIndex = 9;
            // 
            // lblLibroSel
            // 
            lblLibroSel.AutoSize = true;
            lblLibroSel.Font = new Font("Segoe UI", 16F);
            lblLibroSel.Location = new Point(531, 9);
            lblLibroSel.Name = "lblLibroSel";
            lblLibroSel.Size = new Size(198, 30);
            lblLibroSel.TabIndex = 10;
            lblLibroSel.Text = "Libro seleccionado:";
            // 
            // lblDisponibles
            // 
            lblDisponibles.AutoSize = true;
            lblDisponibles.Location = new Point(532, 68);
            lblDisponibles.Name = "lblDisponibles";
            lblDisponibles.Size = new Size(68, 15);
            lblDisponibles.TabIndex = 11;
            lblDisponibles.Text = "Disponibles";
            // 
            // lblDañados
            // 
            lblDañados.AutoSize = true;
            lblDañados.Location = new Point(547, 97);
            lblDañados.Name = "lblDañados";
            lblDañados.Size = new Size(53, 15);
            lblDañados.TabIndex = 12;
            lblDañados.Text = "Dañados";
            // 
            // lblDesaparecidos
            // 
            lblDesaparecidos.AutoSize = true;
            lblDesaparecidos.Location = new Point(517, 126);
            lblDesaparecidos.Name = "lblDesaparecidos";
            lblDesaparecidos.Size = new Size(83, 15);
            lblDesaparecidos.TabIndex = 13;
            lblDesaparecidos.Text = "Desaparecidos";
            // 
            // lblPrestados
            // 
            lblPrestados.AutoSize = true;
            lblPrestados.Location = new Point(542, 155);
            lblPrestados.Name = "lblPrestados";
            lblPrestados.Size = new Size(58, 15);
            lblPrestados.TabIndex = 14;
            lblPrestados.Text = "Prestados";
            // 
            // txtDisponibles
            // 
            txtDisponibles.Location = new Point(606, 65);
            txtDisponibles.Name = "txtDisponibles";
            txtDisponibles.Size = new Size(100, 23);
            txtDisponibles.TabIndex = 15;
            // 
            // txtDañados
            // 
            txtDañados.Location = new Point(606, 94);
            txtDañados.Name = "txtDañados";
            txtDañados.Size = new Size(100, 23);
            txtDañados.TabIndex = 16;
            // 
            // txtDesaparecidos
            // 
            txtDesaparecidos.Location = new Point(606, 123);
            txtDesaparecidos.Name = "txtDesaparecidos";
            txtDesaparecidos.Size = new Size(100, 23);
            txtDesaparecidos.TabIndex = 17;
            // 
            // txtPrestados
            // 
            txtPrestados.Location = new Point(606, 152);
            txtPrestados.Name = "txtPrestados";
            txtPrestados.Size = new Size(100, 23);
            txtPrestados.TabIndex = 18;
            // 
            // btnTomarPrestado
            // 
            btnTomarPrestado.Font = new Font("Segoe UI", 14F);
            btnTomarPrestado.Location = new Point(585, 261);
            btnTomarPrestado.Name = "btnTomarPrestado";
            btnTomarPrestado.Size = new Size(121, 65);
            btnTomarPrestado.TabIndex = 19;
            btnTomarPrestado.Text = "Tomar Prestado";
            btnTomarPrestado.UseVisualStyleBackColor = true;
            // 
            // FormSeleccionarLibro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 385);
            Controls.Add(btnTomarPrestado);
            Controls.Add(txtPrestados);
            Controls.Add(txtDesaparecidos);
            Controls.Add(txtDañados);
            Controls.Add(txtDisponibles);
            Controls.Add(lblPrestados);
            Controls.Add(lblDesaparecidos);
            Controls.Add(lblDañados);
            Controls.Add(lblDisponibles);
            Controls.Add(lblLibroSel);
            Controls.Add(txtEdicion);
            Controls.Add(txtEditorial);
            Controls.Add(txtAutor);
            Controls.Add(txtTitulo);
            Controls.Add(lblEdicion);
            Controls.Add(lblEditorial);
            Controls.Add(lblAutor);
            Controls.Add(lblTitulo);
            Controls.Add(lblLibros);
            Controls.Add(dgvLibro);
            Name = "FormSeleccionarLibro";
            Text = "Seleccionar libro";
            ((System.ComponentModel.ISupportInitialize)dgvLibro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLibro;
        private Label lblLibros;
        private Label lblTitulo;
        private Label lblAutor;
        private Label lblEditorial;
        private Label lblEdicion;
        private TextBox txtTitulo;
        private TextBox txtAutor;
        private TextBox txtEditorial;
        private TextBox txtEdicion;
        private Label lblLibroSel;
        private Label lblDisponibles;
        private Label lblDañados;
        private Label lblDesaparecidos;
        private Label lblPrestados;
        private TextBox txtDisponibles;
        private TextBox txtDañados;
        private TextBox txtDesaparecidos;
        private TextBox txtPrestados;
        private Button btnTomarPrestado;
    }
}