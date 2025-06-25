using BE_327LG;
using DAL_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLEjemplar_327LG
    {
        DALEjemplar_327LG dalEjemplar_327LG;
        public BLLEjemplar_327LG()
        {
            dalEjemplar_327LG = new DALEjemplar_327LG();
        }

        public void CambiarEstado_327LG(int nroEjemplar_327LG, Estado_327LG prestado)
        {
            dalEjemplar_327LG.ActualizarEjemplar_327LG(nroEjemplar_327LG, prestado);
        }

        public List<BEEjemplar_327LG> ObtenerEjemplares(string ISBN)
        {
            return dalEjemplar_327LG.ObtenerEjemplares_327LG(ISBN);
        }
    }
}
