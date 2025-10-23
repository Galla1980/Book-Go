namespace GUI_327LG.GUI_RF2
{
    partial class FormRegistrarDistribuidor_327LG
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
            dgvDistribuidores = new DataGridView();
            lblTitulo = new Label();
            txtCuit = new TextBox();
            txtEmpresa = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            txtCorreo = new TextBox();
            btnRegistrar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            lblCuit = new Label();
            lblEmpresa = new Label();
            lblTelefono = new Label();
            lblDireccion = new Label();
            lblCorreo = new Label();
            btnAplicar = new Button();
            btnCancelar = new Button();
            lblModo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDistribuidores).BeginInit();
            SuspendLayout();
            // 
            // dgvDistribuidores
            // 
            dgvDistribuidores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDistribuidores.Location = new Point(12, 79);
            dgvDistribuidores.Name = "dgvDistribuidores";
            dgvDistribuidores.Size = new Size(736, 306);
            dgvDistribuidores.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(12, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(215, 30);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Registrar distribuidor";
            // 
            // txtCuit
            // 
            txtCuit.Location = new Point(781, 97);
            txtCuit.Name = "txtCuit";
            txtCuit.Size = new Size(100, 23);
            txtCuit.TabIndex = 2;
            // 
            // txtEmpresa
            // 
            txtEmpresa.Location = new Point(781, 149);
            txtEmpresa.Name = "txtEmpresa";
            txtEmpresa.Size = new Size(100, 23);
            txtEmpresa.TabIndex = 3;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(781, 201);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 4;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(781, 258);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(100, 23);
            txtDireccion.TabIndex = 5;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(781, 315);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(100, 23);
            txtCorreo.TabIndex = 6;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Font = new Font("Segoe UI", 12F);
            btnRegistrar.Location = new Point(970, 79);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(92, 35);
            btnRegistrar.TabIndex = 7;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Segoe UI", 12F);
            btnModificar.Location = new Point(970, 135);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(92, 35);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 12F);
            btnEliminar.Location = new Point(970, 191);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(92, 35);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Location = new Point(781, 79);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(33, 15);
            lblCuit.TabIndex = 10;
            lblCuit.Text = "CUIT";
            // 
            // lblEmpresa
            // 
            lblEmpresa.AutoSize = true;
            lblEmpresa.Location = new Point(781, 131);
            lblEmpresa.Name = "lblEmpresa";
            lblEmpresa.Size = new Size(52, 15);
            lblEmpresa.TabIndex = 11;
            lblEmpresa.Text = "Empresa";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(781, 183);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(53, 15);
            lblTelefono.TabIndex = 12;
            lblTelefono.Text = "Telefono";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(781, 240);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(57, 15);
            lblDireccion.TabIndex = 13;
            lblDireccion.Text = "Direccion";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(781, 297);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(43, 15);
            lblCorreo.TabIndex = 14;
            lblCorreo.Text = "Correo";
            // 
            // btnAplicar
            // 
            btnAplicar.Font = new Font("Segoe UI", 12F);
            btnAplicar.Location = new Point(970, 249);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(92, 35);
            btnAplicar.TabIndex = 15;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = true;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.Location = new Point(970, 305);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(92, 33);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblModo
            // 
            lblModo.AutoSize = true;
            lblModo.Location = new Point(781, 370);
            lblModo.Name = "lblModo";
            lblModo.Size = new Size(92, 15);
            lblModo.TabIndex = 17;
            lblModo.Text = "Modo: Consulta";
            // 
            // FormRegistrarDistribuidor_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 586);
            Controls.Add(lblModo);
            Controls.Add(btnCancelar);
            Controls.Add(btnAplicar);
            Controls.Add(lblCorreo);
            Controls.Add(lblDireccion);
            Controls.Add(lblTelefono);
            Controls.Add(lblEmpresa);
            Controls.Add(lblCuit);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnRegistrar);
            Controls.Add(txtCorreo);
            Controls.Add(txtDireccion);
            Controls.Add(txtTelefono);
            Controls.Add(txtEmpresa);
            Controls.Add(txtCuit);
            Controls.Add(lblTitulo);
            Controls.Add(dgvDistribuidores);
            Name = "FormRegistrarDistribuidor_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegistrarDistribuidor_327LG";
            FormClosing += FormRegistrarDistribuidor_327LG_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvDistribuidores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDistribuidores;
        private Label lblTitulo;
        private TextBox txtCuit;
        private TextBox txtEmpresa;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private TextBox txtCorreo;
        private Button btnRegistrar;
        private Button btnModificar;
        private Button btnEliminar;
        private Label lblCuit;
        private Label lblEmpresa;
        private Label lblTelefono;
        private Label lblDireccion;
        private Label lblCorreo;
        private Button btnAplicar;
        private Button btnCancelar;
        private Label lblModo;
    }
}