using Microsoft.Data.SqlClient;
using Services_327LG.Composite_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALPermiso_327LG: DALAbstracta_327LG
    {
 

        public List<BEPermiso_327LG> ObtenerPermisos_327LG()
        {
            List<BEPermiso_327LG> listaPermisos = new List<BEPermiso_327LG>();
            using (SqlConnection con_327LG = new SqlConnection(connectionString_327LG))
            {
                con_327LG.Open();
                SqlCommand cmd_327LG = new SqlCommand("SELECT * FROM Permiso_327LG", con_327LG);
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
            }
            return listaPermisos;
        }
    }
}
