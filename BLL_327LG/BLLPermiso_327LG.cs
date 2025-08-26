using DAL_327LG;
using Services_327LG.Composite_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLPermiso_327LG
    {
        private DALPermiso_327LG dalPermiso_327LG;
        public BLLPermiso_327LG()
        {
            dalPermiso_327LG = new DALPermiso_327LG();
        }

        public List<BEPermiso_327LG> ObtenerPermisos_327LG()
        {
            return dalPermiso_327LG.ObtenerPermisos_327LG();
        }
    }
}
