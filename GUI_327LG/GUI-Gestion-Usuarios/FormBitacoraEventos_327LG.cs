using BLL_327LG;
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
    public partial class FormBitacoraEventos_327LG : Form, IObserverIdioma_327LG
    {
        LanguageManager_327LG LM_327LG = LanguageManager_327LG.Instance_327LG;
        BLLEvento_327LG bLLEvento_327LG = new BLLEvento_327LG();
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
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            string login  = cmbLogin.SelectedItem?.ToString();
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaFin = dtpFechaFin.Value;
            string modulo = cmbModulo.SelectedItem?.ToString();
            string evento = cmbEvento.SelectedItem?.ToString();
            int criticidad = Convert.ToInt32(cmbCriticidad.SelectedItem?.ToString());
            bLLEvento_327LG.ObtenerEventos_327LG(login, fechaInicio, fechaFin, modulo, evento, criticidad);

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
    }
}