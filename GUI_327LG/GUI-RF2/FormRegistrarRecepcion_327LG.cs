using BE_327LG;
using BLL_327LG;
using Services_327LG.Observer_327LG;
using System.Data;

namespace GUI_327LG.GUI_RF2
{
    public partial class FormRegistrarRecepcion_327LG : Form, IObserverIdioma_327LG
    {
        BLLOrdenCompra_327LG bllOrdenCompra_327LG = new BLLOrdenCompra_327LG();
        BLLRecepcion_327LG bllRecepcion_327LG = new BLLRecepcion_327LG();
        BLLEjemplar_327LG bllEjemplar_327LG = new BLLEjemplar_327LG();
        LanguageManager_327LG LM_327LG = LanguageManager_327LG.Instance_327LG;
        public FormRegistrarRecepcion_327LG()
        {
            InitializeComponent();
            dgvOrdenesCompra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenesCompra.MultiSelect = false;
            dgvOrdenesCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenesCompra.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvOrdenesCompra.RowHeadersVisible = false;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.MultiSelect = false;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLibros.RowHeadersVisible = false;
            LM_327LG.AgregarObservador_327LG(this);

        }

        private void FormRegistrarRecepcion_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#055b6b");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }
            foreach (RadioButton rdo in this.Controls.OfType<RadioButton>())
            {
                rdo.ForeColor = Color.White;
                rdo.BackColor = Color.Transparent;
            }
            CargarGrillaOrdenesDeCompra();
            ModoDeseleccionado();
        }

        private void ModoDeseleccionado()
        {
            SetEnabled(btnSeleccionar, true);
            SetEnabled(btnCancelar, false);
            SetEnabled(btnActualizar, false);
            SetEnabled(btnRegistrar, false);
            SetEnabled(txtCantRecibida, false);
            SetEnabled(dgvOrdenesCompra, true);
            rdoPendientes.Enabled = true;
            rdoTodas.Enabled = true;
            dgvLibros.Rows.Clear();
        }

        private void CargarGrillaOrdenesDeCompra()
        {
            List<BEOrdenCompra_327LG> listaOrdenes = bllOrdenCompra_327LG.ObtenerOrdenesCompra_327LG();
            if (rdoPendientes.Checked)
            {
                listaOrdenes = listaOrdenes.Where(o => o.Estado_327LG != EstadoOrden_327LG.Entregado).ToList();
            }
            var linq = from orden in listaOrdenes
                       select new
                       {
                           NroOrden = orden.nroOrden_327LG,
                           Fecha = orden.Fecha_327LG.ToShortDateString(),
                           Distribuidor = orden.Distribuidor_327LG.Empresa_327LG,
                           Total = orden.Total_327LG,
                           Estado = orden.Estado_327LG.ToString()
                       };
            dgvOrdenesCompra.DataSource = linq.ToList();

            Actualizar_327LG();
        }


        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormRegistrarRecepcion_327LG");
                if (dgvOrdenesCompra.Rows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_orden"));

                SetEnabled(btnCancelar, true);
                SetEnabled(btnActualizar, true);
                SetEnabled(btnRegistrar, true);
                SetEnabled(btnSeleccionar, false);
                SetEnabled(txtCantRecibida, true);
                SetEnabled(dgvOrdenesCompra, false);
                rdoTodas.Enabled = false;
                rdoPendientes.Enabled = false;
                dgvLibros.Rows.Clear();
                string nroOrdenSeleccionada = dgvOrdenesCompra.SelectedRows[0].Cells["NroOrden"].Value.ToString();
                List<BEOrdenCompraDetalle_327LG> detallesOrden = bllOrdenCompra_327LG.ObtenerDetalles_327LG(nroOrdenSeleccionada);
                foreach (var detalle in detallesOrden)
                {
                    int cantidadRecibida = bllRecepcion_327LG.ObtenerCantidadRecibida_327LG(nroOrdenSeleccionada, detalle.libro_327LG.ISBN_327LG);
                    dgvLibros.Rows.Add(detalle.libro_327LG.ISBN_327LG, detalle.libro_327LG.titulo_327LG, detalle.Cantidad_327LG, cantidadRecibida, 0);
                }
                dgvLibros.Columns["ISBN"].FillWeight = 80;
                dgvLibros.Columns["Titulo"].FillWeight = 220;
                dgvLibros.Columns["CantPedida"].FillWeight = 90;
                dgvLibros.Columns["CantRecibida"].FillWeight = 90;
                dgvLibros.Columns["CantIngresar"].FillWeight = 100;
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);

            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoDeseleccionado();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormRegistrarRecepcion_327LG");
                if (dgvLibros.Rows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_libro"));
                if (txtCantRecibida.Text.Trim() == string.Empty) throw new Exception(LM_327LG.ObtenerString("exception.cantidad_vacia"));
                if (!int.TryParse(txtCantRecibida.Text, out int cantRecibida) || cantRecibida < 0) throw new Exception(LM_327LG.ObtenerString("exception.cantidad_invalida"));
                int cantPedida = Convert.ToInt32(dgvLibros.SelectedRows[0].Cells["CantPedida"].Value);
                int cantYaRecibida = Convert.ToInt32(dgvLibros.SelectedRows[0].Cells["CantRecibida"].Value);
                if (cantRecibida + cantYaRecibida > cantPedida) throw new Exception(LM_327LG.ObtenerString("exception.cantidad_excede_pedida"));

                dgvLibros.SelectedRows[0].Cells["CantIngresar"].Value = cantRecibida;
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormRegistrarRecepcion_327LG");
                if (dgvOrdenesCompra.SelectedRows[0].Cells["Estado"].Value.ToString() == EstadoOrden_327LG.Entregado.ToString())
                {
                    throw new Exception(LM_327LG.ObtenerString("exception.orden_ya_entregada"));
                }
                if (dgvOrdenesCompra.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_orden"));
                bool hayIngresos = false;
                foreach (DataGridViewRow row in dgvLibros.Rows)
                {
                    int cantIngresar = Convert.ToInt32(row.Cells["CantIngresar"].Value);
                    if (cantIngresar > 0)
                    {
                        hayIngresos = true;
                        break;
                    }
                }
                if (!hayIngresos) throw new Exception(LM_327LG.ObtenerString("exception.sin_cantidades_a_ingresar"));
                if (MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.confirmar_recepcion"), LM_327LG.ObtenerString("messagebox.titulo.confirmar_recepcion"), LM_327LG.ObtenerString("messagebox.button.aceptar"), LM_327LG.ObtenerString("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string nroOrdenSeleccionada = dgvOrdenesCompra.SelectedRows[0].Cells["NroOrden"].Value.ToString();
                    BEOrdenCompra_327LG orden = bllOrdenCompra_327LG.ObtenerOrdenesCompra_327LG().Find(x => x.nroOrden_327LG == nroOrdenSeleccionada);
                    BERecepcion_327LG nuevaRecepcion = new BERecepcion_327LG(DateTime.Now, orden);

                    foreach (DataGridViewRow row in dgvLibros.Rows)
                    {
                        int cantIngresar = Convert.ToInt32(row.Cells["CantIngresar"].Value);
                        if (cantIngresar > 0)
                        {
                            BERepcecionDetalle_327LG detalleRecepcion = new BERepcecionDetalle_327LG();
                            string isbn = row.Cells["ISBN"].Value.ToString();
                            BEOrdenCompraDetalle_327LG detalleOrden = bllOrdenCompra_327LG.ObtenerDetalles_327LG(orden.nroOrden_327LG).Find(x => x.libro_327LG.ISBN_327LG == isbn);
                            BELibro_327LG libro = detalleOrden.libro_327LG;
                            detalleRecepcion.Libro_327LG = libro;
                            detalleRecepcion.Cantidad_327LG = cantIngresar;
                            nuevaRecepcion.LibrosRecibidos_327LG.Add(detalleRecepcion);
                        }
                    }
                    bllRecepcion_327LG.RegistrarRecepcion_327LG(nuevaRecepcion);
                    //cambiar estado de la orden

                    bool completa = true;
                    foreach (BEOrdenCompraDetalle_327LG detalle in bllOrdenCompra_327LG.ObtenerDetalles_327LG(nroOrdenSeleccionada))
                    {
                        int cantRecibida = bllRecepcion_327LG.ObtenerCantidadRecibida_327LG(nroOrdenSeleccionada, detalle.libro_327LG.ISBN_327LG);
                        if (cantRecibida < detalle.Cantidad_327LG)
                        {
                            completa = false;
                            break;
                        }
                    }
                    if (completa)
                    {
                        orden.Estado_327LG = EstadoOrden_327LG.Entregado;
                    }
                    else
                    {
                        orden.Estado_327LG = EstadoOrden_327LG.Incompleto;
                    }
                    bllOrdenCompra_327LG.ActualizarEstadoOrden(orden);
                    MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.recepcion_registrada"), LM_327LG.ObtenerString("messagebox.titulo.exito"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                    CargarGrillaOrdenesDeCompra();
                    ModoDeseleccionado();
                }
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormRegistrarRecepcion_327LG");

            //labels
            lblLibros.Text = LM_327LG.ObtenerString("label.lblLibros");
            lblListaOrdenes.Text = LM_327LG.ObtenerString("label.lblOrdenesCompra");
            lblTitulo.Text = LM_327LG.ObtenerString("label.lblTitulo");
            lblCant.Text = LM_327LG.ObtenerString("label.lblCantidad");
            //buttons
            btnSeleccionar.Text = LM_327LG.ObtenerString("button.btnSeleccionar");
            btnActualizar.Text = LM_327LG.ObtenerString("button.btnActualizar");
            btnCancelar.Text = LM_327LG.ObtenerString("button.btnCancelar");
            btnRegistrar.Text = LM_327LG.ObtenerString("button.btnRegistrar");

            //radiobutton
            rdoPendientes.Text = LM_327LG.ObtenerString("radiobutton.rdoPendientes");
            rdoTodas.Text = LM_327LG.ObtenerString("radiobutton.rdoTodas");

            //dataGridView columns
            dgvOrdenesCompra.Columns["NroOrden"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.nroOrden");
            dgvOrdenesCompra.Columns["Fecha"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.fecha");
            dgvOrdenesCompra.Columns["Distribuidor"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.distribuidor");
            dgvOrdenesCompra.Columns["Total"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.total");
            dgvOrdenesCompra.Columns["Estado"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.estado");

            dgvLibros.Columns["ISBN"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.isbn");
            dgvLibros.Columns["Titulo"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.titulo");
            dgvLibros.Columns["CantPedida"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.cantPedida");
            dgvLibros.Columns["CantRecibida"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.cantRecibida");
            dgvLibros.Columns["CantIngresar"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.cantIngresar");

        }

        private void FormRegistrarRecepcion_327LG_FormClosed(object sender, FormClosedEventArgs e)
        {
            LM_327LG.EliminarObservador_327LG(this);
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

        private void dgvLibros_SelectionChanged(object sender, EventArgs e)
        {
            txtCantRecibida.Clear();
            if (dgvLibros.SelectedRows.Count != 0)
            {
                txtCantRecibida.Text = dgvLibros.SelectedRows[0].Cells["CantIngresar"].Value.ToString();
            }
        }

        private void rdoTodas_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrillaOrdenesDeCompra();
        }

        private void dgvOrdenesCompra_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvOrdenesCompra.Rows)
            {
                if (row.Cells["Estado"].Value == null) continue;

                string estado = row.Cells["Estado"].Value.ToString();

                if (estado == EstadoOrden_327LG.Entregado.ToString())
                {
                    // Verde suave pastel
                    row.DefaultCellStyle.BackColor = Color.FromArgb(198, 239, 206);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 97, 0);
                }
                else if (estado == EstadoOrden_327LG.Incompleto.ToString())
                {
                    // Amarillo pastel suave
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 156);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(102, 60, 0);
                }
            }
        }

    }
}
