using BE_327LG;
using Microsoft.Data.SqlClient;

namespace DAL_327LG
{
    public class DALRecepcion_327LG
    {
        private string connectionString_327LG;

        public DALRecepcion_327LG()
        {
            connectionString_327LG = "Data Source=.;Initial Catalog=SistemaBiblioteca;Integrated Security=True;Trust Server Certificate=True";

        }
        public int ObtenerCantidadRecibida_327LG(string nroOrdenSeleccionada, string iSBN_327LG)
        {
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                con.Open();
                string query = "SELECT SUM(rd.Cantidad_327LG) AS CantidadTotal " +
                    "FROM Recepcion_327LG r JOIN RecepcionDetalle_327LG rd  ON r.NroRecepcion_327LG = rd.NroRecepcion_327LG " +
                    "WHERE r.NroOrden_327LG = @NroOrden AND rd.ISBN_327LG = @ISBN";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@NroOrden", nroOrdenSeleccionada);
                    cmd.Parameters.AddWithValue("@ISBN", iSBN_327LG);
                    object result = cmd.ExecuteScalar();
                    if (result == DBNull.Value || result == null)
                        return 0;

                    return Convert.ToInt32(result);
                }
            }
        }

        public void RegistrarRecepcion_327LG(BERecepcion_327LG nuevaRecepcion)
        {
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    
                    int nuevoNroRecepcion;
                    using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Recepcion_327LG (Fecha_327LG, NroOrden_327LG)
                VALUES (@Fecha, @NroOrden);
                SELECT SCOPE_IDENTITY();", con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Fecha", nuevaRecepcion.Fecha_327LG);
                        cmd.Parameters.AddWithValue("@NroOrden", nuevaRecepcion.OrdenDeCompra_327LG.nroOrden_327LG);
                        nuevoNroRecepcion = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    
                    foreach (var detalle in nuevaRecepcion.LibrosRecibidos_327LG)
                    {
                        
                        using (SqlCommand cmdDet = new SqlCommand(@"
                    INSERT INTO RecepcionDetalle_327LG (NroRecepcion_327LG, ISBN_327LG, Cantidad_327LG)
                    VALUES (@NroRecepcion, @ISBN, @Cantidad)", con, transaction))
                        {
                            cmdDet.Parameters.AddWithValue("@NroRecepcion", nuevoNroRecepcion);
                            cmdDet.Parameters.AddWithValue("@ISBN", detalle.Libro_327LG.ISBN_327LG);
                            cmdDet.Parameters.AddWithValue("@Cantidad", detalle.Cantidad_327LG);
                            cmdDet.ExecuteNonQuery();
                        }

                        
                        using (SqlCommand cmdEj = new SqlCommand(@"
                    INSERT INTO Ejemplar_327LG (Estado_327LG, ISBN_327LG)
                    VALUES (@Estado, @ISBN)", con, transaction))
                        {
                            cmdEj.Parameters.AddWithValue("@Estado", Estado_327LG.Disponible.ToString());
                            cmdEj.Parameters.AddWithValue("@ISBN", detalle.Libro_327LG.ISBN_327LG);

                            for (int i = 0; i < detalle.Cantidad_327LG; i++)
                            {
                                cmdEj.ExecuteNonQuery();
                            }
                        }
                    }

                    // 3️⃣ Confirmar
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

    }
}
