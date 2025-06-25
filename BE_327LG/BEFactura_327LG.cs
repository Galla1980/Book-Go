using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_327LG
{
    public class BEFactura_327LG
    {
        public int nroFactura_327LG { get; set; }
        public DateTime Fecha_327LG  { get; set; }
        public BECliente_327LG Cliente_327LG { get; set; }
        public decimal Monto_327LG { get; set; }
        public BELibro_327LG Libro_327LG { get; set; }
        public BEFactura_327LG(DateTime fecha_327LG, BECliente_327LG cliente_327LG, decimal monto_327LG, BELibro_327LG libro_327LG)
        {
            Fecha_327LG = fecha_327LG;
            Cliente_327LG = cliente_327LG;
            Monto_327LG = monto_327LG;
            Libro_327LG = libro_327LG;
        }

        public BEFactura_327LG(int nroFactura_327LG, DateTime fecha_327LG, BECliente_327LG cliente_327LG, decimal monto_327LG, BELibro_327LG libro_327LG)
        {
            this.nroFactura_327LG = nroFactura_327LG;
            Fecha_327LG = fecha_327LG;
            Cliente_327LG = cliente_327LG;
            Monto_327LG = monto_327LG;
            Libro_327LG = libro_327LG;
        }
    }
}
