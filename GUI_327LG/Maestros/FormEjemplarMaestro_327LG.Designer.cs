namespace GUI_327LG.Maestros
{
    partial class FormEjemplarMaestro_327LG
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
            dgvLibros = new DataGridView();
            lblTituloForm = new Label();
            btnAgregarEjemplar = new Button();
            lblLibros = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AllowUserToDeleteRows = false;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(12, 106);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.Size = new Size(558, 201);
            dgvLibros.TabIndex = 0;
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Segoe UI", 20F);
            lblTituloForm.Location = new Point(165, 9);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(250, 37);
            lblTituloForm.TabIndex = 1;
            lblTituloForm.Text = "Maestro Ejemplares";
            // 
            // btnAgregarEjemplar
            // 
            btnAgregarEjemplar.Font = new Font("Segoe UI", 15F);
            btnAgregarEjemplar.Location = new Point(186, 346);
            btnAgregarEjemplar.Name = "btnAgregarEjemplar";
            btnAgregarEjemplar.Size = new Size(193, 48);
            btnAgregarEjemplar.TabIndex = 2;
            btnAgregarEjemplar.Text = "Agregar ejemplar";
            btnAgregarEjemplar.UseVisualStyleBackColor = true;
            btnAgregarEjemplar.Click += btnAgregarEjemplar_Click;
            // 
            // lblLibros
            // 
            lblLibros.AutoSize = true;
            lblLibros.Font = new Font("Segoe UI", 15F);
            lblLibros.Location = new Point(12, 75);
            lblLibros.Name = "lblLibros";
            lblLibros.Size = new Size(69, 28);
            lblLibros.TabIndex = 3;
            lblLibros.Text = "Libros:";
            // 
            // FormEjemplarMaestro_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 450);
            Controls.Add(lblLibros);
            Controls.Add(btnAgregarEjemplar);
            Controls.Add(lblTituloForm);
            Controls.Add(dgvLibros);
            Name = "FormEjemplarMaestro_327LG";
            Text = "FormEjemplarMaestro_327LG";
            Load += FormEjemplarMaestro_327LG_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLibros;
        private Label lblTituloForm;
        private Button btnAgregarEjemplar;
        private Label lblLibros;
    }
}