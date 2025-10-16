using BE_327LG;
using DAL_327LG;
using Services_327LG.Singleton_327LG;
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
        BLLEvento_327LG bllEvento_327LG = new BLLEvento_327LG();
        public BLLEjemplar_327LG()
        {
            dalEjemplar_327LG = new DALEjemplar_327LG();
            bllEvento_327LG = new BLLEvento_327LG();
        }

        public void AgregarEjemplar_327LG(BEEjemplar_327LG bEEjemplar_327LG, int cantidad)
        {
            dalEjemplar_327LG.RegistrarEjemplar_327LG(bEEjemplar_327LG, cantidad);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de stock", "Registro de nuevo stock", 5);
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
