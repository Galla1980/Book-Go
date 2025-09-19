using BLL_327LG;
using Microsoft.VisualBasic.Logging;
using Services_327LG;
using Services_327LG.Observer_327LG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Actualizar_327LG();

        }

        private void FormBitacoraEventos_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#0c7689");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
            }
            dgvEventos.MultiSelect = false;
            dgvEventos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtpFechaInicio.Value = DateTime.Now.AddDays(-3);
            var linq = from x in bLLEvento_327LG.ObtenerEventos_327LG(null, DateTime.Now.AddDays(-3), DateTime.Now, null, null, null)
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
            cmbEvento.Items.Add("Reseteo de contraseña");
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
                DateTime fechaInicio = dtpFechaInicio.Value.Date;
                DateTime fechaFin = dtpFechaFin.Value.Date;
                bLLEvento_327LG.ObtenerEventos_327LG(login, fechaInicio, fechaFin, modulo, evento, criticidad);
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
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }


        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {

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
                    cmbEvento.Items.Add("Reseteo de contraseña");
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
    }
}