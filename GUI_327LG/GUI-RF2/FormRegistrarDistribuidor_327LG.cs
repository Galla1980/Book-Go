using BE_327LG;
using BLL_327LG;
using Services_327LG.Observer_327LG;
using System.Data;
using System.Text.RegularExpressions;

namespace GUI_327LG.GUI_RF2
{
    public partial class FormRegistrarDistribuidor_327LG : Form, IObserverIdioma_327LG
    {
        BLLDistribuidor_327LG BLLDistribuidor_327LG = new BLLDistribuidor_327LG();
        LanguageManager_327LG LM_327LG;
        string modo = "Consultar";
        public FormRegistrarDistribuidor_327LG()
        {
            InitializeComponent();
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            LM_327LG.AgregarObservador_327LG(this);
            dgvDistribuidores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDistribuidores.MultiSelect = false;
        }
        private void FormRegistrarDistribuidor_327LG_Load(object sender, EventArgs e)
        {
            dgvDistribuidores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDistribuidores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDistribuidores.RowHeadersVisible = false;
            CargarGrilla();
            this.BackColor = ColorTranslator.FromHtml("#055b6b");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }
            ModoConsulta_327LG();
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
                control.BackColor = Color.FromArgb(200, 200, 200); // gris claro
                control.ForeColor = Color.DarkGray;
            }
        }


        private void ModoConsulta_327LG()
        {
            modo = "Consultar";
            SetEnabled(btnAplicar, false);
            SetEnabled(btnEliminar, true);
            SetEnabled(btnModificar, true);
            SetEnabled(btnRegistrar, true);
            SetEnabled(btnCancelar, false);
            SetEnabled(txtCuit, true);
            txtCuit.Text = string.Empty;
            txtEmpresa.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            lblModo.Text = LM_327LG.ObtenerString("label.lblModoConsulta");
        }

        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormRegistrarDistribuidor_327LG");
            //labels
            lblTitulo.Text = LM_327LG.ObtenerString("label.lblTitulo");
            lblCuit.Text = LM_327LG.ObtenerString("label.lblCUIT");
            lblEmpresa.Text = LM_327LG.ObtenerString("label.lblEmpresa");
            lblDireccion.Text = LM_327LG.ObtenerString("label.lblDireccion");
            lblCorreo.Text = LM_327LG.ObtenerString("label.lblCorreo");
            lblTelefono.Text = LM_327LG.ObtenerString("label.lblTelefono");
            if (modo == "Consultar") lblModo.Text = LM_327LG.ObtenerString("label.lblModoConsulta");
            if (modo == "Registrar") lblModo.Text = LM_327LG.ObtenerString("label.lblModoRegistrar");
            if (modo == "Modificar") lblModo.Text = LM_327LG.ObtenerString("label.lblModoModificar");
            if (modo == "Eliminar") lblModo.Text = LM_327LG.ObtenerString("label.lblModoEliminar");

            //botones
            btnRegistrar.Text = LM_327LG.ObtenerString("button.btnRegistrar");
            btnModificar.Text = LM_327LG.ObtenerString("button.btnModificar");
            btnEliminar.Text = LM_327LG.ObtenerString("button.btnEliminar");
            btnAplicar.Text = LM_327LG.ObtenerString("button.btnAplicar");
            btnCancelar.Text = LM_327LG.ObtenerString("button.btnCancelar");

            //datagridview
            dgvDistribuidores.Columns["CUIT"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.CUIT");
            dgvDistribuidores.Columns["Empresa"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.empresa");
            dgvDistribuidores.Columns["Telefono"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.telefono");
            dgvDistribuidores.Columns["Direccion"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.direccion");
            dgvDistribuidores.Columns["Correo"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.correo");

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormRegistrarDistribuidor_327LG");
            modo = "Registrar";
            SetEnabled(btnAplicar, true);
            SetEnabled(btnCancelar, true);
            SetEnabled(btnModificar, false);
            SetEnabled(btnEliminar, false);
            SetEnabled(btnRegistrar, false);

            lblModo.Text = LM_327LG.ObtenerString("label.lblModoRegistrar");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormRegistrarDistribuidor_327LG");
            modo = "Modificar";
            SetEnabled(btnAplicar, true);
            SetEnabled(btnCancelar, true);
            SetEnabled(btnModificar, false);
            SetEnabled(btnEliminar, false);
            SetEnabled(btnRegistrar, false);
            SetEnabled(txtCuit, false);
            lblModo.Text = LM_327LG.ObtenerString("label.lblModoModificar");
            if (dgvDistribuidores.SelectedRows.Count != 0)
            {
                txtCuit.Text = dgvDistribuidores.SelectedRows[0].Cells["CUIT"].Value.ToString();
                txtEmpresa.Text = dgvDistribuidores.SelectedRows[0].Cells["Empresa"].Value.ToString();
                txtTelefono.Text = dgvDistribuidores.SelectedRows[0].Cells["Telefono"].Value.ToString();
                txtDireccion.Text = dgvDistribuidores.SelectedRows[0].Cells["Direccion"].Value.ToString();
                txtCorreo.Text = dgvDistribuidores.SelectedRows[0].Cells["Correo"].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormRegistrarDistribuidor_327LG");
            modo = "Eliminar";
            SetEnabled(btnAplicar, true);
            SetEnabled(btnCancelar, true);
            SetEnabled(btnModificar, false);
            SetEnabled(btnEliminar, false);
            SetEnabled(btnRegistrar, false);
            lblModo.Text = LM_327LG.ObtenerString("label.lblModoEliminar");
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (modo)
                {
                    case "Registrar":
                        {
                            string cuit = txtCuit.Text.Trim();
                            string empresa = txtEmpresa.Text.Trim();
                            string telefono = txtTelefono.Text.Trim();
                            string direccion = txtDireccion.Text.Trim();
                            string correo = txtCorreo.Text.Trim();
                            ValidarCampos(cuit, empresa, telefono, direccion, correo);
                            if (BLLDistribuidor_327LG.ObtenerDistribuidores_327LG().Any(x => x.CUIT_327LG == cuit)) throw new Exception(LM_327LG.ObtenerString("exception.cuit_ya_registrado"));
                            BEDistribuidor_327LG distribuidor = new BEDistribuidor_327LG(cuit, empresa, telefono, direccion, correo, true);
                            BLLDistribuidor_327LG.RegistrarDistribuidor_327LG(distribuidor);
                            MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.registro_exito"), LM_327LG.ObtenerString("messagebox.titulo.registro_exito"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                            CargarGrilla();
                            ModoConsulta_327LG();
                            break;
                        }
                    case "Modificar":
                        {
                            BEDistribuidor_327LG distribuidor = ObtenerDistribuidorSeleccionado_327LG();
                            if (txtEmpresa.Text.Trim() == distribuidor.Empresa_327LG &&
                               txtTelefono.Text.Trim() == distribuidor.Telefono_327LG &&
                               txtDireccion.Text.Trim() == distribuidor.Direccion_327LG &&
                               txtCorreo.Text.Trim() == distribuidor.Correo_327LG)
                            {
                                throw new Exception(LM_327LG.ObtenerString("exception.sin_cambios"));
                            }
                            distribuidor.Empresa_327LG = txtEmpresa.Text.Trim();
                            distribuidor.Telefono_327LG = txtTelefono.Text.Trim();
                            distribuidor.Direccion_327LG = txtDireccion.Text.Trim();
                            distribuidor.Correo_327LG = txtCorreo.Text.Trim();

                            ValidarCampos(distribuidor.CUIT_327LG, distribuidor.Empresa_327LG, distribuidor.Telefono_327LG, distribuidor.Direccion_327LG, distribuidor.Correo_327LG);
                            BLLDistribuidor_327LG.ModificarDistribuidor_327LG(distribuidor);
                            MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.modificacion_exito"), LM_327LG.ObtenerString("messagebox.titulo.modificacion_exito"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                            CargarGrilla();
                            ModoConsulta_327LG();
                            break;
                        }
                    case "Eliminar":
                        {
                            BEDistribuidor_327LG distribuidor = ObtenerDistribuidorSeleccionado_327LG();
                            distribuidor.Activo_327LG = false;
                            BLLDistribuidor_327LG.EliminarDistribuidor_327LG(distribuidor);
                            MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.eliminacion_exito"), LM_327LG.ObtenerString("messagebox.titulo.eliminacion_exito"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                            CargarGrilla();
                            ModoConsulta_327LG();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private BEDistribuidor_327LG ObtenerDistribuidorSeleccionado_327LG()
        {
            if (dgvDistribuidores.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_fila"));
            string cuit = dgvDistribuidores.SelectedRows[0].Cells["CUIT"].Value.ToString();
            BEDistribuidor_327LG distribuidor = BLLDistribuidor_327LG.ObtenerDistribuidores_327LG().FirstOrDefault(x => x.CUIT_327LG == cuit);
            if (distribuidor == null) throw new Exception(LM_327LG.ObtenerString("exception.distribuidor_no_encontrado"));
            return distribuidor;
        }

        private void ValidarCampos(string cuit, string empresa, string telefono, string direccion, string correo)
        {
            if (cuit == string.Empty || empresa == string.Empty || telefono == string.Empty || direccion == string.Empty || correo == string.Empty)
            {
                throw new Exception(LM_327LG.ObtenerString("exception.campos_vacios"));
            }
            if (!Regex.IsMatch(cuit, @"^\d{2}-\d{8}-\d$"))
            {
                throw new Exception(LM_327LG.ObtenerString("exception.cuit_invalido"));
            }
            if (!Regex.IsMatch(correo, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")) throw new Exception(LM_327LG.ObtenerString("exception.email_no_valido"));
            if (!Regex.IsMatch(telefono, @"^\d{2,4}\s\d{4}-\d{4}$")) throw new Exception(LM_327LG.ObtenerString("exception.telefono_no_valido"));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormRegistrarDistribuidor_327LG");

            ModoConsulta_327LG();
        }

        private void CargarGrilla()
        {
            var linq = from x in BLLDistribuidor_327LG.ObtenerDistribuidores_327LG()
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

            Actualizar_327LG();
        }


        private void FormRegistrarDistribuidor_327LG_FormClosing(object sender, FormClosingEventArgs e)
        {
            LM_327LG.EliminarObservador_327LG(this);
        }
    }
}
