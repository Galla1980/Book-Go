using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_327LG
{
    public class BESancion_327LG
    {
        public int nroSancion { get; set; }
        public BECliente_327LG Cliente { get; set; }
        public BEPrestamo_327LG Prestamo { get; set; }
        public string Descripcion { get; set; }
        public string Razon { get; set; }
        public BESancion_327LG(BECliente_327LG cliente, BEPrestamo_327LG prestamo, string descripcion, string razon)
        {
            Cliente = cliente;
            Prestamo = prestamo;
            Descripcion = descripcion;
            Razon = razon;
        }
        public BESancion_327LG(int nroSancion, BECliente_327LG cliente, BEPrestamo_327LG prestamo, string descripcion, string razon)
        {
            this.nroSancion = nroSancion;
            Cliente = cliente;
            Prestamo = prestamo;
            Descripcion = descripcion;
            Razon = razon;
        }
    }
}
