using BE_327LG;
using BLL_327LG;
using Services_327LG.Observer_327LG;
using System.Data;

namespace GUI_327LG
{
    public partial class FormLibro_C_327LG : Form, IObserverIdioma_327LG
    {
        BLLLibro_C_327LG bllLibro_C_327LG = new BLLLibro_C_327LG();
        LanguageManager_327LG LM_327LG = LanguageManager_327LG.Instance_327LG;
        public FormLibro_C_327LG()
        {
            InitializeComponent();
            LM_327LG.AgregarObservador_327LG(this);
            dgvLibro_C.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibro_C.MultiSelect = false;
            dgvLibro_C.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibro_C.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLibro_C.RowHeadersVisible = false;
        }

        private void FormLibro_C_327LG_Load(object sender, EventArgs e)
        {
            CargarGrilla(bllLibro_C_327LG.ObtenerTodosCambios_327LG());
        }

        private void CargarGrilla(List<BELibro_C_327LG> listaCambios)
        {
            var linq = from cambio in listaCambios
                       select new
                       {
                           IdCambio = cambio.IDCambio_327LG,
                           ISBN = cambio.ISBN_327LG,
                           Fecha = cambio.Fecha_327LG,
                           Hora = cambio.Hora_327LG,
                           Titulo = cambio.Titulo_327LG,
                           Autor = cambio.Autor_327LG,
                           Editorial = cambio.Editorial_327LG,
                           Edicion = cambio.Edicion_327LG,
                           Eliminado = cambio.Eliminado_327LG,
                           Activo = cambio.Activo_327LG
                       };
            dgvLibro_C.DataSource = linq.ToList();
            dgvLibro_C.Columns["IdCambio"].FillWeight = 80;
            dgvLibro_C.Columns["ISBN"].FillWeight = 100;
            dgvLibro_C.Columns["Fecha"].FillWeight = 100;
            dgvLibro_C.Columns["Hora"].FillWeight = 80;
            dgvLibro_C.Columns["Titulo"].FillWeight = 200;
            dgvLibro_C.Columns["Autor"].FillWeight = 150;
            dgvLibro_C.Columns["Editorial"].FillWeight = 120;
            dgvLibro_C.Columns["Edicion"].FillWeight = 80;
            dgvLibro_C.Columns["Eliminado"].FillWeight = 80;
            dgvLibro_C.Columns["Activo"].FillWeight = 80;

            Actualizar_327LG();
        }

        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormLibro_C_327LG");
            //label
            lblTitulo.Text = LM_327LG.ObtenerString("label.lblTituloForm");
            lblTituloLibro.Text = LM_327LG.ObtenerString("label.lblTituloLibro");
            lblAutor.Text = LM_327LG.ObtenerString("label.lblAutor");
            lblEditorial.Text = LM_327LG.ObtenerString("label.lblEditorial");
            lblEdicion.Text = LM_327LG.ObtenerString("label.lblEdicion");
            lblFechaInicio.Text = LM_327LG.ObtenerString("label.lblFechaInicio");
            lblFechaFin.Text = LM_327LG.ObtenerString("label.lblFechaFin");

            //button
            btnFiltrar.Text = LM_327LG.ObtenerString("button.btnFiltrar");
            btnLimpiar.Text = LM_327LG.ObtenerString("button.btnLimpiar");
            btnActivar.Text = LM_327LG.ObtenerString("button.btnActivar");

            //DataGridView Headers
            dgvLibro_C.Columns["IdCambio"].HeaderText = LM_327LG.ObtenerString("dataGridView.idCambio");
            dgvLibro_C.Columns["Fecha"].HeaderText = LM_327LG.ObtenerString("dataGridView.Fecha");
            dgvLibro_C.Columns["Hora"].HeaderText = LM_327LG.ObtenerString("dataGridView.Hora");
            dgvLibro_C.Columns["Titulo"].HeaderText = LM_327LG.ObtenerString("dataGridView.Titulo");
            dgvLibro_C.Columns["Autor"].HeaderText = LM_327LG.ObtenerString("dataGridView.Autor");
            dgvLibro_C.Columns["Editorial"].HeaderText = LM_327LG.ObtenerString("dataGridView.Editorial");
            dgvLibro_C.Columns["Edicion"].HeaderText = LM_327LG.ObtenerString("dataGridView.Edicion");
            dgvLibro_C.Columns["Eliminado"].HeaderText = LM_327LG.ObtenerString("dataGridView.Eliminado");
            dgvLibro_C.Columns["Activo"].HeaderText = LM_327LG.ObtenerString("dataGridView.Activo");

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormLibro_C_327LG");
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = string.Empty;
                }
            }
            chkFecha.Checked = false;
            dtpFechaFin.Value = DateTime.Now;
            dtpFechaInicio.Value = DateTime.Now;
            CargarGrilla(bllLibro_C_327LG.ObtenerTodosCambios_327LG());
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormLibro_C_327LG");
                DateTime? fechaInicio = null;
                DateTime? fechaFin = null;
                if (chkFecha.Checked == true)
                {
                    if (dtpFechaInicio.Value.Date > dtpFechaFin.Value.Date)
                    {
                        dtpFechaFin.Value = DateTime.Now;
                        dtpFechaInicio.Value = DateTime.Now;
                        throw new Exception(LM_327LG.ObtenerString("exception.fecha_inicio_menor_fin"));
                    }
                    if (dtpFechaFin.Value.Date > DateTime.Now.Date || dtpFechaInicio.Value.Date > DateTime.Now.Date)
                    {
                        dtpFechaFin.Value = DateTime.Now;
                        dtpFechaInicio.Value = DateTime.Now;
                        throw new Exception(LM_327LG.ObtenerString("exception.fechas_futuras"));
                    }
                    fechaInicio = dtpFechaInicio.Value.Date;
                    fechaFin = dtpFechaFin.Value.Date;
                }
                string edicionTexto = txtEdicion.Text.Trim();
                int? edicion = null;
                if (!string.IsNullOrWhiteSpace(edicionTexto))
                {
                    if (edicionTexto.All(char.IsDigit))
                    {
                        int valor = int.Parse(edicionTexto);
                        if (valor <= 0)
                            throw new Exception(LM_327LG.ObtenerString("exception.edicion_numerica"));

                        edicion = valor;
                    }
                    else
                    {
                        throw new Exception(LM_327LG.ObtenerString("exception.edicion_numerica"));
                    }
                }
                string? isbnTexto = string.IsNullOrEmpty(txtISBN.Text) ? null : txtISBN.Text;
                string? tituloTexto = string.IsNullOrEmpty(txtTitulo.Text) ? null : txtTitulo.Text;
                string? autorTexto = string.IsNullOrEmpty(txtAutor.Text) ? null : txtAutor.Text;
                string? editorialTexto = string.IsNullOrEmpty(txtEditorial.Text) ? null : txtEditorial.Text;

                List<BELibro_C_327LG> listaFiltrada = bllLibro_C_327LG.FiltrarCambios_327LG(
                    isbnTexto,
                    tituloTexto,
                    autorTexto,
                    editorialTexto,
                    edicion,
                    fechaInicio,
                    fechaFin);
                if (listaFiltrada.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.sin_resultados"));
                CargarGrilla(listaFiltrada);
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }

        }

        private void FormLibro_C_327LG_FormClosed(object sender, FormClosedEventArgs e)
        {
            LM_327LG.EliminarObservador_327LG(this);
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFecha.Checked)
            {
                dtpFechaInicio.Enabled = true;
                dtpFechaFin.Enabled = true;
            }
            else
            {
                dtpFechaInicio.Enabled = false;
                dtpFechaFin.Enabled = false;
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormLibro_C_327LG");
                if (dgvLibro_C.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_fila"));
                int idCambio = Convert.ToInt32(dgvLibro_C.SelectedRows[0].Cells["IdCambio"].Value);
                BELibro_C_327LG cambio = bllLibro_C_327LG.ObtenerTodosCambios_327LG().FirstOrDefault(x => x.IDCambio_327LG == idCambio);
                if (cambio == null) throw new Exception(LM_327LG.ObtenerString("exception.cambio_no_encontrado"));
                if (cambio.Activo_327LG) throw new Exception(LM_327LG.ObtenerString("exception.cambio_activo"));
                bllLibro_C_327LG.ActivarCambio_327LG(cambio);
                MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.cambio_activado"), LM_327LG.ObtenerString("messagebox.titulo.cambio_activado"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                CargarGrilla(bllLibro_C_327LG.ObtenerTodosCambios_327LG());
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
    }
}
