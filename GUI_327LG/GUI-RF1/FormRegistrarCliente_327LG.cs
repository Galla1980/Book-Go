using BE_327LG;
using BLL_327LG;
using Services_327LG;
using Services_327LG.Observer_327LG;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI_327LG.GUIRF1
{
    public partial class FormRegistrarCliente_327LG : Form, IObserverIdioma_327LG
    {
        LanguageManager_327LG LM_327LG;
        BLLCliente_327LG bllCliente_327LG;
        string modo = "Consultar";
        public FormRegistrarCliente_327LG()
        {
            InitializeComponent();
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            bllCliente_327LG = new BLLCliente_327LG();
            LM_327LG.AgregarObservador_327LG(this);
            dgvClientes.MultiSelect = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void FormRegistrarCliente_327LG_Load(object sender, EventArgs e)
        {
            ModoConsulta();
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            var linq = from x in bllCliente_327LG.ObtenerClientes_327LG()
                       where x.Activo == true
                       select new { DNI = x.DNI_327LG, Nombre = x.Nombre_327LG, Apellido = x.Apellido_327LG, Email = chkDesencriptar.Checked ? Encriptador_327LG.DesencriptarReversible_327LG(x.Email_327LG) : x.Email_327LG };
            dgvClientes.DataSource = linq.ToList();
            dgvClientes.Columns["DNI"].FillWeight = 20;
            dgvClientes.Columns["Nombre"].FillWeight = 20;
            dgvClientes.Columns["Apellido"].FillWeight = 20;
            dgvClientes.Columns["Email"].FillWeight = 50;

            Actualizar_327LG();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            modo = "Registrar";
            btnAplicar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnRegistrar.Enabled = false;
            btnCancelar.Enabled = true;
            lblModo.Text = LM_327LG.ObtenerString("label.lblModoRegistrar");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoConsulta();
        }

        private void ModoConsulta()
        {
            modo = "Consultar";
            btnAplicar.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnRegistrar.Enabled = true;
            btnCancelar.Enabled = false;
            chkDesencriptar.Enabled = true;
            txtDNI.Enabled = true;
            txtDNI.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            lblModo.Text = LM_327LG.ObtenerString("label.lblModoConsulta");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            modo = "Eliminar";
            btnAplicar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnRegistrar.Enabled = false;
            btnCancelar.Enabled = true;
            lblModo.Text = LM_327LG.ObtenerString("label.lblModoEliminar");
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            modo = "Modificar";
            btnAplicar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnRegistrar.Enabled = false;
            btnCancelar.Enabled = true;
            txtDNI.Enabled = false;
            lblModo.Text = LM_327LG.ObtenerString("label.lblModoModificar");
            if (dgvClientes.SelectedRows.Count != 0)
            {
                txtDNI.Text = dgvClientes.SelectedRows[0].Cells["DNI"].Value.ToString();
                txtNombre.Text = dgvClientes.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvClientes.SelectedRows[0].Cells["Apellido"].Value.ToString();
                txtEmail.Text = chkDesencriptar.Checked ? dgvClientes.SelectedRows[0].Cells["Email"].Value.ToString() : Encriptador_327LG.DesencriptarReversible_327LG(dgvClientes.SelectedRows[0].Cells["Email"].Value.ToString());
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {

            try
            {
                LM_327LG.CargarFormulario_327LG("FormRegistrarCliente_327LG");
                switch (modo)
                {
                    case "Registrar":

                        string dni = txtDNI.Text;
                        string nombre = txtNombre.Text;
                        string apellido = txtApellido.Text;
                        string email = txtEmail.Text;

                        if (!Regex.IsMatch(dni, @"^\d{8}$")) throw new Exception(LM_327LG.ObtenerString("exception.dni_no_valido"));
                        if (dni == string.Empty || apellido == string.Empty || nombre == string.Empty || email == string.Empty) throw new Exception(LM_327LG.ObtenerString("exception.campos_vacios"));
                        if (nombre.Any(char.IsDigit)) throw new Exception(LM_327LG.ObtenerString("exception.nombre_con_numeros"));
                        if (apellido.Any(char.IsDigit)) throw new Exception(LM_327LG.ObtenerString("exception.apellido_con_numeros"));
                        if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")) throw new Exception(LM_327LG.ObtenerString("exception.email_no_valido"));
                        if (bllCliente_327LG.ObtenerClientes_327LG().Any(x => x.DNI_327LG == dni)) throw new Exception(LM_327LG.ObtenerString("exception.dni_en_uso"));
                        if (MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.confirmacion_registrar_cliente"), LM_327LG.ObtenerString("messagebox.titulo.confirmacion"), LM_327LG.ObtenerString("messagebox.button.aceptar"), LM_327LG.ObtenerString("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bllCliente_327LG.RegistrarCliente_327LG(new BECliente_327LG(dni, nombre, apellido, email, true));
                            MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.cliente_registrado"), LM_327LG.ObtenerString("messagebox.titulo.cliente_registrado"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                            CargarGrilla();
                        }
                        break;
                    case "Eliminar":
                        if (dgvClientes.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_fila"));
                        string dniEliminar = dgvClientes.SelectedRows[0].Cells["DNI"].Value.ToString();
                        BECliente_327LG cliente = bllCliente_327LG.ObtenerClientes_327LG().First(x => x.DNI_327LG == dniEliminar);
                        if (MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.confirmacion_eliminar_cliente"), LM_327LG.ObtenerString("messagebox.titulo.confirmacion_eliminar_cliente"), LM_327LG.ObtenerString("messagebox.button.aceptar"), LM_327LG.ObtenerString("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bllCliente_327LG.EliminarCliente_327LG(cliente);
                            MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.cliente_eliminado"), LM_327LG.ObtenerString("messagebox.titulo.cliente_eliminado"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                            CargarGrilla();
                        }
                        break;
                    case "Modificar":
                        if (dgvClientes.SelectedRows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccionar_fila"));
                        string dniModificar = dgvClientes.SelectedRows[0].Cells["DNI"].Value.ToString();
                        BECliente_327LG clienteModificar = bllCliente_327LG.ObtenerClientes_327LG().First(x => x.DNI_327LG == dniModificar);
                        if (txtNombre.Text == string.Empty || txtApellido.Text == string.Empty || txtEmail.Text == string.Empty) throw new Exception(LM_327LG.ObtenerString("exception.campos_vacios"));
                        if (txtNombre.Text.Any(char.IsDigit)) throw new Exception(LM_327LG.ObtenerString("exception.nombre_con_numeros"));
                        if (txtApellido.Text.Any(char.IsDigit)) throw new Exception(LM_327LG.ObtenerString("exception.apellido_con_numeros"));

                        clienteModificar.Nombre_327LG = txtNombre.Text;
                        clienteModificar.Apellido_327LG = txtApellido.Text;
                        clienteModificar.Email_327LG = txtEmail.Text;
                        bllCliente_327LG.ModificarCliente_327LG(clienteModificar);
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.cliente_modificado"), LM_327LG.ObtenerString("messagebox.titulo.cliente_modificado"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        CargarGrilla();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormRegistrarCliente_327LG");
            lblTitulo.Text = LM_327LG.ObtenerString("label.lblTitulo");
            lblDNI.Text = LM_327LG.ObtenerString("label.lblDni");
            lblNombre.Text = LM_327LG.ObtenerString("label.lblNombre");
            lblApellido.Text = LM_327LG.ObtenerString("label.lblApellido");
            lblEmail.Text = LM_327LG.ObtenerString("label.lblEmail");
            btnCancelar.Text = LM_327LG.ObtenerString("button.btnCancelar");
            btnRegistrar.Text = LM_327LG.ObtenerString("button.btnRegistrar");
            grpSerializacion.Text = btnSerializar.Text = LM_327LG.ObtenerString("button.btnSerializar");
            btnDeserializar.Text = LM_327LG.ObtenerString("button.btnDeserializar");
            btnActualizar.Text = LM_327LG.ObtenerString("button.btnActualizar");
            btnLimpiar.Text = LM_327LG.ObtenerString("button.btnLimpiar");
            if (modo == "Consultar") lblModo.Text = LM_327LG.ObtenerString("label.lblModoConsulta");
            if (modo == "Registrar") lblModo.Text = LM_327LG.ObtenerString("label.lblModoRegistrar");
            if (modo == "Modificar") lblModo.Text = LM_327LG.ObtenerString("label.lblModoModificar");
            if (modo == "Eliminar") lblModo.Text = LM_327LG.ObtenerString("label.lblModoEliminar");
            btnAplicar.Text = LM_327LG.ObtenerString("button.btnAplicar");
            btnModificar.Text = LM_327LG.ObtenerString("button.btnModificar");
            btnEliminar.Text = LM_327LG.ObtenerString("button.btnEliminar");
            chkDesencriptar.Text = LM_327LG.ObtenerString("label.lblDesencriptar");
            dgvClientes.Columns["DNI"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.dni");
            dgvClientes.Columns["Nombre"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.nombre");
            dgvClientes.Columns["Apellido"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.apellido");
            dgvClientes.Columns["Email"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.correo");
        }

        private void chkDesencriptar_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrilla();

        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count != 0 && modo == "Modificar")
            {
                txtDNI.Text = dgvClientes.SelectedRows[0].Cells["DNI"].Value.ToString();
                txtNombre.Text = dgvClientes.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvClientes.SelectedRows[0].Cells["Apellido"].Value.ToString();
                txtEmail.Text = chkDesencriptar.Checked ? dgvClientes.SelectedRows[0].Cells["Email"].Value.ToString() : Encriptador_327LG.DesencriptarReversible_327LG(dgvClientes.SelectedRows[0].Cells["Email"].Value.ToString());
            }
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvClientes.Rows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.grilla_vacia"));
                List<BECliente_327LG> listaCLientes = new List<BECliente_327LG>();
                foreach (DataGridViewRow row in dgvClientes.Rows)
                {
                    string dni = row.Cells["DNI"].Value.ToString();
                    BECliente_327LG cliente = bllCliente_327LG.ObtenerClientes_327LG().First(x => x.DNI_327LG == dni);
                    listaCLientes.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ModoConsulta();
            CargarGrilla();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
