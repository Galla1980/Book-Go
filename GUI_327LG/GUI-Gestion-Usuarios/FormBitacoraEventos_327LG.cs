using BLL_327LG;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Services_327LG;
using Services_327LG.Observer_327LG;
using System.Data;
using iTextFont = iTextSharp.text.Font;

namespace GUI_327LG.GUI_Gestion_Usuarios
{
    public partial class FormBitacoraEventos_327LG : Form, IObserverIdioma_327LG
    {
        LanguageManager_327LG LM_327LG = LanguageManager_327LG.Instance_327LG;
        BLLEvento_327LG bLLEvento_327LG = new BLLEvento_327LG();
        BLLUsuario_327LG bllUsuario_327LG = new BLLUsuario_327LG();
        public FormBitacoraEventos_327LG()
        {
            InitializeComponent();
            LM_327LG.AgregarObservador_327LG(this);


        }

        private void FormBitacoraEventos_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#0c7689");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
            }
            chkFiltrarFecha.ForeColor = Color.White;
            dgvEventos.MultiSelect = false;
            dgvEventos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEventos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtpFechaInicio.Value = DateTime.Now.AddDays(-3);
            CargarGrilla_327LG(null, null, null, null, DateTime.Now.AddDays(-3), DateTime.Now);
            CargarcmbLogin();
            CargarcmbModulo();
            CargarcmbEvento();
            CargarcmbCriticidad();

        }

        private void CargarcmbLogin()
        {
            foreach (Usuario_327LG usuario in bllUsuario_327LG.ObtenerUsuarios_327LG())
            {
                cmbLogin.Items.Add(usuario.userName_327LG);
            }
        }

        private void CargarcmbModulo()
        {
            cmbModulo.Items.Clear();
            cmbModulo.Items.Add("Gestión de usuarios");
            cmbModulo.Items.Add("Gestión de perfiles");
            cmbModulo.Items.Add("Préstamos y devoluciones");
            cmbModulo.Items.Add("Gestión de stock");
            cmbModulo.Items.Add("Gestión de Backup/Restore");
        }

        private void CargarcmbEvento()
        {
            cmbEvento.Items.Clear();
            //Modulo gestion de usuarios
            cmbEvento.Items.Add("Inicio de sesión exitoso");
            cmbEvento.Items.Add("Creación de usuario");
            cmbEvento.Items.Add("Modificación de usuario");
            cmbEvento.Items.Add("Bloqueo de usuario");
            cmbEvento.Items.Add("Desbloqueo de usuario");
            cmbEvento.Items.Add("Activación de usuario");
            cmbEvento.Items.Add("Desactivación de usuario");
            cmbEvento.Items.Add("Cambio de contraseña");
            cmbEvento.Items.Add("Cierre de sesión");

            //Modulo gestión de perfiles
            cmbEvento.Items.Add("Creación de perfil");
            cmbEvento.Items.Add("Modificación de perfil");
            cmbEvento.Items.Add("Eliminación de perfil");
            cmbEvento.Items.Add("Creación de familia");
            cmbEvento.Items.Add("Modificación de familia");
            cmbEvento.Items.Add("Eliminación de familia");
            //Modulo préstamos y devoluciones
            cmbEvento.Items.Add("Registro de préstamo");
            cmbEvento.Items.Add("Registro de sanción");
            cmbEvento.Items.Add("Registro de devolución");
            //Modulo gestión de stock
            cmbEvento.Items.Add("Registro de nuevo stock");
            cmbEvento.Items.Add("Registro de distribuidor");
            //Modulo gestión de Backup/Restore
            cmbEvento.Items.Add("Creación de backup");
            cmbEvento.Items.Add("Restauración desde backup");
        }
        private void CargarcmbCriticidad()
        {
            cmbCriticidad.Items.Clear();
            cmbCriticidad.Items.Add("1");
            cmbCriticidad.Items.Add("2");
            cmbCriticidad.Items.Add("3");
            cmbCriticidad.Items.Add("4");
            cmbCriticidad.Items.Add("5");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbLogin.SelectedIndex = -1;
            cmbEvento.SelectedIndex = -1;
            cmbModulo.SelectedIndex = -1;
            cmbCriticidad.SelectedIndex = -1;
            dtpFechaInicio.Value = DateTime.Now.AddDays(-3);
            dtpFechaFin.Value = DateTime.Now;
            chkFiltrarFecha.Checked = false;
            CargarcmbEvento();
        }
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormBitacoraEventos_327LG");
                string? login = string.IsNullOrWhiteSpace(cmbLogin.Text) ? null : cmbLogin.Text;
                string? modulo = string.IsNullOrWhiteSpace(cmbModulo.Text) ? null : cmbModulo.Text;
                string? evento = string.IsNullOrWhiteSpace(cmbEvento.Text) ? null : cmbEvento.Text;
                int? criticidad = string.IsNullOrWhiteSpace(cmbCriticidad.Text) ? null : int.Parse(cmbCriticidad.Text);

                DateTime? fechaInicio = null;
                DateTime? fechaFin = null;
                if (chkFiltrarFecha.Checked)
                {
                    fechaInicio = dtpFechaInicio.Value.Date;
                    fechaFin = dtpFechaFin.Value.Date;
                }
                CargarGrilla_327LG(login, modulo, evento, criticidad, fechaInicio, fechaFin);
                if (bLLEvento_327LG.ObtenerEventos_327LG(login, fechaInicio, fechaFin, modulo, evento, criticidad).Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.NoHayEventos"));
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }


        }

        private void CargarGrilla_327LG(string? login, string? modulo, string? evento, int? criticidad, DateTime? fechaInicio, DateTime? fechaFin)
        {
            var linq = from x in bLLEvento_327LG.ObtenerEventos_327LG(login, fechaInicio, fechaFin, modulo, evento, criticidad)
                       orderby x.IdEvento_327LG descending
                       select new
                       {
                           x.IdEvento_327LG,
                           x.Login_327LG,
                           x.Fecha_327LG,
                           x.Hora_327LG,
                           x.Modulo_327LG,
                           x.evento_327LG,
                           x.Criticidad_327LG
                       };
            dgvEventos.DataSource = linq.ToList();
            dgvEventos.Columns["IdEvento_327LG"].FillWeight = 90;
            dgvEventos.Columns["Login_327LG"].FillWeight = 80;
            dgvEventos.Columns["Fecha_327LG"].FillWeight = 80;
            dgvEventos.Columns["Hora_327LG"].FillWeight = 70;
            dgvEventos.Columns["Modulo_327LG"].FillWeight = 160;
            dgvEventos.Columns["evento_327LG"].FillWeight = 160;
            dgvEventos.Columns["Criticidad_327LG"].FillWeight = 60;

            Actualizar_327LG();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormBitacoraEventos_327LG");
                if (dgvEventos.Rows.Count == 0) throw new Exception(LM_327LG.ObtenerString("exception.sinDatosParaExportar"));
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.FileName = "Eventos.pdf";
                List<Evento_327LG> listaEventos = new List<Evento_327LG>();
                foreach (DataGridViewRow row in dgvEventos.Rows)
                {
                    string idEvento = row.Cells["IdEvento_327LG"].Value.ToString();
                    string login = row.Cells["Login_327LG"].Value.ToString();
                    DateTime fecha = Convert.ToDateTime(row.Cells["Fecha_327LG"].Value);
                    TimeSpan hora = (TimeSpan)row.Cells["Hora_327LG"].Value;
                    string modulo = row.Cells["Modulo_327LG"].Value.ToString();
                    string even = row.Cells["evento_327LG"].Value.ToString();
                    int criticidad = Convert.ToInt32(row.Cells["Criticidad_327LG"].Value);

                    Evento_327LG evento = new Evento_327LG(idEvento, login, fecha.Date, hora, modulo, even, criticidad);
                    listaEventos.Add(evento);

                }
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string ruta = saveFileDialog.FileName;
                    bLLEvento_327LG.ImprimirEventos_327LG(listaEventos, ruta);

                }
            }
            catch (Exception ex)
            {

                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }




        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormBitacoraEventos_327LG");
            lblTitulo.Text = LM_327LG.ObtenerString("label.lblTitulo");
            lblNombre.Text = LM_327LG.ObtenerString("label.lblNombre");
            lblApellido.Text = LM_327LG.ObtenerString("label.lblApellido");
            lblFechaInicio.Text = LM_327LG.ObtenerString("label.lblFechaInicio");
            lblFechaFin.Text = LM_327LG.ObtenerString("label.lblFechaFin");
            lblModulo.Text = LM_327LG.ObtenerString("label.lblModulo");
            lblEvento.Text = LM_327LG.ObtenerString("label.lblEvento");
            lblCriticidad.Text = LM_327LG.ObtenerString("label.lblCriticidad");

            btnAplicar.Text = LM_327LG.ObtenerString("button.btnAplicar");
            btnLimpiar.Text = LM_327LG.ObtenerString("button.btnLimpiar");
            btnImprimir.Text = LM_327LG.ObtenerString("button.btnImprimir");

            chkFiltrarFecha.Text = LM_327LG.ObtenerString("checkbox.chkFiltrarFecha");

            dgvEventos.Columns["IdEvento_327LG"].HeaderText = LM_327LG.ObtenerString("datagridview.column.idEvento");
            dgvEventos.Columns["Login_327LG"].HeaderText = "Login";
            dgvEventos.Columns["Fecha_327LG"].HeaderText = LM_327LG.ObtenerString("datagridview.column.fecha");
            dgvEventos.Columns["Hora_327LG"].HeaderText = LM_327LG.ObtenerString("datagridview.column.hora");
            dgvEventos.Columns["Modulo_327LG"].HeaderText = LM_327LG.ObtenerString("datagridview.column.modulo");
            dgvEventos.Columns["evento_327LG"].HeaderText = LM_327LG.ObtenerString("datagridview.column.evento");
            dgvEventos.Columns["Criticidad_327LG"].HeaderText = LM_327LG.ObtenerString("datagridview.column.criticidad");
        }

        private void dgvEventos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEventos.SelectedRows.Count > 0)
            {
                string username = dgvEventos.SelectedRows[0].Cells["Login_327LG"].Value.ToString();
                Usuario_327LG usuario = bllUsuario_327LG.ObtenerUsuarios_327LG().FirstOrDefault(x => x.userName_327LG == username);
                txtNombre.Text = usuario.nombre_327LG;
                txtApellido.Text = usuario.apellido_327LG;
            }
            else
            {
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
            }
        }

        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbEvento.Items.Clear();
            cmbEvento.SelectedIndex = -1;
            cmbEvento.Text = string.Empty;
            switch (cmbModulo.SelectedIndex)
            {
                case 0: //Gestión de usuarios
                    cmbEvento.Items.Add("Inicio de sesión exitoso");
                    cmbEvento.Items.Add("Creación de usuario");
                    cmbEvento.Items.Add("Modificación de usuario");
                    cmbEvento.Items.Add("Bloqueo de usuario");
                    cmbEvento.Items.Add("Desbloqueo de usuario");
                    cmbEvento.Items.Add("Activación de usuario");
                    cmbEvento.Items.Add("Desactivación de usuario");
                    cmbEvento.Items.Add("Cambio de contraseña");
                    cmbEvento.Items.Add("Cierre de sesión");
                    break;
                case 1: //Gestión de perfiles
                    cmbEvento.Items.Add("Creación de perfil");
                    cmbEvento.Items.Add("Modificación de perfil");
                    cmbEvento.Items.Add("Eliminación de perfil");
                    cmbEvento.Items.Add("Creación de familia");
                    cmbEvento.Items.Add("Modificación de familia");
                    cmbEvento.Items.Add("Eliminación de familia");
                    break;
                case 2: //Préstamos y devoluciones
                    cmbEvento.Items.Add("Registro de préstamo");
                    cmbEvento.Items.Add("Registro de sanción");
                    cmbEvento.Items.Add("Registro de devolución");
                    break;
                case 3: //Gestión de stock
                    cmbEvento.Items.Add("Registro de nuevo stock");
                    break;
                case 4: //Gestión de Backup/Restore
                    cmbEvento.Items.Add("Creación de backup");
                    cmbEvento.Items.Add("Restauración desde backup");
                    break;
            }
        }

        private void FormBitacoraEventos_327LG_FormClosed(object sender, FormClosedEventArgs e)
        {
            LM_327LG.EliminarObservador_327LG(this);
        }
    }
}