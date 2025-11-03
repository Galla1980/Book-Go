using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_327LG
{
    public class BEOrdenCompraDetalle_327LG
    {
        public BELibro_327LG libro_327LG { get; set; }
        public int Cantidad_327LG { get; set; }
        public decimal PrecioUnitario_327LG { get; set; }

        public BEOrdenCompraDetalle_327LG()
        {

        }
        public BEOrdenCompraDetalle_327LG(BELibro_327LG libro_327LG, int cantidad_327LG, decimal precioUnitario_327LG)
        {
            this.libro_327LG = libro_327LG;
            Cantidad_327LG = cantidad_327LG;
            PrecioUnitario_327LG = precioUnitario_327LG;
        }
    }
}
