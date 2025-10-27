using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_327LG
{
    public class BELibro_327LG
    {
        public string ISBN_327LG { get; set; }
        public string titulo_327LG { get; set; }
        public string autor_327LG { get; set; }
        public string editorial_327LG { get; set; }
        public int edicion_327LG { get; set; }

        public BELibro_327LG()
        {
            
        }
        public BELibro_327LG(string iSBN_327LG, string titulo_327LG, string autor_327LG, string editorial_327LG, int edicion_327LG)
        {
            ISBN_327LG = iSBN_327LG;
            this.titulo_327LG = titulo_327LG;
            this.autor_327LG = autor_327LG;
            this.editorial_327LG = editorial_327LG;
            this.edicion_327LG = edicion_327LG;
        }
    }
}
