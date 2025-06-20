using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_327LG
{
    public class BEEjemplar_327LG
    {
        public int nroEjemplar_327LG { get; set; }
        public Estado_327LG Estado_327LG { get; set; }
        public BELibro_327LG libro_327LG { get; set; }
        public BEEjemplar_327LG(int nroEjemplar_327LG, Estado_327LG estado_327LG, BELibro_327LG libro_327LG)
        {
            this.nroEjemplar_327LG = nroEjemplar_327LG;
            Estado_327LG = estado_327LG;
            this.libro_327LG = libro_327LG;
        }
    }
}