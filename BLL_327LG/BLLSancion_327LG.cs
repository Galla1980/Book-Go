using BE_327LG;
using DAL_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLSancion_327LG
    {
        DALSancion_327LG dalSancion_327LG;
        public BLLSancion_327LG()
        {
            dalSancion_327LG = new DALSancion_327LG();
        }

        public List<BESancion_327LG> ObtenerSanciones_327LG(string dni)
        {
            return dalSancion_327LG.ObtenerSanciones_327LG(dni);
        }
    }
}
