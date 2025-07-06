using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_327LG
{
    public class BEPrestamo_327LG
    {
        public int nroPrestamo_327LG { get; set; }
        public BEEjemplar_327LG Ejemplar_327LG { get; set; }
        public BECliente_327LG Cliente_327LG { get; set; }
        public DateTime FechaADevolver_327LG { get; set; }
        public DateTime? FechaDevolucion_327LG { get; set; }
        public bool Activo_327LG { get; set; }
        public BEPrestamo_327LG( BEEjemplar_327LG ejemplar_327LG, BECliente_327LG cliente_327LG, DateTime fechaADevolver_327LG, DateTime? fechaDevolucion_327LG, bool activo_327LG)
        {
            Ejemplar_327LG = ejemplar_327LG;
            Cliente_327LG = cliente_327LG;
            FechaADevolver_327LG = fechaADevolver_327LG;
            FechaDevolucion_327LG = fechaDevolucion_327LG;
            Activo_327LG = activo_327LG;
        }

        public BEPrestamo_327LG(int nroPrestamo_327LG, BEEjemplar_327LG ejemplar_327LG, BECliente_327LG cliente_327LG, DateTime fechaADevolver_327LG, DateTime fechaDevolucion_327LG, bool activo_327LG)
        {
            this.nroPrestamo_327LG = nroPrestamo_327LG;
            Ejemplar_327LG = ejemplar_327LG;
            Cliente_327LG = cliente_327LG;
            FechaADevolver_327LG = fechaADevolver_327LG;
            FechaDevolucion_327LG = fechaDevolucion_327LG;
            Activo_327LG = activo_327LG;
        }
    }
}
