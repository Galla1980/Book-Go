using BE_327LG;
using BLL_327LG;
using Services_327LG.Observer_327LG;
using System.Data;

namespace GUI_327LG.GUIRF1
{
    public partial class FormRegDevolucion_327LG : Form, IObserverIdioma_327LG
    {
        LanguageManager_327LG LM_327LG;

        BLLPrestamo_327LG bllPrestamo_327LG;
        BLLSancion_327LG bllSancion_327LG;
        BLLEjemplar_327LG bLLEjemplar_327LG;

        private string dniCliente_327LG = string.Empty;
        string Estado = Estado_327LG.Disponible.ToString();

        public FormRegDevolucion_327LG()
        {
            InitializeComponent();
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            LM_327LG.AgregarObservador_327LG(this);

            bllPrestamo_327LG = new BLLPrestamo_327LG();
            bllSancion_327LG = new BLLSancion_327LG();
            bLLEjemplar_327LG = new BLLEjemplar_327LG();

            dgvPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrestamos.MultiSelect = false;
            Actualizar_327LG();
        }
        

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormRegDevolucion_327LG");
                
                if (bllPrestamo_327LG.ObtenerPrestamos_327LG(txtDNICliente.Text).Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.prestamos_no_encontrados"));
                dniCliente_327LG = txtDNICliente.Text;
                CargarGrillaPrestamos_327LG(dniCliente_327LG);
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
        private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormRegDevolucion_327LG");
                if (dgvPrestamos.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccione_prestamo"));
                if (dgvPrestamos.SelectedRows[0].Cells[4].Value.ToString() == "False") throw new Exception(LM_327LG.ObtenerString("exception.prestamo_ya_devuelto"));

                int nroPrestamo_327LG = Convert.ToInt32(dgvPrestamos.SelectedRows[0].Cells[0].Value);
                BEPrestamo_327LG prestamo = bllPrestamo_327LG.ObtenerPrestamos_327LG(null).FirstOrDefault(x => x.nroPrestamo_327LG == nroPrestamo_327LG);
                if(prestamo.FechaDevolucion_327LG != Convert.ToDateTime("1/1/0001 00:00:00")) throw new Exception("El prestamo ya fue devuelto.");
                BEEjemplar_327LG ejemplar = prestamo.Ejemplar_327LG;
                ejemplar.Estado_327LG = Estado_327LG.Disponible;
                prestamo.FechaDevolucion_327LG = DateTime.Today;
                prestamo.Activo_327LG = false;

                if (prestamo.FechaADevolver_327LG < DateTime.Today)
                {
                    MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.prestamo_vencido"), LM_327LG.ObtenerString("messagebox.titulo.prestamo_vencido"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                    using (FormRegSancion_327LG formRegistrarSancion = new FormRegSancion_327LG())
                    {
                        formRegistrarSancion.razon = "Devolución tardía";
                        formRegistrarSancion.ShowDialog();
                        if (formRegistrarSancion.DialogResult == DialogResult.OK)
                        {
                            BESancion_327LG sancion = new BESancion_327LG(prestamo.Cliente_327LG, prestamo, formRegistrarSancion.descripcion, formRegistrarSancion.razon);
                            bllSancion_327LG.RegistrarSancion_327LG(sancion);
                            MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.sancion_cargada"), LM_327LG.ObtenerString("messagebox.titulo.sancion_cargada"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);

                        }
                    }
                }
                if (Estado == Estado_327LG.Dañado.ToString())
                {
                    MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.libro_danado"), LM_327LG.ObtenerString("messagebox.titulo.libro_danado"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                    using (FormRegSancion_327LG formRegistrarSancion = new FormRegSancion_327LG())
                    {
                        formRegistrarSancion.razon = "Libro dañado";
                        ejemplar.Estado_327LG = Estado_327LG.Dañado;
                        formRegistrarSancion.ShowDialog();
                        if (formRegistrarSancion.DialogResult == DialogResult.OK)
                        {
                            BESancion_327LG sancion = new BESancion_327LG(prestamo.Cliente_327LG, prestamo, formRegistrarSancion.descripcion, formRegistrarSancion.razon);
                            bllSancion_327LG.RegistrarSancion_327LG(sancion);
                            MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.sancion_cargada"), LM_327LG.ObtenerString("messagebox.titulo.sancion_cargada"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);

                        }
                    }
                }
                if (Estado == Estado_327LG.Desaparecido.ToString())
                {
                    MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.libro_desaparecido"), LM_327LG.ObtenerString("messagebox.titulo.libro_desaparecido"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                    using (FormRegSancion_327LG formRegistrarSancion = new FormRegSancion_327LG())
                    {
                        formRegistrarSancion.razon = "Libro desaparecido";
                        formRegistrarSancion.ShowDialog();
                        ejemplar.Estado_327LG = Estado_327LG.Desaparecido;
                        if (formRegistrarSancion.DialogResult == DialogResult.OK)
                        {
                            BESancion_327LG sancion = new BESancion_327LG(prestamo.Cliente_327LG, prestamo, formRegistrarSancion.descripcion, formRegistrarSancion.razon);
                            bllSancion_327LG.RegistrarSancion_327LG(sancion);
                            MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.sancion_cargada"), LM_327LG.ObtenerString("messagebox.titulo.sancion_cargada"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                            
                        }

                    }
                }
                bllPrestamo_327LG.RegistrarDevolucion_327LG(prestamo);
                bLLEjemplar_327LG.CambiarEstado_327LG(ejemplar.nroEjemplar_327LG,ejemplar.Estado_327LG);
                MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.devolucion_cargada"), LM_327LG.ObtenerString("messagebox.titulo.devolucion_cargada"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                CargarGrillaPrestamos_327LG(null);
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void CargarGrillaPrestamos_327LG(string dniCliente)
        {
            var linq = from x in bllPrestamo_327LG.ObtenerPrestamos_327LG(dniCliente) select new { nroPrestamo = x.nroPrestamo_327LG, FechaDevolucion = x.FechaDevolucion_327LG, FechaADevolver = x.FechaADevolver_327LG, TituloLibro = x.Ejemplar_327LG.libro_327LG.titulo_327LG, Estado = x.Activo_327LG };
            dgvPrestamos.DataSource = linq.ToList();
            dgvPrestamos.Columns[4].Visible = false;
            foreach (DataGridViewRow row in dgvPrestamos.Rows)
            {
                if (Convert.ToBoolean(row.Cells[4].Value) == false)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (Convert.ToDateTime(row.Cells[2].Value) < DateTime.Today)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                if (dgvPrestamos.Rows.Count > 0)
                    dgvPrestamos.ClearSelection();
            }
            dgvPrestamos.Columns[0].HeaderText = LM_327LG.ObtenerString("datagridview.columna.nro_prestamo");
            dgvPrestamos.Columns[1].HeaderText = LM_327LG.ObtenerString("datagridview.columna.fecha_devolucion");
            dgvPrestamos.Columns[2].HeaderText = LM_327LG.ObtenerString("datagridview.columna.fecha_a_devolver");
            dgvPrestamos.Columns[3].HeaderText = LM_327LG.ObtenerString("datagridview.columna.titulo_libro");
            dgvPrestamos.Columns[0].FillWeight = 15;
            dgvPrestamos.Columns[1].FillWeight = 15;
            dgvPrestamos.Columns[2].FillWeight = 15;
            dgvPrestamos.Columns[3].FillWeight = 60;
        }

        private void FormRegDevolucion_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#055b6b");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }
            CargarGrillaPrestamos_327LG(null);
        }
        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormRegDevolucion_327LG");

            lblTituloForm.Text = LM_327LG.ObtenerString("label.lblTituloForm");
            lblPrestamos.Text = LM_327LG.ObtenerString("label.lblPrestamos");
            lblDNICliente.Text = LM_327LG.ObtenerString("label.lblDNICliente");
            lblEstadoLibro.Text = LM_327LG.ObtenerString("label.lblEstadoLibro");

            btnFiltrar.Text = LM_327LG.ObtenerString("button.btnFiltrar");
            btnRegistrarDevolucion.Text = LM_327LG.ObtenerString("button.btnRegistrarDevolucion");
            cmbEstadoLibro.Items.Clear();
            cmbEstadoLibro.Items.Add(LM_327LG.ObtenerString("combobox.itemDisponible"));
            cmbEstadoLibro.Items.Add(LM_327LG.ObtenerString("combobox.itemDanado"));
            cmbEstadoLibro.Items.Add(LM_327LG.ObtenerString("combobox.itemDesaparecido"));

            if (Estado == Estado_327LG.Disponible.ToString()) cmbEstadoLibro.Text = LM_327LG.ObtenerString("combobox.itemDisponible");
            else if (Estado == Estado_327LG.Dañado.ToString()) cmbEstadoLibro.Text = LM_327LG.ObtenerString("combobox.itemDanado");
            else if (Estado == Estado_327LG.Desaparecido.ToString()) cmbEstadoLibro.Text = LM_327LG.ObtenerString("combobox.itemDesaparecido");

            CargarGrillaPrestamos_327LG(dniCliente_327LG);
        }

        private void cmbEstadoLibro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstadoLibro.Text == LM_327LG.ObtenerString("combobox.itemDisponible")) Estado = Estado_327LG.Disponible.ToString();
            else if (cmbEstadoLibro.Text == LM_327LG.ObtenerString("combobox.itemDanado")) Estado = Estado_327LG.Dañado.ToString();
            else if (cmbEstadoLibro.Text == LM_327LG.ObtenerString("combobox.itemDesaparecido")) Estado = Estado_327LG.Desaparecido.ToString();
        }
    }
}