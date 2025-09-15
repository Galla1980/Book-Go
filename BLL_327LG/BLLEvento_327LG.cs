using DAL_327LG;
using Services_327LG;
using Services_327LG.Observer_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLEvento_327LG
    {
        DALEvento_327LG dalEvento = new DALEvento_327LG();
        LanguageManager_327LG LM_327 = new LanguageManager_327LG();
        public List<Evento_327LG> ObtenerEventos_327LG(string? login, DateTime fechaInicio, DateTime fechaFin,string? modulo, string? evento, int? criticidad)
        {
            List<Evento_327LG> eventos = new List<Evento_327LG>();
            if (fechaInicio > fechaFin) throw new Exception(LM_327.ObtenerString("exception.fechasInvalidas"));
            eventos = dalEvento.ObtenerEventos_327LG(login, fechaInicio, fechaFin, modulo, evento, criticidad);
            return eventos;
        }
    }
}
