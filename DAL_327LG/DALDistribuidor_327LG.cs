using BE_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALDistribuidor_327LG
    {
        private string connectionString;
        public DALDistribuidor_327LG()
        {
            connectionString = "Data Source=.;Initial Catalog=SistemaBiblioteca;Integrated Security=True;Trust Server Certificate=True";
        }

        public List<BEDistribuidor_327LG> ObtenerDistribuidores_327LG()
        {
            List<BEDistribuidor_327LG> listaDistribuidores = new List<BEDistribuidor_327LG>();
            
            return listaDistribuidores;
        }

        public void RegistrarDistribuidor_327LG(BEDistribuidor_327LG distribuidor)
        {

        }
    }
}
