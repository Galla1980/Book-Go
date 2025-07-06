using BE_327LG;
using BLL_327LG;
using Services_327LG.Observer_327LG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_327LG.GUIRF1
{
    public partial class FormCobrarSeña_327LG : Form, IObserverIdioma_327LG
    {
        LanguageManager_327LG LM_327LG;
        string metodo = "tarjeta";
        BLLFactura_327LG bllFactura_327LG;
        public BELibro_327LG libro;
        public BECliente_327LG cliente;
        public FormCobrarSeña_327LG()
        {
            InitializeComponent();
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            LM_327LG.AgregarObservador_327LG(this);
            bllFactura_327LG = new BLLFactura_327LG();
        }

        private void FormCobrarSeña_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#055b6b");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }
            Actualizar_327LG();

        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (metodo)
                {
                    case "efectivo":
                        ValidarMonto_327LG();
                        decimal montoEfectivo = decimal.Parse(txtMonto.Text);
                        bllFactura_327LG.GenerarFactura_327LG(cliente, montoEfectivo, libro);
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.pago_exitoso"), LM_327LG.ObtenerString("messagebox.titulo.pago_exitoso"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        break;
                    case "tarjeta":
                        ValidarCampos_327LG();
                        decimal montoTarjeta = decimal.Parse(txtMonto.Text);
                        bllFactura_327LG.GenerarFactura_327LG(cliente, montoTarjeta, libro);
                        MessageBoxPersonalizado.Show(LM_327LG.ObtenerString("messagebox.mensaje.pago_exitoso"), LM_327LG.ObtenerString("messagebox.titulo.pago_exitoso"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void ValidarMonto_327LG()
        {
            if (string.IsNullOrWhiteSpace(txtMonto.Text)) throw new Exception(LM_327LG.ObtenerString("exception.monto_no_ingresado"));
            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0) throw new Exception(LM_327LG.ObtenerString("exception.monto_invalido"));
        }

        private void ValidarCampos_327LG()
        {
            ValidarMonto_327LG();
            if (string.IsNullOrWhiteSpace(txtNombreTitular.Text) || string.IsNullOrWhiteSpace(txtNroTarjeta.Text) || string.IsNullOrWhiteSpace(txtClave.Text) || string.IsNullOrWhiteSpace(txtVencimiento.Text)) throw new Exception(LM_327LG.ObtenerString("exception.campos_tarjeta_vacios"));
            // Validar nombre del titular sin numeros
            if (!Regex.IsMatch(txtNombreTitular.Text, @"^[a-zA-Z\s]+$")) throw new Exception(LM_327LG.ObtenerString("exception.nombre_titular_invalido"));
            // Validar número de tarjeta
            if (!Regex.IsMatch(txtNroTarjeta.Text, @"^\d{16}$")) throw new Exception(LM_327LG.ObtenerString("exception.numero_tarjeta_invalido"));
            // Validar código de seguridad
            if (!Regex.IsMatch(txtClave.Text, @"^\d{3}$")) throw new Exception(LM_327LG.ObtenerString("exception.codigo_seguridad_invalido"));
            // Validar formato y vencimiento de la tarjeta
            if (!Regex.IsMatch(txtVencimiento.Text, @"^(0[1-9]|1[0-2])\/(\d{2})$")) throw new Exception(LM_327LG.ObtenerString("exception.vencimiento_formato_invalido"));
            string[] partes = txtVencimiento.Text.Split('/');
            int mes = int.Parse(partes[0]);
            int año = int.Parse(partes[1].Length == 2 ? "20" + partes[1] : partes[1]);
            DateTime fechaVenc = new DateTime(año, mes, 1).AddMonths(1).AddDays(-1);
            if (fechaVenc < DateTime.Today) throw new Exception(LM_327LG.ObtenerString("exception.tarjeta_vencida"));
        }

        private void cmbMetodoPago_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbMetodoPago.Text == LM_327LG.ObtenerString("combobox.itemEfectivo"))
            {
                metodo = "efectivo";
                lblNombreTitular.Enabled = false;
                lblNroTarjeta.Enabled = false;
                lblClave.Enabled = false;
                lblVencimiento.Enabled = false;
                txtNombreTitular.Enabled = false;
                txtNroTarjeta.Enabled = false;
                txtClave.Enabled = false;
                txtVencimiento.Enabled = false;
            }
            else if (cmbMetodoPago.Text == LM_327LG.ObtenerString("combobox.itemTarjeta"))
            {
                metodo = "tarjeta";
                lblNombreTitular.Enabled = true;
                lblNroTarjeta.Enabled = true;
                lblClave.Enabled = true;
                lblVencimiento.Enabled = true;
                txtNombreTitular.Enabled = true;
                txtNroTarjeta.Enabled = true;
                txtClave.Enabled = true;
                txtVencimiento.Enabled = true;
            }
        }
        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormCobrarSeña_327LG");
            //label
            lblTituloForm.Text = LM_327LG.ObtenerString("label.lblTitulo");
            lblMonto.Text = LM_327LG.ObtenerString("label.lblMonto");
            lblMetodo.Text = LM_327LG.ObtenerString("label.lblMetodo");
            lblNombreTitular.Text = LM_327LG.ObtenerString("label.lblNombre");
            lblNroTarjeta.Text = LM_327LG.ObtenerString("label.lblNumero");
            lblClave.Text = LM_327LG.ObtenerString("label.lblCodigoSeg");
            lblVencimiento.Text = LM_327LG.ObtenerString("label.lblVencimiento");
            //botones
            btnCobrar.Text = LM_327LG.ObtenerString("button.btnCobrar");
            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.Add(LM_327LG.ObtenerString("combobox.itemEfectivo"));
            cmbMetodoPago.Items.Add(LM_327LG.ObtenerString("combobox.itemTarjeta"));
            if (metodo == "tarjeta") cmbMetodoPago.Text = LM_327LG.ObtenerString("combobox.itemTarjeta");
            else cmbMetodoPago.Text = LM_327LG.ObtenerString("combobox.itemEfectivo");

        }

        private void FormCobrarSeña_327LG_FormClosed(object sender, FormClosedEventArgs e)
        {
            LM_327LG.EliminarObservador_327LG(this);
        }
    }
}
