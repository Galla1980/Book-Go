using BE_327LG;
using BLL_327LG;
using System.Text.RegularExpressions;

namespace GUI_327LG.Maestros
{
    public partial class FormLibroMaestro_327LG : Form
    {
        BLLLibro_327LG bllLibro_327LG;
        public FormLibroMaestro_327LG()
        {
            InitializeComponent();
            bllLibro_327LG = new BLLLibro_327LG();
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

                if (string.IsNullOrWhiteSpace(isbn) || string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor) || string.IsNullOrWhiteSpace(editorial) || string.IsNullOrWhiteSpace(edicion)) throw new Exception("Todos los campos son obligatorios.");
                if(!Regex.IsMatch(isbn, @"^\d{13}$")) throw new Exception("El ISBN debe contener 13 caracteres numericos.");
                if(bllLibro_327LG.ObtenerLibros_327LG().Any(x=> x.ISBN_327LG == isbn)) throw new Exception("El libro con este ISBN ya existe.");
                if (!int.TryParse(edicion, out _))throw new Exception("La edición debe ser un número entero.");

                BELibro_327LG libro = new BELibro_327LG(isbn, titulo,autor,editorial,Convert.ToInt32(edicion));
                bllLibro_327LG.CargarLibro_327LG(libro);
                MessageBox.Show("Libro cargado correctamente.", "Libro cargado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
