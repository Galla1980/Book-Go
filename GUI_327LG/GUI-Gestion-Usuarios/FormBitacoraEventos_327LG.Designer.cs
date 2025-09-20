namespace GUI_327LG.GUI_Gestion_Usuarios
{
    partial class FormBitacoraEventos_327LG
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
            dgvEventos = new DataGridView();
            lblTitulo = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            cmbLogin = new ComboBox();
            cmbModulo = new ComboBox();
            cmbEvento = new ComboBox();
            cmbCriticidad = new ComboBox();
            lblLogin = new Label();
            lblModulo = new Label();
            lblFechaInicio = new Label();
            lblEvento = new Label();
            lblFechaFin = new Label();
            lblCriticidad = new Label();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            btnLimpiar = new Button();
            btnAplicar = new Button();
            btnImprimir = new Button();
            chkFiltrarFecha = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvEventos).BeginInit();
            SuspendLayout();
            // 
            // dgvEventos
            // 
            dgvEventos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEventos.Location = new Point(12, 59);
            dgvEventos.Name = "dgvEventos";
            dgvEventos.Size = new Size(728, 223);
            dgvEventos.TabIndex = 0;
            dgvEventos.SelectionChanged += dgvEventos_SelectionChanged;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(204, 30);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Bitácora de eventos";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(109, 301);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(492, 301);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellido:";
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(109, 319);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(121, 23);
            txtNombre.TabIndex = 4;
            // 
            // txtApellido
            // 
            txtApellido.Enabled = false;
            txtApellido.Location = new Point(492, 319);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(139, 23);
            txtApellido.TabIndex = 5;
            // 
            // cmbLogin
            // 
            cmbLogin.FormattingEnabled = true;
            cmbLogin.Location = new Point(109, 379);
            cmbLogin.Name = "cmbLogin";
            cmbLogin.Size = new Size(139, 23);
            cmbLogin.TabIndex = 6;
            // 
            // cmbModulo
            // 
            cmbModulo.FormattingEnabled = true;
            cmbModulo.Location = new Point(109, 439);
            cmbModulo.Name = "cmbModulo";
            cmbModulo.Size = new Size(139, 23);
            cmbModulo.TabIndex = 9;
            cmbModulo.SelectedIndexChanged += cmbModulo_SelectedIndexChanged;
            // 
            // cmbEvento
            // 
            cmbEvento.FormattingEnabled = true;
            cmbEvento.Location = new Point(313, 439);
            cmbEvento.Name = "cmbEvento";
            cmbEvento.Size = new Size(139, 23);
            cmbEvento.TabIndex = 10;
            // 
            // cmbCriticidad
            // 
            cmbCriticidad.FormattingEnabled = true;
            cmbCriticidad.Location = new Point(492, 439);
            cmbCriticidad.Name = "cmbCriticidad";
            cmbCriticidad.Size = new Size(139, 23);
            cmbCriticidad.TabIndex = 11;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(109, 361);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(37, 15);
            lblLogin.TabIndex = 12;
            lblLogin.Text = "Login";
            // 
            // lblModulo
            // 
            lblModulo.AutoSize = true;
            lblModulo.Location = new Point(109, 421);
            lblModulo.Name = "lblModulo";
            lblModulo.Size = new Size(49, 15);
            lblModulo.TabIndex = 13;
            lblModulo.Text = "Módulo";
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(313, 361);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(70, 15);
            lblFechaInicio.TabIndex = 14;
            lblFechaInicio.Text = "Fecha inicio";
            // 
            // lblEvento
            // 
            lblEvento.AutoSize = true;
            lblEvento.Location = new Point(313, 421);
            lblEvento.Name = "lblEvento";
            lblEvento.Size = new Size(43, 15);
            lblEvento.TabIndex = 15;
            lblEvento.Text = "Evento";
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(492, 361);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(57, 15);
            lblFechaFin.TabIndex = 16;
            lblFechaFin.Text = "Fecha Fin";
            // 
            // lblCriticidad
            // 
            lblCriticidad.AutoSize = true;
            lblCriticidad.Location = new Point(492, 421);
            lblCriticidad.Name = "lblCriticidad";
            lblCriticidad.Size = new Size(58, 15);
            lblCriticidad.TabIndex = 17;
            lblCriticidad.Text = "Criticidad";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(313, 379);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(139, 23);
            dtpFechaInicio.TabIndex = 18;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(492, 379);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(139, 23);
            dtpFechaFin.TabIndex = 19;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Segoe UI", 11F);
            btnLimpiar.Location = new Point(140, 491);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(87, 37);
            btnLimpiar.TabIndex = 20;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnAplicar
            // 
            btnAplicar.Font = new Font("Segoe UI", 11F);
            btnAplicar.Location = new Point(325, 491);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(87, 37);
            btnAplicar.TabIndex = 21;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = true;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Font = new Font("Segoe UI", 11F);
            btnImprimir.Location = new Point(513, 491);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(87, 37);
            btnImprimir.TabIndex = 22;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // chkFiltrarFecha
            // 
            chkFiltrarFecha.AutoSize = true;
            chkFiltrarFecha.Checked = true;
            chkFiltrarFecha.CheckState = CheckState.Checked;
            chkFiltrarFecha.Location = new Point(637, 383);
            chkFiltrarFecha.Name = "chkFiltrarFecha";
            chkFiltrarFecha.Size = new Size(88, 19);
            chkFiltrarFecha.TabIndex = 23;
            chkFiltrarFecha.Text = "Filtrar fecha";
            chkFiltrarFecha.UseVisualStyleBackColor = true;
            // 
            // FormBitacoraEventos_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 556);
            Controls.Add(chkFiltrarFecha);
            Controls.Add(btnImprimir);
            Controls.Add(btnAplicar);
            Controls.Add(btnLimpiar);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(lblCriticidad);
            Controls.Add(lblFechaFin);
            Controls.Add(lblEvento);
            Controls.Add(lblFechaInicio);
            Controls.Add(lblModulo);
            Controls.Add(lblLogin);
            Controls.Add(cmbCriticidad);
            Controls.Add(cmbEvento);
            Controls.Add(cmbModulo);
            Controls.Add(cmbLogin);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            Controls.Add(dgvEventos);
            Name = "FormBitacoraEventos_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormBitacoraEventos_327LG";
            Load += FormBitacoraEventos_327LG_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEventos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEventos;
        private Label lblTitulo;
        private Label lblNombre;
        private Label lblApellido;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private ComboBox cmbLogin;
        private ComboBox cmbModulo;
        private ComboBox cmbEvento;
        private ComboBox cmbCriticidad;
        private Label lblLogin;
        private Label lblModulo;
        private Label lblFechaInicio;
        private Label lblEvento;
        private Label lblFechaFin;
        private Label lblCriticidad;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Button btnLimpiar;
        private Button btnAplicar;
        private Button btnImprimir;
        private CheckBox chkFiltrarFecha;
    }
}