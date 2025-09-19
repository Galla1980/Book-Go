using BE_327LG;
using Microsoft.Data.SqlClient;

namespace DAL_327LG
{
    public class DALPrestamo_327LG
    {
        string connectionString;
        public DALPrestamo_327LG()
        {
            connectionString = "Data Source=.;Initial Catalog=SistemaBiblioteca;Integrated Security=True;Trust Server Certificate=True";
        }

        public void ActualizarPrestamo_327LG(BEPrestamo_327LG prestamo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Prestamo_327LG SET FechaDevolucion_327LG = @FechaDevolucion, Activo_327LG = @Activo WHERE nroPrestamo_327LG = @nroPrestamo";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nroPrestamo", prestamo.nroPrestamo_327LG);
                if (prestamo.FechaDevolucion_327LG.HasValue)
                {
                    cmd.Parameters.AddWithValue("@FechaDevolucion", prestamo.FechaDevolucion_327LG.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FechaDevolucion", DBNull.Value);
                }
                
                cmd.Parameters.AddWithValue("@Activo", prestamo.Activo_327LG);
                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void GuardarPrestamo_327LG(BEPrestamo_327LG prestamo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Prestamo_327LG (FechaADevolver_327LG, FechaDevolucion_327LG,nroEjemplar_327LG, Activo_327LG, DNI_327LG) VALUES (@FechaADevolver, @FechaDevolucion, @nroEjemplar, @Activo, @DNI)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FechaADevolver", prestamo.FechaADevolver_327LG);
                if (prestamo.FechaDevolucion_327LG.HasValue)
                {
                    cmd.Parameters.AddWithValue("@FechaDevolucion", prestamo.FechaDevolucion_327LG.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FechaDevolucion", DBNull.Value);
                }   
                cmd.Parameters.AddWithValue("@nroEjemplar", prestamo.Ejemplar_327LG.nroEjemplar_327LG);
                cmd.Parameters.AddWithValue("@Activo", prestamo.Activo_327LG);
                cmd.Parameters.AddWithValue("@DNI", prestamo.Cliente_327LG.DNI_327LG);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<BEPrestamo_327LG> ObtenerPrestamos_327LG(string? dni)
        {
            List<BEPrestamo_327LG> listaPrestamos = new List<BEPrestamo_327LG>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    p.nroPrestamo_327LG, p.FechaDevolucion_327LG, p.FechaADevolver_327LG, p.Activo_327LG,
                    c.DNI_327LG, c.Nombre_327LG, c.Apellido_327LG, c.Email_327LG,
                    e.nroEjemplar_327LG, e.Estado_327LG, 
                    l.ISBN_327LG, l.Titulo_327LG, l.Autor_327LG, l.Edicion_327LG, l.Editorial_327LG
                FROM Prestamo_327LG p
                INNER JOIN Cliente_327LG c ON p.DNI_327LG = c.DNI_327LG
                INNER JOIN Ejemplar_327LG e ON p.nroEjemplar_327LG = e.nroEjemplar_327LG
                INNER JOIN Libro_327LG l ON e.ISBN_327LG = l.ISBN_327LG
                WHERE  (@DNI IS NULL OR p.DNI_327LG = @DNI)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DNI", (object)dni ?? DBNull.Value);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        // Libro
                        BELibro_327LG libro = new BELibro_327LG(
                            iSBN_327LG: dr["ISBN_327LG"].ToString(),
                            titulo_327LG: dr["Titulo_327LG"].ToString(),
                            autor_327LG: dr["Autor_327LG"].ToString(),
                            edicion_327LG: Convert.ToInt32(dr["Edicion_327LG"]),
                            editorial_327LG: dr["Editorial_327LG"].ToString()
                        );
                        // Estado del ejemplar
                        Estado_327LG estadoEjemplar = Enum.TryParse(dr["Estado_327LG"].ToString(), out Estado_327LG estado)
                            ? estado
                            : Estado_327LG.Disponible; // Valor por defecto si no parsea

                        // Ejemplar
                        BEEjemplar_327LG ejemplar = new BEEjemplar_327LG(
                            nroEjemplar_327LG: Convert.ToInt32(dr["nroEjemplar_327LG"]),
                            estado_327LG: estadoEjemplar,
                            libro_327LG: libro
                        );

                        // Cliente
                        BECliente_327LG cliente = new BECliente_327LG(
                            dni_327LG: dr["DNI_327LG"].ToString(),
                            nombre_327LG: dr["Nombre_327LG"].ToString(),
                            apellido_327LG: dr["Apellido_327LG"].ToString(),
                            email_327LG: dr["Email_327LG"].ToString(),
                            activo:Convert.ToBoolean( dr["Activo_327LG"])
                        );

                        // Prestamo
                        BEPrestamo_327LG prestamo = new BEPrestamo_327LG(
                            nroPrestamo_327LG: Convert.ToInt32(dr["nroPrestamo_327LG"]),
                            ejemplar_327LG: ejemplar,
                            cliente_327LG: cliente,
                            fechaADevolver_327LG: Convert.ToDateTime(dr["FechaADevolver_327LG"]),
                            fechaDevolucion_327LG: dr["FechaDevolucion_327LG"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["FechaDevolucion_327LG"]),
                            activo_327LG: Convert.ToBoolean(dr["Activo_327LG"])
                        );
                        listaPrestamos.Add(prestamo);
                    }
                }
            }
            return listaPrestamos;
        }
    }
}
