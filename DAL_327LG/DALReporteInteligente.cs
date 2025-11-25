using BE_327LG;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALReporteInteligente: DALAbstracta_327LG
    {
        public List<(string Titulo, int Cantidad)> ObtenerRankingLibros_327LG()
        {
            var lista = new List<(string, int)>();

            string query = @"
            SELECT L.Titulo_327LG, COUNT(*) AS Cantidad
            FROM Prestamo_327LG P
            INNER JOIN Ejemplar_327LG E ON P.nroEjemplar_327LG = E.nroEjemplar_327LG
            INNER JOIN Libro_327LG L ON L.ISBN_327LG = E.ISBN_327LG
            GROUP BY L.Titulo_327LG
            ORDER BY Cantidad DESC";

            using (SqlConnection conn = new SqlConnection(connectionString_327LG))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add((
                            dr.GetString(0),
                            dr.GetInt32(1)
                        ));
                    }
                }
            }

            return lista;
        }
        public List<(string NombreCompleto, int TotalSanciones)> ObtenerRankingClientesSancionados_327LG()
        {
            var ranking = new List<(string NombreCompleto, int TotalSanciones)>();
            
            string query = @"
                SELECT TOP 10
                    C.Nombre_327LG + ' ' + C.Apellido_327LG AS NombreCompleto,
                    COUNT(S.nroSancion_327LG) AS TotalSanciones
                FROM Cliente_327LG C
                INNER JOIN Sancion_327LG S ON C.DNI_327LG = S.DNI_327LG
                GROUP BY C.Nombre_327LG, C.Apellido_327LG
                ORDER BY TotalSanciones DESC;";

            using (SqlConnection conn = new SqlConnection(connectionString_327LG))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string nombreCompleto = reader["NombreCompleto"].ToString();
                    int totalSanciones = (int)reader["TotalSanciones"];
                    ranking.Add((nombreCompleto, totalSanciones));
                }
            }
            return ranking;
        }
        public List<(string Periodo, int TotalPrestamos)> ObtenerSeriePrestamosMensual_327LG()
        {
            var serie = new List<(string Periodo, int TotalPrestamos)>();
            
            string query = @"
                SELECT 
                    YEAR(p.FechaDevolucion_327LG) AS Año,
                    MONTH(p.FechaDevolucion_327LG) AS Mes,
                    COUNT(p.nroPrestamo_327LG) AS TotalPrestamos
                FROM Prestamo_327LG p
                WHERE p.FechaDevolucion_327LG IS NOT NULL 
                GROUP BY YEAR(p.FechaDevolucion_327LG), MONTH(p.FechaDevolucion_327LG)
                ORDER BY Año, Mes;";

            using (SqlConnection conn = new SqlConnection(connectionString_327LG))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int año = (int)reader["Año"];
                    int mes = (int)reader["Mes"];
                    int total = (int)reader["TotalPrestamos"];

                    
                    string periodo = $"{mes:00}/{año}";
                    serie.Add((periodo, total));
                }
            }
            return serie;
        }
    }
}



