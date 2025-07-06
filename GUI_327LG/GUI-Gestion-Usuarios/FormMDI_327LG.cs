using BLL_327LG;
using GUI_327LG.GUIRF1;
using GUI_327LG.Maestros;
using Services_327LG;
using Services_327LG.Observer_327LG;
using Services_327LG.Singleton_327LG;
namespace GUI_327LG
{
    public partial class FormMDI_327LG : Form, IObserverIdioma_327LG
    {
        private FormMenuPrincipal_327LG menuPrincipal_327LG;
        BLLUsuario_327LG bllUsuario_327LG;
        private LanguageManager_327LG LM_327LG;


        public FormMDI_327LG()
        {
            InitializeComponent();
            mnsPestañas.BackColor = ColorTranslator.FromHtml("#EAEAEA");
            mnsPestañas.ForeColor = ColorTranslator.FromHtml("#055b6b");
            bllUsuario_327LG = new BLLUsuario_327LG();
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            LM_327LG.AgregarObservador_327LG(this);
            LM_327LG.CambiarIdioma_327LG("spanish");
            Actualizar_327LG();
        }

        private void FormMDI_Load(object sender, EventArgs e)
        {
            menuPrincipal_327LG = new FormMenuPrincipal_327LG();
            menuPrincipal_327LG.MdiParent = this;
            menuPrincipal_327LG.Dock = DockStyle.Fill;
            menuPrincipal_327LG.Show();
            ActualizarFormulario_327LG();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormMDI_327LG");
                if (!SessionManager_327LG.Instancia.IsLoggedIn_327LG()) throw new Exception(LM_327LG.ObtenerString("exception.sesion_no_iniciada"));
                if (MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.cierre_sesion"), LM_327LG.ObtenerString("messagebox.titulo.cierre_sesion"), LM_327LG.ObtenerString("messagebox.button.aceptar"), LM_327LG.ObtenerString("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bllUsuario_327LG.CerrarSesion_327LG();
                    ActualizarFormulario_327LG();
                }
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormMDI_327LG");
            usuarioItem.Text = LM_327LG.ObtenerString("menu_usuario.texto");
            iniciarSesiónItem.Text = LM_327LG.ObtenerString("menu_usuario.items.iniciar_sesion");
            cambiarContraseñaItem.Text = LM_327LG.ObtenerString("menu_usuario.items.cambiar_contrasena");
            cerrarSesiónItem.Text = LM_327LG.ObtenerString("menu_usuario.items.cerrar_sesion");
            adminItem.Text = LM_327LG.ObtenerString("menu_admin.texto");
            gestiónUsuariosMenuItem.Text = LM_327LG.ObtenerString("menu_admin.items.gestion_usuarios");
            maestroItem.Text = LM_327LG.ObtenerString("menu_maestro.texto");
            prestamosItem.Text = LM_327LG.ObtenerString("menu_prestamos.texto");
            registrarPrestamoToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_prestamos.items.registrar_prestamo");
            registrarDevoluciónItem.Text = LM_327LG.ObtenerString("menu_prestamos.items.registrar_devolucion");
            reposicionItem.Text = LM_327LG.ObtenerString("menu_reposicion.texto");
            reporteItem.Text = LM_327LG.ObtenerString("menu_reporte.texto");
            ayudaItem.Text = LM_327LG.ObtenerString("menu_ayuda.texto");
            tsmiIdioma.Text = LM_327LG.ObtenerString("label_idioma.texto");
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
            AbrirFormulario<FormIniciarSesion_327LG>();
        }

        private void gestiónUsuariosMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormGestionUsuarios_327LG>();
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
            AbrirFormulario<FormCambiarContraseña_327LG>();
        }

        private void tscmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscmbIdioma.Text == "Español")
            {
                LanguageManager_327LG.Instance_327LG.CambiarIdioma_327LG("spanish");
                if (SessionManager_327LG.Instancia.IsLoggedIn_327LG())
                {
                    SessionManager_327LG.Instancia.Usuario.IdiomaPref_327LG = "spanish";
                    bllUsuario_327LG.CambiarIdioma_327LG(SessionManager_327LG.Instancia.Usuario);
                }
            }
            else if (tscmbIdioma.Text == "English")
            {
                LanguageManager_327LG.Instance_327LG.CambiarIdioma_327LG("english");
                if (SessionManager_327LG.Instancia.IsLoggedIn_327LG())
                {
                    SessionManager_327LG.Instancia.Usuario.IdiomaPref_327LG = "english";
                    bllUsuario_327LG.CambiarIdioma_327LG(SessionManager_327LG.Instancia.Usuario);
                }
            }
            else
            {
                MessageBox.Show("Idioma no soportado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void CargarIdioma_327LG()
        {
            if (SessionManager_327LG.Instancia.Usuario.IdiomaPref_327LG == "spanish")
            {
                LanguageManager_327LG.Instance_327LG.CambiarIdioma_327LG("spanish");
                tscmbIdioma.Text = "Español";
            }
            else if (SessionManager_327LG.Instancia.Usuario.IdiomaPref_327LG == "english")
            {
                LanguageManager_327LG.Instance_327LG.CambiarIdioma_327LG("spanish");
                tscmbIdioma.Text = "English";
            }
        }

        private void registrarPrestamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormRegistrarPrestamo_327LG>();
        }

        private void registrarDevoluciónItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormRegDevolucion_327LG>();
        }

        private void librosItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormLibroMaestro_327LG>();
        }

        private void ejemplaresItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormEjemplarMaestro_327LG>();
        }
    }
}