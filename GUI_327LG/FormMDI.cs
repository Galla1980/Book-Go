using BLL_327LG;
using Services_327LG;
using Services_327LG.Singleton_327LG;
namespace GUI_327LG
{
    public partial class FormMDI : Form
    {
        private FormMenuPrincipal menuPrincipal_327LG;
        BLLUsuario_327LG bllUsuario_327LG;
        public FormMDI()
        {
            InitializeComponent();
            ActualizarFormulario_327LG();
            menuStrip1.BackColor = ColorTranslator.FromHtml("#EAEAEA");
            menuStrip1.ForeColor = ColorTranslator.FromHtml("#055b6b");
            bllUsuario_327LG = new BLLUsuario_327LG();
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
                if (!SessionManager_327LG.Instancia.IsLoggedIn_327LG()) throw new Exception("No hay sesión iniciada");
                if (MessageBox.Show("¿Desea cerrar la sesión?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
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
            if (menuPrincipal_327LG != null) menuPrincipal_327LG.ActualizarBienvenida();
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
            AbrirFormulario<FormCambiarContraseña> ();
        }
    }
}
