namespace GUI_327LG.GUIRF1
{
    partial class FormCobrarSeña_327LG
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
            cmbMetodoPago = new ComboBox();
            lblTituloForm = new Label();
            lblMetodo = new Label();
            lblNombreTitular = new Label();
            lblNroTarjeta = new Label();
            lblClave = new Label();
            lblVencimiento = new Label();
            lblMonto = new Label();
            txtNombreTitular = new TextBox();
            txtNroTarjeta = new TextBox();
            txtClave = new TextBox();
            txtVencimiento = new TextBox();
            txtMonto = new TextBox();
            btnCobrar = new Button();
            SuspendLayout();
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.Font = new Font("Segoe UI", 12F);
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(36, 115);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(121, 29);
            cmbMetodoPago.TabIndex = 0;
            cmbMetodoPago.Text = "Tarjeta";
            cmbMetodoPago.SelectedIndexChanged += cmbMetodoPago_SelectedIndexChanged_1;
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Segoe UI", 20F);
            lblTituloForm.Location = new Point(195, 9);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(162, 37);
            lblTituloForm.TabIndex = 1;
            lblTituloForm.Text = "Cobrar Seña";
            // 
            // lblMetodo
            // 
            lblMetodo.AutoSize = true;
            lblMetodo.Font = new Font("Segoe UI", 12F);
            lblMetodo.Location = new Point(36, 91);
            lblMetodo.Name = "lblMetodo";
            lblMetodo.Size = new Size(127, 21);
            lblMetodo.TabIndex = 2;
            lblMetodo.Text = "Metodo de pago:";
            // 
            // lblNombreTitular
            // 
            lblNombreTitular.AutoSize = true;
            lblNombreTitular.Font = new Font("Segoe UI", 12F);
            lblNombreTitular.Location = new Point(15, 175);
            lblNombreTitular.Name = "lblNombreTitular";
            lblNombreTitular.Size = new Size(138, 21);
            lblNombreTitular.TabIndex = 3;
            lblNombreTitular.Text = "Nombre del titular";
            // 
            // lblNroTarjeta
            // 
            lblNroTarjeta.AutoSize = true;
            lblNroTarjeta.Font = new Font("Segoe UI", 12F);
            lblNroTarjeta.Location = new Point(159, 175);
            lblNroTarjeta.Name = "lblNroTarjeta";
            lblNroTarjeta.Size = new Size(153, 21);
            lblNroTarjeta.TabIndex = 4;
            lblNroTarjeta.Text = "Numero de la tarjeta";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 12F);
            lblClave.Location = new Point(318, 175);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(142, 21);
            lblClave.TabIndex = 5;
            lblClave.Text = "Clave de seguridad";
            // 
            // lblVencimiento
            // 
            lblVencimiento.AutoSize = true;
            lblVencimiento.Font = new Font("Segoe UI", 12F);
            lblVencimiento.Location = new Point(466, 175);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new Size(96, 21);
            lblVencimiento.TabIndex = 6;
            lblVencimiento.Text = "Vencimiento";
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Segoe UI", 12F);
            lblMonto.Location = new Point(387, 91);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(117, 21);
            lblMonto.TabIndex = 7;
            lblMonto.Text = "Monto a cobrar";
            // 
            // txtNombreTitular
            // 
            txtNombreTitular.Location = new Point(15, 199);
            txtNombreTitular.Name = "txtNombreTitular";
            txtNombreTitular.Size = new Size(138, 23);
            txtNombreTitular.TabIndex = 8;
            // 
            // txtNroTarjeta
            // 
            txtNroTarjeta.Location = new Point(159, 199);
            txtNroTarjeta.Name = "txtNroTarjeta";
            txtNroTarjeta.Size = new Size(153, 23);
            txtNroTarjeta.TabIndex = 9;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(318, 199);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(142, 23);
            txtClave.TabIndex = 10;
            // 
            // txtVencimiento
            // 
            txtVencimiento.Location = new Point(466, 199);
            txtVencimiento.Name = "txtVencimiento";
            txtVencimiento.Size = new Size(100, 23);
            txtVencimiento.TabIndex = 11;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(387, 115);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(117, 23);
            txtMonto.TabIndex = 12;
            // 
            // btnCobrar
            // 
            btnCobrar.Font = new Font("Segoe UI", 18F);
            btnCobrar.Location = new Point(202, 259);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(155, 67);
            btnCobrar.TabIndex = 13;
            btnCobrar.Text = "Cobrar";
            btnCobrar.UseVisualStyleBackColor = true;
            btnCobrar.Click += btnCobrar_Click;
            // 
            // FormCobrarSeña_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 359);
            Controls.Add(btnCobrar);
            Controls.Add(txtMonto);
            Controls.Add(txtVencimiento);
            Controls.Add(txtClave);
            Controls.Add(txtNroTarjeta);
            Controls.Add(txtNombreTitular);
            Controls.Add(lblMonto);
            Controls.Add(lblVencimiento);
            Controls.Add(lblClave);
            Controls.Add(lblNroTarjeta);
            Controls.Add(lblNombreTitular);
            Controls.Add(lblMetodo);
            Controls.Add(lblTituloForm);
            Controls.Add(cmbMetodoPago);
            Name = "FormCobrarSeña_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCobrarSeña";
            FormClosed += FormCobrarSeña_327LG_FormClosed;
            Load += FormCobrarSeña_327LG_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMetodoPago;
        private Label lblTituloForm;
        private Label lblMetodo;
        private Label lblNombreTitular;
        private Label lblNroTarjeta;
        private Label lblClave;
        private Label lblVencimiento;
        private Label lblMonto;
        private TextBox txtNombreTitular;
        private TextBox txtNroTarjeta;
        private TextBox txtClave;
        private TextBox txtVencimiento;
        private TextBox txtMonto;
        private Button btnCobrar;
    }
}