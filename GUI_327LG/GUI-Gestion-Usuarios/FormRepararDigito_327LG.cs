using BE_327LG;
using BLL_327LG;
using DAL_327LG;
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

namespace GUI_327LG.GUI_Gestion_Usuarios
{
    public partial class FormRepararDigito_327LG : Form, IObserverIdioma_327LG
    {
        LanguageManager_327LG LM_327LG;
        BLLDigitoVerificador_327LG bllDigitoVerificador;
        BLLBackUpRestore_327LG bllBackUpRestore;
        BLLUsuario_327LG bllUsuario;
        public FormMDI_327LG formPadre;
        public FormRepararDigito_327LG()
        {
            InitializeComponent();
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            LM_327LG.AgregarObservador_327LG(this);
            LM_327LG.CargarFormulario_327LG("FormRepararDigito_327LG");
            bllDigitoVerificador = new BLLDigitoVerificador_327LG();
            bllBackUpRestore = new BLLBackUpRestore_327LG();
            bllUsuario = new BLLUsuario_327LG();
        }

        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormRepararDigito_327LG");

            lblInconsistencias.Text = LM_327LG.ObtenerString("label.lblInconsistencias");
            lblTitulo.Text = LM_327LG.ObtenerString("label.lblTitulo");

            btnRecalcular.Text = LM_327LG.ObtenerString("button.btnRecalcular");
            btnRestaurar.Text = LM_327LG.ObtenerString("button.btnRestaurar");
            btnSalir.Text = LM_327LG.ObtenerString("button.btnSalir");

        }

        private void FormRepararDigito_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#055b6b");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }
            if (bllDigitoVerificador.CompararDigito_327LG().Count > 0)
            {
                string lista = string.Empty;
                foreach (string item in bllDigitoVerificador.CompararDigito_327LG())
                {
                    lista += item + ", ";
                }
                MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.inconsistencias"), LM_327LG.ObtenerString("messagebox.titulo.inconsistencias"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                Actualizar_327LG();
                lblInconsistencias.Text += lista;
            }
        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            foreach (var item in bllDigitoVerificador.CompararDigito_327LG())
            {
                BEDigitoVerificador_327LG digito = bllDigitoVerificador.ObtenerTodos_327LG().First(x => x.NombreTabla_327LG == item);
                bllDigitoVerificador.GuardarDigitoVerificador_327LG(digito);
            }

            MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.reparado"), LM_327LG.ObtenerString("messagebox.titulo.reparado"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
            this.Close();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog fd = new OpenFileDialog())
                {
                    fd.Filter = "SQL Backup Files  (*.bak)|*.bak";
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        if (fd.FileName == string.Empty) throw new Exception("Debe seleccionar un archivo para restaurar.");
                        bllBackUpRestore.HacerRestore_327LG(fd.FileName);
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.restaurada"), LM_327LG.ObtenerString("messagebox.titulo.restaurada"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al restaurar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRepararDigito_327LG_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarFormulario_327LG();
            LM_327LG.EliminarObservador_327LG(this);
        }

        private void CerrarFormulario_327LG()
        {
            bllUsuario.CerrarSesion_327LG();
            formPadre.CerrarFormularios();
            formPadre.ActualizarFormulario_327LG();

        }
    }
}
