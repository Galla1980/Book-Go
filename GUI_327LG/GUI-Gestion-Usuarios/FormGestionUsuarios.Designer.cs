namespace GUI_327LG
{
    partial class FormGestionUsuarios
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
            dgvUsuarios = new DataGridView();
            btnAñadir = new Button();
            btnDesbloquear = new Button();
            btnModificar = new Button();
            btnActDes = new Button();
            btnAplicar = new Button();
            btnCancelar = new Button();
            btnSalir = new Button();
            lblUsuarios = new Label();
            rdoActivos = new RadioButton();
            rdoTodos = new RadioButton();
            lblCanUsuarios = new Label();
            txtMensaje = new TextBox();
            tlpUsuarios = new TableLayoutPanel();
            txtDNI = new TextBox();
            lblApellido = new Label();
            lblNombre = new Label();
            lblEmail = new Label();
            lblRol = new Label();
            lblUsername = new Label();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            txtEmail = new TextBox();
            cmbRol = new ComboBox();
            txtUsername = new TextBox();
            lblDNI = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            tlpUsuarios.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(12, 63);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.Size = new Size(659, 219);
            dgvUsuarios.TabIndex = 0;
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged_327LG;
            // 
            // btnAñadir
            // 
            btnAñadir.Font = new Font("Segoe UI", 12F);
            btnAñadir.Location = new Point(734, 63);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(150, 32);
            btnAñadir.TabIndex = 1;
            btnAñadir.Text = "Añadir";
            btnAñadir.UseVisualStyleBackColor = true;
            btnAñadir.Click += btnAñadir_Click_327LG;
            // 
            // btnDesbloquear
            // 
            btnDesbloquear.Font = new Font("Segoe UI", 12F);
            btnDesbloquear.Location = new Point(734, 101);
            btnDesbloquear.Name = "btnDesbloquear";
            btnDesbloquear.Size = new Size(150, 32);
            btnDesbloquear.TabIndex = 2;
            btnDesbloquear.Text = "Desbloquear";
            btnDesbloquear.UseVisualStyleBackColor = true;
            btnDesbloquear.Click += btnDesbloquear_Click_327LG;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Segoe UI", 12F);
            btnModificar.Location = new Point(734, 139);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(150, 32);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click_327LG;
            // 
            // btnActDes
            // 
            btnActDes.Font = new Font("Segoe UI", 11F);
            btnActDes.Location = new Point(734, 177);
            btnActDes.Name = "btnActDes";
            btnActDes.Size = new Size(150, 33);
            btnActDes.TabIndex = 4;
            btnActDes.Text = "Activar/ Desactivar";
            btnActDes.UseVisualStyleBackColor = true;
            btnActDes.Click += btnActDes_Click;
            // 
            // btnAplicar
            // 
            btnAplicar.Font = new Font("Segoe UI", 12F);
            btnAplicar.Location = new Point(734, 216);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(150, 32);
            btnAplicar.TabIndex = 5;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = true;
            btnAplicar.Click += btnAplicar_Click_327LG;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 12F);
            btnCancelar.Location = new Point(734, 254);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 32);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click_327LG;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 12F);
            btnSalir.Location = new Point(734, 292);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(150, 32);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click_327LG;
            // 
            // lblUsuarios
            // 
            lblUsuarios.AutoSize = true;
            lblUsuarios.Font = new Font("Segoe UI", 20F, FontStyle.Bold | FontStyle.Underline);
            lblUsuarios.Location = new Point(12, 9);
            lblUsuarios.Name = "lblUsuarios";
            lblUsuarios.Size = new Size(128, 37);
            lblUsuarios.TabIndex = 8;
            lblUsuarios.Text = "Usuarios";
            // 
            // rdoActivos
            // 
            rdoActivos.AutoSize = true;
            rdoActivos.CheckAlign = ContentAlignment.TopCenter;
            rdoActivos.Checked = true;
            rdoActivos.Font = new Font("Segoe UI", 9F);
            rdoActivos.Location = new Point(318, 12);
            rdoActivos.Name = "rdoActivos";
            rdoActivos.Size = new Size(50, 32);
            rdoActivos.TabIndex = 9;
            rdoActivos.TabStop = true;
            rdoActivos.Text = "Activos";
            rdoActivos.UseVisualStyleBackColor = true;
            rdoActivos.CheckedChanged += rdoActivos_CheckedChanged_327LG;
            // 
            // rdoTodos
            // 
            rdoTodos.AutoSize = true;
            rdoTodos.CheckAlign = ContentAlignment.TopCenter;
            rdoTodos.Location = new Point(400, 12);
            rdoTodos.Name = "rdoTodos";
            rdoTodos.Size = new Size(42, 32);
            rdoTodos.TabIndex = 10;
            rdoTodos.Text = "Todos";
            rdoTodos.UseVisualStyleBackColor = true;
            // 
            // lblCanUsuarios
            // 
            lblCanUsuarios.AutoSize = true;
            lblCanUsuarios.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCanUsuarios.Location = new Point(467, 23);
            lblCanUsuarios.Name = "lblCanUsuarios";
            lblCanUsuarios.Size = new Size(166, 21);
            lblCanUsuarios.TabIndex = 11;
            lblCanUsuarios.Text = "Cantidad de usuarios:";
            // 
            // txtMensaje
            // 
            txtMensaje.Enabled = false;
            txtMensaje.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMensaje.Location = new Point(434, 308);
            txtMensaje.Multiline = true;
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(237, 192);
            txtMensaje.TabIndex = 12;
            txtMensaje.Text = "Mensaje:";
            txtMensaje.TextAlign = HorizontalAlignment.Center;
            // 
            // tlpUsuarios
            // 
            tlpUsuarios.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpUsuarios.ColumnCount = 2;
            tlpUsuarios.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.57971F));
            tlpUsuarios.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.42029F));
            tlpUsuarios.Controls.Add(txtDNI, 1, 0);
            tlpUsuarios.Controls.Add(lblApellido, 0, 1);
            tlpUsuarios.Controls.Add(lblNombre, 0, 2);
            tlpUsuarios.Controls.Add(lblEmail, 0, 3);
            tlpUsuarios.Controls.Add(lblRol, 0, 4);
            tlpUsuarios.Controls.Add(lblUsername, 0, 5);
            tlpUsuarios.Controls.Add(txtApellido, 1, 1);
            tlpUsuarios.Controls.Add(txtNombre, 1, 2);
            tlpUsuarios.Controls.Add(txtEmail, 1, 3);
            tlpUsuarios.Controls.Add(cmbRol, 1, 4);
            tlpUsuarios.Controls.Add(txtUsername, 1, 5);
            tlpUsuarios.Controls.Add(lblDNI, 0, 0);
            tlpUsuarios.Location = new Point(12, 308);
            tlpUsuarios.Name = "tlpUsuarios";
            tlpUsuarios.RowCount = 6;
            tlpUsuarios.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tlpUsuarios.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tlpUsuarios.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tlpUsuarios.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tlpUsuarios.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tlpUsuarios.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tlpUsuarios.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpUsuarios.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpUsuarios.Size = new Size(346, 192);
            tlpUsuarios.TabIndex = 13;
            // 
            // txtDNI
            // 
            txtDNI.Anchor = AnchorStyles.None;
            txtDNI.BorderStyle = BorderStyle.FixedSingle;
            txtDNI.Location = new Point(75, 4);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(267, 23);
            txtDNI.TabIndex = 0;
            // 
            // lblApellido
            // 
            lblApellido.Anchor = AnchorStyles.None;
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(10, 39);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            lblNombre.Anchor = AnchorStyles.None;
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(10, 70);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre";
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.None;
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(18, 101);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // lblRol
            // 
            lblRol.Anchor = AnchorStyles.None;
            lblRol.AutoSize = true;
            lblRol.Location = new Point(24, 132);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(24, 15);
            lblRol.TabIndex = 5;
            lblRol.Text = "Rol";
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.None;
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(6, 166);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(60, 15);
            lblUsername.TabIndex = 6;
            lblUsername.Text = "Username";
            // 
            // txtApellido
            // 
            txtApellido.Anchor = AnchorStyles.None;
            txtApellido.Location = new Point(75, 35);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(267, 23);
            txtApellido.TabIndex = 9;
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.None;
            txtNombre.Location = new Point(75, 66);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(267, 23);
            txtNombre.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.None;
            txtEmail.Location = new Point(75, 97);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(267, 23);
            txtEmail.TabIndex = 11;
            // 
            // cmbRol
            // 
            cmbRol.Anchor = AnchorStyles.None;
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Bibliotecario", "Repositor", "Admin" });
            cmbRol.Location = new Point(75, 128);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(267, 23);
            cmbRol.TabIndex = 12;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.None;
            txtUsername.Location = new Point(75, 162);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(267, 23);
            txtUsername.TabIndex = 13;
            // 
            // lblDNI
            // 
            lblDNI.Anchor = AnchorStyles.None;
            lblDNI.AutoSize = true;
            lblDNI.Location = new Point(22, 8);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(27, 15);
            lblDNI.TabIndex = 1;
            lblDNI.Text = "DNI";
            // 
            // FormGestionUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 517);
            Controls.Add(tlpUsuarios);
            Controls.Add(txtMensaje);
            Controls.Add(lblCanUsuarios);
            Controls.Add(rdoTodos);
            Controls.Add(rdoActivos);
            Controls.Add(lblUsuarios);
            Controls.Add(btnSalir);
            Controls.Add(btnCancelar);
            Controls.Add(btnAplicar);
            Controls.Add(btnActDes);
            Controls.Add(btnModificar);
            Controls.Add(btnDesbloquear);
            Controls.Add(btnAñadir);
            Controls.Add(dgvUsuarios);
            Name = "FormGestionUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de usuarios";
            Load += FormGestionUsuarios_Load;
            Shown += FormGestionUsuarios_Shown_327LG;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            tlpUsuarios.ResumeLayout(false);
            tlpUsuarios.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsuarios;
        private Button btnAñadir;
        private Button btnDesbloquear;
        private Button btnModificar;
        private Button btnActDes;
        private Button btnAplicar;
        private Button btnCancelar;
        private Button btnSalir;
        private Label lblUsuarios;
        private RadioButton rdoActivos;
        private RadioButton rdoTodos;
        private Label lblCanUsuarios;
        private TextBox txtMensaje;
        private TableLayoutPanel tlpUsuarios;
        private Label lblDNI;
        private Label lblApellido;
        private Label lblNombre;
        private Label lblEmail;
        private Label lblRol;
        private Label lblUsername;
        private TextBox txtDNI;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private TextBox txtEmail;
        private ComboBox cmbRol;
        private TextBox txtUsername;
    }
}