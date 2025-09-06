namespace GUI_327LG.GUIRF1
{
    partial class FormRegistrarCliente_327LG
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
            lblNombre = new Label();
            lblApellido = new Label();
            lblEmail = new Label();
            lblDNI = new Label();
            txtDNI = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtEmail = new TextBox();
            btnRegistrar = new Button();
            lblTitulo = new Label();
            btnCancelar = new Button();
            dgvClientes = new DataGridView();
            chkDesencriptar = new CheckBox();
            btnEliminar = new Button();
            btnModificar = new Button();
            lblModo = new Label();
            btnAplicar = new Button();
            grpSerializacion = new GroupBox();
            btnLimpiar = new Button();
            btnActualizar = new Button();
            btnDeserializar = new Button();
            btnSerializar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            grpSerializacion.SuspendLayout();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(634, 138);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(634, 185);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(634, 243);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Location = new Point(634, 84);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(27, 15);
            lblDNI.TabIndex = 3;
            lblDNI.Text = "DNI";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(634, 102);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(100, 23);
            txtDNI.TabIndex = 4;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(634, 156);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 5;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(634, 203);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(634, 261);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 7;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Font = new Font("Segoe UI", 12F);
            btnRegistrar.Location = new Point(767, 84);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(117, 41);
            btnRegistrar.TabIndex = 8;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F);
            lblTitulo.Location = new Point(248, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(206, 37);
            lblTitulo.TabIndex = 9;
            lblTitulo.Text = "Registrar cliente";
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.Location = new Point(767, 237);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(117, 41);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 84);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(616, 200);
            dgvClientes.TabIndex = 11;
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;
            // 
            // chkDesencriptar
            // 
            chkDesencriptar.AutoSize = true;
            chkDesencriptar.Location = new Point(12, 59);
            chkDesencriptar.Name = "chkDesencriptar";
            chkDesencriptar.Size = new Size(92, 19);
            chkDesencriptar.TabIndex = 12;
            chkDesencriptar.Text = "Desencriptar";
            chkDesencriptar.UseVisualStyleBackColor = true;
            chkDesencriptar.CheckedChanged += chkDesencriptar_CheckedChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 12F);
            btnEliminar.Location = new Point(767, 132);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(117, 41);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Segoe UI", 12F);
            btnModificar.Location = new Point(767, 185);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(117, 41);
            btnModificar.TabIndex = 14;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // lblModo
            // 
            lblModo.AutoSize = true;
            lblModo.Font = new Font("Segoe UI", 11F);
            lblModo.Location = new Point(12, 302);
            lblModo.Name = "lblModo";
            lblModo.Size = new Size(52, 20);
            lblModo.TabIndex = 15;
            lblModo.Text = "Modo:";
            // 
            // btnAplicar
            // 
            btnAplicar.Font = new Font("Segoe UI", 12F);
            btnAplicar.Location = new Point(767, 291);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(117, 41);
            btnAplicar.TabIndex = 16;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = true;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // grpSerializacion
            // 
            grpSerializacion.Controls.Add(btnLimpiar);
            grpSerializacion.Controls.Add(btnActualizar);
            grpSerializacion.Controls.Add(btnDeserializar);
            grpSerializacion.Controls.Add(btnSerializar);
            grpSerializacion.Location = new Point(12, 350);
            grpSerializacion.Name = "grpSerializacion";
            grpSerializacion.Size = new Size(872, 239);
            grpSerializacion.TabIndex = 17;
            grpSerializacion.TabStop = false;
            grpSerializacion.Text = "Serialización";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Segoe UI", 12F);
            btnLimpiar.Location = new Point(583, 49);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(139, 41);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Font = new Font("Segoe UI", 12F);
            btnActualizar.Location = new Point(397, 49);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(157, 41);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar grilla";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnDeserializar
            // 
            btnDeserializar.Font = new Font("Segoe UI", 12F);
            btnDeserializar.Location = new Point(201, 49);
            btnDeserializar.Name = "btnDeserializar";
            btnDeserializar.Size = new Size(157, 41);
            btnDeserializar.TabIndex = 1;
            btnDeserializar.Text = "Deserializar";
            btnDeserializar.UseVisualStyleBackColor = true;
            btnDeserializar.Click += btnDeserializar_Click;
            // 
            // btnSerializar
            // 
            btnSerializar.Font = new Font("Segoe UI", 12F);
            btnSerializar.Location = new Point(22, 49);
            btnSerializar.Name = "btnSerializar";
            btnSerializar.Size = new Size(157, 41);
            btnSerializar.TabIndex = 0;
            btnSerializar.Text = "Serializar";
            btnSerializar.UseVisualStyleBackColor = true;
            btnSerializar.Click += btnSerializar_Click;
            // 
            // FormRegistrarCliente_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 601);
            Controls.Add(grpSerializacion);
            Controls.Add(btnAplicar);
            Controls.Add(lblModo);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(chkDesencriptar);
            Controls.Add(dgvClientes);
            Controls.Add(btnCancelar);
            Controls.Add(lblTitulo);
            Controls.Add(btnRegistrar);
            Controls.Add(txtEmail);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtDNI);
            Controls.Add(lblDNI);
            Controls.Add(lblEmail);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Name = "FormRegistrarCliente_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegistrarCliente";
            Load += FormRegistrarCliente_327LG_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            grpSerializacion.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblApellido;
        private Label lblEmail;
        private Label lblDNI;
        private TextBox txtDNI;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtEmail;
        private Button btnRegistrar;
        private Label lblTitulo;
        private Button btnCancelar;
        private DataGridView dgvClientes;
        private CheckBox chkDesencriptar;
        private Button btnEliminar;
        private Button btnModificar;
        private Label lblModo;
        private Button btnAplicar;
        private GroupBox grpSerializacion;
        private Button btnDeserializar;
        private Button btnSerializar;
        private Button btnLimpiar;
        private Button btnActualizar;
    }
}