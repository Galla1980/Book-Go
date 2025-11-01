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

namespace GUI_327LG.GUI_RF2
{
    public partial class FormPagarOrdenCompra_327LG : Form, IObserverIdioma_327LG
    {
        LanguageManager_327LG LM_327LG;
        
        public string CBU { get; private set; }
        public string Banco { get; private set; }
        public string NombreTitular { get; private set; }
        public string NumeroTarjeta { get; private set; }
        public decimal Monto { get; set; }
        public string Cuit { get; set; }
        public FormPagarOrdenCompra_327LG(decimal monto, string cuit)
        {
            InitializeComponent();
            LM_327LG = LanguageManager_327LG.Instance_327LG;
            LM_327LG.AgregarObservador_327LG(this);
            Monto = monto;
            Cuit = cuit;
        }

        public void Actualizar_327LG()
        {
            LM_327LG.CargarFormulario_327LG("FormPagarOrdenCompra_327LG");

            //label
            lblTituloForm.Text = LM_327LG.ObtenerString("label.lblTitulo");
            lblBanco.Text = LM_327LG.ObtenerString("label.lblBanco");
            lblMonto.Text = LM_327LG.ObtenerString("label.lblMonto");
            lblNombreTitular.Text = LM_327LG.ObtenerString("label.lblNombre");
            lblNroTarjeta.Text = LM_327LG.ObtenerString("label.lblNumero");
            lblClave.Text = LM_327LG.ObtenerString("label.lblCodigoSeg");
            lblVencimiento.Text = LM_327LG.ObtenerString("label.lblVencimiento");
            //Botones 
            btnCobrar.Text = LM_327LG.ObtenerString("button.btnCobrar");
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                LM_327LG.CargarFormulario_327LG("FormPagarOrdenCompra_327LG");
                if (string.IsNullOrWhiteSpace(txtBanco.Text) || string.IsNullOrWhiteSpace(txtCBU.Text) ||
                   string.IsNullOrWhiteSpace(txtNombreTitular.Text) || string.IsNullOrWhiteSpace(txtNroTarjeta.Text) ||
                   string.IsNullOrWhiteSpace(txtClave.Text) || string.IsNullOrWhiteSpace(txtVencimiento.Text))
                {
                    throw new Exception(LM_327LG.ObtenerString("exception.campos_vacios"));
                }
                if (txtCBU.Text.Length != 22 || !txtCBU.Text.All(char.IsDigit))
                {
                    throw new Exception(LM_327LG.ObtenerString("exception.cbu_invalido"));
                }
                if (txtNroTarjeta.Text.Length != 16 || !txtNroTarjeta.Text.All(char.IsDigit)) throw new Exception(LM_327LG.ObtenerString("exception.numero_tarjeta_invalido"));
                if (!Regex.IsMatch(txtClave.Text, @"^\d{3}$")) throw new Exception(LM_327LG.ObtenerString("exception.codigo_seguridad_invalido"));
                
                if (!Regex.IsMatch(txtVencimiento.Text, @"^(0[1-9]|1[0-2])\/(\d{2})$")) throw new Exception(LM_327LG.ObtenerString("exception.vencimiento_formato_invalido"));
                string[] partes = txtVencimiento.Text.Split('/');
                int mes = int.Parse(partes[0]);
                int año = int.Parse(partes[1].Length == 2 ? "20" + partes[1] : partes[1]);
                DateTime fechaVenc = new DateTime(año, mes, 1).AddMonths(1).AddDays(-1);
                if (fechaVenc < DateTime.Today) throw new Exception(LM_327LG.ObtenerString("exception.tarjeta_vencida"));
                CBU = txtCBU.Text.Trim();
                Banco = txtBanco.Text.Trim();
                NombreTitular = txtNombreTitular.Text.Trim();
                NumeroTarjeta = new string('*',12) + txtNroTarjeta.Text.Substring(12);
                
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, LM_327LG.ObtenerString("messagebox.titulo.error"), LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }

        private void FormPagarOrdenCompra_327LG_FormClosed(object sender, FormClosedEventArgs e)
        {
            LM_327LG.EliminarObservador_327LG(this);
        }

        private void FormPagarOrdenCompra_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#055b6b");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }
            txtMonto.Text = Monto.ToString();
            txtCuit.Text = Cuit;
            Actualizar_327LG();
        }
    }
}
