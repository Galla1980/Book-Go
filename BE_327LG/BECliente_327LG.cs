using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_327LG
{
    public class BECliente_327LG
    {
        public string DNI_327LG { get; set; }
        public string Nombre_327LG { get; set; }
        public string Apellido_327LG { get; set; }
        public string Email_327LG { get; set; }
        public BECliente_327LG(string dni_327LG, string nombre_327LG, string apellido_327LG, string email_327LG)
        {
            DNI_327LG = dni_327LG;
            Nombre_327LG = nombre_327LG;
            Apellido_327LG = apellido_327LG;
            Email_327LG = email_327LG;
        }
    }
}
