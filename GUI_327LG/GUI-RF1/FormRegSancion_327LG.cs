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

namespace GUI_327LG.GUIRF1
{
    public partial class FormRegSancion_327LG : Form, IObserverIdioma_327LG
    {
        public string razon;
        public string descripcion;
        LanguageManager_327LG LM_327LG;
        public FormRegSancion_327LG()
        {
            InitializeComponent();
            LM_327LG = LanguageManager_327LG.Instance_327LG;
        }

        public void Actualizar_327LG()
        {
        }

        private void FormRegSancion_327LG_Load(object sender, EventArgs e)
        {
            txtRazon.Text = razon;
            this.BackColor = ColorTranslator.FromHtml("#055b6b");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }
        }

        private void btnRegistrarSancion_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRazon.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text))throw new Exception("Por favor, proporcione una descripción para la sanción.");
                this.DialogResult = DialogResult.OK;
                descripcion = txtDescripcion.Text;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al registrar la sanción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
