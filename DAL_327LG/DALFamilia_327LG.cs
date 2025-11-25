using Microsoft.Data.SqlClient;
using Services_327LG.Composite_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALFamilia_327LG : DALAbstracta_327LG
    {
       

        public List<BEFamilia_327LG> ObtenerFamilias_327LG()
        {
            List<BEFamilia_327LG> listaFamilias = new List<BEFamilia_327LG>();
            List<BEPermiso_327LG> listaPermisos = new List<BEPermiso_327LG>();

            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                con_327LG.Open();

                //Carga familias
                SqlCommand cmd_327LG = new SqlCommand("SELECT * FROM Familia_327LG", con_327LG);
                using (SqlDataReader reader = cmd_327LG.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codigoFamilia = Convert.ToInt32(reader["CodigoFamilia_327LG"]);
                        string nombreFamilia = reader["NombreFamilia_327LG"].ToString();
                        BEFamilia_327LG familia = new BEFamilia_327LG(codigoFamilia, nombreFamilia);
                        listaFamilias.Add(familia);
                    }
                }

                //Carga permisos
                cmd_327LG.CommandText = "SELECT * FROM Permiso_327LG";
                using (SqlDataReader reader = cmd_327LG.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codigoPermiso = Convert.ToInt32(reader["CodigoPermiso_327LG"]);
                        string nombrePermiso = reader["NombrePermiso_327LG"].ToString();
                        BEPermiso_327LG permiso = new BEPermiso_327LG(codigoPermiso, nombrePermiso);
                        listaPermisos.Add(permiso);
                    }
                }

                // Asocia permisos a familias
                cmd_327LG.CommandText = "SELECT * FROM PermisoFamilia_327LG";
                using (SqlDataReader reader = cmd_327LG.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codigoFamilia = Convert.ToInt32(reader["CodigoFamilia_327LG"]);
                        int codigoPermiso = Convert.ToInt32(reader["CodigoPermiso_327LG"]);
                        BEFamilia_327LG familia = listaFamilias.FirstOrDefault(f => f.Codigo_327LG == codigoFamilia);
                        BEPermiso_327LG permiso = listaPermisos.FirstOrDefault(p => p.Codigo_327LG == codigoPermiso);
                        if (familia != null && permiso != null)
                        {
                            familia.AñadirHijo_327LG(permiso);
                        }
                    }
                }

                // Asocia familias a familias
                cmd_327LG.CommandText = "SELECT * FROM FamiliaFamilia_327LG";
                using (SqlDataReader reader = cmd_327LG.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codigoFamiliaPadre = Convert.ToInt32(reader["CodigoFamilia_327LG"]);
                        int codigoFamiliaHijo = Convert.ToInt32(reader["CodigoFamiliaRelacionado_327LG"]);
                        BEFamilia_327LG familiaPadre = listaFamilias.FirstOrDefault(f => f.Codigo_327LG == codigoFamiliaPadre);
                        BEFamilia_327LG familiaHijo = listaFamilias.FirstOrDefault(f => f.Codigo_327LG == codigoFamiliaHijo);
                        if (familiaPadre != null && familiaHijo != null)
                        {
                            familiaPadre.AñadirHijo_327LG(familiaHijo);
                        }
                    }
                }
                return listaFamilias;
            }
        }

        public void CrearFamilia_327LG(string nombre) 
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                string query = "INSERT INTO Familia_327LG (NombreFamilia_327LG) VALUES (@Nombre)";
                SqlCommand cmd_327LG = new SqlCommand(query, con_327LG);
                cmd_327LG.Parameters.AddWithValue("@Nombre", nombre);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public void AsignarPermiso_327LG(BEPermiso_327LG permiso, BEFamilia_327LG familia)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                string query = "INSERT INTO PermisoFamilia_327LG (CodigoPermiso_327LG, CodigoFamilia_327LG) VALUES (@CodigoPermiso, @CodigoFamilia)";
                SqlCommand cmd_327LG = new SqlCommand(query, con_327LG);
                cmd_327LG.Parameters.AddWithValue("@CodigoPermiso", permiso.Codigo_327LG);
                cmd_327LG.Parameters.AddWithValue("@CodigoFamilia", familia.Codigo_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public void AsignarFamilia_327LG(BEFamilia_327LG familiaBase, BEFamilia_327LG familiaAgregada)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                string query = "INSERT INTO FamiliaFamilia_327LG (CodigoFamilia_327LG, CodigoFamiliaRelacionado_327LG) VALUES (@CodigoFamiliaBase, @CodigoFamiliaAgregada)";
                SqlCommand cmd_327LG = new SqlCommand(query, con_327LG);
                cmd_327LG.Parameters.AddWithValue("@CodigoFamiliaBase", familiaBase.Codigo_327LG);
                cmd_327LG.Parameters.AddWithValue("@CodigoFamiliaAgregada", familiaAgregada.Codigo_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public void EliminarFamilia(BEFamilia_327LG familia)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                string query = "DELETE FROM FamiliaFamilia_327LG WHERE CodigoFamilia_327LG = @CodigoFamilia or CodigoFamiliaRelacionado_327LG = @CodigoFamilia";
                SqlCommand cmd_327LG = new SqlCommand(query, con_327LG);
                cmd_327LG.Parameters.AddWithValue("@CodigoFamilia", familia.Codigo_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
                
                query = "DELETE FROM PermisoFamilia_327LG WHERE CodigoFamilia_327LG = @CodigoFamilia";
                cmd_327LG.CommandText = query;
                cmd_327LG.ExecuteNonQuery();

                query = "DELETE FROM Familia_327LG WHERE CodigoFamilia_327LG = @CodigoFamilia";
                cmd_327LG.CommandText = query;
                cmd_327LG.ExecuteNonQuery();
            }
        }

        public void EliminarComponente(BEFamilia_327LG familia, BEPerfil_327LG componente)
        {
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                string query;
                if (componente is BEPermiso_327LG)
                {
                    query = "DELETE FROM PermisoFamilia_327LG WHERE CodigoFamilia_327LG = @CodigoFamilia AND CodigoPermiso_327LG = @CodigoComponente";
                }
                else
                {
                    query = "DELETE FROM FamiliaFamilia_327LG WHERE CodigoFamilia_327LG = @CodigoFamilia AND CodigoFamiliaRelacionado_327LG = @CodigoComponente";
                }
                SqlCommand cmd_327LG = new SqlCommand(query, con_327LG);
                cmd_327LG.Parameters.AddWithValue("@CodigoFamilia", familia.Codigo_327LG);
                cmd_327LG.Parameters.AddWithValue("@CodigoComponente", componente.Codigo_327LG);
                con_327LG.Open();
                cmd_327LG.ExecuteNonQuery();
            }
        }
    }
}
