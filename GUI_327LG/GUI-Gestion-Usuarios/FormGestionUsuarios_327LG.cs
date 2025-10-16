using BLL_327LG;
using Microsoft.Win32;
using Services_327LG;
using Services_327LG.Composite_327LG;
using Services_327LG.Observer_327LG;
using Services_327LG.Singleton_327LG;
using System.Data;
using System.Text.RegularExpressions;

namespace GUI_327LG
{
    public partial class FormGestionUsuarios_327LG : Form, IObserverIdioma_327LG
    {
        BLLUsuario_327LG bllUsuario_327LG;
        BLLPerfil_327LG bllPerfil_327LG;
        LanguageManager_327LG LM_327LG;
        string modo = "Modo Consulta";
        public FormGestionUsuarios_327LG()
        {
            InitializeComponent();
            
            bllUsuario_327LG = new BLLUsuario_327LG();
            bllPerfil_327LG = new BLLPerfil_327LG();

            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            LM_327LG.AgregarObservador_327LG(this);
            LM_327LG.CargarFormulario_327LG("FormGestionUsuarios_327LG");
            Actualizar_327LG();
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            ModoConsulta();
        }
        private void FormGestionUsuarios_Shown_327LG(object sender, EventArgs e)
        {
            CargarGrillaUsuarios_327LG();
        }
        private void CargarGrillaUsuarios_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormGestionUsuarios_327LG");
            List<Usuario_327LG> listaUsuarios = bllUsuario_327LG.ObtenerUsuarios_327LG();
            dgvUsuarios.DataSource = null;
            if (rdoActivos.Checked)
            {
                var linq = from x in listaUsuarios
                           where x.activo_327LG == true
                           select new
                           {
                               DNI = x.dni_327LG,
                               Apellido = x.apellido_327LG,
                               Nombre = x.nombre_327LG,
                               Username = x.userName_327LG,
                               Rol = x.rol_327LG,
                               Email = x.email_327LG
                           };
                dgvUsuarios.DataSource = linq.ToList();
            }
            else
            {
                var linq = from x in listaUsuarios
                           select new
                           {
                               DNI = x.dni_327LG,
                               Apellido = x.apellido_327LG,
                               Nombre = x.nombre_327LG,
                               Username = x.userName_327LG,
                               Rol = x.rol_327LG,
                               Email = x.email_327LG
                           };
                dgvUsuarios.DataSource = linq.ToList();
            }
            //Pinta los registros desactivados y bloqueados
            foreach (DataGridViewRow row in dgvUsuarios.Rows)
            {
                string dni = row.Cells[0].Value.ToString();
                var usuario = listaUsuarios.FirstOrDefault(x => x.dni_327LG == dni);
                if (usuario != null && usuario.bloqueado_327LG)
                    row.DefaultCellStyle.BackColor = Color.Red;
                else if (usuario.activo_327LG == false)
                    row.DefaultCellStyle.BackColor = Color.Gray;
            }

            dgvUsuarios.Columns["Apellido"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.apellido");
            dgvUsuarios.Columns["Nombre"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.nombre");
            dgvUsuarios.Columns["Username"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.usuario");
            dgvUsuarios.Columns["Email"].HeaderText = LM_327LG.ObtenerString("datagridview.columna.correo");
            lblCanUsuarios.Text = LM_327LG.ObtenerString("label.lblCantidadUsuarios") + dgvUsuarios.Rows.Count.ToString();
            if (dgvUsuarios.Rows.Count > 0)
                dgvUsuarios.ClearSelection();

            cmbRol.Items.Clear();
            foreach (var item in bllPerfil_327LG.ObtenerPerfiles_327LG())
            {
                cmbRol.Items.Add(item.Nombre_327LG);
            }
        }
        private void rdoActivos_CheckedChanged_327LG(object sender, EventArgs e)
        {
            CargarGrillaUsuarios_327LG();
        }
        private void btnAñadir_Click_327LG(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormGestionUsuarios_327LG");
            modo = "Modo Añadir";
            txtMensaje.Text = LM_327LG.ObtenerString("textbox.modo.anadir");
            btnAñadir.Enabled = false;
            btnDesbloquear.Enabled = false;
            btnModificar.Enabled = false;
            btnActDes.Enabled = false;
            btnAplicar.Enabled = true;
            btnCancelar.Enabled = true;
            txtUsername.Enabled = false;
        }
        private void btnDesbloquear_Click_327LG(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormGestionUsuarios_327LG");
            modo = "Modo Desbloquear";
            txtMensaje.Text = LM_327LG.ObtenerString("textbox.modo.desbloquear");
            btnAñadir.Enabled = false;
            btnDesbloquear.Enabled = false;
            btnModificar.Enabled = false;
            btnActDes.Enabled = false;
            btnAplicar.Enabled = true;
            btnCancelar.Enabled = true;
            tlpUsuarios.Enabled = false;
        }
        private void btnModificar_Click_327LG(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormGestionUsuarios_327LG");
            modo = "Modo Modificar";
            txtMensaje.Text = LM_327LG.ObtenerString("textbox.modo.modificar");
            txtDNI.Enabled = false;
            btnAñadir.Enabled = false;
            btnDesbloquear.Enabled = false;
            btnModificar.Enabled = false;
            btnActDes.Enabled = false;
            btnAplicar.Enabled = true;
            btnCancelar.Enabled = true;
            txtUsername.Enabled = false;
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                LlenarCamposTlp_327LG();
            }
        }
        private void btnActDes_Click(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormGestionUsuarios_327LG");
            modo = "Modo Activar/Desactivar";
            txtMensaje.Text = LM_327LG.ObtenerString("textbox.modo.desactivar");
            btnAñadir.Enabled = false;
            btnDesbloquear.Enabled = false;
            btnModificar.Enabled = false;
            btnActDes.Enabled = false;
            btnAplicar.Enabled = true;
            btnCancelar.Enabled = true;
            tlpUsuarios.Enabled = false;
        }

        private void LlenarCamposTlp_327LG()
        {
            txtDNI.Text = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
            Usuario_327LG user = bllUsuario_327LG.ConsultaIndividual_327LG(txtDNI.Text);
            txtApellido.Text = user.apellido_327LG;
            txtNombre.Text = user.nombre_327LG;
            txtEmail.Text = user.email_327LG;
            txtUsername.Text = user.userName_327LG;
        }

        private void btnAplicar_Click_327LG(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormGestionUsuarios_327LG");
            try
            {
                switch (modo)
                {
                    case "Modo Añadir":
                        string dni_327LG = txtDNI.Text;
                        string apellido_327LG = txtApellido.Text;
                        string nombre_327LG = txtNombre.Text;
                        string username_327LG = dni_327LG + nombre_327LG;
                        string password_327LG = dni_327LG + apellido_327LG;
                        string email_327LG = txtEmail.Text;
                        BEPerfil_327LG rol_327LG = bllPerfil_327LG.ObtenerPerfiles_327LG().FirstOrDefault(x => x.Nombre_327LG == cmbRol.Text);

                        if (!Regex.IsMatch(dni_327LG, @"^\d{8}$")) throw new Exception(LM_327LG.ObtenerString("exception.dni_no_valido"));
                        if (bllUsuario_327LG.ObtenerUsuarios_327LG().Any(x => x.dni_327LG.Equals(dni_327LG))) throw new Exception(LM_327LG.ObtenerString("exception.dni_en_uso"));
                        ValidarEntradasUsuario_327LG(dni_327LG, apellido_327LG, nombre_327LG, email_327LG);
                        if (bllUsuario_327LG.ObtenerUsuarios_327LG().Any(x => x.email_327LG.Equals(email_327LG, StringComparison.OrdinalIgnoreCase))) throw new Exception(LM_327LG.ObtenerString("exception.email_en_uso"));
                        bllUsuario_327LG.AgregarUsuario_327LG(new Usuario_327LG(dni_327LG, apellido_327LG, nombre_327LG, username_327LG, Encriptador_327LG.Encriptar_327LG(password_327LG), rol_327LG, email_327LG, false, true, 0, "spanish"));
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.usuario_anadido.mensaje"), LM_327LG.ObtenerString("messagebox.usuario_anadido.titulo"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        CargarGrillaUsuarios_327LG();
                        ModoConsulta();
                        break;

                    case "Modo Desbloquear":
                        if (dgvUsuarios.SelectedRows.Count <= 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccion_usuario_desbloqueo"));
                        string dniBloqueado_327LG = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                        string respuesta = MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.desbloquear_usuario.mensaje"), LM_327LG.ObtenerString("messagebox.desbloquear_usuario.titulo"), LM_327LG.ObtenerString("messagebox.button.aceptar"), LM_327LG.ObtenerString("messagebox.button.cancelar"), MessageBoxIcon.Question).ToString();
                        if (respuesta == "No") return;
                        if (bllUsuario_327LG.ConsultaIndividual_327LG(dniBloqueado_327LG).bloqueado_327LG == false) throw new Exception(LM_327LG.ObtenerString("exception.usuario_no_bloqueado"));

                        bllUsuario_327LG.ActualizarBloqueo_327LG(dniBloqueado_327LG, false);
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.usuario_desbloqueado.mensaje"), LM_327LG.ObtenerString("messagebox.usuario_desbloqueado.titulo"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        CargarGrillaUsuarios_327LG();
                        ModoConsulta();
                        break;

                    case "Modo Modificar":
                        if (dgvUsuarios.SelectedRows.Count <= 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccion_usuario_modificar"));
                        ValidarEntradasUsuario_327LG(txtDNI.Text, txtApellido.Text, txtNombre.Text, txtEmail.Text);
                        Usuario_327LG user = bllUsuario_327LG.ConsultaIndividual_327LG(txtDNI.Text);
                        if (SessionManager_327LG.Instancia.Usuario == user) throw new Exception(LM_327LG.ObtenerString("exception.mismo_usuario"));
                        user.nombre_327LG = txtNombre.Text;
                        user.apellido_327LG = txtApellido.Text;
                        user.email_327LG = txtEmail.Text;
                        user.rol_327LG = bllPerfil_327LG.ObtenerPerfiles_327LG().FirstOrDefault(x => x.Nombre_327LG == cmbRol.Text);
                        user.userName_327LG = txtDNI.Text + txtNombre.Text;
                        if (MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.cambiar_contrasena.mensaje"), LM_327LG.ObtenerString("messagebox.cambiar_contrasena.titulo"), LM_327LG.ObtenerString("messagebox.button.aceptar"), "No", MessageBoxIcon.Question) == DialogResult.Yes) user.password_327LG = Encriptador_327LG.Encriptar_327LG(txtDNI.Text + txtApellido.Text);
                        bllUsuario_327LG.ModificarUsuario_327LG(user);
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.usuario_modificado.mensaje"), LM_327LG.ObtenerString("messagebox.usuario_modificado.titulo"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        CargarGrillaUsuarios_327LG();
                        ModoConsulta();
                        break;

                    case "Modo Activar/Desactivar":
                        if (dgvUsuarios.SelectedRows.Count <= 0) throw new Exception(LM_327LG.ObtenerString("exception.seleccion_usuario_desactivar"));
                        string dniActDes_327LG = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                        //si el usuario es el mismo que el que inicio sesion no se puede desactivar
                        if (dniActDes_327LG == SessionManager_327LG.Instancia.Usuario.dni_327LG) throw new Exception(LM_327LG.ObtenerString("exception.usuario_desactivar_no_valido"));
                        if (MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.desactivar_activar.mensaje"), LM_327LG.ObtenerString("messagebox.desactivar_activar.titulo"), LM_327LG.ObtenerString("messagebox.button.aceptar"), LM_327LG.ObtenerString("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bllUsuario_327LG.ActualizarActivo_327LG(bllUsuario_327LG.ConsultaIndividual_327LG(dniActDes_327LG));
                            MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.usuario_desactivado.mensaje"), LM_327LG.ObtenerString("messagebox.usuario_desactivado.titulo"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                            CargarGrillaUsuarios_327LG();
                            ModoConsulta();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void ValidarEntradasUsuario_327LG(string dni_327LG, string apellido_327LG, string nombre_327LG, string email_327LG)
        {
            if (dni_327LG == string.Empty || apellido_327LG == string.Empty || nombre_327LG == string.Empty || email_327LG == string.Empty || cmbRol.Text == string.Empty)
                throw new Exception(LM_327LG.ObtenerString("exception.campos_vacios"));
            if (nombre_327LG.Any(char.IsDigit)) throw new Exception(LM_327LG.ObtenerString("exception.nombre_con_numeros"));
            if (apellido_327LG.Any(char.IsDigit)) throw new Exception(LM_327LG.ObtenerString("exception.apellido_con_numeros"));
        }

        private void btnCancelar_Click_327LG(object sender, EventArgs e)
        {
            ModoConsulta();
        }

        private void btnSalir_Click_327LG(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ModoConsulta()
        {
            LM_327LG.CargarFormulario_327LG("FormGestionUsuarios_327LG");
            modo = "Modo Consulta";
            txtMensaje.Text = LM_327LG.ObtenerString("textbox.modo.consulta");

            txtDNI.Enabled = true;
            btnAñadir.Enabled = true;
            btnDesbloquear.Enabled = true;
            btnModificar.Enabled = true;
            btnActDes.Enabled = true;
            btnAplicar.Enabled = false;
            btnCancelar.Enabled = false;
            tlpUsuarios.Enabled = true;
            txtUsername.Enabled = true;
            if (dgvUsuarios.Rows.Count > 0)
                dgvUsuarios.ClearSelection();
            foreach (Control c in tlpUsuarios.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = string.Empty;
                }
            }
            
        }

        private void dgvUsuarios_SelectionChanged_327LG(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0 && (txtMensaje.Text == "Modo Modificar"))
            {
                LlenarCamposTlp_327LG();
            }
        }

        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormGestionUsuarios_327LG");
            if (modo == "Modo Consulta") txtMensaje.Text = LM_327LG.ObtenerString("textbox.modo.consulta");
            if (modo == "Modo Añadir") txtMensaje.Text = LM_327LG.ObtenerString("textbox.modo.anadir");
            if (modo == "Modo Modificar") txtMensaje.Text = LM_327LG.ObtenerString("textbox.modo.modificar");
            if (modo == "Modo Desbloquear") txtMensaje.Text = LM_327LG.ObtenerString("textbox.modo.desbloquear");
            if (modo == "Modo Activar/Desactivar") txtMensaje.Text = LM_327LG.ObtenerString("textbox.modo.desactivar");
            CargarGrillaUsuarios_327LG();
            //Label
            lblUsuarios.Text = LM_327LG.ObtenerString("label.lblUsuarios");
            lblCanUsuarios.Text = LM_327LG.ObtenerString("label.lblCantidadUsuarios") + dgvUsuarios.Rows.Count.ToString();
            lblApellido.Text = LM_327LG.ObtenerString("label.lblApellido");
            lblNombre.Text = LM_327LG.ObtenerString("label.lblNombre");
            lblUsername.Text = LM_327LG.ObtenerString("label.lblUsername");
            lblEmail.Text = LM_327LG.ObtenerString("label.lblCorreo");
            //Radio
            rdoActivos.Text = LM_327LG.ObtenerString("radio.rdoActivos");
            rdoTodos.Text = LM_327LG.ObtenerString("radio.rdoTodos");
            //Botones
            btnAñadir.Text = LM_327LG.ObtenerString("button.btnAnadir");
            btnDesbloquear.Text = LM_327LG.ObtenerString("button.btnDesbloquear");
            btnModificar.Text = LM_327LG.ObtenerString("button.btnModificar");
            btnActDes.Text = LM_327LG.ObtenerString("button.btnActivarDesactivar");
            btnAplicar.Text = LM_327LG.ObtenerString("button.btnAplicar");
            btnCancelar.Text = LM_327LG.ObtenerString("button.btnCancelar");
            btnSalir.Text = LM_327LG.ObtenerString("button.btnSalir");
        }

        private void FormGestionUsuarios_327LG_FormClosed(object sender, FormClosedEventArgs e)
        {
            LM_327LG.EliminarObservador_327LG(this);
        }
    }
}