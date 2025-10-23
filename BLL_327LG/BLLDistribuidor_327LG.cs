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
    public class BLLDistribuidor_327LG
    {
        private readonly DALDistribuidor_327LG dalDistribuidor;
        private readonly BLLEvento_327LG bllEvento;
        public BLLDistribuidor_327LG()
        {
            dalDistribuidor = new DALDistribuidor_327LG();
        }

        public void RegistrarDistribuidor_327LG(BEDistribuidor_327LG distribuidor)
        {
            dalDistribuidor.RegistrarDistribuidor_327LG(distribuidor);
            bllEvento.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de stock", "Registro de distribuidor", 4);
        }
        public List<BEDistribuidor_327LG> ObtenerDistribuidores_327LG()
        {
            List<BEDistribuidor_327LG> listaDistribuidores = dalDistribuidor.ObtenerDistribuidores_327LG();
            return listaDistribuidores;
        }
    }
}
