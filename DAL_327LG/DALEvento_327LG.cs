using Microsoft.Data.SqlClient;
using Services_327LG;
using Services_327LG.Composite_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALEvento_327LG : DALAbstracta_327LG
    {
        
        public List<Evento_327LG> ObtenerEventos_327LG(string? login, DateTime? fechaInicio, DateTime? fechaFin, string? modulo, string? evento, int? criticidad)
        {
            List<Evento_327LG> eventos = new List<Evento_327LG>();

            using(SqlConnection con =  new SqlConnection(connectionString_327LG))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"
                    SELECT 
                        e.idEvento_327LG, e.Fecha_327LG, e.Hora_327LG, e.Modulo_327LG, e.Evento_327LG, e.Criticidad_327LG, 
                        u.Username_327LG
                    FROM Evento_327LG e
                    INNER JOIN Usuario_327LG u ON e.DNI_327LG = u.DNI_327LG
                    WHERE (@Username IS NULL OR u.Username_327LG = @Username)
                      AND (@FechaInicio IS NULL OR e.Fecha_327LG >= @FechaInicio)
                      AND (@FechaFin IS NULL OR e.Fecha_327LG <= @FechaFin)
                      AND (@Modulo IS NULL OR e.Modulo_327LG = @Modulo)
                      AND (@Evento IS NULL OR e.Evento_327LG LIKE @Evento + '%')
                      AND (@Criticidad IS NULL OR e.Criticidad_327LG = @Criticidad);";

                    cmd.Parameters.AddWithValue("@Username", (object?)login ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaInicio", (object?)fechaInicio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaFin", (object?)fechaFin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Modulo", (object?)modulo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Evento", (object?)evento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Criticidad", (object?)criticidad ?? DBNull.Value);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Evento_327LG evento_327LG = new Evento_327LG(reader.GetString(reader.GetOrdinal("idEvento_327LG")), reader.GetString(reader.GetOrdinal("Username_327LG")), reader.GetDateTime(reader.GetOrdinal("Fecha_327LG")),
                                reader.GetTimeSpan(reader.GetOrdinal("Hora_327LG")), reader.GetString(reader.GetOrdinal("Modulo_327LG")), reader.GetString(reader.GetOrdinal("Evento_327LG")), reader.GetInt32(reader.GetOrdinal("Criticidad_327LG")));
                            
                            eventos.Add(evento_327LG);
                        }
                    }
                    con.Close();
                }

            }

            return eventos;
        }

        public Evento_327LG ObtenerUltimoEvento_327LG()
        {
            Evento_327LG evento = null;
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                using(SqlCommand cmd = new SqlCommand()) 
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"SELECT TOP 1 * 
                                        FROM Evento_327LG 
                                        ORDER BY idEvento_327LG DESC;
                                        ";
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            evento = new Evento_327LG(reader.GetString(reader.GetOrdinal("idEvento_327LG")), reader.GetString(reader.GetOrdinal("DNI_327LG")), reader.GetDateTime(reader.GetOrdinal("Fecha_327LG")),
                                reader.GetTimeSpan(reader.GetOrdinal("Hora_327LG")), reader.GetString(reader.GetOrdinal("Modulo_327LG")), reader.GetString(reader.GetOrdinal("Evento_327LG")), reader.GetInt32(reader.GetOrdinal("Criticidad_327LG")));
                            
                        }
                    }
                    con.Close();
                }
            }
            return evento;
        }

        public void RegistrarEvento_327LG(Evento_327LG evento)
        {
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"
                    INSERT INTO Evento_327LG (idEvento_327LG, DNI_327LG, Fecha_327LG, Hora_327LG, Modulo_327LG, Evento_327LG, Criticidad_327LG) 
                    VALUES (@IdEvento, @DNI, @Fecha, @Hora, @Modulo, @Evento, @Criticidad);";
                    cmd.Parameters.AddWithValue("@IdEvento", evento.IdEvento_327LG);
                    cmd.Parameters.AddWithValue("@DNI", evento.DNI_327LG);
                    cmd.Parameters.AddWithValue("@Fecha", evento.Fecha_327LG);
                    cmd.Parameters.AddWithValue("@Hora", evento.Hora_327LG);
                    cmd.Parameters.AddWithValue("@Modulo", evento.Modulo_327LG);
                    cmd.Parameters.AddWithValue("@Evento", evento.evento_327LG);
                    cmd.Parameters.AddWithValue("@Criticidad", evento.Criticidad_327LG);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
