namespace GUI_327LG.GUIRF1
{
    partial class FormRegSancion_327LG
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
            lblRazon = new Label();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            btnRegistrarSancion = new Button();
            txtRazon = new TextBox();
            SuspendLayout();
            // 
            // lblTituloForm
            // 
            lblTituloForm.AutoSize = true;
            lblTituloForm.Font = new Font("Segoe UI", 20F);
            lblTituloForm.Location = new Point(57, 9);
            lblTituloForm.Name = "lblTituloForm";
            lblTituloForm.Size = new Size(218, 37);
            lblTituloForm.TabIndex = 1;
            lblTituloForm.Text = "Registrar sanción";
            // 
            // lblRazon
            // 
            lblRazon.AutoSize = true;
            lblRazon.Font = new Font("Segoe UI", 12F);
            lblRazon.Location = new Point(12, 67);
            lblRazon.Name = "lblRazon";
            lblRazon.Size = new Size(56, 21);
            lblRazon.TabIndex = 2;
            lblRazon.Text = "Razón:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 12F);
            lblDescripcion.Location = new Point(12, 164);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(94, 21);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(12, 188);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(303, 141);
            txtDescripcion.TabIndex = 4;
            // 
            // btnRegistrarSancion
            // 
            btnRegistrarSancion.Font = new Font("Segoe UI", 14F);
            btnRegistrarSancion.Location = new Point(97, 363);
            btnRegistrarSancion.Name = "btnRegistrarSancion";
            btnRegistrarSancion.Size = new Size(141, 66);
            btnRegistrarSancion.TabIndex = 6;
            btnRegistrarSancion.Text = "Registrar sanción";
            btnRegistrarSancion.UseVisualStyleBackColor = true;
            btnRegistrarSancion.Click += btnRegistrarSancion_Click;
            // 
            // txtRazon
            // 
            txtRazon.Enabled = false;
            txtRazon.Location = new Point(12, 91);
            txtRazon.Name = "txtRazon";
            txtRazon.Size = new Size(100, 23);
            txtRazon.TabIndex = 7;
            // 
            // FormRegSancion_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 441);
            Controls.Add(txtRazon);
            Controls.Add(btnRegistrarSancion);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(lblRazon);
            Controls.Add(lblTituloForm);
            Name = "FormRegSancion_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegSancion";
            Load += FormRegSancion_327LG_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloForm;
        private Label lblRazon;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Button btnRegistrarSancion;
        private TextBox txtRazon;
    }
}