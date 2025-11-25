using BE_327LG;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALLibro_C_327LG : DALAbstracta_327LG
    {
        public void ActivarCambio_327LG(BELibro_C_327LG cambio)
        {
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("DISABLE TRIGGER trg_Libro_Update ON Libro_327LG;", con, transaction))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("UPDATE Libro_C_327LG SET Activo_327LG = 0 " +
                                                       "WHERE ISBN_327LG = @ISBN", con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ISBN", cambio.ISBN_327LG);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("UPDATE Libro_C_327LG SET Activo_327lG = 1 WHERE IdCambio_327LG = @ID", con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ID", cambio.IDCambio_327LG);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("UPDATE Libro_327LG SET " +
                                                       "Titulo_327LG = @Titulo, " +
                                                       "Autor_327LG = @Autor, " +
                                                       "Editorial_327LG = @Editorial, " +
                                                       "Edicion_327LG = @Edicion, " +
                                                       "Eliminado_327LG = @Eliminado " +
                                                       "WHERE ISBN_327LG = @ISBN", con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Titulo", cambio.Titulo_327LG);
                        cmd.Parameters.AddWithValue("@Autor", cambio.Autor_327LG);
                        cmd.Parameters.AddWithValue("@Editorial", cambio.Editorial_327LG);
                        cmd.Parameters.AddWithValue("@Edicion", cambio.Edicion_327LG);
                        cmd.Parameters.AddWithValue("@Eliminado", cambio.Eliminado_327LG);
                        cmd.Parameters.AddWithValue("@ISBN", cambio.ISBN_327LG);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmdEnable = new SqlCommand("ENABLE TRIGGER trg_Libro_Update ON Libro_327LG;", con, transaction))
                    {
                        cmdEnable.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    using (SqlCommand cmd = new SqlCommand("ENABLE TRIGGER trg_Libro_Update ON Libro_327LG;", con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    throw;
                }
                

            }
        }

        public List<BELibro_C_327LG> Filtrarcambios_327LG(string? isbn, string? titulo, string? autor, string? editorial, int? edicion, DateTime? fechaInicio, DateTime? fechaFin)
        {
            List<BELibro_C_327LG> cambios = new List<BELibro_C_327LG>();

            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"
                        SELECT 
                            IdCambio_327LG,
                            ISBN_327LG,
                            Fecha_327LG,
                            Hora_327LG,
                            Titulo_327LG,
                            Autor_327LG,
                            Edicion_327LG,
                            Editorial_327LG,
                            Eliminado_327LG,
                            Activo_327LG
                        FROM Libro_C_327LG
                        WHERE (@ISBN IS NULL OR ISBN_327LG = @ISBN)
                          AND (@Titulo IS NULL OR Titulo_327LG LIKE '%' + @Titulo + '%')
                          AND (@Autor IS NULL OR Autor_327LG LIKE '%' + @Autor + '%')
                          AND (@Editorial IS NULL OR Editorial_327LG LIKE '%' + @Editorial + '%')
                          AND (@Edicion IS NULL OR Edicion_327LG = @Edicion)
                          AND (@FechaInicio IS NULL OR Fecha_327LG >= @FechaInicio)
                          AND (@FechaFin IS NULL OR Fecha_327LG <= @FechaFin)";

                    cmd.Parameters.AddWithValue("@ISBN", (object?)isbn ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Titulo", (object?)titulo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Autor", (object?)autor ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Editorial", (object?)editorial ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Edicion", (object?)edicion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaInicio", (object?)fechaInicio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaFin", (object?)fechaFin ?? DBNull.Value);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BELibro_C_327LG cambio = new BELibro_C_327LG
                            {
                                IDCambio_327LG = reader.GetInt32(reader.GetOrdinal("IdCambio_327LG")),
                                ISBN_327LG = reader.GetString(reader.GetOrdinal("ISBN_327LG")),
                                Fecha_327LG = reader.GetDateTime(reader.GetOrdinal("Fecha_327LG")),
                                Hora_327LG = reader.GetTimeSpan(reader.GetOrdinal("Hora_327LG")),
                                Titulo_327LG = reader.GetString(reader.GetOrdinal("Titulo_327LG")),
                                Autor_327LG = reader.GetString(reader.GetOrdinal("Autor_327LG")),
                                Edicion_327LG = reader.GetInt32(reader.GetOrdinal("Edicion_327LG")),
                                Editorial_327LG = reader.GetString(reader.GetOrdinal("Editorial_327LG")),
                                Eliminado_327LG = reader.GetBoolean(reader.GetOrdinal("Eliminado_327LG")),
                                Activo_327LG = reader.GetBoolean(reader.GetOrdinal("Activo_327LG"))
                            };

                            cambios.Add(cambio);
                        }
                    }
                }
            }

            return cambios;
        }


        public List<BELibro_C_327LG> ObtenerTodosCambios_327LG()
        {
            List<BELibro_C_327LG> listaCambios = new List<BELibro_C_327LG>();
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                using(SqlCommand cmd = new SqlCommand("SELECT * FROM Libro_C_327LG", con))
                {
                    con.Open();
                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            BELibro_C_327LG cambio = new BELibro_C_327LG
                            {
                                IDCambio_327LG = Convert.ToInt32(dr["IDCambio_327LG"]),
                                ISBN_327LG = dr["ISBN_327LG"].ToString(),
                                Fecha_327LG = Convert.ToDateTime(dr["Fecha_327LG"]),
                                Hora_327LG = (TimeSpan)dr["Hora_327LG"],
                                Titulo_327LG = dr["Titulo_327LG"].ToString(),
                                Autor_327LG = dr["Autor_327LG"].ToString(),
                                Editorial_327LG = dr["Editorial_327LG"].ToString(),
                                Edicion_327LG = Convert.ToInt32(dr["Edicion_327LG"]),
                                Eliminado_327LG = Convert.ToBoolean(dr["Eliminado_327LG"]),
                                Activo_327LG = Convert.ToBoolean(dr["Activo_327LG"])
                            };
                            listaCambios.Add(cambio);
                        }
                    }
                }
            }
            return listaCambios;
        }
    }
}
