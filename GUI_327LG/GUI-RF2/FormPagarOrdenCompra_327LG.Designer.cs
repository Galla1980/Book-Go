namespace GUI_327LG.GUI_RF2
{
    partial class FormPagarOrdenCompra_327LG
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
            btnCobrar = new Button();
            txtMonto = new TextBox();
            txtVencimiento = new TextBox();
            txtClave = new TextBox();
            txtNroTarjeta = new TextBox();
            txtNombreTitular = new TextBox();
            lblMonto = new Label();
            lblVencimiento = new Label();
            lblClave = new Label();
            lblNroTarjeta = new Label();
            lblNombreTitular = new Label();
            lblTituloForm = new Label();
            label1 = new Label();
            lblCuit = new Label();
            lblCBU = new Label();
            txtCuit = new TextBox();
            txtCBU = new TextBox();
            lblBanco = new Label();
            txtBanco = new TextBox();
            SuspendLayout();
            // 
            // btnCobrar
            // 
            btnCobrar.Font = new Font("Segoe UI", 18F);
            btnCobrar.Location = new Point(261, 248);
            btnCobrar.Name = "btnCobrar";
            btnCobrar.Size = new Size(155, 67);
            btnCobrar.TabIndex = 27;
            btnCobrar.Text = "Pagar";
            btnCobrar.UseVisualStyleBackColor = true;
            btnCobrar.Click += btnCobrar_Click;
            // 
            // txtMonto
            // 
            txtMonto.Enabled = false;
            txtMonto.Location = new Point(471, 98);
            txtMonto.Name = "txtMonto";
            txtMonto.ReadOnly = true;
            txtMonto.Size = new Size(117, 23);
            txtMonto.TabIndex = 26;
            // 
            // txtVencimiento
            // 
            txtVencimiento.Location = new Point(505, 189);
            txtVencimiento.Name = "txtVencimiento";
            txtVencimiento.Size = new Size(100, 23);
            txtVencimiento.TabIndex = 25;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(357, 189);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(142, 23);
            txtClave.TabIndex = 24;
            // 
            // txtNroTarjeta
            // 
            txtNroTarjeta.Location = new Point(198, 189);
            txtNroTarjeta.Name = "txtNroTarjeta";
            txtNroTarjeta.Size = new Size(153, 23);
            txtNroTarjeta.TabIndex = 23;
            // 
            // txtNombreTitular
            // 
            txtNombreTitular.Location = new Point(54, 189);
            txtNombreTitular.Name = "txtNombreTitular";
            txtNombreTitular.Size = new Size(138, 23);
            txtNombreTitular.TabIndex = 22;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Enabled = false;
            lblMonto.Font = new Font("Segoe UI", 12F);
            lblMonto.Location = new Point(471, 74);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(112, 21);
            lblMonto.TabIndex = 21;
            lblMonto.Text = "Monto a pagar";
            // 
            // lblVencimiento
            // 
            lblVencimiento.AutoSize = true;
            lblVencimiento.Font = new Font("Segoe UI", 12F);
            lblVencimiento.Location = new Point(505, 165);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new Size(96, 21);
            lblVencimiento.TabIndex = 20;
            lblVencimiento.Text = "Vencimiento";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 12F);
            lblClave.Location = new Point(357, 165);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(142, 21);
            lblClave.TabIndex = 19;
            lblClave.Text = "Clave de seguridad";
            // 
            // lblNroTarjeta
            // 
            lblNroTarjeta.AutoSize = true;
            lblNroTarjeta.Font = new Font("Segoe UI", 12F);
            lblNroTarjeta.Location = new Point(198, 165);
            lblNroTarjeta.Name = "lblNroTarjeta";
            lblNroTarjeta.Size = new Size(153, 21);
            lblNroTarjeta.TabIndex = 18;
            lblNroTarjeta.Text = "Numero de la tarjeta";
            // 
            // lblNombreTitular
            // 
            lblNombreTitular.AutoSize = true;
            lblNombreTitular.Font = new Font("Segoe UI", 12F);
            lblNombreTitular.Location = new Point(54, 165);
            lblNombreTitular.Name = "lblNombreTitular";
            lblNombreTitular.Size = new Size(138, 21);
            lblNombreTitular.TabIndex = 17;
            lblNombreTitular.Text = "Nombre del titular";
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Segoe UI", 20F);
            lblTituloForm.Location = new Point(189, 9);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(295, 37);
            lblTituloForm.TabIndex = 15;
            lblTituloForm.Text = "Pagar orden de compra";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(86, 73);
            label1.Name = "label1";
            label1.Size = new Size(0, 21);
            label1.TabIndex = 28;
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Font = new Font("Segoe UI", 12F);
            lblCuit.Location = new Point(86, 73);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(43, 21);
            lblCuit.TabIndex = 29;
            lblCuit.Text = "CUIT";
            // 
            // lblCBU
            // 
            lblCBU.AutoSize = true;
            lblCBU.Font = new Font("Segoe UI", 12F);
            lblCBU.Location = new Point(216, 73);
            lblCBU.Name = "lblCBU";
            lblCBU.Size = new Size(40, 21);
            lblCBU.TabIndex = 30;
            lblCBU.Text = "CBU";
            // 
            // txtCuit
            // 
            txtCuit.Location = new Point(86, 98);
            txtCuit.Name = "txtCuit";
            txtCuit.ReadOnly = true;
            txtCuit.Size = new Size(106, 23);
            txtCuit.TabIndex = 31;
            // 
            // txtCBU
            // 
            txtCBU.Location = new Point(216, 98);
            txtCBU.Name = "txtCBU";
            txtCBU.Size = new Size(100, 23);
            txtCBU.TabIndex = 32;
            // 
            // lblBanco
            // 
            lblBanco.AutoSize = true;
            lblBanco.Font = new Font("Segoe UI", 12F);
            lblBanco.Location = new Point(342, 74);
            lblBanco.Name = "lblBanco";
            lblBanco.Size = new Size(52, 21);
            lblBanco.TabIndex = 33;
            lblBanco.Text = "Banco";
            // 
            // txtBanco
            // 
            txtBanco.Location = new Point(342, 98);
            txtBanco.Name = "txtBanco";
            txtBanco.Size = new Size(103, 23);
            txtBanco.TabIndex = 34;
            // 
            // FormPagarOrdenCompra_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 351);
            Controls.Add(txtBanco);
            Controls.Add(lblBanco);
            Controls.Add(txtCBU);
            Controls.Add(txtCuit);
            Controls.Add(lblCBU);
            Controls.Add(lblCuit);
            Controls.Add(label1);
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
            Controls.Add(lblTituloForm);
            Name = "FormPagarOrdenCompra_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPagarOrdenCompra_327LG";
            FormClosed += FormPagarOrdenCompra_327LG_FormClosed;
            Load += FormPagarOrdenCompra_327LG_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCobrar;
        private TextBox txtMonto;
        private TextBox txtVencimiento;
        private TextBox txtClave;
        private TextBox txtNroTarjeta;
        private TextBox txtNombreTitular;
        private Label lblMonto;
        private Label lblVencimiento;
        private Label lblClave;
        private Label lblNroTarjeta;
        private Label lblNombreTitular;
        private Label lblTituloForm;
        private Label label1;
        private Label lblCuit;
        private Label lblCBU;
        private TextBox txtCuit;
        private TextBox txtCBU;
        private Label lblBanco;
        private TextBox txtBanco;
    }
}