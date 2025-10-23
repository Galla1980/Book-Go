using BLL_327LG;
using com.itextpdf.text.pdf;
using Services_327LG;
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

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormRegistrarDistribuidor_327LG");
            modo = "Registrar";
            btnAplicar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnRegistrar.Enabled = false;
            btnCancelar.Enabled = true;
            lblModo.Text = LM_327LG.ObtenerString("label.lblModoRegistrar");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormRegistrarDistribuidor_327LG");
            modo = "Modificar";
            btnAplicar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnRegistrar.Enabled = false;
            btnCancelar.Enabled = true;
            txtCuit.Enabled = false;
            lblModo.Text = LM_327LG.ObtenerString("label.lblModoModificar");
            if (dgvDistribuidores.SelectedRows.Count != 0)
            {
                txtCuit.Text = dgvDistribuidores.SelectedRows[0].Cells["CUIT"].Value.ToString();
                txtEmpresa.Text = dgvDistribuidores.SelectedRows[0].Cells["Empresa"].Value.ToString();
                txtTelefono.Text = dgvDistribuidores.SelectedRows[0].Cells["Telefono"].Value.ToString();
                txtDireccion.Text = dgvDistribuidores.SelectedRows[0].Cells["Direccion"].Value.ToString();
                txtCorreo.Text = dgvDistribuidores.SelectedRows[0].Cells["Email"].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormRegistrarDistribuidor_327LG");
            modo = "Eliminar";
            btnAplicar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnRegistrar.Enabled = false;
            btnCancelar.Enabled = true;
            lblModo.Text = LM_327LG.ObtenerString("label.lblModoEliminar");
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LM_327LG.CargarFormulario_327LG("FormRegistrarDistribuidor_327LG");

            modo = "Consultar";
            btnAplicar.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnRegistrar.Enabled = true;
            btnCancelar.Enabled = false;
            txtCuit.Text = string.Empty;
            txtEmpresa.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            lblModo.Text = LM_327LG.ObtenerString("label.lblModoConsulta");
        }
        private void FormRegistrarDistribuidor_327LG_FormClosing(object sender, FormClosingEventArgs e)
        {
            LM_327LG.EliminarObservador_327LG(this);
        }

    }
}
