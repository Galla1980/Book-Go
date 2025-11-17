using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_327LG
{
    public class BEDigitoVerificador_327LG
    {
        public string NombreTabla_327LG { get; set; }
        public string DigitoVerificadorHorizontal_327LG { get; set; }
        public string DigitoVerificadorVertical_327LG { get; set; }

        public BEDigitoVerificador_327LG() 
        {

        }
        public BEDigitoVerificador_327LG(string nombre)
        {
            NombreTabla_327LG = nombre;
        }

        public BEDigitoVerificador_327LG(string nombre, string dvh, string dvv): this(nombre)
        {
            NombreTabla_327LG = nombre;
            DigitoVerificadorHorizontal_327LG = dvh;
            DigitoVerificadorVertical_327LG = dvv;
        }
    }
}
