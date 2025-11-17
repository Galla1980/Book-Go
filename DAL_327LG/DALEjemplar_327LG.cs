using BE_327LG;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALEjemplar_327LG: DALAbstracta_327LG
    {
    

        public void ActualizarEjemplar_327LG(int nroEjemplar_327LG, Estado_327LG estado)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                string query = "UPDATE Ejemplar_327LG SET Estado_327LG = @Estado WHERE nroEjemplar_327LG = @nroEjemplar";
                SqlCommand cmd_327LG = new SqlCommand(query, con_327LG);
                cmd_327LG.Parameters.AddWithValue("@Estado", estado.ToString());
                cmd_327LG.Parameters.AddWithValue("@nroEjemplar", nroEjemplar_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public void RegistrarEjemplar_327LG(BEEjemplar_327LG bEEjemplar_327LG, int cantidad)
        {
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                string query = @"INSERT INTO Ejemplar_327LG (Estado_327LG, ISBN_327LG) 
                                 VALUES (@Estado, @ISBN)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Estado", bEEjemplar_327LG.Estado_327LG.ToString());
                cmd.Parameters.AddWithValue("@ISBN", bEEjemplar_327LG.libro_327LG.ISBN_327LG);
                con.Open();
                for (int i = 0; i < cantidad; i++)
                {
                    cmd.ExecuteNonQuery();
                }

            }
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

        public List<BEEjemplar_327LG> ObtenerTodosEjemplares()
        {
            List<BEEjemplar_327LG> listaEjemplares = new List<BEEjemplar_327LG>();
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                string query = @" SELECT *
                FROM Ejemplar_327LG";
                SqlCommand cmd_327LG = new SqlCommand(query, con_327LG);
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
                            Convert.ToString(dr["ISBN_327LG"])
                        );
                        listaEjemplares.Add(ejemplar);
                    }
                }
            }
            return listaEjemplares;
        }
    }
}
