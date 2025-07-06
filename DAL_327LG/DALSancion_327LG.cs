using BE_327LG;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALSancion_327LG
    {
        string connectionString;
        public DALSancion_327LG()
        {
            connectionString = "Data Source=.;Initial Catalog=SistemaBiblioteca;Integrated Security=True;Trust Server Certificate=True";
        }

        public void GuardarSancion_327LG(BESancion_327LG sancion)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                INSERT INTO Sancion_327LG (Descripcion_327LG, Razon_327LG, DNI_327LG, nroPrestamo_327LG)
                VALUES (@Descripcion, @Razon, @DNI, @nroPrestamo)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DNI", sancion.Cliente.DNI_327LG);
                cmd.Parameters.AddWithValue("@nroPrestamo", sancion.Prestamo.nroPrestamo_327LG);
                cmd.Parameters.AddWithValue("@Descripcion", sancion.Descripcion);
                cmd.Parameters.AddWithValue("@Razon", sancion.Razon);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<BESancion_327LG> ObtenerSanciones_327LG(string dni)
        {
            List<BESancion_327LG> lista = new List<BESancion_327LG>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                s.nroSancion_327LG, s.Descripcion_327LG, s.Razon_327LG,
                
                c.DNI_327LG, c.Nombre_327LG, c.Apellido_327LG, c.Email_327LG,
                
                p.nroPrestamo_327LG, p.FechaDevolucion_327LG, p.FechaADevolver_327LG, p.Activo_327LG,

                
                e.nroEjemplar_327LG, e.Estado_327LG,

                
                l.ISBN_327LG, l.Titulo_327LG, l.Autor_327LG, l.Edicion_327LG, l.Editorial_327LG

            FROM Sancion_327LG s
            INNER JOIN Cliente_327LG c ON s.DNI_327LG = c.DNI_327LG
            INNER JOIN Prestamo_327LG p ON s.nroPrestamo_327LG = p.nroPrestamo_327LG
            INNER JOIN Ejemplar_327LG e ON p.nroEjemplar_327LG = e.nroEjemplar_327LG
            INNER JOIN Libro_327LG l ON e.ISBN_327LG = l.ISBN_327LG
            WHERE c.DNI_327LG = @DNI";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DNI", dni);
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

                        // Estado ejemplar
                        Estado_327LG estadoEjemplar = Enum.TryParse(dr["Estado_327LG"].ToString(), out Estado_327LG estado)
                            ? estado
                            : Estado_327LG.Disponible;

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
                            email_327LG: dr["Email_327LG"].ToString()
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

                        // Sanción
                        BESancion_327LG sancion = new BESancion_327LG(
                            nroSancion: Convert.ToInt32(dr["nroSancion_327LG"]),
                            cliente: cliente,
                            prestamo: prestamo,
                            descripcion: dr["Descripcion_327LG"].ToString(),
                            razon: dr["Razon_327LG"].ToString()
                        );

                        lista.Add(sancion);
                    }
                }
            }

            return lista;
        }

    }
}
