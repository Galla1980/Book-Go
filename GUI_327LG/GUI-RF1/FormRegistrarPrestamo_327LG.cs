using BE_327LG;
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
    public partial class FormRegistrarPrestamo_327LG : Form
    {
        BEEjemplar_327LG ejemplarPrestamo;
        public FormRegistrarPrestamo_327LG()
        {
            InitializeComponent();
        }


        private void FormRegistrarPrestamo_327LG_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#055b6b");
            foreach (Label label in this.Controls.OfType<Label>())
            {
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
            }
        }
        private void btnSeleccionarLibro_Click(object sender, EventArgs e)
        {
            using (FormSeleccionarLibro_327LG formSeleccionarLibro_327LG = new FormSeleccionarLibro_327LG())
            {
                if (formSeleccionarLibro_327LG.ShowDialog() == DialogResult.OK)
                {
                    ejemplarPrestamo = formSeleccionarLibro_327LG.libroSeleccionado_327LG;
                }
            }
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            using (FormRegistrarCliente_327LG formRegistrarCliente_327LG = new FormRegistrarCliente_327LG())
            {
                if (formRegistrarCliente_327LG.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }
    }
}
