using BE_327LG;
using BLL_327LG;
using Services_327LG.Observer_327LG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_327LG.GUI_RF2
{
    public partial class FormSolicitarCotizacion_327LG : Form, IObserverIdioma_327LG
    {
        BLLDistribuidor_327LG bllDistribuidor_327LG = new BLLDistribuidor_327LG();
        BLLLibro_327LG bllLibro_327LG = new BLLLibro_327LG();
        BLLEjemplar_327LG bllEjemplar_327LG = new BLLEjemplar_327LG();
        BLLSolicitudCotizacion_327LG bllSolicitudCotizacion_327LG = new BLLSolicitudCotizacion_327LG();
        LanguageManager_327LG LM_327LG;
        public FormSolicitarCotizacion_327LG()
        {
            InitializeComponent();
            dgvDistribuidores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDistribuidores.MultiSelect = false;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.MultiSelect = false;
            dgvDistribuidores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDistribuidores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDistribuidores.RowHeadersVisible = false;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLibros.RowHeadersVisible = false;
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            LM_327LG.AgregarObservador_327LG(this);
        }

        private void FormSolicitarCotizacion_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#055b6b");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }
            CargarGrillaLibros(bllLibro_327LG.ObtenerLibros_327LG());
            CargarGrillaDistribuidores(bllDistribuidor_327LG.ObtenerDistribuidores_327LG());
            Actualizar_327LG();

        }

        private void CargarGrillaLibros(List<BELibro_327LG> libros)
        {
            List<BEEjemplar_327LG> ejemplares = bllEjemplar_327LG.ObtenerTodosEjemplares();
            var linq = from libro in libros
                       join e in ejemplares
                           on libro.ISBN_327LG equals e.ISBN_327LG into grupo
                       select new
                       {
                           ISBN = libro.ISBN_327LG,
                           Titulo = libro.titulo_327LG,
                           Autor = libro.autor_327LG,
                           Editorial = libro.editorial_327LG,
                           Edicion = libro.edicion_327LG,
                           Disponibles = grupo.Count(e => e.Estado_327LG == Estado_327LG.Disponible),
                           Prestados = grupo.Count(e => e.Estado_327LG == Estado_327LG.Prestado)
                       };
            dgvLibros.DataSource = linq.ToList();
            dgvLibros.Columns["Titulo"].FillWeight = 200;
            dgvLibros.Columns["Autor"].FillWeight = 150;
            dgvLibros.Columns["Editorial"].FillWeight = 120;
            dgvLibros.Columns["Edicion"].FillWeight = 80;
            dgvLibros.Columns["Disponibles"].FillWeight = 82;
            dgvLibros.Columns["Prestados"].FillWeight = 75;

        }

        private void CargarGrillaDistribuidores(List<BEDistribuidor_327LG> distribuidores)
        {
            var linq = from x in distribuidores
                       where x.Activo_327LG == true
                       select new
                       {
                           CUIT = x.CUIT_327LG,
                           Empresa = x.Empresa_327LG,
                           Telefono = x.Telefono_327LG,
                           Direccion = x.Direccion_327LG,
                           Correo = x.Correo_327LG
                       };
            dgvDistribuidores.DataSource = linq.ToList();
            dgvDistribuidores.Columns["CUIT"].FillWeight = 80;
            dgvDistribuidores.Columns["Empresa"].FillWeight = 150;
            dgvDistribuidores.Columns["Telefono"].FillWeight = 100;
            dgvDistribuidores.Columns["Direccion"].FillWeight = 150;
            dgvDistribuidores.Columns["Correo"].FillWeight = 150;

        }

        private void dgvLibros_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dr in dgvLibros.Rows)
            {
                if (Convert.ToInt32(dr.Cells[5].Value) == 0)
                {
                    dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 180, 180);
                }
                else if (Convert.ToInt32(dr.Cells[5].Value) < 5)
                {
                    dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 180);
                }
            }
        }

        private void btnFiltrarLibros_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormSolicitarCotizacion_327LG");
                string? isbn = string.IsNullOrWhiteSpace(txtISBN.Text) ? null : txtISBN.Text.Trim();
                string? autor = string.IsNullOrWhiteSpace(txtAutor.Text) ? null : txtAutor.Text.Trim();
                string? titulo = string.IsNullOrWhiteSpace(txtTitulo.Text) ? null : txtTitulo.Text.Trim();
                string? editorial = string.IsNullOrWhiteSpace(txtEditorial.Text) ? null : txtEditorial.Text.Trim();
                string edicionTexto = txtEdicion.Text.Trim();
                int? edicion = null;

                if (!string.IsNullOrWhiteSpace(edicionTexto))
                {
                    if (edicionTexto.All(char.IsDigit))
                        edicion = int.Parse(edicionTexto);
                    else
                        throw new Exception("La edición debe contener solo números.");
                }
                List<BELibro_327LG> librosFiltrados = bllLibro_327LG.FiltrarLibros_327LG(isbn, titulo, autor, editorial, edicion);
                if (librosFiltrados.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.libro_no_encontrado"));
                CargarGrillaLibros(librosFiltrados);


            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnFiltrarDistribuidor_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormSolicitarCotizacion_327LG");
                string? cuit = string.IsNullOrWhiteSpace(txtCUIT.Text) ? null : txtCUIT.Text.Trim();
                string? empresa = string.IsNullOrWhiteSpace(txtEmpresa.Text) ? null : txtEmpresa.Text.Trim();
                List<BEDistribuidor_327LG> distribuidoresFiltrados = bllDistribuidor_327LG.FiltrarDistribuidores_327LG(cuit, empresa);
                if (distribuidoresFiltrados.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.distribuidor_no_encontrado"));
                CargarGrillaDistribuidores(distribuidoresFiltrados);

            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormSolicitarCotizacion_327LG");
                if (dgvLibros.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_libro"));
                string isbn = dgvLibros.SelectedRows[0].Cells["ISBN"].Value.ToString();
                string titulo = dgvLibros.SelectedRows[0].Cells["Titulo"].Value.ToString();
                string autor = dgvLibros.SelectedRows[0].Cells["Autor"].Value.ToString();

                string libro = $"{isbn} - {titulo} - {autor}";
                if (lstLibros.Items.Contains(libro)) throw new Exception(LM_327LG.ObtenerString("exception.libro_ya_agregado"));
                lstLibros.Items.Add(libro);
            }
            catch (Exception ex)
            {

                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);

            }
        }
        private void btnQuitarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormSolicitarCotizacion_327LG");
                if (lstLibros.SelectedItems.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_libro_lista"));
                string libro = lstLibros.SelectedItem.ToString();
                lstLibros.Items.Remove(libro);
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
        private void btnAgregarDistribuidor_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormSolicitarCotizacion_327LG");
                if (dgvDistribuidores.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_fila"));
                string cuit = dgvDistribuidores.SelectedRows[0].Cells["CUIT"].Value.ToString();
                string empresa = dgvDistribuidores.SelectedRows[0].Cells["Empresa"].Value.ToString();
                string distribuidor = $"{cuit} - {empresa}";
                if (lstDistribuidores.Items.Contains(distribuidor)) throw new Exception(LM_327LG.ObtenerString("exception.distribuidor_ya_agregado"));
                lstDistribuidores.Items.Add(distribuidor);
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
        private void btnQuitarDistribuidor_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormSolicitarCotizacion_327LG");
                if (lstDistribuidores.SelectedItems.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_distribuidor_lista"));
                string distribuidor = lstDistribuidores.SelectedItem.ToString();
                lstDistribuidores.Items.Remove(distribuidor);
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormSolicitarCotizacion_327LG");

            //labels 
            lblTituloForm.Text = LM_327LG.ObtenerString("label.lblTituloForm");
            lblEjemplares.Text = LM_327LG.ObtenerString("label.lblEjemplares");
            lblLibroSeleccionado.Text = LM_327LG.ObtenerString("label.lblLibroSeleccionado");
            lblISBN.Text = LM_327LG.ObtenerString("label.lblISBN");
            lblTitulo.Text = LM_327LG.ObtenerString("label.lblTitulo");
            lblAutor.Text = LM_327LG.ObtenerString("label.lblAutor");
            lblEditorial.Text = LM_327LG.ObtenerString("label.lblEditorial");
            lblEdicion.Text = LM_327LG.ObtenerString("label.lblEdicion");
            lblDistribuidores.Text = LM_327LG.ObtenerString("label.lblDistribuidores");
            lblDistribuidorSeleccionado.Text = LM_327LG.ObtenerString("label.lblDistribuidorSeleccionado");
            lblCUIT.Text = LM_327LG.ObtenerString("label.lblCUIT");
            lblEmpresa.Text = LM_327LG.ObtenerString("label.lblEmpresa");

            //buttons
            btnAgregarLibro.Text = LM_327LG.ObtenerString("button.btnAgregarLibro");
            btnQuitarLibro.Text = LM_327LG.ObtenerString("button.btnQuitarLibro");
            btnFiltrarLibros.Text = LM_327LG.ObtenerString("button.btnFiltrar");
            btnFiltrarDistribuidor.Text = LM_327LG.ObtenerString("button.btnFiltrar");
            btnAgregarDistribuidor.Text = LM_327LG.ObtenerString("button.btnAgregarDistribuidor");
            btnQuitarDistribuidor.Text = LM_327LG.ObtenerString("button.btnQuitarDistribuidor");
            btnGenerarSolicitud.Text = LM_327LG.ObtenerString("button.btnGenerarSolicitud");


            //DataGridView 
            dgvLibros.Columns["ISBN"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.isbn");
            dgvLibros.Columns["Titulo"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.titulo");
            dgvLibros.Columns["Autor"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.autor");
            dgvLibros.Columns["Editorial"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.editorial");
            dgvLibros.Columns["Edicion"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.edicion");
            dgvLibros.Columns["Disponibles"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.disponibles");
            dgvLibros.Columns["Prestados"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.prestados");

            dgvDistribuidores.Columns["CUIT"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.cuit");
            dgvDistribuidores.Columns["Empresa"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.empresa");
            dgvDistribuidores.Columns["Telefono"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.telefono");
            dgvDistribuidores.Columns["Direccion"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.direccion");
            dgvDistribuidores.Columns["Correo"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.correo");

        }

        private void FormSolicitarCotizacion_327LG_FormClosed(object sender, FormClosedEventArgs e)
        {
            LM_327LG.EliminarObservador_327LG(this);
        }

        private void btnGenerarSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormSolicitarCotizacion_327LG");
                if (lstLibros.Items.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.lista_libros_vacia"));
                if(lstDistribuidores.Items.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.lista_distribuidores_vacia"));
                List<BELibro_327LG> libros = bllLibro_327LG.ObtenerLibros_327LG();
                List<BELibro_327LG> librosSolicitados = new List<BELibro_327LG>();
                foreach (string libro in lstLibros.Items)
                {
                    string isbn = libro.Split(" - ")[0];
                    BELibro_327LG libro_327LG = libros.Find(x=> x.ISBN_327LG == isbn);
                    librosSolicitados.Add(libro_327LG);
                }
                List<BEDistribuidor_327LG> distribuidores = bllDistribuidor_327LG.ObtenerDistribuidores_327LG();
                
                foreach (string distribuidor in lstDistribuidores.Items)
                {
                    string cuit = distribuidor.Split(" - ")[0];
                    BEDistribuidor_327LG distribuidor_327LG = distribuidores.Find(x => x.CUIT_327LG == cuit);
                    var librosrepetidos = bllSolicitudCotizacion_327LG.SolicitudRepetida_327LG(distribuidor_327LG, librosSolicitados);

                    if (librosrepetidos.Any())
                    {
                        string titulos = "\n-" + string.Join("\n-", librosrepetidos.Select(l => l.titulo_327LG));
                        throw new Exception($"{LM_327LG.ObtenerString("exception.solicitud_repetida")} {titulos}");
                    }
                    bllSolicitudCotizacion_327LG.GenerarSolicitudCotizacion_327LG(librosSolicitados, distribuidor_327LG);
                }
                MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.solicitud_generada_exito"), LM_327LG.ObtenerString("messagebox.titulo.solicitud_generada_exito"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
    }
}
