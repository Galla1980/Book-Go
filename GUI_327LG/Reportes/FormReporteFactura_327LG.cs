using BE_327LG;
using BLL_327LG;
using Org.BouncyCastle.Pqc.Crypto.Lms;
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

namespace GUI_327LG.Reportes
{
    public partial class FormReporteFactura_327LG : Form, IObserverIdioma_327LG
    {
        LanguageManager_327LG LM_327LG = LanguageManager_327LG.Instance_327LG;
        BLLFactura_327LG bllFactura_327LG;
        public FormReporteFactura_327LG()
        {
            InitializeComponent();
            bllFactura_327LG = new BLLFactura_327LG();
            LM_327LG.AgregarObservador_327LG(this);

            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.MultiSelect = false;
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void Actualizar_327LG()
        {
        }

        private void FormReporteFactura_327LG_Load(object sender, EventArgs e)
        {
            
            var linq = from factura in bllFactura_327LG.ObtenerFacturas_327LG()
                       select new
                       {
                           NumeroFactura = factura.nroFactura_327LG,
                           Fecha = factura.Fecha_327LG,
                           Monto = factura.Monto_327LG,
                           DNI_Cliente = factura.Cliente_327LG.DNI_327LG,
                           ISBN_Libro = factura.Libro_327LG.ISBN_327LG
                       };

            dgvFacturas.DataSource = linq.ToList();
        }

        private void dgvFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BEFactura_327LG bEFactura_327LG = bllFactura_327LG.ObtenerFacturas_327LG().Find(x=> x.nroFactura_327LG == Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells[0].Value));
                bllFactura_327LG.GenerarReporte(bEFactura_327LG);
            }
            catch(Exception ex)
            {
                MessageBoxPersonalizado.Show(ex.Message, "Error", LM_327LG.ObtenerString("messagebox.button.aceptar"), MessageBoxIcon.Error);
            }
        }
    }
}
