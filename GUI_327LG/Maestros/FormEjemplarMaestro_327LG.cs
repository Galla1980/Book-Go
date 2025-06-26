using BE_327LG;
using BLL_327LG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_327LG.Maestros
{
    public partial class FormEjemplarMaestro_327LG : Form
    {
        BLLLibro_327LG bllLibro_327LG;
        BLLEjemplar_327LG bllEjemplar_327;
        public FormEjemplarMaestro_327LG()
        {
            InitializeComponent();
            bllLibro_327LG = new BLLLibro_327LG();
            bllEjemplar_327 = new BLLEjemplar_327LG();
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.MultiSelect = false;
        }

        private void btnAgregarEjemplar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLibros.SelectedRows.Count == 0) throw new Exception("Debe seleccionar un libro para agregar un ejemplar.");
                BELibro_327LG libro = (BELibro_327LG)dgvLibros.SelectedRows[0].DataBoundItem;
                BEEjemplar_327LG bEEjemplar_327LG = new BEEjemplar_327LG(Estado_327LG.Disponible, libro);
                bllEjemplar_327.AgregarEjemplar_327LG(bEEjemplar_327LG);
                MessageBox.Show("Ejemplar agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormEjemplarMaestro_327LG_Load(object sender, EventArgs e)
        {
            dgvLibros.DataSource = bllLibro_327LG.ObtenerLibros_327LG();
            dgvLibros.Columns["ISBN_327LG"].FillWeight = 20;
            dgvLibros.Columns["Editorial_327LG"].FillWeight = 15;
            dgvLibros.Columns["Edicion_327LG"].FillWeight = 15;
            dgvLibros.Columns["Titulo_327LG"].FillWeight = 50;
            dgvLibros.Columns["Autor_327LG"].FillWeight = 20;
        }
    }
}
