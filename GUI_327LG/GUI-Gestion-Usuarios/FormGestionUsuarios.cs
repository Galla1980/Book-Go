using BLL_327LG;
using Microsoft.VisualBasic;
using Services_327LG;
using Services_327LG.Singleton_327LG;
using System.Data;
using System.Text.RegularExpressions;

namespace GUI_327LG
{
    public partial class FormGestionUsuarios : Form
    {
        BLLUsuario_327LG bllUsuario_327LG;
        public FormGestionUsuarios()
        {
            InitializeComponent();
            bllUsuario_327LG = new BLLUsuario_327LG();
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            foreach (DataGridViewRow row in dgvUsuarios.Rows)
            {
                string dni = row.Cells[0].Value.ToString();
                var usuario = listaUsuarios.FirstOrDefault(x => x.dni_327LG == dni);
                if (usuario != null && usuario.bloqueado_327LG)
                    row.DefaultCellStyle.BackColor = Color.Red;
                else if(usuario.activo_327LG == false)
                    row.DefaultCellStyle.BackColor = Color.Gray;
            }
            lblCanUsuarios.Text = "Cantidad de usuarios:" + dgvUsuarios.Rows.Count.ToString();
            if (dgvUsuarios.Rows.Count > 0)
                dgvUsuarios.ClearSelection();
        }
        private void rdoActivos_CheckedChanged_327LG(object sender, EventArgs e)
        {
            CargarGrillaUsuarios_327LG();
        }
        private void btnAñadir_Click_327LG(object sender, EventArgs e)
        {
            txtMensaje.Text = "Modo Añadir";
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
            txtMensaje.Text = "Modo Desbloquear";
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
            txtMensaje.Text = "Modo Modificar";
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
            txtMensaje.Text = "Modo Activar/Desactivar";
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
            cmbRol.Text = user.rol_327LG;
            txtUsername.Text = user.userName_327LG;
        }

        private void btnAplicar_Click_327LG(object sender, EventArgs e)
        {
            try
            {
                switch (txtMensaje.Text)
                {
                    case "Modo Añadir":
                        string dni_327LG = txtDNI.Text;
                        string apellido_327LG = txtApellido.Text;
                        string nombre_327LG = txtNombre.Text;
                        string username_327LG = dni_327LG + nombre_327LG;
                        string password_327LG = dni_327LG + apellido_327LG;
                        string email_327LG = txtEmail.Text;
                        string rol_327LG = cmbRol.Text;
                        if (!Regex.IsMatch(dni_327LG, @"^\d{8}$")) throw new Exception("El DNI no es valido");
                        if(bllUsuario_327LG.ObtenerUsuarios_327LG().Any(x => x.dni_327LG.Equals(dni_327LG))) throw new Exception("El DNI ya esta en uso.");
                        ValidarEntradasUsuario_327LG(dni_327LG, apellido_327LG, nombre_327LG, email_327LG, rol_327LG);
                        if (bllUsuario_327LG.ObtenerUsuarios_327LG().Any(x => x.email_327LG.Equals(email_327LG, StringComparison.OrdinalIgnoreCase))) throw new Exception("Email en uso.");
                        bllUsuario_327LG.AgregarUsuario_327LG(new Usuario_327LG(dni_327LG, apellido_327LG, nombre_327LG, username_327LG, Encriptador_327LG.Encriptar_327LG(password_327LG), rol_327LG, email_327LG, false, true, 0));
                        MessageBox.Show("Usuario añadido correctamente.", "Usuario añadido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrillaUsuarios_327LG();
                        ModoConsulta();
                        break;
                    case "Modo Desbloquear":
                        if (dgvUsuarios.SelectedRows.Count <= 0) throw new Exception("No hay usuarios seleccionados para desbloquear");
                        string dniBloqueado_327LG = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                        string respuesta = MessageBox.Show("¿Está seguro que desea desbloquear al usuario?", "Desbloquear usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
                        if (respuesta == "No") return;
                        bllUsuario_327LG.ActualizarBloqueo_327LG(dniBloqueado_327LG, false);
                        MessageBox.Show("Usuario desbloqueado correctamente.", "Usuario desbloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrillaUsuarios_327LG();
                        ModoConsulta();
                        break;
                    case "Modo Modificar":
                        if (dgvUsuarios.SelectedRows.Count <= 0) throw new Exception("No hay usuarios seleccionados para modificar.");
                        ValidarEntradasUsuario_327LG(txtDNI.Text, txtApellido.Text, txtNombre.Text, txtEmail.Text, cmbRol.Text);
                        Usuario_327LG user = bllUsuario_327LG.ConsultaIndividual_327LG(txtDNI.Text);
                        user.nombre_327LG = txtNombre.Text;
                        user.apellido_327LG = txtApellido.Text;
                        user.email_327LG = txtEmail.Text;
                        user.rol_327LG = cmbRol.Text;
                        user.userName_327LG = txtDNI.Text + txtNombre.Text;
                        if(MessageBox.Show("¿Desea cambiar la contraseña con los nuevos valores?","Cambio de contraseña", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) user.password_327LG = Encriptador_327LG.Encriptar_327LG(txtDNI.Text + txtApellido.Text);
                        bllUsuario_327LG.ModificarUsuario_327LG(user);
                        MessageBox.Show("Usuario modificado correctamente.", "Usuario modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrillaUsuarios_327LG();
                        ModoConsulta();
                        break;
                    case "Modo Activar/Desactivar":
                        if (dgvUsuarios.SelectedRows.Count <= 0) throw new Exception("No hay usuarios seleccionados para modificar.");
                        string dniActDes_327LG = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                        //si el usuario es el mismo que el que inicio sesion no se puede desactivar
                        if (dniActDes_327LG == SessionManager_327LG.Instancia.Usuario.dni_327LG) throw new Exception("No se puede desactivar el usuario que inicio sesion.");
                        bllUsuario_327LG.ActualizarActivo_327LG(bllUsuario_327LG.ConsultaIndividual_327LG(dniActDes_327LG));
                        CargarGrillaUsuarios_327LG();
                        ModoConsulta();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ValidarEntradasUsuario_327LG(string dni_327LG, string apellido_327LG, string nombre_327LG, string email_327LG, string rol_327LG)
        {
            if (dni_327LG == string.Empty || apellido_327LG == string.Empty || nombre_327LG == string.Empty || email_327LG == string.Empty || rol_327LG == string.Empty)
                throw new Exception("Deben estar completos todos los campos.");
            if (nombre_327LG.Any(char.IsDigit)) throw new Exception("El nombre no puede contener números.");
            if (apellido_327LG.Any(char.IsDigit)) throw new Exception("El apellido no puede contener números.");
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
            txtMensaje.Text = "Modo Consulta";
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
            cmbRol.SelectedIndex = -1;
        }

        private void dgvUsuarios_SelectionChanged_327LG(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0 && (txtMensaje.Text == "Modo Modificar"))
            {
                LlenarCamposTlp_327LG();
            }
        }

    }
}