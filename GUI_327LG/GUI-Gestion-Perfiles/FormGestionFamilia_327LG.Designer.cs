namespace GUI_327LG.GUI_Gestion_Perfiles
{
    partial class FormGestionFamilia_327LG
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
            lstPermisos = new ListBox();
            tvwFamilias = new TreeView();
            btnAgregarFam = new Button();
            txtNombreFam = new TextBox();
            lblNombreFam = new Label();
            btnAsignarPermiso = new Button();
            btnAsignarFam = new Button();
            btnEliminarFam = new Button();
            btnEliminarComp = new Button();
            tvwFamSel = new TreeView();
            lblFamilias = new Label();
            lblFamAgregar = new Label();
            lblPermisos = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F);
            lblTitulo.Location = new Point(364, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(243, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de familias";
            // 
            // lstPermisos
            // 
            lstPermisos.FormattingEnabled = true;
            lstPermisos.ItemHeight = 15;
            lstPermisos.Location = new Point(720, 119);
            lstPermisos.Name = "lstPermisos";
            lstPermisos.Size = new Size(250, 334);
            lstPermisos.TabIndex = 1;
            // 
            // tvwFamilias
            // 
            tvwFamilias.Location = new Point(151, 119);
            tvwFamilias.Name = "tvwFamilias";
            tvwFamilias.Size = new Size(250, 334);
            tvwFamilias.TabIndex = 2;
            tvwFamilias.AfterSelect += tvwFamilias_AfterSelect;
            // 
            // btnAgregarFam
            // 
            btnAgregarFam.Location = new Point(301, 478);
            btnAgregarFam.Name = "btnAgregarFam";
            btnAgregarFam.Size = new Size(100, 40);
            btnAgregarFam.TabIndex = 3;
            btnAgregarFam.Text = "Agregar Familia";
            btnAgregarFam.UseVisualStyleBackColor = true;
            btnAgregarFam.Click += btnAgregarFam_Click;
            // 
            // txtNombreFam
            // 
            txtNombreFam.Location = new Point(151, 488);
            txtNombreFam.Name = "txtNombreFam";
            txtNombreFam.Size = new Size(106, 23);
            txtNombreFam.TabIndex = 4;
            // 
            // lblNombreFam
            // 
            lblNombreFam.AutoSize = true;
            lblNombreFam.Location = new Point(151, 470);
            lblNombreFam.Name = "lblNombreFam";
            lblNombreFam.Size = new Size(106, 15);
            lblNombreFam.TabIndex = 5;
            lblNombreFam.Text = "Nombre de familia";
            // 
            // btnAsignarPermiso
            // 
            btnAsignarPermiso.Location = new Point(22, 119);
            btnAsignarPermiso.Name = "btnAsignarPermiso";
            btnAsignarPermiso.Size = new Size(100, 40);
            btnAsignarPermiso.TabIndex = 6;
            btnAsignarPermiso.Text = "Asignar permiso";
            btnAsignarPermiso.UseVisualStyleBackColor = true;
            btnAsignarPermiso.Click += btnAsignarPermiso_Click;
            // 
            // btnAsignarFam
            // 
            btnAsignarFam.Location = new Point(22, 180);
            btnAsignarFam.Name = "btnAsignarFam";
            btnAsignarFam.Size = new Size(100, 40);
            btnAsignarFam.TabIndex = 7;
            btnAsignarFam.Text = "Asignar familia";
            btnAsignarFam.UseVisualStyleBackColor = true;
            btnAsignarFam.Click += btnAsignarFam_Click;
            // 
            // btnEliminarFam
            // 
            btnEliminarFam.Location = new Point(22, 250);
            btnEliminarFam.Name = "btnEliminarFam";
            btnEliminarFam.Size = new Size(100, 40);
            btnEliminarFam.TabIndex = 8;
            btnEliminarFam.Text = "Eliminar familia";
            btnEliminarFam.UseVisualStyleBackColor = true;
            btnEliminarFam.Click += btnEliminarFam_Click;
            // 
            // btnEliminarComp
            // 
            btnEliminarComp.Location = new Point(22, 316);
            btnEliminarComp.Name = "btnEliminarComp";
            btnEliminarComp.Size = new Size(100, 40);
            btnEliminarComp.TabIndex = 9;
            btnEliminarComp.Text = "Eliminar componente";
            btnEliminarComp.UseVisualStyleBackColor = true;
            btnEliminarComp.Click += btnEliminarComp_Click;
            // 
            // tvwFamSel
            // 
            tvwFamSel.Location = new Point(437, 119);
            tvwFamSel.Name = "tvwFamSel";
            tvwFamSel.Size = new Size(250, 334);
            tvwFamSel.TabIndex = 10;
            tvwFamSel.AfterSelect += tvwFamSel_AfterSelect;
            // 
            // lblFamilias
            // 
            lblFamilias.AutoSize = true;
            lblFamilias.Font = new Font("Segoe UI", 12F);
            lblFamilias.Location = new Point(151, 85);
            lblFamilias.Name = "lblFamilias";
            lblFamilias.Size = new Size(98, 21);
            lblFamilias.TabIndex = 11;
            lblFamilias.Text = "Familia base:";
            // 
            // lblFamAgregar
            // 
            lblFamAgregar.AutoSize = true;
            lblFamAgregar.Font = new Font("Segoe UI", 12F);
            lblFamAgregar.Location = new Point(437, 85);
            lblFamAgregar.Name = "lblFamAgregar";
            lblFamAgregar.Size = new Size(132, 21);
            lblFamAgregar.TabIndex = 12;
            lblFamAgregar.Text = "Familia a agregar:";
            // 
            // lblPermisos
            // 
            lblPermisos.AutoSize = true;
            lblPermisos.Font = new Font("Segoe UI", 12F);
            lblPermisos.Location = new Point(720, 85);
            lblPermisos.Name = "lblPermisos";
            lblPermisos.Size = new Size(80, 21);
            lblPermisos.TabIndex = 13;
            lblPermisos.Text = "Permisos: ";
            // 
            // FormGestionFamilia_327LG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 544);
            Controls.Add(lblPermisos);
            Controls.Add(lblFamAgregar);
            Controls.Add(lblFamilias);
            Controls.Add(tvwFamSel);
            Controls.Add(btnEliminarComp);
            Controls.Add(btnEliminarFam);
            Controls.Add(btnAsignarFam);
            Controls.Add(btnAsignarPermiso);
            Controls.Add(lblNombreFam);
            Controls.Add(txtNombreFam);
            Controls.Add(btnAgregarFam);
            Controls.Add(tvwFamilias);
            Controls.Add(lstPermisos);
            Controls.Add(lblTitulo);
            Name = "FormGestionFamilia_327LG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormGestionFamilia_327LG";
            Load += FormGestionFamilia_327LG_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private ListBox lstPermisos;
        private TreeView tvwFamilias;
        private Button btnAgregarFam;
        private TextBox txtNombreFam;
        private Label lblNombreFam;
        private Button btnAsignarPermiso;
        private Button btnAsignarFam;
        private Button btnEliminarFam;
        private Button btnEliminarComp;
        private TreeView tvwFamSel;
        private Label lblFamilias;
        private Label lblFamAgregar;
        private Label lblPermisos;
    }
}