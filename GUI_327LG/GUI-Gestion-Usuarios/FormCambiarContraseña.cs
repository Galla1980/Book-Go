using BLL_327LG;
using Services_327LG;
using Services_327LG.Observer_327LG;
using Services_327LG.Singleton_327LG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_327LG
{
    public partial class FormCambiarContraseña : Form, IObserverIdioma_327LG
    {
        BLLUsuario_327LG bllUsuario_327LG;
        public FormCambiarContraseña()
        {
            InitializeComponent();
            bllUsuario_327LG = new BLLUsuario_327LG();
            LanguageManager.Instance.AgregarObservador_327LG(this);
            Actualizar_327LG();
        }

        private void btnCambiarContraseña_Click_327LG(object sender, EventArgs e)
        {
            try
            {
                string contraseña = txtContraseñaAct.Text;
                string nuevaContraseña = txtNuevaContraseña.Text;
                string confirmarContraseña = txtConfContraseña.Text;
                if(string.IsNullOrWhiteSpace(contraseña) || string.IsNullOrWhiteSpace(nuevaContraseña) || string.IsNullOrWhiteSpace(confirmarContraseña))
                {
                    throw new Exception(LanguageManager.Instance.ObtenerString("FormCambiarContrasena.messagebox.campos_vacios"));
                }
                if (SessionManager_327LG.Instancia.Usuario.password_327LG != Encriptador_327LG.Encriptar_327LG(contraseña)) throw new Exception(LanguageManager.Instance.ObtenerString("FormCambiarContrasena.messagebox.contrasena_actual_incorrecta"));
                if (nuevaContraseña != confirmarContraseña) throw new Exception(LanguageManager.Instance.ObtenerString("FormCambiarContrasena.messagebox.contrasena_no_coincide"));
                if (contraseña == nuevaContraseña) throw new Exception(LanguageManager.Instance.ObtenerString("FormCambiarContrasena.messagebox.contrasena_nueva_identica"));
                if (MessageBox.Show(LanguageManager.Instance.ObtenerString("FormCambiarContrasena.messagebox.confirmar_cambio_contrasena.mensaje"), LanguageManager.Instance.ObtenerString("FormCambiarContrasena.messagebox.confirmar_cambio_contrasena.titulo"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bllUsuario_327LG.CambiarContraseña_327LG(SessionManager_327LG.Instancia.Usuario, nuevaContraseña);
                    bllUsuario_327LG.CerrarSesion_327LG();
                    MessageBox.Show(LanguageManager.Instance.ObtenerString("FormCambiarContrasena.messagebox.contrasena_cambiada"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                FormMDI mdi = (FormMDI)this.MdiParent;
                mdi.ActualizarFormulario_327LG();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkContraseñaActual_CheckedChanged(object sender, EventArgs e)
        {
            VerContraseña(chkContraseñaActual, txtContraseñaAct);
        }
        private void chkConfContraseña_CheckedChanged(object sender, EventArgs e)
        {
            VerContraseña(chkConfContraseña, txtConfContraseña);
        }

        private void VerContraseña(CheckBox chk, TextBox txtContraseña)
        {
            if (chk.Checked)
            {
                txtContraseña.PasswordChar = '\0';
            }
            else
            {
                txtContraseña.PasswordChar = '●';
            }
        }

        private void FormCambiarContraseña_Load(object sender, EventArgs e)
        {
            // Fondo del formulario
            this.BackColor = ColorTranslator.FromHtml("#0c7689");

            // Labels 
            lblCmbContraseña.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }

            // Checkboxes "Ver"
            chkContraseñaActual.ForeColor = Color.White;
            chkConfContraseña.ForeColor = Color.White;

            // TextBoxes
            txtContraseñaAct.BackColor = Color.White;
            txtContraseñaAct.ForeColor = Color.Black;
            txtContraseñaAct.BorderStyle = BorderStyle.FixedSingle;

            txtNuevaContraseña.BackColor = Color.White;
            txtNuevaContraseña.ForeColor = Color.Black;
            txtNuevaContraseña.BorderStyle = BorderStyle.FixedSingle;

            txtConfContraseña.BackColor = Color.White;
            txtConfContraseña.ForeColor = Color.Black;
            txtConfContraseña.BorderStyle = BorderStyle.FixedSingle;

            // Botón Cambiar Contraseña
            btnCambiarContraseña.BackColor = ColorTranslator.FromHtml("#4cb2c7");
            btnCambiarContraseña.ForeColor = Color.White;
            btnCambiarContraseña.FlatStyle = FlatStyle.Flat;
            btnCambiarContraseña.FlatAppearance.BorderSize = 0;

            // Botón Salir
            btnSalir.BackColor = ColorTranslator.FromHtml("#cccccc");
            btnSalir.ForeColor = Color.Black;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderSize = 0;
        }

        public void Actualizar_327LG()
        {
            lblCmbContraseña.Text = LanguageManager.Instance.ObtenerString("FormCambiarContrasena.label.lblTitulo");
            lblContraseñaAct.Text = LanguageManager.Instance.ObtenerString("FormCambiarContrasena.label.lblContrasenaActual");
            lblNuevaContraseña.Text = LanguageManager.Instance.ObtenerString("FormCambiarContrasena.label.lblNuevaContrasena");
            lblConfContraseña.Text = LanguageManager.Instance.ObtenerString("FormCambiarContrasena.label.lblConfirmarContrasena");
            btnCambiarContraseña.Text = LanguageManager.Instance.ObtenerString("FormCambiarContrasena.button.btnCambiar");
            btnSalir.Text = LanguageManager.Instance.ObtenerString("FormCambiarContrasena.button.btnCancelar");
            chkContraseñaActual.Text = LanguageManager.Instance.ObtenerString("FormCambiarContrasena.checkbox.chkMostrarContrasena");
            chkConfContraseña.Text = LanguageManager.Instance.ObtenerString("FormCambiarContrasena.checkbox.chkMostrarContrasena");
        }
    }
}
