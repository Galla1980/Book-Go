namespace GUI_327LG.GUI_RF2
{
    partial class FormGenerarOrdenCompra_327LG
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
            dgvSolicitudes = new DataGridView();
            dgvLibros = new DataGridView();
            ISBN = new DataGridViewTextBoxColumn();
            Titulo = new DataGridViewTextBoxColumn();
            Autor = new DataGridViewTextBoxColumn();
            Edicion = new DataGridViewTextBoxColumn();
            Editorial = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            PrecioUnit = new DataGridViewTextBoxColumn();
            Subtotal = new DataGridViewTextBoxColumn();
            lblSolicitudes = new Label();
            lblLibros = new Label();
            lblTitulo = new Label();
            lblCantidad = new Label();
            lblPrecioUnit = new Label();
            txtCantidad = new TextBox();
            txtPrecioUnit = new TextBox();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnGenerarOrden = new Button();
            btnSeleccionar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            // 
            // dgvSolicitudes
            // 
            dgvSolicitudes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSolicitudes.Location = new Point(12, 117);
            dgvSolicitudes.Name = "dgvSolicitudes";
            dgvSolicitudes.Size = new Size(496, 150);
            dgvSolicitudes.TabIndex = 0;
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AllowUserToDeleteRows = false;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Columns.AddRange(new DataGridViewColumn[] { ISBN, Titulo, Autor, Edicion, Editorial, Cantidad, PrecioUnit, Subtotal });
            dgvLibros.Location = new Point(527, 117);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.Size = new Size(790, 150);
            dgvLibros.TabIndex = 1;
            dgvLibros.SelectionChanged += dgvLibros_SelectionChanged;
            // 
            // ISBN
            // 
            ISBN.HeaderText = "ISBN";
            ISBN.Name = "ISBN";
            ISBN.ReadOnly = true;
            // 
            // Titulo
            // 
            Titulo.HeaderText = "Titulo";
            Titulo.Name = "Titulo";
            Titulo.ReadOnly = true;
            // 
            // Autor
            // 
            Autor.HeaderText = "Autor";
            Autor.Name = "Autor";
            Autor.ReadOnly = true;
            // 
            // Edicion
            // 
            Edicion.HeaderText = "Edicion";
            Edicion.Name = "Edicion";
            Edicion.ReadOnly = true;
            // 
            // Editorial
            // 
            Editorial.HeaderText = "Editorial";
            Editorial.Name = "Editorial";
            Editorial.ReadOnly = true;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            // 
            // PrecioUnit
            // 
            PrecioUnit.HeaderText = "Precio Unit.";
            PrecioUnit.Name = "PrecioUnit";
            PrecioUnit.ReadOnly = true;
            // 
            // Subtotal
            // 
            Subtotal.HeaderText = "Subtotal";
            Subtotal.Name = "Subtotal";
            Subtotal.ReadOnly = true;
            // 
            // lblSolicitudes
            // 
            lblSolicitudes.AutoSize = true;
            lblSolicitudes.Font = new Font("Segoe UI", 16F);
            lblSolicitudes.Location = new Point(12, 75);
            lblSolicitudes.Name = "lblSolicitudes";
            lblSolicitudes.Size = new Size(197, 30);
            lblSolicitudes.TabIndex = 2;
            lblSolicitudes.Text = "Lista de solicitudes:";
            // 
            // lblLibros
            // 
            lblLibros.AutoSize = true;
            lblLibros.Font = new Font("Segoe UI", 16F);
            lblLibros.Location = new Point(527, 75);
            lblLibros.Name = "lblLibros";
            lblLibros.Size = new Size(214, 30);
            lblLibros.TabIndex = 3;
            lblLibros.Text = "Libros de la solicitud:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F);
            lblTitulo.Location = new Point(527, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(289, 32);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "Generar orden de compra";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(674, 292);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(55, 15);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "Cantidad";
            // 
            // lblPrecioUnit
            // 
            lblPrecioUnit.AutoSize = true;
            lblPrecioUnit.Location = new Point(799, 292);
            lblPrecioUnit.Name = "lblPrecioUnit";
            lblPrecioUnit.Size = new Size(84, 15);
            lblPrecioUnit.TabIndex = 6;
            lblPrecioUnit.Text = "Precio unitario";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(674, 310);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(100, 23);
            txtCantidad.TabIndex = 7;
            // 
            // txtPrecioUnit
            // 
            txtPrecioUnit.Location = new Point(799, 310);
            txtPrecioUnit.Name = "txtPrecioUnit";
            txtPrecioUnit.Size = new Size(100, 23);
            txtPrecioUnit.TabIndex = 8;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(1084, 294);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(117, 39);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(938, 294);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(117, 43);
            btnActualizar.TabIndex = 10;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnGenerarOrden
            // 
            btnGenerarOrden.Font = new Font("Segoe UI", 11F);
            btnGenerarOrden.Location = new Point(603, 394);
            btnGenerarOrden.Name = "btnGenerarOrden";
            btnGenerarOrden.Size = new Size(126, 45);
            btnGenerarOrden.TabIndex = 11;
            btnGenerarOrden.Text = "Generar orden";
            btnGenerarOrden.UseVisualStyleBackColor = true;
            btnGenerarOrden.Click += btnGenerarOrden_Click;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(12, 298);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(117, 42);
            btnSeleccionar.TabIndex = 12;
            btnSeleccionar.Text = "Seleccionar solicitud";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(154, 298);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(117, 42);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormGenerarOrdenCompra_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1329, 460);
            Controls.Add(btnCancelar);
            Controls.Add(btnSeleccionar);
            Controls.Add(btnGenerarOrden);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(txtPrecioUnit);
            Controls.Add(txtCantidad);
            Controls.Add(lblPrecioUnit);
            Controls.Add(lblCantidad);
            Controls.Add(lblTitulo);
            Controls.Add(lblLibros);
            Controls.Add(lblSolicitudes);
            Controls.Add(dgvLibros);
            Controls.Add(dgvSolicitudes);
            Name = "FormGenerarOrdenCompra_327LG";
            Text = "FormGenerarOrdenCompra_327LG";
            FormClosed += FormGenerarOrdenCompra_327LG_FormClosed;
            Load += FormGenerarOrdenCompra_327LG_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSolicitudes;
        private DataGridView dgvLibros;
        private Label lblSolicitudes;
        private Label lblLibros;
        private Label lblTitulo;
        private Label lblCantidad;
        private Label lblPrecioUnit;
        private TextBox txtCantidad;
        private TextBox txtPrecioUnit;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnGenerarOrden;
        private DataGridViewTextBoxColumn ISBN;
        private DataGridViewTextBoxColumn Titulo;
        private DataGridViewTextBoxColumn Autor;
        private DataGridViewTextBoxColumn Edicion;
        private DataGridViewTextBoxColumn Editorial;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn PrecioUnit;
        private DataGridViewTextBoxColumn Subtotal;
        private Button btnSeleccionar;
        private Button btnCancelar;
    }
}