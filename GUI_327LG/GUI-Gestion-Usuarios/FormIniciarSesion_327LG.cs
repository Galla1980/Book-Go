using BLL_327LG;
using Services_327LG.Observer_327LG;
using Services_327LG.Singleton_327LG;

namespace GUI_327LG
{
    public partial class FormIniciarSesion_327LG : Form, IObserverIdioma_327LG
    {
        BLLUsuario_327LG bllUsuario_327LG;
        LanguageManager_327LG LM_327LG;
        public FormIniciarSesion_327LG()
        {
            InitializeComponent();
            bllUsuario_327LG = new BLLUsuario_327LG();
            LM_327LG = LanguageManager_327LG.Instance;
            LM_327LG.AgregarObservador_327LG(this);
            Actualizar_327LG();
        }

        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormIniciarSesion_327LG");
            lblIniciarSesion.Text = LM_327LG.ObtenerString("label.lblTitulo");
            lblIniciarSesion.Left = (this.ClientSize.Width - lblIniciarSesion.Width) / 2;
            lblUsuario.Text = LM_327LG.ObtenerString("label.lblUsuario");
            lblContraseña.Text = LM_327LG.ObtenerString("label.lblContrasena");
            btnIniciarSesion.Text = LM_327LG.ObtenerString("button.btnIniciarSesion");
            btnSalir.Text = LM_327LG.ObtenerString("button.btnSalir");
            chkVerContraseña.Text = LM_327LG.ObtenerString("checkbox.chkVerContrasena");
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormIniciarSesion_327LG");
                if (SessionManager_327LG.Instancia.IsLoggedIn_327LG()) throw new Exception(LM_327LG.ObtenerString("exception.sesion_iniciada"));
                bllUsuario_327LG.IniciarSesion_327LG(txtUsuario.Text, txtContraseña.Text);
                FormMDI_327LG form = (FormMDI_327LG)this.MdiParent;
                form.ActualizarFormulario_327LG();
                this.Close();
            }
            catch (LoginException_327LG ex)
            {
                LM_327LG.CargarFormulario_327LG("FormIniciarSesion_327LG");
                switch (ex.Result)
                {
                    case LoginResult_327LG.InvalidUsername:
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.invalid_username"), "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
                        break;
                    case LoginResult_327LG.InvalidPassword:
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.invalid_password"), "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
                        break;
                    case LoginResult_327LG.UserBlocked:
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.user_bloqued"), "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
                        break;
                    case LoginResult_327LG.UserDisabled:
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.user_disabled"), "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LM_327LG.CargarFormulario_327LG("FormIniciarSesion_327LG");
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkVerContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVerContraseña.Checked)
            {
                txtContraseña.PasswordChar = '\0';
            }
            else
            {
                txtContraseña.PasswordChar = '●';
            }

        }

        private void FormIniciarSesion_Load(object sender, EventArgs e)
        {
            // Fondo del formulario principal
            this.BackColor = ColorTranslator.FromHtml("#0c7689");
            // Labels
            lblIniciarSesion.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }

            // CheckBox
            chkVerContraseña.ForeColor = Color.White;
            chkVerContraseña.BackColor = Color.Transparent;

            // TextBoxes
            txtUsuario.BackColor = Color.White;
            txtUsuario.ForeColor = Color.Black;
            txtContraseña.BackColor = Color.White;
            txtContraseña.ForeColor = Color.Black;

            // Botón Iniciar sesión 
            btnIniciarSesion.BackColor = ColorTranslator.FromHtml("#4cb2c7");
            btnIniciarSesion.ForeColor = Color.White;
            btnIniciarSesion.FlatStyle = FlatStyle.Flat;
            btnIniciarSesion.FlatAppearance.BorderSize = 0;

            // Botón Salir (gris claro)
            btnSalir.BackColor = ColorTranslator.FromHtml("#cccccc");
            btnSalir.ForeColor = Color.Black;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderSize = 0;
            Actualizar_327LG();
        }

        private void FormIniciarSesion_327LG_FormClosed(object sender, FormClosedEventArgs e)
        {
            LM_327LG.EliminarObservador_327LG(this);
        }
    }
}
