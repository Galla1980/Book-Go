namespace GUI_327LG
{
    partial class FormMDI_327LG
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
            mnsPestañas = new MenuStrip();
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
            mnsIdioma = new MenuStrip();
            tsmiIdioma = new ToolStripMenuItem();
            tscmbIdioma = new ToolStripComboBox();
            mnsPestañas.SuspendLayout();
            mnsIdioma.SuspendLayout();
            SuspendLayout();
            // 
            // mnsPestañas
            // 
            mnsPestañas.BackColor = SystemColors.Control;
            mnsPestañas.Items.AddRange(new ToolStripItem[] { usuarioItem, adminItem, maestroItem, prestamosItem, reposicionItem, reporteItem, ayudaItem });
            mnsPestañas.Location = new Point(0, 0);
            mnsPestañas.Name = "mnsPestañas";
            mnsPestañas.RenderMode = ToolStripRenderMode.Professional;
            mnsPestañas.Size = new Size(1208, 24);
            mnsPestañas.TabIndex = 2;
            mnsPestañas.Text = "menuStrip1";
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
            // mnsIdioma
            // 
            mnsIdioma.Dock = DockStyle.Bottom;
            mnsIdioma.Items.AddRange(new ToolStripItem[] { tsmiIdioma, tscmbIdioma });
            mnsIdioma.Location = new Point(0, 586);
            mnsIdioma.Name = "mnsIdioma";
            mnsIdioma.Size = new Size(1208, 27);
            mnsIdioma.TabIndex = 8;
            mnsIdioma.Text = "menuStrip1";
            // 
            // tsmiIdioma
            // 
            tsmiIdioma.Enabled = false;
            tsmiIdioma.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tsmiIdioma.Name = "tsmiIdioma";
            tsmiIdioma.Size = new Size(60, 23);
            tsmiIdioma.Text = "Idioma:";
            // 
            // tscmbIdioma
            // 
            tscmbIdioma.Items.AddRange(new object[] { "Español", "English" });
            tscmbIdioma.Name = "tscmbIdioma";
            tscmbIdioma.Size = new Size(121, 23);
            tscmbIdioma.Text = "Español";
            tscmbIdioma.SelectedIndexChanged += tscmbIdioma_SelectedIndexChanged;
            // 
            // FormMDI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1208, 613);
            Controls.Add(mnsPestañas);
            Controls.Add(mnsIdioma);
            IsMdiContainer = true;
            MainMenuStrip = mnsIdioma;
            Name = "FormMDI";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de gestion de biblioteca";
            Load += FormMDI_Load;
            mnsPestañas.ResumeLayout(false);
            mnsPestañas.PerformLayout();
            mnsIdioma.ResumeLayout(false);
            mnsIdioma.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnsPestañas;
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
        private MenuStrip mnsIdioma;
        private ToolStripMenuItem tsmiIdioma;
        private ToolStripComboBox tscmbIdioma;
    }
}
