using BE_327LG;
using DAL_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLReporteInteligente_327LG
    {
        private readonly DALReporteInteligente dalReporteInteligente;

        public BLLReporteInteligente_327LG()
        {
            dalReporteInteligente = new DALReporteInteligente();
        }

        public List<(string Titulo, int Cantidad)> ObtenerRankingLibros_327LG()
        {
            return dalReporteInteligente.ObtenerRankingLibros_327LG();
        }
        public List<(string NombreCompleto, int TotalSanciones)> ObtenerRankingClientesSancionados_327LG()
        {
            return dalReporteInteligente.ObtenerRankingClientesSancionados_327LG();
        }
        
        public List<(string Periodo, int TotalPrestamos)> ObtenerSeriePrestamosMensual_327LG()
        {
            var datosDB = dalReporteInteligente.ObtenerSeriePrestamosMensual_327LG();
            return CompletarSerieMensual(datosDB);
        }


        private List<(string Periodo, int TotalPrestamos)> CompletarSerieMensual(List<(string Periodo, int TotalPrestamos)> datosExistentes)
        {
            var serieCompleta = new List<(string Periodo, int TotalPrestamos)>();

            DateTime hoy = DateTime.Now;
            int añoActual = hoy.Year;

            
            DateTime fechaInicio = new DateTime(añoActual, 1, 1);
            DateTime fechaFin = new DateTime(añoActual, hoy.Month, 1);
            var dictDatos = datosExistentes.ToDictionary(
                k => k.Periodo,
                v => v.TotalPrestamos
            );

            DateTime fechaIterador = fechaInicio;
            while (fechaIterador <= fechaFin)
            {
                string periodoKey = $"{fechaIterador.Month:00}/{fechaIterador.Year}";
                int cantidad = 0;
                if (dictDatos.ContainsKey(periodoKey))
                {
                    cantidad = dictDatos[periodoKey];
                }
                serieCompleta.Add((periodoKey, cantidad));
                fechaIterador = fechaIterador.AddMonths(1);
            }

            return serieCompleta;
        }
    }
}
