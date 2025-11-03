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

namespace GUI_327LG.Reportes
{
    public partial class FormReporteOrdenCompra_327LG : Form
    {
        BLLOrdenCompra_327LG bllOrdenCompra = new BLLOrdenCompra_327LG();
        public FormReporteOrdenCompra_327LG()
        {
            InitializeComponent();
            dgvOrdenes.MultiSelect = false;
            dgvOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvOrdenes.RowHeadersVisible = false;
        }

        private void FormReporteOrdenCompra_Load(object sender, EventArgs e)
        {
            List<BEOrdenCompra_327LG> listaOrdenesCompra = bllOrdenCompra.ObtenerOrdenesCompra_327LG();
            var linq = from x in listaOrdenesCompra
                       select new
                       {
                           NroOrden = x.nroOrden_327LG,
                           Fecha = x.Fecha_327LG,
                           Distribuidor = x.Distribuidor_327LG.Empresa_327LG,
                           Total = x.Total_327LG,
                           Estado = x.Estado_327LG.ToString()
                       };
            dgvOrdenes.DataSource = linq.ToList();
        }
        private void dgvOrdenes_CellContentDoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                BEOrdenCompra_327LG ordenCompra = bllOrdenCompra.ObtenerOrdenesCompra_327LG().Find(x => x.nroOrden_327LG == dgvOrdenes.SelectedRows[0].Cells[0].Value.ToString());
                ordenCompra.LibrosSolcitados_327LG = bllOrdenCompra.ObtenerDetalles_327LG(ordenCompra.nroOrden_327LG);
                bllOrdenCompra.GenerarReporte_327LG(ordenCompra);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message);
            }
        }
    }
}
