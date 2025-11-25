using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_327LG
{
    public class BELibro_C_327LG
    {
        public int IDCambio_327LG { get; set; }
        public string ISBN_327LG { get; set; }
        public DateTime Fecha_327LG { get; set; }
        public TimeSpan Hora_327LG { get; set; }
        public string Titulo_327LG { get; set; }
        public string Autor_327LG { get; set; }
        public string Editorial_327LG { get; set; }
        public int Edicion_327LG { get; set; }
        public bool Eliminado_327LG { get; set; }
        public bool Activo_327LG { get; set; }
        public BELibro_C_327LG()
        {
        }
    }
}
