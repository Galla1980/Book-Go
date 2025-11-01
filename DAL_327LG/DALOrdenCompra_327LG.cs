using BE_327LG;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALOrdenCompra_327LG
    {
        private string connectionString_327LG;

        public DALOrdenCompra_327LG()
        {
            connectionString_327LG = "Data Source=.;Initial Catalog=SistemaBiblioteca;Integrated Security=True;Trust Server Certificate=True";

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
                        "VALUES (@NroOrden_327LG, @Fecha_327LG, @CUIT_327LG, @Total_327LG, @Banco_327LG, @CBU_327LG, @NombreTitular_327LG, @NumeroTarjeta_327LG, @Estado)", con,transaction))
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
                    foreach (var detalle in ordenCompra.LibrosSolcitados_327LGs)
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO OrdenCompraDetalle_327LG (NroOrden_327LG, ISBN_327LG, Cantidad_327LG, PrecioUnitario_327LG)" +
                            "VALUES (@NroOrden_327LG, @ISBN_327LG, @Cantidad_327LG, @PrecioUnitario_327LG)", con,transaction))
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
