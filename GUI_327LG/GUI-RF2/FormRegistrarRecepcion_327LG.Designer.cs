namespace GUI_327LG.GUI_RF2
{
    partial class FormRegistrarRecepcion_327LG
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
            lblTitulo = new Label();
            lblListaOrdenes = new Label();
            lblLibros = new Label();
            dgvOrdenesCompra = new DataGridView();
            dgvLibros = new DataGridView();
            ISBN = new DataGridViewTextBoxColumn();
            Titulo = new DataGridViewTextBoxColumn();
            CantPedida = new DataGridViewTextBoxColumn();
            CantRecibida = new DataGridViewTextBoxColumn();
            CantIngresar = new DataGridViewTextBoxColumn();
            btnSeleccionar = new Button();
            btnCancelar = new Button();
            txtCantRecibida = new TextBox();
            lblCant = new Label();
            btnActualizar = new Button();
            btnRegistrar = new Button();
            rdoTodas = new RadioButton();
            rdoPendientes = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenesCompra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F);
            lblTitulo.Location = new Point(491, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(217, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar recepcion";
            // 
            // lblListaOrdenes
            // 
            lblListaOrdenes.AutoSize = true;
            lblListaOrdenes.Font = new Font("Segoe UI", 14F);
            lblListaOrdenes.Location = new Point(12, 87);
            lblListaOrdenes.Name = "lblListaOrdenes";
            lblListaOrdenes.Size = new Size(187, 25);
            lblListaOrdenes.TabIndex = 1;
            lblListaOrdenes.Text = "Ordenes de compra: ";
            // 
            // lblLibros
            // 
            lblLibros.AutoSize = true;
            lblLibros.Font = new Font("Segoe UI", 14F);
            lblLibros.Location = new Point(609, 87);
            lblLibros.Name = "lblLibros";
            lblLibros.Size = new Size(168, 25);
            lblLibros.TabIndex = 2;
            lblLibros.Text = "Libros de la orden:";
            // 
            // dgvOrdenesCompra
            // 
            dgvOrdenesCompra.AllowUserToAddRows = false;
            dgvOrdenesCompra.AllowUserToDeleteRows = false;
            dgvOrdenesCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrdenesCompra.Location = new Point(12, 115);
            dgvOrdenesCompra.Name = "dgvOrdenesCompra";
            dgvOrdenesCompra.ReadOnly = true;
            dgvOrdenesCompra.Size = new Size(556, 199);
            dgvOrdenesCompra.TabIndex = 3;
            dgvOrdenesCompra.DataBindingComplete += dgvOrdenesCompra_DataBindingComplete;
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AllowUserToDeleteRows = false;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Columns.AddRange(new DataGridViewColumn[] { ISBN, Titulo, CantPedida, CantRecibida, CantIngresar });
            dgvLibros.Location = new Point(609, 115);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.Size = new Size(563, 199);
            dgvLibros.TabIndex = 4;
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
            // CantPedida
            // 
            CantPedida.HeaderText = "Cant. Pedida";
            CantPedida.Name = "CantPedida";
            CantPedida.ReadOnly = true;
            // 
            // CantRecibida
            // 
            CantRecibida.HeaderText = "Cant. Recibida";
            CantRecibida.Name = "CantRecibida";
            CantRecibida.ReadOnly = true;
            // 
            // CantIngresar
            // 
            CantIngresar.HeaderText = "Cant. a ingresar";
            CantIngresar.Name = "CantIngresar";
            CantIngresar.ReadOnly = true;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(12, 328);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(94, 32);
            btnSeleccionar.TabIndex = 5;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(123, 328);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 32);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtCantRecibida
            // 
            txtCantRecibida.Location = new Point(609, 337);
            txtCantRecibida.Name = "txtCantRecibida";
            txtCantRecibida.Size = new Size(120, 23);
            txtCantRecibida.TabIndex = 7;
            // 
            // lblCant
            // 
            lblCant.AutoSize = true;
            lblCant.Location = new Point(609, 319);
            lblCant.Name = "lblCant";
            lblCant.Size = new Size(109, 15);
            lblCant.TabIndex = 9;
            lblCant.Text = "Cantidad a ingresar";
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(756, 333);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(92, 29);
            btnActualizar.TabIndex = 10;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Font = new Font("Segoe UI", 11F);
            btnRegistrar.Location = new Point(522, 422);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(134, 56);
            btnRegistrar.TabIndex = 11;
            btnRegistrar.Text = "Registrar recepción";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // rdoTodas
            // 
            rdoTodas.AutoSize = true;
            rdoTodas.Checked = true;
            rdoTodas.Location = new Point(423, 90);
            rdoTodas.Name = "rdoTodas";
            rdoTodas.Size = new Size(56, 19);
            rdoTodas.TabIndex = 12;
            rdoTodas.TabStop = true;
            rdoTodas.Text = "Todas";
            rdoTodas.UseVisualStyleBackColor = true;
            rdoTodas.CheckedChanged += rdoTodas_CheckedChanged;
            // 
            // rdoPendientes
            // 
            rdoPendientes.AutoSize = true;
            rdoPendientes.Location = new Point(485, 90);
            rdoPendientes.Name = "rdoPendientes";
            rdoPendientes.Size = new Size(83, 19);
            rdoPendientes.TabIndex = 13;
            rdoPendientes.Text = "Pendientes";
            rdoPendientes.UseVisualStyleBackColor = true;
            // 
            // FormRegistrarRecepcion_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 490);
            Controls.Add(rdoPendientes);
            Controls.Add(rdoTodas);
            Controls.Add(btnRegistrar);
            Controls.Add(btnActualizar);
            Controls.Add(lblCant);
            Controls.Add(txtCantRecibida);
            Controls.Add(btnCancelar);
            Controls.Add(btnSeleccionar);
            Controls.Add(dgvLibros);
            Controls.Add(dgvOrdenesCompra);
            Controls.Add(lblLibros);
            Controls.Add(lblListaOrdenes);
            Controls.Add(lblTitulo);
            Name = "FormRegistrarRecepcion_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegistrarRecepcion_327LG";
            FormClosed += FormRegistrarRecepcion_327LG_FormClosed;
            Load += FormRegistrarRecepcion_327LG_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrdenesCompra).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblListaOrdenes;
        private Label lblLibros;
        private DataGridView dgvOrdenesCompra;
        private DataGridView dgvLibros;
        private Button btnSeleccionar;
        private Button btnCancelar;
        private TextBox txtCantRecibida;
        private Label lblCant;
        private Button btnActualizar;
        private Button btnRegistrar;
        private DataGridViewTextBoxColumn ISBN;
        private DataGridViewTextBoxColumn Titulo;
        private DataGridViewTextBoxColumn CantPedida;
        private DataGridViewTextBoxColumn CantRecibida;
        private DataGridViewTextBoxColumn CantIngresar;
        private RadioButton rdoTodas;
        private RadioButton rdoPendientes;
    }
}