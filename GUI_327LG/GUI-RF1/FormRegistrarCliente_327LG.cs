using BE_327LG;
using BLL_327LG;
using Services_327LG.Observer_327LG;
using System.Text.RegularExpressions;

namespace GUI_327LG.GUIRF1
{
    public partial class FormRegistrarCliente_327LG : Form, IObserverIdioma_327LG
    {
        LanguageManager_327LG LM_327LG;
        BLLCliente_327LG bllCliente_327LG;
        public FormRegistrarCliente_327LG()
        {
            InitializeComponent();
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            bllCliente_327LG = new BLLCliente_327LG();
            Actualizar_327LG();
        }
        private void FormRegistrarCliente_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#055b6b");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormRegistrarCliente_327LG");
                string dni = txtDNI.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;

                if (!Regex.IsMatch(dni, @"^\d{8}$")) throw new Exception(LM_327LG.ObtenerString("exception.dni_no_valido"));
                if (dni == string.Empty || apellido == string.Empty || nombre == string.Empty || email == string.Empty) throw new Exception(LM_327LG.ObtenerString("exception.campos_vacios"));
                if (nombre.Any(char.IsDigit)) throw new Exception(LM_327LG.ObtenerString("exception.nombre_con_numeros"));
                if (apellido.Any(char.IsDigit)) throw new Exception(LM_327LG.ObtenerString("exception.apellido_con_numeros"));
                if(!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")) throw new Exception(LM_327LG.ObtenerString("exception.email_no_valido"));
                if (bllCliente_327LG.ObtenerClientes_327LG().Any(x => x.DNI_327LG == dni)) throw new Exception(LM_327LG.ObtenerString("exception.dni_en_uso"));
                if(MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.confirmacion_registrar_cliente"), LM_327LG.ObtenerString("messagebox.titulo.confirmacion"), LM_327LG.ObtenerString("messagebox.button.aceptar"), LM_327LG.ObtenerString("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bllCliente_327LG.RegistrarCliente_327LG(new BECliente_327LG(dni, nombre, apellido, email));
                    MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.cliente_registrado"), LM_327LG.ObtenerString("messagebox.titulo.cliente_registrado"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormRegistrarCliente_327LG");
            lblTitulo.Text = LM_327LG.ObtenerString("label.lblTitulo");
            lblDNI.Text = LM_327LG.ObtenerString("label.lblDni");
            lblNombre.Text = LM_327LG.ObtenerString("label.lblNombre");
            lblApellido.Text = LM_327LG.ObtenerString("label.lblApellido");
            lblEmail.Text = LM_327LG.ObtenerString("label.lblEmail");
            btnCancelar.Text = LM_327LG.ObtenerString("button.btnCancelar");
            btnRegistrar.Text = LM_327LG.ObtenerString("button.btnRegistrar");
        }
    }
}
