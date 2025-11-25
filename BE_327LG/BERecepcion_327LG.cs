using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_327LG
{
    public class BERecepcion_327LG
    {
        public int nroRecepcion_327LG { get; set; }
        public DateTime Fecha_327LG { get; set; }
        public BEOrdenCompra_327LG OrdenDeCompra_327LG { get; set; }
        public List<BERepcecionDetalle_327LG> LibrosRecibidos_327LG = new List<BERepcecionDetalle_327LG>();

        public BERecepcion_327LG()
        {
        }
        public BERecepcion_327LG(DateTime fecha_327LG, BEOrdenCompra_327LG ordenDeCompra_327LG)
        {
            this.Fecha_327LG = fecha_327LG;
            this.OrdenDeCompra_327LG = ordenDeCompra_327LG;
        }
    }
}
