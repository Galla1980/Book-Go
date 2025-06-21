using BE_327LG;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALCliente_327LG
    {
        private string connectionString;
        public DALCliente_327LG()
        {
            connectionString = "Data Source=.;Initial Catalog=SistemaBiblioteca;Integrated Security=True;Trust Server Certificate=True";
        }

        public void CargarCliente_327LG(BECliente_327LG cliente)
        {
            using(SqlConnection con = new SqlConnection(connectionString)) 
            {
                string query = "INSERT INTO Cliente_327LG (DNI_327LG, Nombre_327LG, Apellido_327LG, Email_327LG) VALUES (@DNI, @Nombre, @Apellido, @Email)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DNI", cliente.DNI_327LG);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre_327LG);
                cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido_327LG);
                cmd.Parameters.AddWithValue("@Email", cliente.Email_327LG);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<BECliente_327LG> ObtenerTodos_327LG()
        {
            List<BECliente_327LG> listaClientes = new List<BECliente_327LG>();
            using (SqlConnection con = new SqlConnection(connectionString)) 
            {
                string query = "SELECT * FROM Cliente_327LG";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BECliente_327LG cliente = new BECliente_327LG(
                            dr["DNI_327LG"].ToString(),
                            dr["Nombre_327LG"].ToString(),
                            dr["Apellido_327LG"].ToString(),
                            dr["Email_327LG"].ToString()
                        );
                        listaClientes.Add(cliente);
                    }
                }
            }
            return listaClientes;
        }
    }
}
