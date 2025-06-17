namespace GUI_327LG
{
    partial class FormIniciarSesion_327LG
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
            lblIniciarSesion = new Label();
            lblContraseña = new Label();
            lblUsuario = new Label();
            chkVerContraseña = new CheckBox();
            txtContraseña = new TextBox();
            txtUsuario = new TextBox();
            btnIniciarSesion = new Button();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(230, 168);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(116, 31);
            btnSalir.TabIndex = 15;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblIniciarSesion
            // 
            lblIniciarSesion.AutoSize = true;
            lblIniciarSesion.BackColor = Color.Transparent;
            lblIniciarSesion.Font = new Font("Segoe UI", 14F);
            lblIniciarSesion.Location = new Point(144, 9);
            lblIniciarSesion.Name = "lblIniciarSesion";
            lblIniciarSesion.Size = new Size(142, 25);
            lblIniciarSesion.TabIndex = 14;
            lblIniciarSesion.Text = "Inicio de sesion";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.BackColor = Color.Transparent;
            lblContraseña.Location = new Point(81, 112);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(67, 15);
            lblContraseña.TabIndex = 13;
            lblContraseña.Text = "Contraseña";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.Transparent;
            lblUsuario.ForeColor = SystemColors.ControlText;
            lblUsuario.Location = new Point(101, 67);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(47, 15);
            lblUsuario.TabIndex = 12;
            lblUsuario.Text = "Usuario";
            // 
            // chkVerContraseña
            // 
            chkVerContraseña.AutoSize = true;
            chkVerContraseña.BackColor = Color.Transparent;
            chkVerContraseña.Location = new Point(276, 114);
            chkVerContraseña.Name = "chkVerContraseña";
            chkVerContraseña.Size = new Size(42, 19);
            chkVerContraseña.TabIndex = 11;
            chkVerContraseña.Text = "Ver";
            chkVerContraseña.UseVisualStyleBackColor = false;
            chkVerContraseña.CheckedChanged += chkVerContraseña_CheckedChanged;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(154, 112);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '●';
            txtContraseña.Size = new Size(116, 23);
            txtContraseña.TabIndex = 10;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(154, 67);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(116, 23);
            txtUsuario.TabIndex = 9;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(81, 168);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(116, 31);
            btnIniciarSesion.TabIndex = 8;
            btnIniciarSesion.Text = "Iniciar sesión";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // FormIniciarSesion_327LG
            // 
            AcceptButton = btnIniciarSesion;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 241);
            Controls.Add(btnSalir);
            Controls.Add(lblIniciarSesion);
            Controls.Add(lblContraseña);
            Controls.Add(lblUsuario);
            Controls.Add(chkVerContraseña);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(btnIniciarSesion);
            Name = "FormIniciarSesion_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormIniciarSesion";
            FormClosed += FormIniciarSesion_327LG_FormClosed;
            Load += FormIniciarSesion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalir;
        private Label lblIniciarSesion;
        private Label lblContraseña;
        private Label lblUsuario;
        private CheckBox chkVerContraseña;
        private TextBox txtContraseña;
        private TextBox txtUsuario;
        private Button btnIniciarSesion;
    }
}