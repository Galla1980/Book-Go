using BE_327LG;
using DAL_327LG;
using Services_327LG.Singleton_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLOrdenCompra_327LG
    {
        private readonly DALOrdenCompra_327LG dalOrdenCompra_327LG = new DALOrdenCompra_327LG();
        private readonly BLLEvento_327LG bllEvento_327LG = new BLLEvento_327LG();
        public void GenerarOrdenCompra_327LG(BEOrdenCompra_327LG ordenCompra)
        {
            string nroOrden = string.Empty;
            int numero = 1;
            BEOrdenCompra_327LG ultimaSolicitud = ObtenerUltimaOrden_327LG();
            if (ultimaSolicitud != null)
            {
                var partes = ultimaSolicitud.nroOrden_327LG.ToString().Split('-');
                DateTime Fecha = DateTime.ParseExact(partes[0], "yyyyMMdd", null);
                if (Fecha.Date == DateTime.Now.Date) numero = int.Parse(partes[1]) + 1;
            }
            nroOrden = DateTime.Now.ToString("yyyyMMdd") + "-" + numero.ToString("D3");
            ordenCompra.nroOrden_327LG = nroOrden;
            dalOrdenCompra_327LG.GenerarOrdenCompra_327LG(ordenCompra);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de stock", "Generación de orden de compra", 3);
        }

        private BEOrdenCompra_327LG ObtenerUltimaOrden_327LG()
        {
            return dalOrdenCompra_327LG.ObtenerUltimaOrden_327LG();
        }
    }
}
