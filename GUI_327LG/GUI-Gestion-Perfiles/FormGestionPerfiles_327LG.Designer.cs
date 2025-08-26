namespace GUI_327LG.GUI_Gestion_Perfiles
{
    partial class FormGestionPerfiles_327LG
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
            tvwFamilias = new TreeView();
            tvwPerfiles = new TreeView();
            lstPermisos = new ListBox();
            lblPermisos = new Label();
            lblFamilias = new Label();
            lblPerfil = new Label();
            lblTitulo = new Label();
            btnEliminarComp = new Button();
            btnEliminarPerfil = new Button();
            btnAsignarFam = new Button();
            btnAsignarPermiso = new Button();
            lblNombrePerfil = new Label();
            txtNombrePerfil = new TextBox();
            btnAgregarPerfil = new Button();
            SuspendLayout();
            // 
            // tvwFamilias
            // 
            tvwFamilias.Location = new Point(510, 118);
            tvwFamilias.Name = "tvwFamilias";
            tvwFamilias.Size = new Size(250, 334);
            tvwFamilias.TabIndex = 0;
            tvwFamilias.AfterSelect += tvwFamilias_AfterSelect;
            // 
            // tvwPerfiles
            // 
            tvwPerfiles.Location = new Point(224, 118);
            tvwPerfiles.Name = "tvwPerfiles";
            tvwPerfiles.Size = new Size(250, 334);
            tvwPerfiles.TabIndex = 1;
            tvwPerfiles.AfterSelect += tvwPerfiles_AfterSelect;
            // 
            // lstPermisos
            // 
            lstPermisos.FormattingEnabled = true;
            lstPermisos.ItemHeight = 15;
            lstPermisos.Location = new Point(793, 118);
            lstPermisos.Name = "lstPermisos";
            lstPermisos.Size = new Size(250, 334);
            lstPermisos.TabIndex = 2;
            // 
            // lblPermisos
            // 
            lblPermisos.AutoSize = true;
            lblPermisos.Font = new Font("Segoe UI", 12F);
            lblPermisos.Location = new Point(793, 85);
            lblPermisos.Name = "lblPermisos";
            lblPermisos.Size = new Size(80, 21);
            lblPermisos.TabIndex = 17;
            lblPermisos.Text = "Permisos: ";
            // 
            // lblFamilias
            // 
            lblFamilias.AutoSize = true;
            lblFamilias.Font = new Font("Segoe UI", 12F);
            lblFamilias.Location = new Point(510, 85);
            lblFamilias.Name = "lblFamilias";
            lblFamilias.Size = new Size(69, 21);
            lblFamilias.TabIndex = 16;
            lblFamilias.Text = "Familias:";
            // 
            // lblPerfil
            // 
            lblPerfil.AutoSize = true;
            lblPerfil.Font = new Font("Segoe UI", 12F);
            lblPerfil.Location = new Point(224, 85);
            lblPerfil.Name = "lblPerfil";
            lblPerfil.Size = new Size(63, 21);
            lblPerfil.TabIndex = 15;
            lblPerfil.Text = "Perfiles:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F);
            lblTitulo.Location = new Point(437, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(238, 37);
            lblTitulo.TabIndex = 14;
            lblTitulo.Text = "Gestión de perfiles";
            // 
            // btnEliminarComp
            // 
            btnEliminarComp.Location = new Point(44, 315);
            btnEliminarComp.Name = "btnEliminarComp";
            btnEliminarComp.Size = new Size(106, 40);
            btnEliminarComp.TabIndex = 21;
            btnEliminarComp.Text = "Eliminar componente";
            btnEliminarComp.UseVisualStyleBackColor = true;
            btnEliminarComp.Click += btnEliminarComp_Click;
            // 
            // btnEliminarPerfil
            // 
            btnEliminarPerfil.Location = new Point(44, 249);
            btnEliminarPerfil.Name = "btnEliminarPerfil";
            btnEliminarPerfil.Size = new Size(106, 40);
            btnEliminarPerfil.TabIndex = 20;
            btnEliminarPerfil.Text = "Eliminar perfil";
            btnEliminarPerfil.UseVisualStyleBackColor = true;
            btnEliminarPerfil.Click += btnEliminarPerfil_Click;
            // 
            // btnAsignarFam
            // 
            btnAsignarFam.Location = new Point(44, 179);
            btnAsignarFam.Name = "btnAsignarFam";
            btnAsignarFam.Size = new Size(106, 40);
            btnAsignarFam.TabIndex = 19;
            btnAsignarFam.Text = "Asignar familia";
            btnAsignarFam.UseVisualStyleBackColor = true;
            btnAsignarFam.Click += btnAsignarFam_Click;
            // 
            // btnAsignarPermiso
            // 
            btnAsignarPermiso.Location = new Point(44, 118);
            btnAsignarPermiso.Name = "btnAsignarPermiso";
            btnAsignarPermiso.Size = new Size(106, 40);
            btnAsignarPermiso.TabIndex = 18;
            btnAsignarPermiso.Text = "Asignar permiso";
            btnAsignarPermiso.UseVisualStyleBackColor = true;
            btnAsignarPermiso.Click += btnAsignarPermiso_Click;
            // 
            // lblNombrePerfil
            // 
            lblNombrePerfil.AutoSize = true;
            lblNombrePerfil.Location = new Point(224, 477);
            lblNombrePerfil.Name = "lblNombrePerfil";
            lblNombrePerfil.Size = new Size(97, 15);
            lblNombrePerfil.TabIndex = 24;
            lblNombrePerfil.Text = "Nombre de perfil";
            // 
            // txtNombrePerfil
            // 
            txtNombrePerfil.Location = new Point(224, 495);
            txtNombrePerfil.Name = "txtNombrePerfil";
            txtNombrePerfil.Size = new Size(106, 23);
            txtNombrePerfil.TabIndex = 23;
            // 
            // btnAgregarPerfil
            // 
            btnAgregarPerfil.Location = new Point(374, 485);
            btnAgregarPerfil.Name = "btnAgregarPerfil";
            btnAgregarPerfil.Size = new Size(100, 40);
            btnAgregarPerfil.TabIndex = 22;
            btnAgregarPerfil.Text = "Agregar perfil";
            btnAgregarPerfil.UseVisualStyleBackColor = true;
            btnAgregarPerfil.Click += btnAgregarPerfil_Click;
            // 
            // FormGestionPerfiles_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 561);
            Controls.Add(lblNombrePerfil);
            Controls.Add(txtNombrePerfil);
            Controls.Add(btnAgregarPerfil);
            Controls.Add(btnEliminarComp);
            Controls.Add(btnEliminarPerfil);
            Controls.Add(btnAsignarFam);
            Controls.Add(btnAsignarPermiso);
            Controls.Add(lblPermisos);
            Controls.Add(lblFamilias);
            Controls.Add(lblPerfil);
            Controls.Add(lblTitulo);
            Controls.Add(lstPermisos);
            Controls.Add(tvwPerfiles);
            Controls.Add(tvwFamilias);
            Name = "FormGestionPerfiles_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormGestionPerfiles_327LG";
            Load += FormGestionPerfiles_327LG_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView tvwFamilias;
        private TreeView tvwPerfiles;
        private ListBox lstPermisos;
        private Label lblPermisos;
        private Label lblFamilias;
        private Label lblPerfil;
        private Label lblTitulo;
        private Button btnEliminarComp;
        private Button btnEliminarPerfil;
        private Button btnAsignarFam;
        private Button btnAsignarPermiso;
        private Label lblNombrePerfil;
        private TextBox txtNombrePerfil;
        private Button btnAgregarPerfil;
    }
}