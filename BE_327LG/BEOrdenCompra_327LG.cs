using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_327LG
{
    public class BEOrdenCompra_327LG
    {
        public string nroOrden_327LG { get; set; }
        public DateTime Fecha_327LG { get; set; }
        public BEDistribuidor_327LG Distribuidor_327LG { get; set; }
        public decimal Total_327LG { get; set; }
        public List<BEOrdenCompraDetalle_327LG> LibrosSolcitados_327LG = new List<BEOrdenCompraDetalle_327LG>();
        public string Banco_327LG { get; set; }
        public string CBU_327LG { get; set; }
        public string NombreTitular_327LG { get; set; }
        public string NroTarjeta_327LG { get; set; }
        public EstadoOrden_327LG Estado_327LG { get; set; }
        public BEOrdenCompra_327LG()
        {
        }
        public BEOrdenCompra_327LG(DateTime fecha_327LG, BEDistribuidor_327LG distribuidor_327LG, decimal total_327LG, List<BEOrdenCompraDetalle_327LG> librosSolcitados_327LGs, string banco_327LG, string cbu_327LG, string nombreTitular_327LG, string nroTarjeta_327LG, EstadoOrden_327LG estado)
        {
            Fecha_327LG = fecha_327LG;
            Distribuidor_327LG = distribuidor_327LG;
            Total_327LG = total_327LG;
            LibrosSolcitados_327LG = librosSolcitados_327LGs;
            Banco_327LG = banco_327LG;
            CBU_327LG = cbu_327LG;
            NombreTitular_327LG = nombreTitular_327LG;
            NroTarjeta_327LG = nroTarjeta_327LG;
            Estado_327LG = estado;
        }
    }
}