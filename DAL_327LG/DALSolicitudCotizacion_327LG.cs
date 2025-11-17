using BE_327LG;
using Microsoft.Data.SqlClient;

namespace DAL_327LG
{
    public class DALSolicitudCotizacion_327LG : DALAbstracta_327LG
    {
       
        DALDistribuidor_327LG dalDistribuidor_327LG = new DALDistribuidor_327LG();
  
        public void GuardarSolicitudCotizacion_327LG(BESolicitudCotizacion_327LG nuevaSolicitud)
        {
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"
                    INSERT INTO SolicitudCotizacion_327LG (nroSolicitud_327LG, Fecha_327LG, CUIT_327LG, Activo_327LG)
                    VALUES (@NroSolicitud_327LG, @Fecha_327LG, @cuit, 1);";
                    cmd.Parameters.AddWithValue("@NroSolicitud_327LG", nuevaSolicitud.NroSolicitud_327LG);
                    cmd.Parameters.AddWithValue("@Fecha_327LG", nuevaSolicitud.Fecha_327LG);
                    cmd.Parameters.AddWithValue("@cuit", nuevaSolicitud.Distribuidor_327LG.CUIT_327LG);
                    cmd.ExecuteNonQuery();
                    ;
                }

                foreach (var libro in nuevaSolicitud.librosSolicitados)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = @"
                        INSERT INTO SolicitudLibro_327LG (nroSolicitud_327LG, ISBN_327LG)
                        VALUES (@NroSolicitud_327LG, @ISBN_327LG);";
                        cmd.Parameters.AddWithValue("@NroSolicitud_327LG", nuevaSolicitud.NroSolicitud_327LG);
                        cmd.Parameters.AddWithValue("@ISBN_327LG", libro.ISBN_327LG);
                        cmd.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
        }

        public List<BESolicitudCotizacion_327LG> ObtenerTodasSolicitudesActivas_327LG()
        {
            List<BESolicitudCotizacion_327LG> listaSolicitudes = new List<BESolicitudCotizacion_327LG>();

            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            using (SqlCommand cmd = new SqlCommand(@"
            SELECT NroSolicitud_327LG, Fecha_327LG, CUIT_327LG
            FROM SolicitudCotizacion_327LG
            WHERE Activo_327LG = 1;", con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string nroSolicitud = reader.GetString(reader.GetOrdinal("NroSolicitud_327LG"));
                    string cuit = reader.GetString(reader.GetOrdinal("CUIT_327LG"));
                    DateTime fecha = reader.GetDateTime(reader.GetOrdinal("Fecha_327LG"));

                    BESolicitudCotizacion_327LG solicitud = new BESolicitudCotizacion_327LG(nroSolicitud, fecha)
                    {
                        Distribuidor_327LG = dalDistribuidor_327LG.ObtenerDistribuidorPorCUIT(cuit),
                        librosSolicitados = ObtenerLibrosPorSolicitud(nroSolicitud)
                    };

                    listaSolicitudes.Add(solicitud);
                }
            }

            return listaSolicitudes;
        }

        public List<BELibro_327LG> ObtenerLibrosPorSolicitud(string nroSolicitud)
        {
            List<BELibro_327LG> listaLibros = new List<BELibro_327LG>();
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                string query = @"
                    SELECT 
                        L.ISBN_327LG,
                        L.Titulo_327LG,
                        L.Autor_327LG,
                        L.Edicion_327LG,
                        L.Editorial_327LG
                    FROM SolicitudLibro_327LG SL
                    INNER JOIN Libro_327LG L ON SL.ISBN_327LG = L.ISBN_327LG
                    WHERE SL.NroSolicitud_327LG = @nroSolicitud;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nroSolicitud", nroSolicitud);
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            BELibro_327LG libro = new BELibro_327LG
                            {
                                ISBN_327LG = dr["ISBN_327LG"].ToString(),
                                titulo_327LG = dr["Titulo_327LG"].ToString(),
                                autor_327LG = dr["Autor_327LG"].ToString(),
                                edicion_327LG = Convert.ToInt32(dr["Edicion_327LG"]),
                                editorial_327LG = dr["Editorial_327LG"].ToString()
                            };

                            listaLibros.Add(libro);
                        }
                    }
                }
            }

            return listaLibros;
        }


        public BESolicitudCotizacion_327LG ObtenerUltimaSolicitud_327LG()
        {
            BESolicitudCotizacion_327LG ultimaSolicitud = null;
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"
                    SELECT TOP 1 
                        NroSolicitud_327LG, Fecha_327LG
                    FROM SolicitudCotizacion_327LG
                    ORDER BY NroSolicitud_327LG DESC;";
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ultimaSolicitud = new BESolicitudCotizacion_327LG(reader.GetString(reader.GetOrdinal("nroSolicitud_327LG")), reader.GetDateTime(reader.GetOrdinal("Fecha_327LG")));
                        }
                    }
                    con.Close();
                }
            }
            return ultimaSolicitud;
        }

        public void ActualizarEstadoSolicitud_327LG(string nroSolicitud)
        {
            using(SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"
                    UPDATE SolicitudCotizacion_327LG
                    SET Activo_327LG = 0
                    WHERE NroSolicitud_327LG = @nroSolicitud;";
                    cmd.Parameters.AddWithValue("@nroSolicitud", nroSolicitud);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
