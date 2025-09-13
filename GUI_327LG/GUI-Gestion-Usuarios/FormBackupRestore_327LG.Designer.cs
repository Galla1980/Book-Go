namespace GUI_327LG.GUI_Gestion_Usuarios
{
    partial class FormBackupRestore_327LG
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
            btnBackup = new Button();
            txtBackup = new TextBox();
            btnElegirRuta = new Button();
            txtRestore = new TextBox();
            btnElegirArchivo = new Button();
            btnRestore = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F);
            lblTitulo.Location = new Point(111, 23);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(168, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "BackUp/Restore";
            // 
            // btnBackup
            // 
            btnBackup.Location = new Point(144, 141);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(105, 23);
            btnBackup.TabIndex = 1;
            btnBackup.Text = "Hacer BackUp";
            btnBackup.UseVisualStyleBackColor = true;
            btnBackup.Click += btnBackup_Click;
            // 
            // txtBackup
            // 
            txtBackup.Enabled = false;
            txtBackup.Location = new Point(25, 93);
            txtBackup.Name = "txtBackup";
            txtBackup.Size = new Size(254, 23);
            txtBackup.TabIndex = 2;
            // 
            // btnElegirRuta
            // 
            btnElegirRuta.Location = new Point(285, 92);
            btnElegirRuta.Name = "btnElegirRuta";
            btnElegirRuta.Size = new Size(92, 24);
            btnElegirRuta.TabIndex = 3;
            btnElegirRuta.Text = "Cambiar ruta";
            btnElegirRuta.UseVisualStyleBackColor = true;
            btnElegirRuta.Click += btnElegirRuta_Click;
            // 
            // txtRestore
            // 
            txtRestore.Location = new Point(25, 214);
            txtRestore.Name = "txtRestore";
            txtRestore.Size = new Size(254, 23);
            txtRestore.TabIndex = 4;
            // 
            // btnElegirArchivo
            // 
            btnElegirArchivo.Location = new Point(285, 214);
            btnElegirArchivo.Name = "btnElegirArchivo";
            btnElegirArchivo.Size = new Size(92, 23);
            btnElegirArchivo.TabIndex = 5;
            btnElegirArchivo.Text = "Elegir archivo";
            btnElegirArchivo.UseVisualStyleBackColor = true;
            btnElegirArchivo.Click += btnElegirArchivo_Click;
            // 
            // btnRestore
            // 
            btnRestore.Location = new Point(144, 263);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(105, 23);
            btnRestore.TabIndex = 6;
            btnRestore.Text = "Restaurar ";
            btnRestore.UseVisualStyleBackColor = true;
            btnRestore.Click += btnRestore_Click;
            // 
            // FormBackupRestore_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 332);
            Controls.Add(btnRestore);
            Controls.Add(btnElegirArchivo);
            Controls.Add(txtRestore);
            Controls.Add(btnElegirRuta);
            Controls.Add(txtBackup);
            Controls.Add(btnBackup);
            Controls.Add(lblTitulo);
            Name = "FormBackupRestore_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormBackupRestore_327LG";
            Load += FormBackupRestore_327LG_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnBackup;
        private TextBox txtBackup;
        private Button btnElegirRuta;
        private TextBox txtRestore;
        private Button btnElegirArchivo;
        private Button btnRestore;
    }
}