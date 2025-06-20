using BE_327LG;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALEjemplar_327LG
    {
        private string connectionString_327LG;
        public DALEjemplar_327LG() 
        {
            connectionString_327LG = "Data Source=.;Initial Catalog=SistemaBiblioteca;Integrated Security=True;Trust Server Certificate=True";
        }
        public List<BEEjemplar_327LG> ObtenerEjemplares_327LG(string iSBN)
        {
            List<BEEjemplar_327LG> listaEjemplares = new List<BEEjemplar_327LG>();
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                string query = @" SELECT 
                e.nroEjemplar_327LG, 
                e.Estado_327LG,
                l.ISBN_327LG, 
                l.Titulo_327LG, 
                l.Autor_327LG, 
                l.Edicion_327LG, 
                l.Editorial_327LG
                FROM Ejemplar_327LG e
                INNER JOIN Libro_327LG l ON e.ISBN_327LG = l.ISBN_327LG
                Where l.ISBN_327LG = @isbn";
                SqlCommand cmd_327LG = new SqlCommand(query, con_327LG);
                cmd_327LG.Parameters.AddWithValue("@Isbn", iSBN);
                con_327LG.Open();

                using (SqlDataReader dr = cmd_327LG.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Estado_327LG estado;
                        if (!Enum.TryParse(dr["Estado_327LG"].ToString(), out estado))
                            estado = Estado_327LG.Disponible; 

                        BEEjemplar_327LG ejemplar = new BEEjemplar_327LG(
                            Convert.ToInt32(dr["nroEjemplar_327LG"]),
                            estado,
                            new BELibro_327LG(
                                dr["ISBN_327LG"].ToString(),
                                dr["Titulo_327LG"].ToString(),
                                dr["Autor_327LG"].ToString(),
                                dr["Editorial_327LG"].ToString(),
                                Convert.ToInt32(dr["Edicion_327LG"])
                            )
                        );
                        listaEjemplares.Add(ejemplar);
                    }
                }
            }
            return listaEjemplares;
        }
    }
}
