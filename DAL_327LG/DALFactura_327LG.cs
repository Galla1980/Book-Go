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
    }
}
