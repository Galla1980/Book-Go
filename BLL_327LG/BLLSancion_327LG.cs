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
    public class BLLSancion_327LG
    {
        DALSancion_327LG dalSancion_327LG;
        BLLEvento_327LG bllEvento_327LG;
        private readonly BLLDigitoVerificador_327LG bllDigitoVerificador_327LG = new BLLDigitoVerificador_327LG();

        public BLLSancion_327LG()
        {
            dalSancion_327LG = new DALSancion_327LG();
            bllEvento_327LG = new BLLEvento_327LG();
        }

        public List<BESancion_327LG> ObtenerSanciones_327LG(string dni)
        {
            return dalSancion_327LG.ObtenerSanciones_327LG(dni);
        }

        public void RegistrarSancion_327LG(BESancion_327LG sancion)
        {
            dalSancion_327LG.GuardarSancion_327LG(sancion);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Préstamos y devoluciones", "Registro de sanción", 2);
            bllDigitoVerificador_327LG.GuardarDigitoVerificador_327LG(new BEDigitoVerificador_327LG("Sancion_327LG"));
        }
    }
}
