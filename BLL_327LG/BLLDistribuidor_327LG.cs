using BE_327LG;
using DAL_327LG;
using Services_327LG.Singleton_327LG;

namespace BLL_327LG
{
    public class BLLDistribuidor_327LG
    {
        private readonly DALDistribuidor_327LG dalDistribuidor;
        private readonly BLLDigitoVerificador_327LG bllDigitoVerificador_327LG = new BLLDigitoVerificador_327LG();
        private readonly BLLEvento_327LG bllEvento;
        public BLLDistribuidor_327LG()
        {
            dalDistribuidor = new DALDistribuidor_327LG();
            bllEvento = new BLLEvento_327LG();
        }

        public void RegistrarDistribuidor_327LG(BEDistribuidor_327LG distribuidor)
        {
            dalDistribuidor.RegistrarDistribuidor_327LG(distribuidor);
            bllEvento.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de stock", "Registro de distribuidor", 5);
            bllDigitoVerificador_327LG.GuardarDigitoVerificador_327LG(new BEDigitoVerificador_327LG("Distribuidor_327LG"));

        }
        public List<BEDistribuidor_327LG> ObtenerDistribuidores_327LG()
        {
            List<BEDistribuidor_327LG> listaDistribuidores = dalDistribuidor.ObtenerDistribuidores_327LG();
            return listaDistribuidores;
        }

        public void ModificarDistribuidor_327LG(BEDistribuidor_327LG distribuidor)
        {
            dalDistribuidor.ModificarDistribuidor_327LG(distribuidor);
            bllEvento.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de stock", "Modificación de distribuidor", 4);
            bllDigitoVerificador_327LG.GuardarDigitoVerificador_327LG(new BEDigitoVerificador_327LG("Distribuidor_327LG"));

        }

        public void EliminarDistribuidor_327LG(BEDistribuidor_327LG distribuidor)
        {
            dalDistribuidor.EliminarDistribuidor_327LG(distribuidor);
            bllEvento.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de stock", "Eliminacion de distribuidor", 3);
            bllDigitoVerificador_327LG.GuardarDigitoVerificador_327LG(new BEDigitoVerificador_327LG("Distribuidor_327LG"));

        }

        public List<BEDistribuidor_327LG> FiltrarDistribuidores_327LG(string? CUIT, string? Empresa)
        {
            return dalDistribuidor.FiltrarDistribuidores_327LG(CUIT, Empresa);
        }

        
    }
}
