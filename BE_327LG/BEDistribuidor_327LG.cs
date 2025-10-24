using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_327LG
{
    public class BEDistribuidor_327LG
    {
        public string CUIT_327LG { get; set; }
        public string Empresa_327LG { get; set; }
        public string Telefono_327LG { get; set; }
        public string Direccion_327LG { get; set; }
        public string Correo_327LG { get; set; }
        public bool Activo_327LG { get; set; }

        public BEDistribuidor_327LG()
        {
        }

        public BEDistribuidor_327LG(string cuit, string empresa, string telefono, string direccion, string correo, bool activo)
        {
            CUIT_327LG = cuit;
            Empresa_327LG = empresa;
            Telefono_327LG = telefono;
            Direccion_327LG = direccion;
            Correo_327LG = correo;
            Activo_327LG = activo;
        }
    }
}
