using BE_327LG;
using Microsoft.Data.SqlClient;

namespace DAL_327LG
{
    public class DALOrdenCompra_327LG
    {
        private string connectionString_327LG;

        public DALOrdenCompra_327LG()
        {
            connectionString_327LG = "Data Source=.;Initial Catalog=SistemaBiblioteca;Integrated Security=True;Trust Server Certificate=True";

        }

        public void ActualizarEstadoOrden(BEOrdenCompra_327LG orden)
        {
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE OrdenCompra_327LG SET Estado_327LG = @Estado WHERE NroOrden_327LG = @NroOrden_327LG", con))
                {
                    cmd.Parameters.AddWithValue("@Estado", orden.Estado_327LG.ToString());
                    cmd.Parameters.AddWithValue("@NroOrden_327LG", orden.nroOrden_327LG);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void GenerarOrdenCompra_327LG(BEOrdenCompra_327LG ordenCompra)
        {
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO OrdenCompra_327LG (NroOrden_327lG, Fecha_327LG, CUIT_327LG, Total_327LG, Banco_327LG, CBU_327LG, NombreTitular_327LG, NumeroTarjeta_327LG, Estado_327LG)" +
                        "VALUES (@NroOrden_327LG, @Fecha_327LG, @CUIT_327LG, @Total_327LG, @Banco_327LG, @CBU_327LG, @NombreTitular_327LG, @NumeroTarjeta_327LG, @Estado)", con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@NroOrden_327LG", ordenCompra.nroOrden_327LG);
                        cmd.Parameters.AddWithValue("@Fecha_327LG", ordenCompra.Fecha_327LG);
                        cmd.Parameters.AddWithValue("@CUIT_327LG", ordenCompra.Distribuidor_327LG.CUIT_327LG);
                        cmd.Parameters.AddWithValue("@Total_327LG", ordenCompra.Total_327LG);
                        cmd.Parameters.AddWithValue("@Banco_327LG", ordenCompra.Banco_327LG);
                        cmd.Parameters.AddWithValue("@CBU_327LG", ordenCompra.CBU_327LG);
                        cmd.Parameters.AddWithValue("@NombreTitular_327LG", ordenCompra.NombreTitular_327LG);
                        cmd.Parameters.AddWithValue("@NumeroTarjeta_327LG", ordenCompra.NroTarjeta_327LG);
                        cmd.Parameters.AddWithValue("@Estado", ordenCompra.Estado_327LG.ToString());
                        cmd.ExecuteNonQuery();
                    }
                    foreach (var detalle in ordenCompra.LibrosSolcitados_327LG)
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO OrdenCompraDetalle_327LG (NroOrden_327LG, ISBN_327LG, Cantidad_327LG, PrecioUnitario_327LG)" +
                            "VALUES (@NroOrden_327LG, @ISBN_327LG, @Cantidad_327LG, @PrecioUnitario_327LG)", con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@NroOrden_327LG", ordenCompra.nroOrden_327LG);
                            cmd.Parameters.AddWithValue("@ISBN_327LG", detalle.libro_327LG.ISBN_327LG);
                            cmd.Parameters.AddWithValue("@Cantidad_327LG", detalle.Cantidad_327LG);
                            cmd.Parameters.AddWithValue("@PrecioUnitario_327LG", detalle.PrecioUnitario_327LG);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();

                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public List<BEOrdenCompraDetalle_327LG> ObtenerDetalles_327LG(string nroOrden)
        {
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                List<BEOrdenCompraDetalle_327LG> listaDetalles = new List<BEOrdenCompraDetalle_327LG>();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"
                    SELECT 
                        ocd.ISBN_327LG, ocd.Cantidad_327LG, ocd.PrecioUnitario_327LG,
                        l.Titulo_327LG
                    FROM OrdenCompraDetalle_327LG ocd
                    JOIN Libro_327LG l ON ocd.ISBN_327LG = l.ISBN_327LG
                    WHERE ocd.NroOrden_327LG = @NroOrden_327LG;";
                    cmd.Parameters.AddWithValue("@NroOrden_327LG", nroOrden);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BEOrdenCompraDetalle_327LG detalle = new BEOrdenCompraDetalle_327LG
                            {
                                libro_327LG = new BELibro_327LG
                                {
                                    ISBN_327LG = reader["ISBN_327LG"].ToString(),
                                    titulo_327LG = reader["Titulo_327LG"].ToString(),
                                },
                                Cantidad_327LG = Convert.ToInt32(reader["Cantidad_327LG"]),
                                PrecioUnitario_327LG = Convert.ToDecimal(reader["PrecioUnitario_327LG"])
                            };
                            listaDetalles.Add(detalle);
                        }
                    }
                    con.Close();
                    return listaDetalles;
                }
            }
        }

        public List<BEOrdenCompra_327LG> ObtenerOrdenesCompra_327LG()
        {
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                List<BEOrdenCompra_327LG> listaOrdenes = new List<BEOrdenCompra_327LG>();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"
                    SELECT 
                        oc.NroOrden_327LG, oc.Fecha_327LG, oc.Total_327LG, oc.Banco_327LG, oc.CBU_327LG, 
                        oc.NombreTitular_327LG, oc.NumeroTarjeta_327LG, oc.Estado_327LG,
                        d.CUIT_327LG, d.Empresa_327LG, d.Correo_327LG, d.Telefono_327LG
                    FROM OrdenCompra_327LG oc
                    JOIN Distribuidor_327LG d ON oc.CUIT_327LG = d.CUIT_327LG;";
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BEOrdenCompra_327LG orden = new BEOrdenCompra_327LG
                            {
                                nroOrden_327LG = reader["NroOrden_327LG"].ToString(),
                                Fecha_327LG = Convert.ToDateTime(reader["Fecha_327LG"]),
                                Total_327LG = Convert.ToDecimal(reader["Total_327LG"]),
                                Banco_327LG = reader["Banco_327LG"].ToString(),
                                CBU_327LG = reader["CBU_327LG"].ToString(),
                                NombreTitular_327LG = reader["NombreTitular_327LG"].ToString(),
                                NroTarjeta_327LG = reader["NumeroTarjeta_327LG"].ToString(),
                                Estado_327LG = (EstadoOrden_327LG)Enum.Parse(typeof(EstadoOrden_327LG), reader["Estado_327LG"].ToString()),
                                Distribuidor_327LG = new BEDistribuidor_327LG
                                {
                                    CUIT_327LG = reader["CUIT_327LG"].ToString(),
                                    Empresa_327LG = reader["Empresa_327LG"].ToString(),
                                    Correo_327LG = reader["Correo_327LG"].ToString(),
                                    Telefono_327LG = reader["Telefono_327LG"].ToString()

                                }
                            };
                            listaOrdenes.Add(orden);
                        }
                    }
                    con.Close();
                }


                return listaOrdenes;
            }
        }

        public BEOrdenCompra_327LG ObtenerUltimaOrden_327LG()
        {
            BEOrdenCompra_327LG ultimaOrden = null;
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"
                    SELECT TOP 1 
                        NroOrden_327LG, Fecha_327LG
                    FROM OrdenCompra_327LG
                    ORDER BY NroOrden_327LG DESC;";
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ultimaOrden = new BEOrdenCompra_327LG
                            {
                                nroOrden_327LG = reader["NroOrden_327LG"].ToString(),
                                Fecha_327LG = Convert.ToDateTime(reader["Fecha_327LG"])
                            };
                        }
                    }
                    con.Close();
                }
            }
            return ultimaOrden;
        }
    }
}
