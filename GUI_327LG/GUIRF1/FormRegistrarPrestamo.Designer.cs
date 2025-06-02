namespace GUI_327LG.GUIRF1
{
    partial class FormRegistrarPrestamo
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
            dgvClientes = new DataGridView();
            lblClientes = new Label();
            btnFiltrar = new Button();
            txtDNICliente = new TextBox();
            lblDNICliente = new Label();
            btnSeleccionarLibro = new Button();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Segoe UI", 20F);
            lblTituloForm.Location = new Point(311, 9);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(240, 37);
            lblTituloForm.TabIndex = 0;
            lblTituloForm.Text = "Registrar préstamo";
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 89);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(580, 195);
            dgvClientes.TabIndex = 1;
            // 
            // lblClientes
            // 
            lblClientes.AutoSize = true;
            lblClientes.Font = new Font("Segoe UI", 14F);
            lblClientes.Location = new Point(12, 61);
            lblClientes.Name = "lblClientes";
            lblClientes.Size = new Size(185, 25);
            lblClientes.TabIndex = 2;
            lblClientes.Text = "Clientes Registrados:";
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(133, 322);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(121, 25);
            btnFiltrar.TabIndex = 7;
            btnFiltrar.Text = "Filtrar clientes";
            btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // txtDNICliente
            // 
            txtDNICliente.Location = new Point(12, 322);
            txtDNICliente.Name = "txtDNICliente";
            txtDNICliente.Size = new Size(115, 23);
            txtDNICliente.TabIndex = 6;
            // 
            // lblDNICliente
            // 
            lblDNICliente.AutoSize = true;
            lblDNICliente.Location = new Point(12, 304);
            lblDNICliente.Name = "lblDNICliente";
            lblDNICliente.Size = new Size(68, 15);
            lblDNICliente.TabIndex = 5;
            lblDNICliente.Text = "DNI cliente:";
            // 
            // btnSeleccionarLibro
            // 
            btnSeleccionarLibro.Font = new Font("Segoe UI", 14F);
            btnSeleccionarLibro.Location = new Point(645, 89);
            btnSeleccionarLibro.Name = "btnSeleccionarLibro";
            btnSeleccionarLibro.Size = new Size(160, 62);
            btnSeleccionarLibro.TabIndex = 8;
            btnSeleccionarLibro.Text = "Seleccionar Libro";
            btnSeleccionarLibro.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(645, 157);
            button1.Name = "button1";
            button1.Size = new Size(160, 62);
            button1.TabIndex = 9;
            button1.Text = "Registrar Cliente";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14F);
            button2.Location = new Point(645, 298);
            button2.Name = "button2";
            button2.Size = new Size(160, 62);
            button2.TabIndex = 10;
            button2.Text = "Registrar Préstamo";
            button2.UseVisualStyleBackColor = true;
            // 
            // FormRegistrarPrestamo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 402);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnSeleccionarLibro);
            Controls.Add(btnFiltrar);
            Controls.Add(txtDNICliente);
            Controls.Add(lblDNICliente);
            Controls.Add(lblClientes);
            Controls.Add(dgvClientes);
            Controls.Add(lblTituloForm);
            Name = "FormRegistrarPrestamo";
            Text = "FormRegistrarPrestamo";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloForm;
        private DataGridView dgvClientes;
        private Label lblClientes;
        private Button btnFiltrar;
        private TextBox txtDNICliente;
        private Label lblDNICliente;
        private Button btnSeleccionarLibro;
        private Button button1;
        private Button button2;
    }
}