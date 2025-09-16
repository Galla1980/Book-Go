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
        LanguageManager_327LG LM_327;

        public BLLEvento_327LG()
        {
            LM_327 = LanguageManager_327LG.Instance_327LG;
        }
        public List<Evento_327LG> ObtenerEventos_327LG(string? login, DateTime fechaInicio, DateTime fechaFin,string? modulo, string? evento, int? criticidad)
        {
            LM_327.CargarFormulario_327LG("FormBitacoraEventos_327LG");
            List<Evento_327LG> eventos = new List<Evento_327LG>();
            if (fechaInicio > fechaFin) throw new Exception(LM_327.ObtenerString("exception.fechasInvalidas"));
            eventos = dalEvento.ObtenerEventos_327LG(login, fechaInicio, fechaFin, modulo, evento, criticidad);
            return eventos;
        }

        public void RegistrarEvento_327LG(string dni, string modulo, string evento, int criticidad)
        {
            string id = string.Empty;
            int numero = 1;

            //Generar ID del evento con codigo de fecha y numero de evento del dia
            Evento_327LG ultimoEvento = ObtenerUltimoEvento_327LG();
            if (ultimoEvento != null)
            {   
                var partes = ultimoEvento.IdEvento_327LG.ToString().Split('-');
                DateTime Fecha = DateTime.ParseExact(partes[0], "yyyyMMdd", null);
                if(Fecha.Date == DateTime.Now.Date) numero = int.Parse(partes[1]) + 1;
            }
            id = DateTime.Now.ToString("yyyyMMdd") + "-" + numero.ToString("D3");

            //Registrar evento
            Evento_327LG evento_327LG = new Evento_327LG(id, dni, DateTime.Now, modulo, evento, criticidad);
            dalEvento.RegistrarEvento_327LG(evento_327LG);
        }

        public Evento_327LG ObtenerUltimoEvento_327LG()
        {
            return dalEvento.ObtenerUltimoEvento_327LG();
        }
    }
}
