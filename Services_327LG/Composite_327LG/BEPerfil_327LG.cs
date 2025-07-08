using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_327LG.Composite_327LG
{
    public class BEPerfil_327LG
    {
        public int Codigo_327LG { get; set; }
        public string Nombre_327LG { get; set; }
        private List<BEPerfil_327LG> Hijos_327LG = new List<BEPerfil_327LG>();
        public BEPerfil_327LG(int codigo, string Nombre)
        {
            Codigo_327LG = codigo;
            Nombre_327LG = Nombre;
        }

        public override string ToString()
        {
            return $"{Codigo_327LG} - {Nombre_327LG}";
        }

        public virtual void AñadirHijo_327LG(BEPerfil_327LG hijo)
        {
            Hijos_327LG.Add(hijo);
        }
        public virtual void EliminarHijo_327LG(BEPerfil_327LG hijo)
        {
            Hijos_327LG.Remove(hijo);
        }

        public virtual List<BEPerfil_327LG> ObtenerHijos_327LG()
        {
            return Hijos_327LG;
        }
    }
}
