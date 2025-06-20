using BE_327LG;
using Microsoft.Data.SqlClient;

namespace DAL_327LG
{
    public class DALLibro_327LG
    {
        private string connectionString_327LG;
        public DALLibro_327LG()
        {
            connectionString_327LG = "Data Source=.;Initial Catalog=SistemaBiblioteca;Integrated Security=True;Trust Server Certificate=True";
        }
        public List<BELibro_327LG> BuscarLibros_327LG(string? titulo_327LG, string? autor_327LG, string? editorial_327LG, int? edicion_327LG)
        {
            List<BELibro_327LG> listaLibros = new List<BELibro_327LG>();

            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                string query = @"SELECT * FROM Libro_327LG 
                         WHERE (@Titulo IS NULL OR Titulo_327LG LIKE '%' + @Titulo + '%')
                           AND (@Autor IS NULL OR Autor_327LG LIKE '%' + @Autor + '%')
                           AND (@Editorial IS NULL OR Editorial_327LG LIKE '%' + @Editorial + '%')
                           AND (@Edicion IS NULL OR Edicion_327LG = @Edicion)";
                SqlCommand cmd_327LG = new SqlCommand(query, con_327LG);
                cmd_327LG.Parameters.AddWithValue("@Titulo", string.IsNullOrEmpty(titulo_327LG) ? DBNull.Value : titulo_327LG);
                cmd_327LG.Parameters.AddWithValue("@Autor", string.IsNullOrEmpty(autor_327LG) ? DBNull.Value : autor_327LG);
                cmd_327LG.Parameters.AddWithValue("@Editorial", string.IsNullOrEmpty(editorial_327LG) ? DBNull.Value : editorial_327LG);
                cmd_327LG.Parameters.AddWithValue("@Edicion", edicion_327LG.HasValue ? edicion_327LG.Value : DBNull.Value);

                con_327LG.Open();
                using (SqlDataReader dr_327LG = cmd_327LG.ExecuteReader())
                {
                    while (dr_327LG.Read())
                    {
                        BELibro_327LG libro = new BELibro_327LG(
                            dr_327LG["ISBN_327LG"].ToString(),
                            dr_327LG["Titulo_327LG"].ToString(),
                            dr_327LG["Autor_327LG"].ToString(),
                            dr_327LG["Editorial_327LG"].ToString(),
                            Convert.ToInt32(dr_327LG["Edicion_327LG"])
                        );
                        listaLibros.Add(libro);
                    }
                }

            }

            return listaLibros;
        }

        public List<BELibro_327LG> ListarLibros_327LG()
        {
            List<BELibro_327LG> listaLibros = new List<BELibro_327LG>();
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                SqlCommand cmd_327LG = new SqlCommand("SELECT * FROM Libro_327LG", con_327LG);
                con_327LG.Open();
                using (SqlDataReader dr_327LG = cmd_327LG.ExecuteReader())
                {
                    if (dr_327LG != null)
                    {
                        while (dr_327LG.Read())
                        {
                            BELibro_327LG libro = new BELibro_327LG(dr_327LG["ISBN_327LG"].ToString(), dr_327LG["Titulo_327LG"].ToString(), dr_327LG["Autor_327LG"].ToString(),
                                                  dr_327LG["Editorial_327LG"].ToString(), Convert.ToInt32(dr_327LG["Edicion_327LG"]));
                            listaLibros.Add(libro);
                        }
                    }

                }
            }
            return listaLibros;
        }
    }
}
