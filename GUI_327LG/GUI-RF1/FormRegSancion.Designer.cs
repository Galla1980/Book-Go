namespace GUI_327LG.GUIRF1
{
    partial class FormRegSancion
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
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
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
            // textBox1
            // 
            textBox1.Location = new Point(12, 188);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(303, 141);
            textBox1.TabIndex = 4;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 91);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "Devolución Tardía";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(97, 363);
            button1.Name = "button1";
            button1.Size = new Size(141, 66);
            button1.TabIndex = 6;
            button1.Text = "Registrar sanción";
            button1.UseVisualStyleBackColor = true;
            // 
            // FormRegSancion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 441);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(lblDescripcion);
            Controls.Add(lblRazon);
            Controls.Add(lblTituloForm);
            Name = "FormRegSancion";
            Text = "FormRegSancion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloForm;
        private Label lblRazon;
        private Label lblDescripcion;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Button button1;
    }
}