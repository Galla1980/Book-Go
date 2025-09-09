using BE_327LG;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALFactura_327LG
    {
        string connectionString_327LG;
        public DALFactura_327LG()
        {
            connectionString_327LG = "Data Source=.;Initial Catalog=SistemaBiblioteca;Integrated Security=True;Trust Server Certificate=True";
        }
        public void GuardarFactura_327LG(BEFactura_327LG factura)
        {
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                string query = "INSERT INTO Factura_327LG (Fecha_327LG, DNI_327LG, Monto_327LG, ISBN_327LG) VALUES (@Fecha, @DNI, @Monto, @ISBN)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Fecha", factura.Fecha_327LG);
                cmd.Parameters.AddWithValue("@DNI", factura.Cliente_327LG.DNI_327LG);
                cmd.Parameters.AddWithValue("@Monto", factura.Monto_327LG);
                cmd.Parameters.AddWithValue("@ISBN", factura.Libro_327LG.ISBN_327LG);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<BEFactura_327LG> ObtenerFacturas_327LG()
        {
            List<BEFactura_327LG> listaFacturas = new List<BEFactura_327LG>();
            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                string query = @"
                SELECT 
                    f.nroFactura_327LG, f.Fecha_327LG, f.Monto_327LG,
                    c.DNI_327LG, c.Nombre_327LG, c.Apellido_327LG, c.Email_327LG,
                    l.ISBN_327LG, l.Titulo_327LG, l.Autor_327LG, l.Edicion_327LG, l.Editorial_327LG
                FROM Factura_327LG f
                INNER JOIN Cliente_327LG c ON f.DNI_327LG = c.DNI_327LG
                INNER JOIN Libro_327LG l ON f.ISBN_327LG = l.ISBN_327LG";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BEFactura_327LG factura = new BEFactura_327LG(reader.GetInt32(reader.GetOrdinal("nroFactura_327LG")), reader.GetDateTime(reader.GetOrdinal("Fecha_327LG")),
                            new BECliente_327LG(reader.GetString(reader.GetOrdinal("DNI_327LG")), reader.GetString(reader.GetOrdinal("Nombre_327LG")), reader.GetString(reader.GetOrdinal("Apellido_327LG")),
                            reader.GetString(reader.GetOrdinal("Email_327LG"))), reader.GetDecimal(reader.GetOrdinal("Monto_327LG")), new BELibro_327LG(reader.GetString(reader.GetOrdinal("ISBN_327LG")),
                            reader.GetString(reader.GetOrdinal("Titulo_327LG")), reader.GetString(reader.GetOrdinal("Autor_327LG")), reader.GetString(reader.GetOrdinal("Editorial_327LG")), reader.GetInt32(reader.GetOrdinal("Edicion_327LG"))));
                        

                        listaFacturas.Add(factura);
                    }
                }
            }
            return listaFacturas;
        }
    }
}
