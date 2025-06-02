using BLL_327LG;
using Services_327LG.Singleton_327LG;

namespace GUI_327LG
{
    public partial class FormIniciarSesion : Form
    {
        BLLUsuario_327LG bllUsuario_327LG;
        public FormIniciarSesion()
        {
            InitializeComponent();
            bllUsuario_327LG = new BLLUsuario_327LG();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                bllUsuario_327LG.IniciarSesion_327LG(txtUsuario.Text, txtContraseña.Text);
                FormMDI form = (FormMDI)this.MdiParent;
                form.ActualizarFormulario_327LG();
                this.Close();
            }
            catch (LoginException_327LG ex)
            {
                switch (ex.Result)
                {
                    case LoginResult_327LG.InvalidUsername:
                        MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case LoginResult_327LG.InvalidPassword:
                        MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case LoginResult_327LG.UserBlocked:
                        MessageBox.Show("Usuario bloqueado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case LoginResult_327LG.UserDisabled:
                        MessageBox.Show("Usuario deshabilitado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }
    }
}
