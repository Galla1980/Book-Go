using BE_327LG;
using BLL_327LG;
using Microsoft.IdentityModel.Tokens;
using Services_327LG.Observer_327LG;
using System.Diagnostics;

namespace GUI_327LG.GUIRF1
{
    public partial class FormSeleccionarLibro_327LG : Form, IObserverIdioma_327LG
    {
        BLLLibro_327LG bllLibro_327LG;
        LanguageManager_327LG LM_327LG;
        BLLEjemplar_327LG bllEjemplar_327LG;
        public BEEjemplar_327LG libroSeleccionado_327LG;
        public FormSeleccionarLibro_327LG()
        {
            InitializeComponent();
            dgvLibro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibro.MultiSelect = false;
            bllLibro_327LG = new BLLLibro_327LG();
            bllEjemplar_327LG = new BLLEjemplar_327LG();
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            LM_327LG.AgregarObservador_327LG(this);
        }

        private void FormSeleccionarLibro_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#055b6b");

            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }
            dgvLibro.DataSource = bllLibro_327LG.ObtenerLibros_327LG();
            Actualizar_327LG();
            dgvLibro.Columns["ISBN_327LG"].FillWeight = 20;
            dgvLibro.Columns["Editorial_327LG"].FillWeight = 15;
            dgvLibro.Columns["Edicion_327LG"].FillWeight = 15;
            dgvLibro.Columns["Titulo_327LG"].FillWeight = 50;
            dgvLibro.Columns["Autor_327LG"].FillWeight = 20;
            dgvLibro.Columns["Editorial_327LG"].FillWeight = 15;
            dgvLibro.Columns["Edicion_327LG"].FillWeight = 15;
        }

        private void CambiarIdiomaGrillaLibros_327LG()
        {
            dgvLibro.Columns["ISBN_327LG"].HeaderText = "ISBN";
            dgvLibro.Columns["Titulo_327LG"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.titulo");
            dgvLibro.Columns["Autor_327LG"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.autor");
            dgvLibro.Columns["Editorial_327LG"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.editorial");
            dgvLibro.Columns["Edicion_327LG"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.edicion");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string? titulo = string.IsNullOrWhiteSpace(txtTitulo.Text) ? null : txtTitulo.Text;
                string? autor = string.IsNullOrWhiteSpace(txtAutor.Text) ? null : txtAutor.Text;
                string? editorial = string.IsNullOrWhiteSpace(txtEditorial.Text) ? null : txtEditorial.Text;
                int? edicion = null;
                if (int.TryParse(txtEdicion.Text, out int edicionParsed)) edicion = edicionParsed;
                if (bllLibro_327LG.FiltrarLibros_327LG(null, titulo, autor, editorial, edicion).IsNullOrEmpty()) throw new Exception(LM_327LG.ObtenerString("exception.libro_no_encontrado"));
                dgvLibro.DataSource = bllLibro_327LG.FiltrarLibros_327LG(null, titulo, autor, editorial, edicion);
                Actualizar_327LG();
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormSeleccionarLibro_327LG");
            lblLibros.Text = LM_327LG.ObtenerString("label.lblLibros");
            lblLibroSel.Text = LM_327LG.ObtenerString("label.lblLibroSel");
            lblDisponibles.Text = LM_327LG.ObtenerString("label.lblDisponibles");
            lblDañados.Text = LM_327LG.ObtenerString("label.lblDanados");
            lblDesaparecidos.Text = LM_327LG.ObtenerString("label.lblDesaparecidos");
            lblPrestados.Text = LM_327LG.ObtenerString("label.lblPrestados");
            lblTitulo.Text = LM_327LG.ObtenerString("label.lblTitulo");
            lblAutor.Text = LM_327LG.ObtenerString("label.lblAutor");
            lblEditorial.Text = LM_327LG.ObtenerString("label.lblEditorial");
            lblEdicion.Text = LM_327LG.ObtenerString("label.lblEdicion");
            btnBuscar.Text = LM_327LG.ObtenerString("button.btnBuscar");
            btnTomarPrestado.Text = LM_327LG.ObtenerString("button.btnTomarPrestado");
            btnCancelar.Text = LM_327LG.ObtenerString("button.btnCancelar");
            CambiarIdiomaGrillaLibros_327LG();
        }

        private void dgvLibro_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLibro.SelectedRows.Count == 0) return;
            string isbn = dgvLibro.SelectedRows[0].Cells[0].Value.ToString();
            int disponibles = 0;
            int prestados = 0;
            int desaparecidos = 0;
            int dañados = 0;

            foreach (BEEjemplar_327LG ejemplar in bllEjemplar_327LG.ObtenerEjemplares(isbn))
            {
                switch (ejemplar.Estado_327LG)
                {
                    case Estado_327LG.Disponible:
                        disponibles++;
                        break;
                    case Estado_327LG.Prestado:
                        prestados++;
                        break;
                    case Estado_327LG.Desaparecido:
                        desaparecidos++;
                        break;
                    case Estado_327LG.Dañado:
                        dañados++;
                        break;
                }
            }

            txtDisponibles.Text = disponibles.ToString();
            txtPrestados.Text = prestados.ToString();
            txtDesaparecidos.Text = desaparecidos.ToString();
            txtDañados.Text = dañados.ToString();
        }

        private void btnTomarPrestado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLibro.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.libro_no_seleccionado"));
                string isbn = dgvLibro.SelectedRows[0].Cells[0].Value.ToString();
                BEEjemplar_327LG ejemplar = bllEjemplar_327LG.ObtenerEjemplares(isbn).FirstOrDefault(e => e.Estado_327LG == Estado_327LG.Disponible);
                if (ejemplar == null) throw new Exception(LM_327LG.ObtenerString("exception.libro_no_disponible"));
                libroSeleccionado_327LG = ejemplar;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
                return;
            }

        }

        private void FormSeleccionarLibro_327LG_FormClosed(object sender, FormClosedEventArgs e)
        {
            LM_327LG.EliminarObservador_327LG(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}
