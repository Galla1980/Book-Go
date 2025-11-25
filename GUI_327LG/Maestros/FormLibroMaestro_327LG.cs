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
        string modo = "consulta";
        public FormLibroMaestro_327LG()
        {
            InitializeComponent();
            bllLibro_327LG = new BLLLibro_327LG();
            LM_327LG.AgregarObservador_327LG(this);
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.MultiSelect = false;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLibros.RowHeadersVisible = false;
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
            modo = "Cargar";
            btnAplicar.Enabled = true;
            btnCancelar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCargarLibro.Enabled = false;
            btnRefrescar.Enabled = false;
        }

        private void ModoConsulta()
        {
            modo = "Consulta";
            btnAplicar.Enabled = false;
            btnCancelar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnCargarLibro.Enabled = true;
            txtISBN.Enabled = true;
            btnRefrescar.Enabled = true;
            txtISBN.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
            txtEdicion.Clear();
            txtEditorial.Clear();
        }

        private void FormLibroMaestro_327LG_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            ModoConsulta();
        }

        private void CargarGrilla()
        {
            List<BELibro_327LG> libros = bllLibro_327LG.ObtenerLibros_327LG();
            var linq = from x in libros
                       select new
                       {
                           ISBN = x.ISBN_327LG,
                           Titulo = x.titulo_327LG,
                           Autor = x.autor_327LG,
                           Editorial = x.editorial_327LG,
                           Edicion = x.edicion_327LG
                       };
            dgvLibros.DataSource = linq.ToList();
            dgvLibros.Columns["ISBN"].FillWeight = 100;
            dgvLibros.Columns["Titulo"].FillWeight = 200;
            dgvLibros.Columns["Autor"].FillWeight = 150;
            dgvLibros.Columns["Editorial"].FillWeight = 120;
            dgvLibros.Columns["Edicion"].FillWeight = 80;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormLibroMaestro_327LG");
                switch (modo)
                {
                    case "Cargar":
                        string isbn = txtISBN.Text;
                        string titulo = txtTitulo.Text;
                        string autor = txtAutor.Text;
                        string editorial = txtEditorial.Text;
                        string edicion = txtEdicion.Text;

                        if (string.IsNullOrWhiteSpace(isbn) || string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor) || string.IsNullOrWhiteSpace(editorial) || string.IsNullOrWhiteSpace(edicion)) throw new Exception(LM_327LG.ObtenerString("exception.campos_vacios"));
                        if (!Regex.IsMatch(isbn, @"^\d{13}$")) throw new Exception(LM_327LG.ObtenerString("exception.isbn_caracteres"));
                        if (bllLibro_327LG.ObtenerTodosLibros_327LG().Any(x => x.ISBN_327LG == isbn)) throw new Exception(LM_327LG.ObtenerString("exception.libro_existe"));
                        if (!int.TryParse(edicion, out _)) throw new Exception(LM_327LG.ObtenerString("exception.edicion_entero"));

                        BELibro_327LG libro = new BELibro_327LG(isbn, titulo, autor, editorial, Convert.ToInt32(edicion));
                        bllLibro_327LG.CargarLibro_327LG(libro);
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.libro_cargado"), LM_327LG.ObtenerString("messagebox.titulo.libro_cargado"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        break;
                    case "Modificar":
                        if (dgvLibros.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_fila"));
                        if (string.IsNullOrWhiteSpace(txtISBN.Text) || string.IsNullOrWhiteSpace(txtTitulo.Text) || string.IsNullOrWhiteSpace(txtAutor.Text) || string.IsNullOrWhiteSpace(txtEditorial.Text) || string.IsNullOrWhiteSpace(txtEdicion.Text)) throw new Exception(LM_327LG.ObtenerString("exception.campos_vacios"));
                        if (!Regex.IsMatch(txtISBN.Text, @"^\d{13}$")) throw new Exception(LM_327LG.ObtenerString("exception.campos_vacios"));
                        if (!int.TryParse(txtEdicion.Text, out _)) throw new Exception(LM_327LG.ObtenerString("exception.edicion_entero"));

                        BELibro_327LG libroModificado = bllLibro_327LG.ObtenerLibros_327LG().FirstOrDefault(x => x.ISBN_327LG == dgvLibros.SelectedRows[0].Cells["ISBN"].Value.ToString());
                        if(libroModificado.titulo_327LG == txtTitulo.Text &&
                           libroModificado.autor_327LG == txtAutor.Text &&
                           libroModificado.editorial_327LG == txtEditorial.Text &&
                           libroModificado.edicion_327LG == Convert.ToInt32(txtEdicion.Text))
                        {
                            throw new Exception(LM_327LG.ObtenerString("exception.sin_cambios"));
                        }
                        libroModificado.titulo_327LG = txtTitulo.Text;
                        libroModificado.autor_327LG = txtAutor.Text;
                        libroModificado.editorial_327LG = txtEditorial.Text;
                        libroModificado.edicion_327LG = Convert.ToInt32(txtEdicion.Text);

                        bllLibro_327LG.ModificarLibro_327LG(libroModificado);
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.libro_modificado"), LM_327LG.ObtenerString("messagebox.titulo.libro_modificado"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);

                        break;
                    case "Eliminar":
                        if (dgvLibros.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_fila"));
                        BELibro_327LG libroEliminar = bllLibro_327LG.ObtenerLibros_327LG().FirstOrDefault(x => x.ISBN_327LG == dgvLibros.SelectedRows[0].Cells["ISBN"].Value.ToString());
                        libroEliminar.Eliminado_327LG = true;
                        bllLibro_327LG.EliminarLibro_327LG(libroEliminar);
                        break;
                    default:
                        break;
                }
                ModoConsulta();
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modo = "Modificar";
            btnAplicar.Enabled = true;
            btnCancelar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCargarLibro.Enabled = false;
            txtISBN.Enabled = false;
            txtISBN.Text = dgvLibros.SelectedRows[0].Cells["ISBN"].Value.ToString();
            txtTitulo.Text = dgvLibros.SelectedRows[0].Cells["Titulo"].Value.ToString();
            txtAutor.Text = dgvLibros.SelectedRows[0].Cells["Autor"].Value.ToString();
            txtEdicion.Text = dgvLibros.SelectedRows[0].Cells["Edicion"].Value.ToString();
            txtEditorial.Text = dgvLibros.SelectedRows[0].Cells["Editorial"].Value.ToString();
            btnRefrescar.Enabled = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoConsulta();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            modo = "Eliminar";
            btnAplicar.Enabled = true;
            btnCancelar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCargarLibro.Enabled = false;
            btnRefrescar.Enabled = false;

        }

        private void dgvLibros_SelectionChanged(object sender, EventArgs e)
        {
            if (modo == "Modificar")
            {
                txtISBN.Text = dgvLibros.SelectedRows[0].Cells["ISBN"].Value.ToString();
                txtTitulo.Text = dgvLibros.SelectedRows[0].Cells["Titulo"].Value.ToString();
                txtAutor.Text = dgvLibros.SelectedRows[0].Cells["Autor"].Value.ToString();
                txtEdicion.Text = dgvLibros.SelectedRows[0].Cells["Edicion"].Value.ToString();
                txtEditorial.Text = dgvLibros.SelectedRows[0].Cells["Editorial"].Value.ToString();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}
