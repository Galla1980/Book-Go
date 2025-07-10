using BE_327LG;
using BLL_327LG;
using Services_327LG.Observer_327LG;
using System.Text.RegularExpressions;

namespace GUI_327LG.Maestros
{
    public partial class FormLibroMaestro_327LG : Form, IObserverIdioma_327LG
    {
        BLLLibro_327LG bllLibro_327LG;
        LanguageManager_327LG LM_327LG = LanguageManager_327LG.Instance_327LG;
        public FormLibroMaestro_327LG()
        {
            InitializeComponent();
            bllLibro_327LG = new BLLLibro_327LG();
            LM_327LG.AgregarObservador_327LG(this);
            Actualizar_327LG();
        }

        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormLibroMaestro_327LG");
            lblTituloForm.Text = LM_327LG.ObtenerString("label.lblTituloForm");
            lblAutor.Text = LM_327LG.ObtenerString("label.lblAutor");
            lblEdicion.Text = LM_327LG.ObtenerString("label.lblEdicion");
            lblTitulo.Text = LM_327LG.ObtenerString("label.lblTituloLibro");
            lblEditorial.Text = LM_327LG.ObtenerString("label.lblEditorial");
            btnCargarLibro.Text = LM_327LG.ObtenerString("button.btnCargarLibro");
        }

        private void btnCargarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                string isbn = txtISBN.Text;
                string titulo = txtTitulo.Text;
                string autor = txtAutor.Text;
                string editorial = txtEditorial.Text;
                string edicion = txtEdicion.Text;

                if (string.IsNullOrWhiteSpace(isbn) || string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor) || string.IsNullOrWhiteSpace(editorial) || string.IsNullOrWhiteSpace(edicion)) throw new Exception(LM_327LG.ObtenerString("exception.campos_vacios"));
                if(!Regex.IsMatch(isbn, @"^\d{13}$")) throw new Exception(LM_327LG.ObtenerString("exception.campos_vacios"));
                if(bllLibro_327LG.ObtenerLibros_327LG().Any(x=> x.ISBN_327LG == isbn)) throw new Exception(LM_327LG.ObtenerString("exception.libro_existe"));
                if (!int.TryParse(edicion, out _))throw new Exception(LM_327LG.ObtenerString("exception.edicion_entero"));

                BELibro_327LG libro = new BELibro_327LG(isbn, titulo,autor,editorial,Convert.ToInt32(edicion));
                bllLibro_327LG.CargarLibro_327LG(libro);
                MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.libro_cargado"), LM_327LG.ObtenerString("messagebox.titulo.libro_cargado"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
    }
}
