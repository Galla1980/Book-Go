namespace GUI_327LG.GUI_Gestion_Usuarios
{
    partial class FormRepararDigito_327LG
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
            btnRecalcular = new Button();
            btnRestaurar = new Button();
            btnSalir = new Button();
            lblTitulo = new Label();
            lblInconsistencias = new Label();
            SuspendLayout();
            // 
            // btnRecalcular
            // 
            btnRecalcular.Font = new Font("Segoe UI", 16F);
            btnRecalcular.Location = new Point(151, 152);
            btnRecalcular.Name = "btnRecalcular";
            btnRecalcular.Size = new Size(255, 66);
            btnRecalcular.TabIndex = 0;
            btnRecalcular.Text = "Recalcular digito";
            btnRecalcular.UseVisualStyleBackColor = true;
            btnRecalcular.Click += btnRecalcular_Click;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Font = new Font("Segoe UI", 16F);
            btnRestaurar.Location = new Point(151, 244);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(255, 66);
            btnRestaurar.TabIndex = 1;
            btnRestaurar.Text = "Restaurar base de datos";
            btnRestaurar.UseVisualStyleBackColor = true;
            btnRestaurar.Click += btnRestaurar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 16F);
            btnSalir.Location = new Point(151, 339);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(255, 66);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F);
            lblTitulo.Location = new Point(151, 29);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(262, 32);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "Inconsistencia de datos";
            // 
            // lblInconsistencias
            // 
            lblInconsistencias.AutoSize = true;
            lblInconsistencias.Location = new Point(151, 89);
            lblInconsistencias.Name = "lblInconsistencias";
            lblInconsistencias.Size = new Size(160, 15);
            lblInconsistencias.TabIndex = 4;
            lblInconsistencias.Text = "Inconsistencias en las tablas: ";
            // 
            // FormRepararDigito_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 420);
            Controls.Add(lblInconsistencias);
            Controls.Add(lblTitulo);
            Controls.Add(btnSalir);
            Controls.Add(btnRestaurar);
            Controls.Add(btnRecalcular);
            Name = "FormRepararDigito_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRepararDigito_327LG";
            FormClosed += FormRepararDigito_327LG_FormClosed;
            Load += FormRepararDigito_327LG_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRecalcular;
        private Button btnRestaurar;
        private Button btnSalir;
        private Label lblTitulo;
        private Label lblInconsistencias;
    }
}