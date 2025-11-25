using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_327LG
{
    public class BESolicitudCotizacion_327LG
    {
        public string NroSolicitud_327LG { get; set; }
        public List<BELibro_327LG> librosSolicitados = new List<BELibro_327LG>();
        public BEDistribuidor_327LG Distribuidor_327LG { get; set; }
        public DateTime Fecha_327LG { get; set; }

        public BESolicitudCotizacion_327LG(string nroSolicitud, DateTime fecha)
        {
            NroSolicitud_327LG = nroSolicitud;
            Fecha_327LG = fecha;
        }

        public BESolicitudCotizacion_327LG(string nroSolicitud, List<BELibro_327LG> libros, BEDistribuidor_327LG distribuidor, DateTime fecha) 
        {
            NroSolicitud_327LG = nroSolicitud;
            librosSolicitados = libros;
            Distribuidor_327LG = distribuidor;
            Fecha_327LG = fecha;
        }

        
    }
}
