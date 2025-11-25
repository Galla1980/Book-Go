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
    public class BLLRecepcion_327LG
    {
        private readonly DALRecepcion_327LG dalRecepcion_327LG = new DALRecepcion_327LG();
        private readonly BLLEvento_327LG bllEvento_327LG = new BLLEvento_327LG();
        private readonly BLLDigitoVerificador_327LG bllDigitoVerificador_327LG = new BLLDigitoVerificador_327LG();


        public int ObtenerCantidadRecibida_327LG(string nroOrdenSeleccionada, string iSBN_327LG)
        {
            return dalRecepcion_327LG.ObtenerCantidadRecibida_327LG(nroOrdenSeleccionada,iSBN_327LG);
        }

        public void RegistrarRecepcion_327LG(BERecepcion_327LG nuevaRecepcion)
        {
            dalRecepcion_327LG.RegistrarRecepcion_327LG(nuevaRecepcion);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Gestión de stock", "Registro de recepción", 5);
            bllDigitoVerificador_327LG.GuardarDigitoVerificador_327LG(new BEDigitoVerificador_327LG("Recepcion_327LG"));
            bllDigitoVerificador_327LG.GuardarDigitoVerificador_327LG(new BEDigitoVerificador_327LG("RecepcionDetalle_327LG"));
            bllDigitoVerificador_327LG.GuardarDigitoVerificador_327LG(new BEDigitoVerificador_327LG("Ejemplar_327LG"));
        }
    }
}
