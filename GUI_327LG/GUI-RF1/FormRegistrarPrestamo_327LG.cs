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

namespace GUI_327LG.GUIRF1
{
    public partial class FormRegistrarPrestamo_327LG : Form, IObserverIdioma_327LG
    {
        LanguageManager_327LG LM_327LG;

        BLLCliente_327LG bllCliente_327LG;
        BLLPrestamo_327LG bllPrestamo_327LG;
        BLLEjemplar_327LG bllEjemplar_327LG;
        BLLSancion_327LG bllSancion_327LG;

        BECliente_327LG clienteSeleccionado;
        BEEjemplar_327LG ejemplarPrestamo;
        public FormRegistrarPrestamo_327LG()
        {
            InitializeComponent();
            bllCliente_327LG = new BLLCliente_327LG();
            bllPrestamo_327LG = new BLLPrestamo_327LG();
            bllEjemplar_327LG = new BLLEjemplar_327LG();
            bllSancion_327LG = new BLLSancion_327LG();

            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.MultiSelect = false;
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            LM_327LG.AgregarObservador_327LG(this);
            HabilitarLibroSeleccionado_327LG(false);
        }

        private void FormRegistrarPrestamo_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#055b6b");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }

            CargarGrillaClientes_327LG();
        }
        private void btnSeleccionarLibro_Click(object sender, EventArgs e)
        {
            using (FormSeleccionarLibro_327LG formSeleccionarLibro_327LG = new FormSeleccionarLibro_327LG())
            {
                if (formSeleccionarLibro_327LG.ShowDialog() == DialogResult.OK)
                {
                    ejemplarPrestamo = formSeleccionarLibro_327LG.libroSeleccionado_327LG;
                    HabilitarLibroSeleccionado_327LG(true);
                }
                else if (formSeleccionarLibro_327LG.DialogResult == DialogResult.Abort)
                {
                    ejemplarPrestamo = null;
                    HabilitarLibroSeleccionado_327LG(false);
                }
            }
        }

        private void HabilitarLibroSeleccionado_327LG(bool seleccionado)
        {
            LM_327LG.CargarFormulario_327LG("FormRegistrarPrestamo_327LG");
            lblTituloLibro.Visible = seleccionado;
            lblAutor.Visible = seleccionado;
            lblEdicion.Visible = seleccionado;
            lblEditorial.Visible = seleccionado;
            txtTitulo.Visible = seleccionado;
            txtAutor.Visible = seleccionado;
            txtEdicion.Visible = seleccionado;
            txtEditorial.Visible = seleccionado;
            if (seleccionado)
            {
                lblLibroSel.Text = LM_327LG.ObtenerString("label.lblLibroSeleccionado");
                txtTitulo.Text = ejemplarPrestamo.libro_327LG.titulo_327LG;
                txtAutor.Text = ejemplarPrestamo.libro_327LG.autor_327LG;
                txtEdicion.Text = ejemplarPrestamo.libro_327LG.edicion_327LG.ToString();
                txtEditorial.Text = ejemplarPrestamo.libro_327LG.editorial_327LG;
            }
            else
            {
                lblLibroSel.Text = LM_327LG.ObtenerString("label.lblLibroSeleccionado") + " - " + LM_327LG.ObtenerString("label.lblSeleccionarLibro");
                txtTitulo.Clear();
                txtAutor.Clear();
                txtEdicion.Clear();
                txtEditorial.Clear();
            }
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            using (FormRegistrarCliente_327LG formRegistrarCliente_327LG = new FormRegistrarCliente_327LG())
            {
                formRegistrarCliente_327LG.ShowDialog();
                CargarGrillaClientes_327LG();
            }
        }

        private void CargarGrillaClientes_327LG()
        {
            dgvClientes.DataSource = bllCliente_327LG.ObtenerClientes_327LG();
            dgvClientes.Columns["DNI_327LG"].FillWeight = 20;
            dgvClientes.Columns["Nombre_327LG"].FillWeight = 20;
            dgvClientes.Columns["Apellido_327LG"].FillWeight = 20;
            dgvClientes.Columns["Email_327LG"].FillWeight = 30;
            Actualizar_327LG();
        }
        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.cliente_no_seleccionado"));
                string dniSeleccionado = dgvClientes.SelectedRows[0].Cells["DNI_327LG"].Value.ToString();
                if (bllPrestamo_327LG.ObtenerPrestamos_327LG(dniSeleccionado).Any(x => x.Activo_327LG == true)) throw new Exception(LM_327LG.ObtenerString("exception.prestamo_activo"));
                if (bllSancion_327LG.ObtenerSanciones_327LG(dniSeleccionado).Count >= 3) throw new Exception(LM_327LG.ObtenerString("exception.sanciones_excedidas"));
                clienteSeleccionado = dgvClientes.SelectedRows[0].DataBoundItem as BECliente_327LG;
                MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.cliente_seleccionado") + " " + clienteSeleccionado.Nombre_327LG + " " + clienteSeleccionado.Apellido_327LG, LM_327LG.ObtenerString("messagebox.titulo.cliente_seleccionado"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
        private void FormRegistrarPrestamo_327LG_FormClosed(object sender, FormClosedEventArgs e)
        {
            LM_327LG.EliminarObservador_327LG(this);
        }
        private void btnRegistrarPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteSeleccionado == null) throw new Exception(LM_327LG.ObtenerString("exception.cliente_no_seleccionado"));
                if(ejemplarPrestamo == null) throw new Exception(LM_327LG.ObtenerString("exception.libro_no_seleccionado"));
                using (FormCobrarSeña_327LG formCobrarSeña_327LG = new FormCobrarSeña_327LG())
                {
                    formCobrarSeña_327LG.libro = ejemplarPrestamo.libro_327LG;
                    formCobrarSeña_327LG.cliente = clienteSeleccionado;
                    formCobrarSeña_327LG.ShowDialog();
                    if (formCobrarSeña_327LG.DialogResult == DialogResult.OK)
                    {
                        bllPrestamo_327LG.RegistrarPrestamo_327LG(clienteSeleccionado, ejemplarPrestamo);
                        bllEjemplar_327LG.CambiarEstado_327LG(ejemplarPrestamo.nroEjemplar_327LG, Estado_327LG.Prestado);
                        LM_327LG.CargarFormulario_327LG("FormRegistrarPrestamo_327LG");
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.prestamo_registrado"), LM_327LG.ObtenerString("messagebox.titulo.prestamo_registrado"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        public void Actualizar_327LG()
        {
            //strings de labels
            HabilitarLibroSeleccionado_327LG(ejemplarPrestamo != null);
            lblTituloForm.Text = LM_327LG.ObtenerString("label.lblTitulo");
            lblClientes.Text = LM_327LG.ObtenerString("label.lblClientes");
            lblDNICliente.Text = LM_327LG.ObtenerString("label.lblDNI");
            //string de datagridview
            dgvClientes.Columns["DNI_327LG"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.dni");
            dgvClientes.Columns["Nombre_327LG"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.nombre");
            dgvClientes.Columns["Apellido_327LG"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.apellido");
            dgvClientes.Columns["Email_327LG"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.correo");
            //strings de botones
            btnSeleccionarLibro.Text = LM_327LG.ObtenerString("button.btnSeleccionarLibro");
            btnRegistrarCliente.Text = LM_327LG.ObtenerString("button.btnRegistrarCliente");
            btnRegistrarPrestamo.Text = LM_327LG.ObtenerString("button.btnRegistrarPrestamo");
            btnFiltrar.Text = LM_327LG.ObtenerString("button.btnFiltrarClientes");
            btnSeleccionarCliente.Text = LM_327LG.ObtenerString("button.btnSeleccionarCliente");
            //strings libro seleccionado
            lblTituloLibro.Text = LM_327LG.ObtenerString("label.lblTituloLibro");
            lblAutor.Text = LM_327LG.ObtenerString("label.lblAutor");
            lblEdicion.Text = LM_327LG.ObtenerString("label.lblEdicion");
            lblEditorial.Text = LM_327LG.ObtenerString("label.lblEditorial");

        }

    }
}