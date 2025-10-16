using BLL_327LG;
using Services_327LG.Composite_327LG;
using Services_327LG.Observer_327LG;
using Services_327LG.Singleton_327LG;

namespace GUI_327LG.GUI_Gestion_Perfiles
{
    public partial class FormGestionPerfiles_327LG : Form, IObserverIdioma_327LG
    {
        BLLPermiso_327LG bllPermiso_327LG;
        BLLFamilia_327LG bllFamilia_327LG;
        BLLPerfil_327LG bllPerfil_327LG;

        LanguageManager_327LG LM_327LG;

        private TreeNode nodoSeleccionadoPerfil_327LG;
        private TreeNode nodoSeleccionadoFamilia_327LG;

        public FormGestionPerfiles_327LG()
        {
            InitializeComponent();

            bllPermiso_327LG = new BLLPermiso_327LG();
            bllFamilia_327LG = new BLLFamilia_327LG();
            bllPerfil_327LG = new BLLPerfil_327LG();

            LM_327LG = LanguageManager_327LG.Instance_327LG;
            LM_327LG.AgregarObservador_327LG(this);
            Actualizar_327LG();

        }
        private void FormGestionPerfiles_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#055b6b");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }
            CargarGrillas_327LG();
        }

        public void CargarGrillas_327LG()
        {
            lstPermisos.Items.Clear();
            foreach (BEPermiso_327LG permiso in bllPermiso_327LG.ObtenerPermisos_327LG())
            {
                lstPermisos.Items.Add(permiso);
            }

            tvwFamilias.Nodes.Clear();
            tvwPerfiles.Nodes.Clear();

            List<BEFamilia_327LG> familias = bllFamilia_327LG.ObtenerFamilias_327LG();
            List<BEPerfil_327LG> perfiles = bllPerfil_327LG.ObtenerPerfiles_327LG();

            foreach (BEFamilia_327LG familia in familias)
            {
                TreeNode nodo = NuevoNodo_327LG(familia);
                tvwFamilias.Nodes.Add(nodo);
                nodo.Expand();
            }

            foreach (BEPerfil_327LG perfil in perfiles)
            {
                TreeNode nodo = NuevoNodo_327LG(perfil);
                tvwPerfiles.Nodes.Add(nodo);
                nodo.Expand();
            }

            nodoSeleccionadoFamilia_327LG = null;
            nodoSeleccionadoPerfil_327LG = null;
        }

        private TreeNode NuevoNodo_327LG(BEPerfil_327LG pNodo)
        {
            TreeNode nodo = new TreeNode(pNodo.Nombre_327LG);
            nodo.Tag = pNodo;

            if (!(pNodo is BEPermiso_327LG))
            {
                List<BEPerfil_327LG> hijos = pNodo.ObtenerHijos_327LG();
                if (hijos != null && hijos.Count > 0)
                {
                    foreach (BEPerfil_327LG hijo in hijos)
                    {
                        nodo.Nodes.Add(NuevoNodo_327LG(hijo));
                    }
                }
            }

            return nodo;
        }


        private void btnAsignarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormGestionPerfiles_327LG");
                if (lstPermisos.SelectedItems.Count <= 0) throw new Exception(LM_327LG.ObtenerString("exception.permiso_no_seleccionado"));
                if (nodoSeleccionadoPerfil_327LG == null) throw new Exception(LM_327LG.ObtenerString("exception.perfil_no_seleccionado"));
                if ((nodoSeleccionadoPerfil_327LG.Tag is BEFamilia_327LG) || nodoSeleccionadoPerfil_327LG.Tag is BEPermiso_327LG) throw new Exception(LM_327LG.ObtenerString("exception.debe_seleccionar_perfil"));
                if (nodoSeleccionadoPerfil_327LG.Parent != null) throw new Exception(LM_327LG.ObtenerString("exception.debe_seleccionar_perfil"));
                BEPerfil_327LG perfil = (BEPerfil_327LG)nodoSeleccionadoPerfil_327LG.Tag;
                BEPermiso_327LG permiso = (BEPermiso_327LG)lstPermisos.SelectedItem;
                //if (perfil.Codigo_327LG == SessionManager_327LG.Instancia.Usuario.rol_327LG.Codigo_327LG) throw new Exception(LM_327LG.ObtenerString("exception.perfil_actual"));
                bllPerfil_327LG.AsignarPermiso_327LG(perfil, permiso); 
                CargarGrillas_327LG();
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
        private void btnAsignarFam_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormGestionPerfiles_327LG");
                if (nodoSeleccionadoPerfil_327LG == null) throw new Exception(LM_327LG.ObtenerString("exception.perfil_no_seleccionado"));
                if (nodoSeleccionadoFamilia_327LG == null) throw new Exception(LM_327LG.ObtenerString("exception.familiaagregada_no_seleccionada"));
                if (!(nodoSeleccionadoPerfil_327LG.Tag is BEPerfil_327LG)) throw new Exception(LM_327LG.ObtenerString("exception.debe_seleccionar_perfil"));
                if(!(nodoSeleccionadoFamilia_327LG.Tag is BEFamilia_327LG)) throw new Exception(LM_327LG.ObtenerString("exception."));
                if(nodoSeleccionadoPerfil_327LG.Parent != null) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_perfil_simple"));
                if (nodoSeleccionadoFamilia_327LG.Parent != null) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_familia_simple"));
                BEPerfil_327LG perfil = (BEPerfil_327LG)nodoSeleccionadoPerfil_327LG.Tag;
                BEFamilia_327LG familia = (BEFamilia_327LG)nodoSeleccionadoFamilia_327LG.Tag;
                if (perfil.Codigo_327LG == SessionManager_327LG.Instancia.Usuario.rol_327LG.Codigo_327LG) throw new Exception(LM_327LG.ObtenerString("exception.perfil_actual"));
                bllPerfil_327LG.AsignarFamilia_327LG(perfil, familia);
                CargarGrillas_327LG();
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnEliminarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormGestionPerfiles_327LG");
                if (nodoSeleccionadoPerfil_327LG == null) throw new Exception(LM_327LG.ObtenerString("exception.debe_seleccionar_perfil"));
                if (nodoSeleccionadoPerfil_327LG.Parent != null) throw new Exception(LM_327LG.ObtenerString("exception.debe_seleccionar_perfil"));
                BEPerfil_327LG perfil = (BEPerfil_327LG)nodoSeleccionadoPerfil_327LG.Tag;
                if (perfil.Codigo_327LG == SessionManager_327LG.Instancia.Usuario.rol_327LG.Codigo_327LG) throw new Exception(LM_327LG.ObtenerString("exception.perfil_actual"));

                if (MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.confirmar_eliminar_perfil"), LM_327LG.ObtenerString("messagebox.titulo.confirmar_eliminar_perfil"), LM_327LG.ObtenerString("messagebox.button.aceptar"), LM_327LG.ObtenerString("messagebox.button.cancelar"), MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    bllPerfil_327LG.EliminarPerfil_327LG(perfil);
                    CargarGrillas_327LG();
                }
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnEliminarComp_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormGestionPerfiles_327LG");
                if (nodoSeleccionadoPerfil_327LG == null || nodoSeleccionadoPerfil_327LG.Parent == null || nodoSeleccionadoPerfil_327LG.Parent.Parent != null) throw new Exception(LM_327LG.ObtenerString("exception.debe_seleccionar_componente"));
                BEPerfil_327LG perfil = (BEPerfil_327LG)nodoSeleccionadoPerfil_327LG.Parent.Tag;
                if (perfil.Codigo_327LG == SessionManager_327LG.Instancia.Usuario.rol_327LG.Codigo_327LG) throw new Exception(LM_327LG.ObtenerString("exception.perfil_actual"));

                BEPerfil_327LG componente = (BEPerfil_327LG)nodoSeleccionadoPerfil_327LG.Tag;
                perfil.EliminarHijo_327LG(componente);
                bllPerfil_327LG.EliminarComponente_327LG(perfil, componente);
                CargarGrillas_327LG();
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnAgregarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormGestionPerfiles_327LG");
                string nombre = txtNombrePerfil.Text.Trim();
                if (nombre == string.Empty) throw new Exception(LM_327LG.ObtenerString("exception.nombre_vacio"));
                bllPerfil_327LG.CrearPerfil_327LG(nombre);
                CargarGrillas_327LG();
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormGestionPerfiles_327LG");
            lblTitulo.Text = LM_327LG.ObtenerString("label.lblTitulo");
            lblPerfil.Text = LM_327LG.ObtenerString("label.lblPerfil");
            lblFamilias.Text = LM_327LG.ObtenerString("label.lblFamilia");
            lblPermisos.Text = LM_327LG.ObtenerString("label.lblPermisos");
            lblNombrePerfil.Text = LM_327LG.ObtenerString("label.lblNombrePerfil");

            btnAsignarPermiso.Text = LM_327LG.ObtenerString("button.btnAsignarPermiso");
            btnAsignarFam.Text = LM_327LG.ObtenerString("button.btnAsignarFam");
            btnEliminarPerfil.Text = LM_327LG.ObtenerString("button.btnEliminarPerfil");
            btnEliminarComp.Text = LM_327LG.ObtenerString("button.btnEliminarComp");
            btnAgregarPerfil.Text = LM_327LG.ObtenerString("button.btnAgregarPerfil");
        }

        private void tvwPerfiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (nodoSeleccionadoPerfil_327LG != null)
            {
                nodoSeleccionadoPerfil_327LG.BackColor = Color.White;
                nodoSeleccionadoPerfil_327LG.ForeColor = Color.Black;
            }
            nodoSeleccionadoPerfil_327LG = e.Node;
            nodoSeleccionadoPerfil_327LG.BackColor = SystemColors.Highlight;
            nodoSeleccionadoPerfil_327LG.ForeColor = SystemColors.HighlightText;
        }

        private void tvwFamilias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (nodoSeleccionadoFamilia_327LG != null)
            {
                nodoSeleccionadoFamilia_327LG.BackColor = Color.White;
                nodoSeleccionadoFamilia_327LG.ForeColor = Color.Black;
            }
            nodoSeleccionadoFamilia_327LG = e.Node;
            nodoSeleccionadoFamilia_327LG.BackColor = SystemColors.Highlight;
            nodoSeleccionadoFamilia_327LG.ForeColor = SystemColors.HighlightText;
        }
    }
}
