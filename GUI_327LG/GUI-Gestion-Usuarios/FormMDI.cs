using BLL_327LG;
using Services_327LG;
using Services_327LG.Observer_327LG;
using Services_327LG.Singleton_327LG;
namespace GUI_327LG
{

    public partial class FormMDI : Form, IObserverIdioma_327LG
    {
        private FormMenuPrincipal menuPrincipal_327LG;
        BLLUsuario_327LG bllUsuario_327LG;

        public FormMDI()
        {
            InitializeComponent();
            ActualizarFormulario_327LG();
            mnsPestañas.BackColor = ColorTranslator.FromHtml("#EAEAEA");
            mnsPestañas.ForeColor = ColorTranslator.FromHtml("#055b6b");
            bllUsuario_327LG = new BLLUsuario_327LG();
            LanguageManager.Instance.AgregarObservador_327LG(this);
            LanguageManager.Instance.CargarIdioma("spanish");
        }

        private void FormMDI_Load(object sender, EventArgs e)
        {
            menuPrincipal_327LG = new FormMenuPrincipal();
            menuPrincipal_327LG.MdiParent = this;
            menuPrincipal_327LG.Dock = DockStyle.Fill;
            menuPrincipal_327LG.Show();
        }


        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SessionManager_327LG.Instancia.IsLoggedIn_327LG()) throw new Exception(LanguageManager.Instance.ObtenerString("FormMDI.exception.sesion_no_iniciada"));
                if (MessageBox.Show(LanguageManager.Instance.ObtenerString("FormMDI.messagebox.confirmar_cierre_sesion"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    bllUsuario_327LG.CerrarSesion_327LG();
                    ActualizarFormulario_327LG();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ActualizarFormulario_327LG()
        {
            bool logueado = SessionManager_327LG.Instancia.IsLoggedIn_327LG();
            this.cambiarContraseñaItem.Visible = logueado;
            this.adminItem.Visible = logueado;
            this.maestroItem.Visible = logueado;
            this.prestamosItem.Visible = logueado;
            this.reposicionItem.Visible = logueado;
            this.reporteItem.Visible = logueado;
            this.ayudaItem.Visible = logueado;
            if (menuPrincipal_327LG != null) menuPrincipal_327LG.Actualizar_327LG();
            if (!logueado) CerrarFormularios();

        }

        private void iniciarSesiónItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormIniciarSesion>();
        }

        private void gestiónUsuariosMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormGestionUsuarios>();
        }

        private void AbrirFormulario<T>() where T : Form, new()
        {
            Form form = Application.OpenForms.OfType<T>().FirstOrDefault();
            if (form != null)
            {
                form.BringToFront();
            }
            else
            {
                form = new T();
                form.MdiParent = this;
                form.Show();
            }
        }
        private void CerrarFormularios()
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form != menuPrincipal_327LG)
                    form.Close();
            }
        }

        private void cambiarContraseñaItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormCambiarContraseña>();
        }

        public void Actualizar_327LG()
        {
            usuarioItem.Text = LanguageManager.Instance.ObtenerString("FormMDI.menu_usuario.texto");
            iniciarSesiónItem.Text = LanguageManager.Instance.ObtenerString("FormMDI.menu_usuario.items.iniciar_sesion");
            cambiarContraseñaItem.Text = LanguageManager.Instance.ObtenerString("FormMDI.menu_usuario.items.cambiar_contrasena");
            cerrarSesiónItem.Text = LanguageManager.Instance.ObtenerString("FormMDI.menu_usuario.items.cerrar_sesion");
            adminItem.Text = LanguageManager.Instance.ObtenerString("FormMDI.menu_admin.texto");
            gestiónUsuariosMenuItem.Text = LanguageManager.Instance.ObtenerString("FormMDI.menu_admin.items.gestion_usuarios");
            maestroItem.Text = LanguageManager.Instance.ObtenerString("FormMDI.menu_maestro.texto");
            prestamosItem.Text = LanguageManager.Instance.ObtenerString("FormMDI.menu_prestamos.texto");
            reposicionItem.Text = LanguageManager.Instance.ObtenerString("FormMDI.menu_reposicion.texto");
            reporteItem.Text = LanguageManager.Instance.ObtenerString("FormMDI.menu_reporte.texto");
            ayudaItem.Text = LanguageManager.Instance.ObtenerString("FormMDI.menu_ayuda.texto");
            tsmiIdioma.Text = LanguageManager.Instance.ObtenerString("FormMDI.label_idioma.texto");
        }

        private void tscmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscmbIdioma.Text == "Español")
            {
                LanguageManager.Instance.CargarIdioma("spanish");
            }
            else if (tscmbIdioma.Text == "English")
            {
                LanguageManager.Instance.CargarIdioma("english");
            }
            else
            {
                MessageBox.Show("Idioma no soportado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
