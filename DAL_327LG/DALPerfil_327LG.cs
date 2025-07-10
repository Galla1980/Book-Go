using Microsoft.Data.SqlClient;
using Services_327LG.Composite_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALPerfil_327LG
    {
        private string connectionString_327LG;

        public DALPerfil_327LG()
        {
            connectionString_327LG = "Data Source=.;Initial Catalog=SistemaBiblioteca;Integrated Security=True;Trust Server Certificate=True";
        }

        public void AsignarFamilia_327LG(BEPerfil_327LG perfil, BEFamilia_327LG familia)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                string query = "INSERT INTO FamiliaPerfil_327LG (CodigoFamilia_327LG, CodigoPerfil_327LG) VALUES (@CodigoFamilia, @CodigoPerfil)";
                SqlCommand cmd_327LG = new SqlCommand(query, con_327LG);
                cmd_327LG.Parameters.AddWithValue("@CodigoFamilia", familia.Codigo_327LG);
                cmd_327LG.Parameters.AddWithValue("@CodigoPerfil", perfil.Codigo_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public void AsignarPermiso_327LG(BEPerfil_327LG perfil, BEPermiso_327LG permiso)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                string query = "INSERT INTO PermisoPerfil_327LG (CodigoPermiso_327LG, CodigoPerfil_327LG) VALUES (@CodigoPermiso, @CodigoPerfil)";
                SqlCommand cmd_327LG = new SqlCommand(query, con_327LG);
                cmd_327LG.Parameters.AddWithValue("@CodigoPermiso", permiso.Codigo_327LG);
                cmd_327LG.Parameters.AddWithValue("@CodigoPerfil", perfil.Codigo_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public void CrearPerfil_327LG(string nombre)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                string query = "INSERT INTO Perfil_327LG (NombrePerfil_327LG) VALUES (@Nombre)";
                SqlCommand cmd_327LG = new SqlCommand(query, con_327LG);
                cmd_327LG.Parameters.AddWithValue("@Nombre", nombre);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public void EliminarComponente_327LG(BEPerfil_327LG perfil, BEPerfil_327LG componente)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                string query;
                
                if (componente is BEFamilia_327LG)
                {
                    query = "DELETE FROM FamiliaPerfil_327LG WHERE CodigoFamilia_327LG = @CodigoComponente AND CodigoPerfil_327LG = @CodigoPerfil";
                }
                else
                { 
                    query = "DELETE FROM PermisoPerfil_327LG WHERE CodigoPermiso_327LG = @CodigoComponente AND CodigoPerfil_327LG = @CodigoPerfil";
                }
                SqlCommand cmd_327LG = new SqlCommand(query, con_327LG);
                cmd_327LG.Parameters.AddWithValue("@CodigoPerfil", perfil.Codigo_327LG);
                cmd_327LG.Parameters.AddWithValue("@CodigoComponente", componente.Codigo_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public void EliminarPerfil_327LG(BEPerfil_327LG perfil)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                string query = "DELETE FROM PermisoPerfil_327LG WHERE CodigoPerfil_327LG = @CodigoPerfil";
                SqlCommand cmd_327LG = new SqlCommand(query, con_327LG);
                cmd_327LG.Parameters.AddWithValue("@CodigoPerfil", perfil.Codigo_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
                query = "DELETE FROM FamiliaPerfil_327LG WHERE CodigoPerfil_327LG = @CodigoPerfil";
                cmd_327LG.CommandText = query;
                cmd_327LG.ExecuteNonQuery();
                query = "DELETE FROM Perfil_327LG WHERE CodigoPerfil_327LG = @CodigoPerfil";
                cmd_327LG.CommandText = query;
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public List<BEPerfil_327LG> ObtenerPerfiles_327LG()
        {
            List<BEPerfil_327LG> listaPerfiles = new List<BEPerfil_327LG>();
            List<BEPermiso_327LG> listaPermisos = new List<BEPermiso_327LG>();
            List<BEFamilia_327LG> listaFamilias;

            using (SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                con.Open();

                // Carga perfiles
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Perfil_327LG", con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codigo = Convert.ToInt32(reader["CodigoPerfil_327LG"]);
                        string nombre = reader["NombrePerfil_327LG"].ToString();
                        listaPerfiles.Add(new BEPerfil_327LG(codigo, nombre));
                    }
                }

                // Carga permisos
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Permiso_327LG", con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codigo = Convert.ToInt32(reader["CodigoPermiso_327LG"]);
                        string nombre = reader["NombrePermiso_327LG"].ToString();
                        listaPermisos.Add(new BEPermiso_327LG(codigo, nombre));
                    }
                }

                // Asocia permisos a perfiles
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM PermisoPerfil_327LG", con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codPerfil = Convert.ToInt32(reader["CodigoPerfil_327LG"]);
                        int codPermiso = Convert.ToInt32(reader["CodigoPermiso_327LG"]);

                        var perfil = listaPerfiles.FirstOrDefault(p => p.Codigo_327LG == codPerfil);
                        var permiso = listaPermisos.FirstOrDefault(p => p.Codigo_327LG == codPermiso);

                        perfil?.AñadirHijo_327LG(permiso);
                    }
                }

                // Carga familias
                listaFamilias = ObtenerFamilias_327LG(con);

                // Asocia familias a perfiles
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM FamiliaPerfil_327LG", con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codPerfil = Convert.ToInt32(reader["CodigoPerfil_327LG"]);
                        int codFamilia = Convert.ToInt32(reader["CodigoFamilia_327LG"]);

                        var perfil = listaPerfiles.FirstOrDefault(p => p.Codigo_327LG == codPerfil);
                        var familia = listaFamilias.FirstOrDefault(f => f.Codigo_327LG == codFamilia);

                        perfil?.AñadirHijo_327LG(familia);
                    }
                }
            }

            return listaPerfiles;
        }

        private List<BEFamilia_327LG> ObtenerFamilias_327LG(SqlConnection con)
        {
            var listaFamilias = new List<BEFamilia_327LG>();
            var listaPermisos = new List<BEPermiso_327LG>();

            // Carga familias
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Familia_327LG", con))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int codigo = Convert.ToInt32(reader["CodigoFamilia_327LG"]);
                    string nombre = reader["NombreFamilia_327LG"].ToString();
                    listaFamilias.Add(new BEFamilia_327LG(codigo, nombre));
                }
            }

            // Carga permisos
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Permiso_327LG", con))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int codigo = Convert.ToInt32(reader["CodigoPermiso_327LG"]);
                    string nombre = reader["NombrePermiso_327LG"].ToString();
                    listaPermisos.Add(new BEPermiso_327LG(codigo, nombre));
                }
            }

            // Asocia permisos a familias
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM PermisoFamilia_327LG", con))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int codFamilia = Convert.ToInt32(reader["CodigoFamilia_327LG"]);
                    int codPermiso = Convert.ToInt32(reader["CodigoPermiso_327LG"]);

                    var familia = listaFamilias.FirstOrDefault(f => f.Codigo_327LG == codFamilia);
                    var permiso = listaPermisos.FirstOrDefault(p => p.Codigo_327LG == codPermiso);

                    familia?.AñadirHijo_327LG(permiso);
                }
            }

            // Asocia familias a familias
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM FamiliaFamilia_327LG", con))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int codPadre = Convert.ToInt32(reader["CodigoFamilia_327LG"]);
                    int codHijo = Convert.ToInt32(reader["CodigoFamiliaRelacionado_327LG"]);

                    var padre = listaFamilias.FirstOrDefault(f => f.Codigo_327LG == codPadre);
                    var hijo = listaFamilias.FirstOrDefault(f => f.Codigo_327LG == codHijo);

                    padre?.AñadirHijo_327LG(hijo);
                }
            }

            return listaFamilias;
        }
    }

}
