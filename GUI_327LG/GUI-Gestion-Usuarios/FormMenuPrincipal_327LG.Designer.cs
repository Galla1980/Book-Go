namespace GUI_327LG
{
    partial class FormMenuPrincipal_327LG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuPrincipal_327LG));
            pic = new PictureBox();
            lblBienvenido = new Label();
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            SuspendLayout();
            // 
            // pic
            // 
            pic.Image = (Image)resources.GetObject("pic.Image");
            pic.Location = new Point(583, 233);
            pic.Name = "pic";
            pic.Size = new Size(205, 205);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.TabIndex = 0;
            pic.TabStop = false;
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Location = new Point(84, 356);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(0, 15);
            lblBienvenido.TabIndex = 2;
            // 
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 450);
            Controls.Add(lblBienvenido);
            Controls.Add(pic);
            Name = "FormMenuPrincipal";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "FormMenuPrincipal";
            Load += FormMenuPrincipal_Load;
            Resize += FormMenuPrincipal_Resize;
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pic;
        private Label lblBienvenido;
    }
}