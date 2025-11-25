using BE_327LG;
using BLL_327LG;
using Services_327LG.Observer_327LG;
using System.Data;

namespace GUI_327LG.GUI_RF2
{
    public partial class FormGenerarOrdenCompra_327LG : Form, IObserverIdioma_327LG
    {
        BLLSolicitudCotizacion_327LG bllSolicitudCotizacion_327LG = new BLLSolicitudCotizacion_327LG();
        BLLOrdenCompra_327LG bllOrdenCompra_327LG = new BLLOrdenCompra_327LG();
        LanguageManager_327LG LM_327LG;
        public FormGenerarOrdenCompra_327LG()
        {
            InitializeComponent();
            dgvSolicitudes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSolicitudes.MultiSelect = false;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.MultiSelect = false;
            dgvSolicitudes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSolicitudes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSolicitudes.RowHeadersVisible = false;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLibros.RowHeadersVisible = false;
            dgvLibros.Columns[6].DefaultCellStyle.Format = "C2";
            dgvLibros.Columns[7].DefaultCellStyle.Format = "C2";
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            LM_327LG.AgregarObservador_327LG(this);
        }

        private void SetEnabled(Control control, bool enabled)
        {
            control.Enabled = enabled;
            if (enabled)
            {
                control.BackColor = Color.White;
                control.ForeColor = Color.Black;
            }
            else
            {
                control.BackColor = Color.FromArgb(200, 200, 200);
                control.ForeColor = Color.DarkGray;
            }
        }

        private void FormGenerarOrdenCompra_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#055b6b");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }
            CargarGrillaSolicitudes();
            SetEnabled(txtCantidad, false);
            SetEnabled(txtPrecioUnit, false);
            SetEnabled(btnActualizar, false);
            SetEnabled(btnEliminar, false);
            SetEnabled(btnCancelar, false);
            SetEnabled(btnGenerarOrden, false);
            Actualizar_327LG();
        }

        private void CargarGrillaSolicitudes()
        {
            List<BESolicitudCotizacion_327LG> solicitudes = bllSolicitudCotizacion_327LG.ObtenerSolicitudesPendientes_327LG();
            var linq = from solicitud in solicitudes
                       orderby solicitud.NroSolicitud_327LG descending
                       select new
                       {
                           NroSolicitud = solicitud.NroSolicitud_327LG,
                           Distribuidor = solicitud.Distribuidor_327LG.Empresa_327LG,
                           Fecha = solicitud.Fecha_327LG.ToString("dd/MM/yyyy"),
                           Articulos = solicitud.librosSolicitados.Count()
                       };
            dgvSolicitudes.DataSource = linq.ToList();
        }

        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormGenerarOrdenCompra_327LG");

            //labels
            lblTitulo.Text = LM_327LG.ObtenerString("label.lblTitulo");
            lblSolicitudes.Text = LM_327LG.ObtenerString("label.lblSolicitudes");
            lblLibros.Text = LM_327LG.ObtenerString("label.lblLibros");
            lblCantidad.Text = LM_327LG.ObtenerString("label.lblCantidad");
            lblPrecioUnit.Text = LM_327LG.ObtenerString("label.lblPrecio");

            //buttons
            btnSeleccionar.Text = LM_327LG.ObtenerString("button.btnSeleccionar");
            btnActualizar.Text = LM_327LG.ObtenerString("button.btnActualizar");
            btnEliminar.Text = LM_327LG.ObtenerString("button.btnEliminar");
            btnCancelar.Text = LM_327LG.ObtenerString("button.btnCancelar");
            btnGenerarOrden.Text = LM_327LG.ObtenerString("button.btnGenerarOrden");

            //dataGridView columns
            dgvSolicitudes.Columns[0].HeaderText = LM_327LG.ObtenerString("datagridview.solicitudes.columna.nrosolicitud");
            dgvSolicitudes.Columns[1].HeaderText = LM_327LG.ObtenerString("datagridview.solicitudes.columna.distribuidor");
            dgvSolicitudes.Columns[2].HeaderText = LM_327LG.ObtenerString("datagridview.solicitudes.columna.fecha");
            dgvSolicitudes.Columns[3].HeaderText = LM_327LG.ObtenerString("datagridview.solicitudes.columna.articulos");

            dgvLibros.Columns[0].HeaderText = LM_327LG.ObtenerString("datagridview.libros.columna.isbn");
            dgvLibros.Columns[1].HeaderText = LM_327LG.ObtenerString("datagridview.libros.columna.titulo");
            dgvLibros.Columns[2].HeaderText = LM_327LG.ObtenerString("datagridview.libros.columna.autor");
            dgvLibros.Columns[3].HeaderText = LM_327LG.ObtenerString("datagridview.libros.columna.editorial");
            dgvLibros.Columns[4].HeaderText = LM_327LG.ObtenerString("datagridview.libros.columna.edicion");
            dgvLibros.Columns[5].HeaderText = LM_327LG.ObtenerString("datagridview.libros.columna.cantidad");
            dgvLibros.Columns[6].HeaderText = LM_327LG.ObtenerString("datagridview.libros.columna.preciounitario");
            dgvLibros.Columns[7].HeaderText = LM_327LG.ObtenerString("datagridview.libros.columna.subtotal");

        }

        private void FormGenerarOrdenCompra_327LG_FormClosed(object sender, FormClosedEventArgs e)
        {
            LM_327LG.EliminarObservador_327LG(this);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormGenerarOrdenCompra_327LG");
                if (MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.eliminar"), LM_327LG.ObtenerString("messagebox.titulo.eliminar"), LM_327LG.ObtenerString("messagebox.button.aceptar"), LM_327LG.ObtenerString("messagebox.button.cancelar"), MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (dgvLibros.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_libro"));
                    dgvLibros.Rows.Remove(dgvLibros.SelectedRows[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormGenerarOrdenCompra_327LG");

                if (dgvLibros.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_libro"));
                if (string.IsNullOrWhiteSpace(txtCantidad.Text.Trim())) throw new Exception(LM_327LG.ObtenerString("exception.cantidad_vacia"));
                if ((!int.TryParse(txtCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)) throw new Exception(LM_327LG.ObtenerString("exception.cantidad_invalida"));
                if (string.IsNullOrWhiteSpace(txtPrecioUnit.Text.Trim())) throw new Exception(LM_327LG.ObtenerString("exception.precio_vacio"));
                if (!decimal.TryParse(txtPrecioUnit.Text.Trim(), out decimal precio) || precio <= 0) throw new Exception(LM_327LG.ObtenerString("exception.precio_invalido"));
                DataGridViewRow fila = dgvLibros.SelectedRows[0];
                fila.Cells["Cantidad"].Value = txtCantidad.Text.TrimStart('0');
                fila.Cells[6].Value = Convert.ToDecimal(txtPrecioUnit.Text.TrimStart('0'));
                decimal subtotal = Convert.ToDecimal(txtCantidad.Text.Trim()) * Convert.ToDecimal(txtPrecioUnit.Text.Trim());
                fila.Cells["Subtotal"].Value = subtotal;
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormGenerarOrdenCompra_327LG");

                dgvLibros.Rows.Clear();
                if (dgvSolicitudes.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_solicitud"));
                string nroSolicitud = dgvSolicitudes.SelectedRows[0].Cells[0].Value.ToString();
                List<BEOrdenCompraDetalle_327LG> detalles = bllSolicitudCotizacion_327LG.ObtenerDetallesSolicitud_327LG(nroSolicitud);
                foreach (var detalle in detalles)
                {
                    dgvLibros.Rows.Add(detalle.libro_327LG.ISBN_327LG, detalle.libro_327LG.titulo_327LG, detalle.libro_327LG.autor_327LG, detalle.libro_327LG.edicion_327LG, detalle.libro_327LG.editorial_327LG, "0", 0, 0);
                }
                SetEnabled(txtCantidad, true);
                SetEnabled(txtPrecioUnit, true);
                SetEnabled(btnActualizar, true);
                SetEnabled(btnEliminar, true);
                SetEnabled(btnCancelar, true);
                SetEnabled(btnSeleccionar, false);
                SetEnabled(btnGenerarOrden, true);
                SetEnabled(dgvSolicitudes, false);
                dgvLibros.Columns["Titulo"].FillWeight = 200;
                dgvLibros.Columns["Autor"].FillWeight = 150;
                dgvLibros.Columns["Editorial"].FillWeight = 120;
                dgvLibros.Columns["Edicion"].FillWeight = 80;
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormGenerarOrdenCompra_327LG");
                if (MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.cancelar"), LM_327LG.ObtenerString("messagebox.titulo.cancelar"), LM_327LG.ObtenerString("messagebox.button.aceptar"), LM_327LG.ObtenerString("messagebox.button.cancelar"), MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SetEnabled(txtCantidad, false);
                    SetEnabled(txtPrecioUnit, false);
                    SetEnabled(btnActualizar, false);
                    SetEnabled(btnEliminar, false);
                    SetEnabled(btnCancelar, false);
                    SetEnabled(btnSeleccionar, true);
                    SetEnabled(btnGenerarOrden, false);
                    SetEnabled(dgvSolicitudes, true);

                    txtPrecioUnit.Clear();
                    txtCantidad.Clear();
                    dgvLibros.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnGenerarOrden_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormGenerarOrdenCompra_327LG");
                if (dgvSolicitudes.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_solicitud"));
                string nroSolicitud = dgvSolicitudes.SelectedRows[0].Cells[0].Value.ToString();
                BESolicitudCotizacion_327LG solicitud = bllSolicitudCotizacion_327LG.ObtenerSolicitudesPendientes_327LG().FirstOrDefault(x => x.NroSolicitud_327LG == nroSolicitud);
                decimal monto = 0;
                if (dgvLibros.Rows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.sin_libros_orden_compra"));
                foreach (DataGridViewRow fila in dgvLibros.Rows)
                {
                    if (fila.Cells["Cantidad"].Value == null || fila.Cells[6].Value == null)
                    {
                        throw new Exception(LM_327LG.ObtenerString("exception.campos_vacios_libro"));
                    }
                    if (!int.TryParse(fila.Cells["Cantidad"].Value.ToString(), out int cantidad) || cantidad <= 0)
                    {
                        throw new Exception(LM_327LG.ObtenerString("exception.cantidad_invalida_libro"));
                    }
                    if (!decimal.TryParse(fila.Cells[6].Value.ToString(), out decimal precio) || precio <= 0)
                    {
                        throw new Exception(LM_327LG.ObtenerString("exception.precio_invalido_libro"));
                    }
                    monto += Convert.ToDecimal(fila.Cells[7].Value);
                }

                using (FormPagarOrdenCompra_327LG form = new FormPagarOrdenCompra_327LG(monto, solicitud.Distribuidor_327LG.CUIT_327LG))
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        LM_327LG.CargarFormulario_327LG("FormGenerarOrdenCompra_327LG");
                        string CBU = form.CBU;
                        string Banco = form.Banco;
                        string NombreTitular = form.NombreTitular;
                        string NumeroTarjeta = form.NumeroTarjeta;
                        List<BEOrdenCompraDetalle_327LG> detalles = new List<BEOrdenCompraDetalle_327LG>();
                        decimal total = 0;
                        foreach (DataGridViewRow fila in dgvLibros.Rows)
                        {
                            string isbn = fila.Cells["ISBN"].Value.ToString();
                            int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                            decimal precioUnitario = Convert.ToDecimal(fila.Cells[6].Value);
                            BEOrdenCompraDetalle_327LG detalle = new BEOrdenCompraDetalle_327LG
                            {
                                libro_327LG = new BELibro_327LG { ISBN_327LG = isbn },
                                Cantidad_327LG = cantidad,
                                PrecioUnitario_327LG = precioUnitario
                            };
                            detalles.Add(detalle);
                            total += Convert.ToDecimal(fila.Cells[7].Value);
                        }
                        BEOrdenCompra_327LG ordenCompra = new BEOrdenCompra_327LG(DateTime.Now, solicitud.Distribuidor_327LG, total, detalles, Banco, CBU, NombreTitular, NumeroTarjeta, EstadoOrden_327LG.Solicitado);
                        bllOrdenCompra_327LG.GenerarOrdenCompra_327LG(ordenCompra);
                        bllSolicitudCotizacion_327LG.ActualizarEstadoSolicitud_327LG(nroSolicitud);
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.orden_compra_generada"), LM_327LG.ObtenerString("messagebox.titulo.exito"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        SetEnabled(txtCantidad, false);
                        SetEnabled(txtPrecioUnit, false);
                        SetEnabled(btnActualizar, false);
                        SetEnabled(btnEliminar, false);
                        SetEnabled(btnCancelar, false);
                        SetEnabled(btnSeleccionar, true);
                        SetEnabled(btnGenerarOrden, false);
                        SetEnabled(dgvSolicitudes, true);

                        txtPrecioUnit.Clear();
                        txtCantidad.Clear();
                        dgvLibros.Rows.Clear();
                    }
                    else
                    {
                        throw new Exception(LM_327LG.ObtenerString("exception.pago_no_completado"));
                    }
                    CargarGrillaSolicitudes();
                }

            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void dgvLibros_SelectionChanged(object sender, EventArgs e)
        {
            txtCantidad.Clear();
            txtPrecioUnit.Clear();
            if (dgvLibros.SelectedRows.Count > 0)
            {
                txtPrecioUnit.Text = dgvLibros.SelectedRows[0].Cells[6].Value.ToString();
                txtCantidad.Text = dgvLibros.SelectedRows[0].Cells["Cantidad"].Value.ToString();
            }

        }
    }
}