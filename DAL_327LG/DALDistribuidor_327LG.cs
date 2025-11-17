using BE_327LG;
using Microsoft.Data.SqlClient;

namespace DAL_327LG
{
    public class DALDistribuidor_327LG : DALAbstracta_327LG
    {
 

        public BEDistribuidor_327LG ObtenerDistribuidorPorCUIT(string cuit)
        {
            BEDistribuidor_327LG distribuidor = null;
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from Distribuidor_327LG WHERE CUIT_327LG = @CUIT", con))
                {
                    cmd.Parameters.AddWithValue("@CUIT", cuit);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            distribuidor = new(
                                reader["CUIT_327LG"].ToString(),
                                reader["Empresa_327LG"].ToString(),
                                reader["Telefono_327LG"].ToString(),
                                reader["Direccion_327LG"].ToString(),
                                reader["Correo_327LG"].ToString(),
                                Convert.ToBoolean(reader["Activo_327LG"]));
                        }
                    }
                    con.Close();
                }
            }
            return distribuidor;
        }

        public void EliminarDistribuidor_327LG(BEDistribuidor_327LG distribuidor)
        {
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Distribuidor_327LG SET Activo_327LG = 'false' where CUIT_327LG = @CUIT", con))
                {
                    cmd.Parameters.AddWithValue("@CUIT", distribuidor.CUIT_327LG);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public List<BEDistribuidor_327LG> FiltrarDistribuidores_327LG(string? CUIT, string? empresa)
        {
            List<BEDistribuidor_327LG> listaDistribuidores = new List<BEDistribuidor_327LG>();
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from Distribuidor_327LG WHERE (@CUIT IS NULL OR CUIT_327LG = @CUIT) " +
                    "AND (@Empresa IS NULL OR Empresa_327LG LIKE '%' + @Empresa + '%')", con))
                {
                    cmd.Parameters.AddWithValue("@CUIT", (object?)CUIT ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Empresa", (object?)empresa ?? DBNull.Value);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BEDistribuidor_327LG distribuidor = new(
                                reader["CUIT_327LG"].ToString(),
                                reader["Empresa_327LG"].ToString(),
                                reader["Telefono_327LG"].ToString(),
                                reader["Direccion_327LG"].ToString(),
                                reader["Correo_327LG"].ToString(),
                                Convert.ToBoolean(reader["Activo_327LG"]));
                            listaDistribuidores.Add(distribuidor);
                        }
                    }
                    con.Close();
                }
            }
            return listaDistribuidores;
        }

        public void ModificarDistribuidor_327LG(BEDistribuidor_327LG distribuidor)
        {
            using(SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                using(SqlCommand cmd = new SqlCommand("UPDATE Distribuidor_327LG SET Empresa_327LG = @Empresa, Telefono_327LG = @Telefono, " +
                    "Direccion_327LG = @Direccion, Correo_327LG = @Correo WHERE CUIT_327LG = @CUIT", con))
                {
                    cmd.Parameters.AddWithValue("@CUIT", distribuidor.CUIT_327LG);
                    cmd.Parameters.AddWithValue("@Empresa", distribuidor.Empresa_327LG);
                    cmd.Parameters.AddWithValue("@Telefono", distribuidor.Telefono_327LG);
                    cmd.Parameters.AddWithValue("@Direccion", distribuidor.Direccion_327LG);
                    cmd.Parameters.AddWithValue("@Correo", distribuidor.Correo_327LG);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
        }

        public List<BEDistribuidor_327LG> ObtenerDistribuidores_327LG()
        {
            List<BEDistribuidor_327LG> listaDistribuidores = new List<BEDistribuidor_327LG>();
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from Distribuidor_327LG", con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BEDistribuidor_327LG distribuidor = new(
                                reader["CUIT_327LG"].ToString(),
                                reader["Empresa_327LG"].ToString(),
                                reader["Telefono_327LG"].ToString(),
                                reader["Direccion_327LG"].ToString(),
                                reader["Correo_327LG"].ToString(),
                                Convert.ToBoolean(reader["Activo_327LG"]));
                            listaDistribuidores.Add(distribuidor);
                        }
                    }
                    con.Close();
                }
            }
            return listaDistribuidores;
        }

        public void RegistrarDistribuidor_327LG(BEDistribuidor_327LG distribuidor)
        {
            using(SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                string query = @"INSERT INTO Distribuidor_327LG (CUIT_327LG, Empresa_327LG, Telefono_327LG, Direccion_327LG, Correo_327LG, Activo_327LG) 
                                 VALUES (@CUIT, @Empresa, @Telefono, @Direccion, @Correo, @Activo)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CUIT", distribuidor.CUIT_327LG);
                    cmd.Parameters.AddWithValue("@Empresa", distribuidor.Empresa_327LG);
                    cmd.Parameters.AddWithValue("@Telefono", distribuidor.Telefono_327LG);
                    cmd.Parameters.AddWithValue("@Direccion", distribuidor.Direccion_327LG);
                    cmd.Parameters.AddWithValue("@Correo", distribuidor.Correo_327LG);
                    cmd.Parameters.AddWithValue("@Activo", distribuidor.Activo_327LG);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
