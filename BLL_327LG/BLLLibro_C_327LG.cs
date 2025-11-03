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
    public class BLLLibro_C_327LG
    {
        private readonly DALLibro_C_327LG dalLibro_C_327LG = new DALLibro_C_327LG();
        private readonly BLLEvento_327LG bllEvento_327LG = new BLLEvento_327LG();

        public void ActivarCambio_327LG(BELibro_C_327LG cambio)
        {
            dalLibro_C_327LG.ActivarCambio_327LG(cambio);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Bitacora cambios", "Activación estado historico", 5);
        }

        public List<BELibro_C_327LG> FiltrarCambios_327LG(string? isbn, string? titulo, string? autor, string? editorial, int? edicion, DateTime? fechaInicio, DateTime? fechaFin)
        {
            return dalLibro_C_327LG.Filtrarcambios_327LG(isbn,titulo,autor,editorial,edicion,fechaInicio,fechaFin);
        }

        public List<BELibro_C_327LG> ObtenerTodosCambios_327LG()
        {
            return dalLibro_C_327LG.ObtenerTodosCambios_327LG();
        }
    }
}
