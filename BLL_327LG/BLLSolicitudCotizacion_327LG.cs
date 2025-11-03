using BE_327LG;
using DAL_327LG;
using Microsoft.Extensions.Logging;
using Services_327LG;
using Services_327LG.Singleton_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLSolicitudCotizacion_327LG
    {
        private readonly DALSolicitudCotizacion_327LG dalSolicitudCotizacion_327LG;
        private readonly BLLEvento_327LG bllEvento_327LG = new BLLEvento_327LG();

        public BLLSolicitudCotizacion_327LG()
        {
            dalSolicitudCotizacion_327LG = new DALSolicitudCotizacion_327LG();
            bllEvento_327LG = new BLLEvento_327LG();
        }

        public void GenerarSolicitudCotizacion_327LG(List<BELibro_327LG> librosSolicitados, BEDistribuidor_327LG? distribuidor_327LG)
        {
            string nroSolicitud = string.Empty;
            int numero = 1;
            BESolicitudCotizacion_327LG ultimaSolicitud = ObtenerUltimaSolicitud_327LG();
            if (ultimaSolicitud != null)
            {
                var partes = ultimaSolicitud.NroSolicitud_327LG.ToString().Split('-');
                DateTime Fecha = DateTime.ParseExact(partes[0], "yyyyMMdd", null);
                if (Fecha.Date == DateTime.Now.Date) numero = int.Parse(partes[1]) + 1;
            }
            nroSolicitud = DateTime.Now.ToString("yyyyMMdd") + "-" + numero.ToString("D3");
            BESolicitudCotizacion_327LG nuevaSolicitud = new BESolicitudCotizacion_327LG(nroSolicitud, librosSolicitados, distribuidor_327LG, DateTime.Now);
            dalSolicitudCotizacion_327LG.GuardarSolicitudCotizacion_327LG(nuevaSolicitud);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de stock", "Generación de solicitud de  cotización", 4);
        }

        private BESolicitudCotizacion_327LG ObtenerUltimaSolicitud_327LG()
        {
            return dalSolicitudCotizacion_327LG.ObtenerUltimaSolicitud_327LG();
        }

        public List<BELibro_327LG> SolicitudRepetida_327LG(BEDistribuidor_327LG distribuidor_327LG, List<BELibro_327LG> librosSolicitados)
        {
            List<BESolicitudCotizacion_327LG> listaSolicitudes = dalSolicitudCotizacion_327LG.ObtenerTodasSolicitudesActivas_327LG();
            List<BELibro_327LG> librosRepetidos = new List<BELibro_327LG>();
            foreach (var solicitud in listaSolicitudes)
            {
                if(solicitud.Distribuidor_327LG.CUIT_327LG == distribuidor_327LG.CUIT_327LG && solicitud.Fecha_327LG.Date == DateTime.Today)
                {
                    foreach (var libro in librosSolicitados)
                    {
                        if (!(librosRepetidos.Any(x=> x.ISBN_327LG == libro.ISBN_327LG)) && solicitud.librosSolicitados.Any(l => l.ISBN_327LG == libro.ISBN_327LG))
                        {
                            librosRepetidos.Add(libro);
                        }
                    }
                }
            }
            return librosRepetidos;
        }

        public List<BESolicitudCotizacion_327LG> ObtenerSolicitudesPendientes_327LG()
        {
            return dalSolicitudCotizacion_327LG.ObtenerTodasSolicitudesActivas_327LG();
        }

        public List<BEOrdenCompraDetalle_327LG> ObtenerDetallesSolicitud_327LG(string? nroSolicitud)
        {
            List<BEOrdenCompraDetalle_327LG> detalles = new List<BEOrdenCompraDetalle_327LG>();
            List<BELibro_327LG> libros = dalSolicitudCotizacion_327LG.ObtenerLibrosPorSolicitud(nroSolicitud);
            foreach (var libro in libros)
            {
                BEOrdenCompraDetalle_327LG detalle = new BEOrdenCompraDetalle_327LG
                {
                    libro_327LG = libro,
                    Cantidad_327LG = 0,
                    PrecioUnitario_327LG = 0
                };
                detalles.Add(detalle);
            }
            return detalles;
        }

        public void ActualizarEstadoSolicitud_327LG(string nroSolicitud)
        {
            dalSolicitudCotizacion_327LG.ActualizarEstadoSolicitud_327LG(nroSolicitud);
        }
    }
}