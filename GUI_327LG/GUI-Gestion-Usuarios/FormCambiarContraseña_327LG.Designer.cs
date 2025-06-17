namespace GUI_327LG
{
    partial class FormCambiarContraseña_327LG
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
            btnSalir = new Button();
            lblCmbContraseña = new Label();
            lblNuevaContraseña = new Label();
            lblContraseñaAct = new Label();
            chkConfContraseña = new CheckBox();
            txtNuevaContraseña = new TextBox();
            txtContraseñaAct = new TextBox();
            btnCambiarContraseña = new Button();
            txtConfContraseña = new TextBox();
            lblConfContraseña = new Label();
            chkContraseñaActual = new CheckBox();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(224, 228);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(116, 31);
            btnSalir.TabIndex = 23;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblCmbContraseña
            // 
            lblCmbContraseña.AutoSize = true;
            lblCmbContraseña.Font = new Font("Segoe UI", 14F);
            lblCmbContraseña.Location = new Point(137, 25);
            lblCmbContraseña.Name = "lblCmbContraseña";
            lblCmbContraseña.Size = new Size(181, 25);
            lblCmbContraseña.TabIndex = 22;
            lblCmbContraseña.Text = "Cambiar contraseña\r\n";
            // 
            // lblNuevaContraseña
            // 
            lblNuevaContraseña.AutoSize = true;
            lblNuevaContraseña.Location = new Point(116, 132);
            lblNuevaContraseña.Name = "lblNuevaContraseña";
            lblNuevaContraseña.Size = new Size(102, 15);
            lblNuevaContraseña.TabIndex = 21;
            lblNuevaContraseña.Text = "Nueva contraseña";
            // 
            // lblContraseñaAct
            // 
            lblContraseñaAct.AutoSize = true;
            lblContraseñaAct.Location = new Point(116, 89);
            lblContraseñaAct.Name = "lblContraseñaAct";
            lblContraseñaAct.Size = new Size(102, 15);
            lblContraseñaAct.TabIndex = 20;
            lblContraseñaAct.Text = "Contraseña actual";
            // 
            // chkConfContraseña
            // 
            chkConfContraseña.AutoSize = true;
            chkConfContraseña.Location = new Point(346, 171);
            chkConfContraseña.Name = "chkConfContraseña";
            chkConfContraseña.Size = new Size(42, 19);
            chkConfContraseña.TabIndex = 19;
            chkConfContraseña.Text = "Ver";
            chkConfContraseña.UseVisualStyleBackColor = true;
            chkConfContraseña.CheckedChanged += chkConfContraseña_CheckedChanged;
            // 
            // txtNuevaContraseña
            // 
            txtNuevaContraseña.Location = new Point(224, 129);
            txtNuevaContraseña.Name = "txtNuevaContraseña";
            txtNuevaContraseña.PasswordChar = '●';
            txtNuevaContraseña.Size = new Size(116, 23);
            txtNuevaContraseña.TabIndex = 18;
            // 
            // txtContraseñaAct
            // 
            txtContraseñaAct.Location = new Point(224, 86);
            txtContraseñaAct.Name = "txtContraseñaAct";
            txtContraseñaAct.PasswordChar = '●';
            txtContraseñaAct.Size = new Size(116, 23);
            txtContraseñaAct.TabIndex = 17;
            // 
            // btnCambiarContraseña
            // 
            btnCambiarContraseña.Location = new Point(94, 228);
            btnCambiarContraseña.Name = "btnCambiarContraseña";
            btnCambiarContraseña.Size = new Size(124, 31);
            btnCambiarContraseña.TabIndex = 16;
            btnCambiarContraseña.Text = "Cambiar contraseña";
            btnCambiarContraseña.UseVisualStyleBackColor = true;
            btnCambiarContraseña.Click += btnCambiarContraseña_Click_327LG;
            // 
            // txtConfContraseña
            // 
            txtConfContraseña.Location = new Point(224, 169);
            txtConfContraseña.Name = "txtConfContraseña";
            txtConfContraseña.PasswordChar = '●';
            txtConfContraseña.Size = new Size(116, 23);
            txtConfContraseña.TabIndex = 24;
            // 
            // lblConfContraseña
            // 
            lblConfContraseña.AutoSize = true;
            lblConfContraseña.Location = new Point(96, 172);
            lblConfContraseña.Name = "lblConfContraseña";
            lblConfContraseña.Size = new Size(122, 15);
            lblConfContraseña.TabIndex = 25;
            lblConfContraseña.Text = "Confirmar contraseña";
            // 
            // chkContraseñaActual
            // 
            chkContraseñaActual.AutoSize = true;
            chkContraseñaActual.Location = new Point(346, 88);
            chkContraseñaActual.Name = "chkContraseñaActual";
            chkContraseñaActual.Size = new Size(42, 19);
            chkContraseñaActual.TabIndex = 26;
            chkContraseñaActual.Text = "Ver";
            chkContraseñaActual.UseVisualStyleBackColor = true;
            chkContraseñaActual.CheckedChanged += chkContraseñaActual_CheckedChanged;
            // 
            // FormCambiarContraseña_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 288);
            Controls.Add(chkContraseñaActual);
            Controls.Add(lblConfContraseña);
            Controls.Add(txtConfContraseña);
            Controls.Add(btnSalir);
            Controls.Add(lblCmbContraseña);
            Controls.Add(lblNuevaContraseña);
            Controls.Add(lblContraseñaAct);
            Controls.Add(chkConfContraseña);
            Controls.Add(txtNuevaContraseña);
            Controls.Add(txtContraseñaAct);
            Controls.Add(btnCambiarContraseña);
            Name = "FormCambiarContraseña_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCambiarContraseña";
            FormClosed += FormCambiarContraseña_327LG_FormClosed;
            Load += FormCambiarContraseña_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalir;
        private Label lblCmbContraseña;
        private Label lblNuevaContraseña;
        private Label lblContraseñaAct;
        private CheckBox chkConfContraseña;
        private TextBox txtNuevaContraseña;
        private TextBox txtContraseñaAct;
        private Button btnCambiarContraseña;
        private TextBox txtConfContraseña;
        private Label lblConfContraseña;
        private CheckBox chkContraseñaActual;
    }
}