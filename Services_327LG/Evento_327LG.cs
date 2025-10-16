using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_327LG
{
    public class Evento_327LG
    {
        public string IdEvento_327LG { get; set; }
        public string Login_327LG { get; set; }
        public string DNI_327LG { get; set; }
        public DateTime Fecha_327LG { get; set; }
        public TimeSpan Hora_327LG{ get; set; }
        public string Modulo_327LG { get; set; }
        public string evento_327LG { get; set; }
        public int Criticidad_327LG { get; set; }
        // Obtener de base de datos
        public Evento_327LG(string id, string login, DateTime fecha,TimeSpan hora, string modulo, string evento, int criticidad)
        {
            IdEvento_327LG = id;
            Login_327LG = login;
            Fecha_327LG = fecha.Date;
            Hora_327LG = hora;
            Modulo_327LG = modulo;
            evento_327LG = evento;
            Criticidad_327LG = criticidad;
        }
        //Registrar en base de datos
        public Evento_327LG(string id, string dni, DateTime fecha, string modulo, string evento, int criticidad)
        {
            IdEvento_327LG = id;
            DNI_327LG = dni;
            Fecha_327LG = fecha.Date;
            Hora_327LG = fecha.TimeOfDay;
            Modulo_327LG = modulo;
            evento_327LG = evento;
            Criticidad_327LG = criticidad;
        }
    }
}
