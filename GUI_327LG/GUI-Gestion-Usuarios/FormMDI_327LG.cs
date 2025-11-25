using BLL_327LG;
using GUI_327LG.GUI_Gestion_Perfiles;
using GUI_327LG.GUI_Gestion_Usuarios;
using GUI_327LG.GUI_RF2;
using GUI_327LG.GUIRF1;
using GUI_327LG.Maestros;
using GUI_327LG.Reportes;
using Services_327LG;
using Services_327LG.Composite_327LG;
using Services_327LG.Observer_327LG;
using Services_327LG.Singleton_327LG;
using System.Diagnostics;
namespace GUI_327LG
{
    public partial class FormMDI_327LG : Form, IObserverIdioma_327LG
    {
        private FormMenuPrincipal_327LG menuPrincipal_327LG;
        BLLDigitoVerificador_327LG bllDigitoVerificador_327LG;
        BLLUsuario_327LG bllUsuario_327LG;
        private LanguageManager_327LG LM_327LG;
        BLLPerfil_327LG bllPerfil_327LG;

        public FormMDI_327LG()
        {
            InitializeComponent();
            mnsPestañas.BackColor = ColorTranslator.FromHtml("#EAEAEA");
            mnsPestañas.ForeColor = ColorTranslator.FromHtml("#055b6b");
            bllUsuario_327LG = new BLLUsuario_327LG();
            bllDigitoVerificador_327LG = new BLLDigitoVerificador_327LG();
            bllPerfil_327LG = new BLLPerfil_327LG();
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
            //usuario
            usuarioItem.Text = LM_327LG.ObtenerString("menu_usuario.texto");
            iniciarSesiónItem.Text = LM_327LG.ObtenerString("menu_usuario.items.iniciar_sesion");
            cambiarContraseñaItem.Text = LM_327LG.ObtenerString("menu_usuario.items.cambiar_contrasena");
            cerrarSesiónItem.Text = LM_327LG.ObtenerString("menu_usuario.items.cerrar_sesion");

            //admin
            adminItem.Text = LM_327LG.ObtenerString("menu_admin.texto");
            gestiónUsuariosMenuItem.Text = LM_327LG.ObtenerString("menu_admin.items.gestion_usuarios");
            gestiónDeFamiliasMenuItem.Text = LM_327LG.ObtenerString("menu_admin.items.perfiles");
            perfilesMenuItem.Text = LM_327LG.ObtenerString("menu_admin.items.perfiles");
            gestiónDeFamiliasMenuItem.Text = LM_327LG.ObtenerString("menu_admin.items.gestion_familias");
            gestionDePerfilesMenuItem.Text = LM_327LG.ObtenerString("menu_admin.items.gestion_perfiles");
            bitacoraMenuItem.Text = LM_327LG.ObtenerString("menu_admin.items.bitacora");

            //maestros
            maestroItem.Text = LM_327LG.ObtenerString("menu_maestro.texto");
            librosItem.Text = LM_327LG.ObtenerString("menu_maestro.items.libros");
            ejemplaresItem.Text = LM_327LG.ObtenerString("menu_maestro.items.ejemplares");
            clientesToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_maestro.items.clientes");
            distribuidoresToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_maestro.items.distribuidores");

            //prestamos
            prestamosItem.Text = LM_327LG.ObtenerString("menu_prestamos.texto");
            registrarPrestamoToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_prestamos.items.registrar_prestamo");
            registrarDevoluciónItem.Text = LM_327LG.ObtenerString("menu_prestamos.items.registrar_devolucion");
            //reposicion
            reposicionItem.Text = LM_327LG.ObtenerString("menu_reposicion.texto");
            registrarDistribuidorToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_reposicion.items.registrar_distribuidor");
            solicitarCotizaciónToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_reposicion.items.solicitar_cotizacion");
            generarOrdenCompraToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_reposicion.items.generar_orden_compra");
            registrarRecepcionToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_reposicion.items.registrar_recepcion");

            //reportes
            reporteItem.Text = LM_327LG.ObtenerString("menu_reporte.texto");
            facturaMenuItem.Text = LM_327LG.ObtenerString("menu_reporte.items.factura");
            ordenesDeCompraToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_reporte.items.orden");

            //ayuda 
            ayudaItem.Text = LM_327LG.ObtenerString("menu_ayuda.texto");
            tsmiIdioma.Text = LM_327LG.ObtenerString("label_idioma.texto");


            usuarioToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_usuario.texto");
            inicioDeSesiónToolStripMenuItem.Text =  LM_327LG.ObtenerString("menu_usuario.items.iniciar_sesion");
            cambiarContraseñaToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_usuario.items.cambiar_contrasena");
            cerrarSesiónToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_usuario.items.cerrar_sesion");

            adminToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_admin.texto");
            gestionDeUsuariosToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_admin.items.gestion_usuarios");
            perfilesToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_admin.items.perfiles");
            bitacoraToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_admin.items.bitacora");

            maestrosToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_maestro.texto");
            librosToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_maestro.items.libros");
            ejemplaresToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_maestro.items.ejemplares");
            clienteToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_maestro.items.clientes");
            distribuidoresToolStripMenuItem1.Text = LM_327LG.ObtenerString("menu_maestro.items.distribuidores");

            prestamosToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_prestamos.texto");
            registrarPrestamoToolStripMenuItem1.Text = LM_327LG.ObtenerString("menu_prestamos.items.registrar_prestamo");
            registrarDevolicionToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_prestamos.items.registrar_devolucion");

            reposiciónToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_reposicion.texto");
            registrarToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_reposicion.items.registrar_distribuidor");
            solicitarCotizacionToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_reposicion.items.solicitar_cotizacion");
            generarOrdenDeCompraToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_reposicion.items.generar_orden_compra");
            registrarRecepcionToolStripMenuItem1.Text = LM_327LG.ObtenerString("menu_reposicion.items.registrar_recepcion");

            reporteToolStripMenuItem.Text = LM_327LG.ObtenerString("menu_reporte.texto");
            

        }

        public void ActualizarFormulario_327LG()
        {

            Usuario_327LG usuario = SessionManager_327LG.Instancia.Usuario;
            bool logueado = SessionManager_327LG.Instancia.IsLoggedIn_327LG();

            if (logueado)
            {
                CargarIdioma_327LG();

                if (bllDigitoVerificador_327LG.CompararDigito_327LG().Count > 0)
                {
                    if (bllPerfil_327LG.FamiliaContienePermiso_327LG(usuario.rol_327LG, new BEPermiso_327LG(2, "Admin")))
                    {
                        using (FormRepararDigito_327LG form = new FormRepararDigito_327LG())
                        {
                            form.formPadre = this;
                            form.ShowDialog();
                        }
                    }
                    else
                    {
                        LM_327LG.CargarFormulario_327LG("FormMDI_327LG");
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.inconsistencias"), LM_327LG.ObtenerString("messagebox.titulo.inconsistencias"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
                        bllUsuario_327LG.CerrarSesion_327LG();
                        ActualizarFormulario_327LG();

                    }
                }
                else
                {
                    if (bllPerfil_327LG.FamiliaContienePermiso_327LG(usuario.rol_327LG, new BEPermiso_327LG(1, "Usuario")))
                    {
                        cambiarContraseñaItem.Enabled = true;
                    }
                    if (bllPerfil_327LG.FamiliaContienePermiso_327LG(usuario.rol_327LG, new BEPermiso_327LG(2, "Admin")))
                    {
                        adminItem.Enabled = true;
                    }
                    if (bllPerfil_327LG.FamiliaContienePermiso_327LG(usuario.rol_327LG, new BEPermiso_327LG(3, "Maestro")))
                    {
                        maestroItem.Enabled = true;
                    }
                    if (bllPerfil_327LG.FamiliaContienePermiso_327LG(usuario.rol_327LG, new BEPermiso_327LG(4, "Prestamos")))
                    {
                        prestamosItem.Enabled = true;
                    }
                    if (bllPerfil_327LG.FamiliaContienePermiso_327LG(usuario.rol_327LG, new BEPermiso_327LG(6, "Reposición")) || bllPerfil_327LG.FamiliaContienePermiso_327LG(usuario.rol_327LG, new BEPermiso_327LG(7, "Encargado")))
                    {
                        reposicionItem.Enabled = true;
                        if (bllPerfil_327LG.FamiliaContienePermiso_327LG(usuario.rol_327LG, new BEPermiso_327LG(6, "Reposición")))
                        {
                            registrarRecepcionToolStripMenuItem.Enabled = true;
                        }
                        if (bllPerfil_327LG.FamiliaContienePermiso_327LG(usuario.rol_327LG, new BEPermiso_327LG(7, "Encargado")))
                        {
                            registrarDistribuidorToolStripMenuItem.Enabled = true;
                            solicitarCotizaciónToolStripMenuItem.Enabled = true;
                            generarOrdenCompraToolStripMenuItem.Enabled = true;
                        }
                    }
                    if (bllPerfil_327LG.FamiliaContienePermiso_327LG(usuario.rol_327LG, new BEPermiso_327LG(5, "Reporte")))
                    {
                        reporteItem.Enabled = true;
                    }
                }


            }
            else
            {
                cambiarContraseñaItem.Enabled = false;
                adminItem.Enabled = false;
                maestroItem.Enabled = false;
                prestamosItem.Enabled = false;
                reporteItem.Enabled = false;
                reposicionItem.Enabled = false;
                ayudaItem.Enabled = true;
                registrarRecepcionToolStripMenuItem.Enabled = false;

                registrarDistribuidorToolStripMenuItem.Enabled = false;
                solicitarCotizaciónToolStripMenuItem.Enabled = false;
                generarOrdenCompraToolStripMenuItem.Enabled = false;
                CerrarFormularios();
                CargarIdioma_327LG();

            }

        }

        private void iniciarSesiónItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormIniciarSesion_327LG>();
        }

        private void gestiónUsuariosMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormGestionUsuarios_327LG>();
        }

        private void AbrirFormulario_327LG<T>() where T : Form, new()
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
        public void CerrarFormularios()
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form != menuPrincipal_327LG)
                    form.Close();
            }
        }

        private void cambiarContraseñaItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormCambiarContraseña_327LG>();
        }

        private void tscmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscmbIdioma.Text == "Español")
            {
                LanguageManager_327LG.Instance_327LG.CambiarIdioma_327LG("spanish");
                if (SessionManager_327LG.Instancia.IsLoggedIn_327LG())
                {
                    SessionManager_327LG.Instancia.Usuario.IdiomaPref_327LG = "spanish";
                }
            }
            else if (tscmbIdioma.Text == "English")
            {
                LanguageManager_327LG.Instance_327LG.CambiarIdioma_327LG("english");
                if (SessionManager_327LG.Instancia.IsLoggedIn_327LG())
                {
                    SessionManager_327LG.Instancia.Usuario.IdiomaPref_327LG = "english";
                }
            }
            else
            {
                MessageBox.Show("Idioma no soportado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void CargarIdioma_327LG()
        {
            if (!SessionManager_327LG.Instancia.IsLoggedIn_327LG())
            {
                tscmbIdioma.Text = "Español";
                LanguageManager_327LG.Instance_327LG.CambiarIdioma_327LG("spanish");
            }
            else if (SessionManager_327LG.Instancia.Usuario.IdiomaPref_327LG == "spanish")
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
            AbrirFormulario_327LG<FormRegistrarPrestamo_327LG>();
        }

        private void registrarDevoluciónItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormRegDevolucion_327LG>();
        }

        private void librosItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormLibroMaestro_327LG>();
        }

        private void ejemplaresItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormEjemplarMaestro_327LG>();
        }

        private void gestiónDeFamiliasMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormGestionFamilia_327LG>();
        }

        private void gestionDePerfilesMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormGestionPerfiles_327LG>();
        }

        private void facturaMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormReporteFactura_327LG>();
        }

        private void backUpRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormBackupRestore_327LG>();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormRegistrarCliente_327LG>();
        }

        private void bitacoraMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormBitacoraEventos_327LG>();
        }

        private void FormMDI_327LG_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SessionManager_327LG.Instancia.IsLoggedIn_327LG()) bllUsuario_327LG.CerrarSesion_327LG();
        }

        private void registrarDistribuidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormRegistrarDistribuidor_327LG>();
        }

        private void solicitarCotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormSolicitarCotizacion_327LG>();
        }

        private void generarOrdenCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormGenerarOrdenCompra_327LG>();
        }

        private void registrarRecepcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormRegistrarRecepcion_327LG>();
        }

        private void libroCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormLibro_C_327LG>();
        }

        private void ordenesDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormReporteOrdenCompra_327LG>();
        }

        private void reporteInteligenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario_327LG<FormReporteInteligente_327LG>();
        }

        private void inicioDeSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("InicioSesion");

        }

        private void cambioDeIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("CambioIdioma");

        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("CambiarContraseña");

        }

        private void cerrarSesiónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirAyudaPDF("CerrarSesion");

        }

        private void gestionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("GestionUsuarios");

        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("Perfiles");

        }

        private void backupRestoreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("BackupRestore");

        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("Bitacora");

        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("Libros");
        }

        private static void AbrirAyudaPDF(string pantalla)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Manuales", $"{LanguageManager_327LG.Instance_327LG.Idioma_327LG}", $"{pantalla}.pdf");
            try
            {
                if (File.Exists(path))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = path,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ejemplaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("Ejemplares");

        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("Cliente");

        }

        private void distribuidoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("Distribuidores");

        }

        private void libroCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("Libro_C");

        }

        private void registrarPrestamoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("RegistrarPrestamo");

        }

        private void registrarDevolicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("RegistrarDevolucion");

        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("Distribuidores");

        }

        private void solicitarCotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("SolicitarCotizacion");

        }

        private void generarOrdenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("GenerarOrdenCompra");

        }

        private void registrarRecepcionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("RegistrarRecepcion");

        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirAyudaPDF("Reporte");

        }
    }
}