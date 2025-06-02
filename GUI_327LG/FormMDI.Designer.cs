namespace GUI_327LG
{
    partial class FormMDI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            usuarioItem = new ToolStripMenuItem();
            iniciarSesiónItem = new ToolStripMenuItem();
            cambiarContraseñaItem = new ToolStripMenuItem();
            cerrarSesiónItem = new ToolStripMenuItem();
            adminItem = new ToolStripMenuItem();
            gestiónUsuariosMenuItem = new ToolStripMenuItem();
            maestroItem = new ToolStripMenuItem();
            prestamosItem = new ToolStripMenuItem();
            reposicionItem = new ToolStripMenuItem();
            reporteItem = new ToolStripMenuItem();
            ayudaItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.Items.AddRange(new ToolStripItem[] { usuarioItem, adminItem, maestroItem, prestamosItem, reposicionItem, reporteItem, ayudaItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Size = new Size(1208, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // usuarioItem
            // 
            usuarioItem.DropDownItems.AddRange(new ToolStripItem[] { iniciarSesiónItem, cambiarContraseñaItem, cerrarSesiónItem });
            usuarioItem.Name = "usuarioItem";
            usuarioItem.Size = new Size(59, 20);
            usuarioItem.Text = "Usuario";
            // 
            // iniciarSesiónItem
            // 
            iniciarSesiónItem.Name = "iniciarSesiónItem";
            iniciarSesiónItem.Size = new Size(180, 22);
            iniciarSesiónItem.Text = "Iniciar sesión";
            iniciarSesiónItem.Click += iniciarSesiónItem_Click;
            // 
            // cambiarContraseñaItem
            // 
            cambiarContraseñaItem.Name = "cambiarContraseñaItem";
            cambiarContraseñaItem.Size = new Size(180, 22);
            cambiarContraseñaItem.Text = "Cambiar contraseña";
            cambiarContraseñaItem.Click += cambiarContraseñaItem_Click;
            // 
            // cerrarSesiónItem
            // 
            cerrarSesiónItem.Name = "cerrarSesiónItem";
            cerrarSesiónItem.Size = new Size(180, 22);
            cerrarSesiónItem.Text = "Cerrar sesión";
            cerrarSesiónItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // adminItem
            // 
            adminItem.DropDownItems.AddRange(new ToolStripItem[] { gestiónUsuariosMenuItem });
            adminItem.Name = "adminItem";
            adminItem.Size = new Size(55, 20);
            adminItem.Text = "Admin";
            // 
            // gestiónUsuariosMenuItem
            // 
            gestiónUsuariosMenuItem.Name = "gestiónUsuariosMenuItem";
            gestiónUsuariosMenuItem.Size = new Size(177, 22);
            gestiónUsuariosMenuItem.Text = "Gestión de usuarios";
            gestiónUsuariosMenuItem.Click += gestiónUsuariosMenuItem_Click;
            // 
            // maestroItem
            // 
            maestroItem.Name = "maestroItem";
            maestroItem.Size = new Size(62, 20);
            maestroItem.Text = "Maestro";
            // 
            // prestamosItem
            // 
            prestamosItem.Name = "prestamosItem";
            prestamosItem.Size = new Size(74, 20);
            prestamosItem.Text = "Prestamos";
            // 
            // reposicionItem
            // 
            reposicionItem.Name = "reposicionItem";
            reposicionItem.Size = new Size(77, 20);
            reposicionItem.Text = "Reposición";
            // 
            // reporteItem
            // 
            reporteItem.Name = "reporteItem";
            reporteItem.Size = new Size(60, 20);
            reporteItem.Text = "Reporte";
            // 
            // ayudaItem
            // 
            ayudaItem.Name = "ayudaItem";
            ayudaItem.Size = new Size(53, 20);
            ayudaItem.Text = "Ayuda";
            // 
            // FormMDI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1208, 613);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            Name = "FormMDI";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de gestion de biblioteca";
            Load += FormMDI_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem usuarioItem;
        private ToolStripMenuItem iniciarSesiónItem;
        private ToolStripMenuItem cerrarSesiónItem;
        private ToolStripMenuItem adminItem;
        private ToolStripMenuItem maestroItem;
        private ToolStripMenuItem prestamosItem;
        private ToolStripMenuItem reposicionItem;
        private ToolStripMenuItem reporteItem;
        private ToolStripMenuItem ayudaItem;
        private ToolStripMenuItem gestiónUsuariosMenuItem;
        private ToolStripMenuItem cambiarContraseñaItem;
    }
}
