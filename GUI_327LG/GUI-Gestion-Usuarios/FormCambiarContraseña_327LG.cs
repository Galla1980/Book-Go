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
    public partial class FormCambiarContraseña_327LG : Form, IObserverIdioma_327LG
    {
        BLLUsuario_327LG bllUsuario_327LG;
        LanguageManager_327LG LM_327LG;
        public FormCambiarContraseña_327LG()
        {
            InitializeComponent();
            bllUsuario_327LG = new BLLUsuario_327LG();
            LM_327LG = LanguageManager_327LG.Instance;
            LM_327LG.AgregarObservador_327LG(this);
            Actualizar_327LG();
        }

        private void btnCambiarContraseña_Click_327LG(object sender, EventArgs e)
        {
            try
            {
                string contraseña = txtContraseñaAct.Text;
                string nuevaContraseña = txtNuevaContraseña.Text;
                string confirmarContraseña = txtConfContraseña.Text;
                
                LM_327LG.CargarFormulario_327LG("FormCambiarContraseña_327LG");
                if (string.IsNullOrWhiteSpace(contraseña) || string.IsNullOrWhiteSpace(nuevaContraseña) || string.IsNullOrWhiteSpace(confirmarContraseña)) throw new Exception(LM_327LG.ObtenerString("exception.campos_vacios"));
                if (SessionManager_327LG.Instancia.Usuario.password_327LG != Encriptador_327LG.Encriptar_327LG(contraseña)) throw new Exception(LM_327LG.ObtenerString("exception.contrasena_actual_incorrecta"));
                if (nuevaContraseña != confirmarContraseña) throw new Exception(LM_327LG.ObtenerString("exception.contrasena_no_coincide"));
                if (contraseña == nuevaContraseña) throw new Exception(LM_327LG.ObtenerString("exception.contrasena_nueva_identica"));

                if (MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.confirmar_cambio_contrasena.mensaje"), LM_327LG.ObtenerString("messagebox.confirmar_cambio_contrasena.titulo"), LM_327LG.ObtenerString("messagebox.button.aceptar"),LM_327LG.ObtenerString("messagebox.button.cancelar"), MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bllUsuario_327LG.CambiarContraseña_327LG(SessionManager_327LG.Instancia.Usuario, nuevaContraseña);
                    bllUsuario_327LG.CerrarSesion_327LG();
                    MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.contrasena_cambiada.mensaje"), LM_327LG.ObtenerString("messagebox.contrasena_cambiada.titulo"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                }

                FormMDI_327LG mdi = (FormMDI_327LG)this.MdiParent;
                mdi.ActualizarFormulario_327LG();
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormCambiarContraseña_327LG");
            lblCmbContraseña.Text = LM_327LG.ObtenerString("label.lblTitulo");
            lblContraseñaAct.Text = LM_327LG.ObtenerString("label.lblContrasenaActual");
            lblNuevaContraseña.Text = LM_327LG.ObtenerString("label.lblNuevaContrasena");
            lblConfContraseña.Text = LM_327LG.ObtenerString("label.lblConfirmarContrasena");
            btnCambiarContraseña.Text = LM_327LG.ObtenerString("button.btnCambiar");
            btnSalir.Text = LM_327LG.ObtenerString("button.btnCancelar");
            chkContraseñaActual.Text = LM_327LG.ObtenerString("checkbox.chkMostrarContrasena");
            chkConfContraseña.Text = LM_327LG.ObtenerString("checkbox.chkMostrarContrasena");
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
        private void FormCambiarContraseña_327LG_FormClosed(object sender, FormClosedEventArgs e)
        {
            LM_327LG.EliminarObservador_327LG(this);
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
    }
}
