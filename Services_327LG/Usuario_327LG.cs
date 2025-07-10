using Services_327LG.Composite_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_327LG
{
    public class Usuario_327LG
    {
        public string dni_327LG { get; set; }
        public string apellido_327LG { get; set; }
        public string nombre_327LG { get; set; }
        public string userName_327LG { get; set; }
        public string password_327LG { get; set; }
        public BEPerfil_327LG rol_327LG { get; set; }
        public string email_327LG { get; set; }
        public bool bloqueado_327LG { get; set; }
        public bool activo_327LG { get; set; }
        public int intento_327LG { get; set; }
        public string  IdiomaPref_327LG { get; set; }


        public Usuario_327LG() 
        {

        }

        public Usuario_327LG(string dni_327LG, string apellido_327LG, string nombre_327LG, string userName_327LG, string password_327LG, BEPerfil_327LG rol_327LG, string email_327LG, bool bloqueado_327LG, bool activo_327LG, int intento_327LG, string idioma)
        {
            this.dni_327LG = dni_327LG;
            this.apellido_327LG = apellido_327LG;
            this.nombre_327LG = nombre_327LG;
            this.userName_327LG = userName_327LG;
            this.password_327LG = password_327LG;
            this.rol_327LG = rol_327LG;
            this.email_327LG = email_327LG;
            this.bloqueado_327LG = bloqueado_327LG;
            this.activo_327LG = activo_327LG;
            this.intento_327LG = intento_327LG;
            this.IdiomaPref_327LG = idioma; 
        }
    }
}
