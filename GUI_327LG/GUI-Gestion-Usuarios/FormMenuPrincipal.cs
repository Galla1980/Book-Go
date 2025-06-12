using Services_327LG.Observer_327LG;
using Services_327LG.Singleton_327LG;

namespace GUI_327LG
{
    public partial class FormMenuPrincipal : Form, IObserverIdioma_327LG
    {

        public FormMenuPrincipal()
        {
            InitializeComponent();
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Segoe UI", 14, FontStyle.Regular); 
            lblBienvenido.ForeColor = Color.White;
            LanguageManager.Instance.AgregarObservador_327LG(this);
        }

        public void Actualizar_327LG()
        {
            if (SessionManager_327LG.Instancia.IsLoggedIn_327LG())
                lblBienvenido.Text = LanguageManager.Instance.ObtenerString("FormMenuPrincipal.lblBienvenida") + SessionManager_327LG.Instancia.Usuario.nombre_327LG;
            else
                lblBienvenido.Text = "";
        }



        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#055b6b");
            this.Size = new Size(this.Parent.Width, this.Parent.Height);
            this.FormBorderStyle = FormBorderStyle.None;
            FormMenuPrincipal_Resize(sender, e);
            Actualizar_327LG();
        }

        private void FormMenuPrincipal_Resize(object sender, EventArgs e)
        {
            pic.Location = new Point(this.Width - pic.Width - 10, this.Height - pic.Height - 10);
            lblBienvenido.Location = new Point(10, this.ClientSize.Height - lblBienvenido.Height - 10);
            
        }
    }
}
