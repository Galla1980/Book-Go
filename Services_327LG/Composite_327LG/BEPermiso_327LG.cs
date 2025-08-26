using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_327LG.Composite_327LG
{
    public class BEPermiso_327LG : BEPerfil_327LG
    {
        public BEPermiso_327LG(int Codigo, string Nombre) : base(Codigo, Nombre)
        {
        }

        public override void AñadirHijo_327LG(BEPerfil_327LG hijo)
        {
            throw new InvalidOperationException("No se pueden añadir hijos a un permiso.");
        }
        public override void EliminarHijo_327LG(BEPerfil_327LG hijo)
        {
            throw new InvalidOperationException("No se pueden eliminar hijos de un permiso.");
        }

        public override List<BEPerfil_327LG> ObtenerHijos_327LG()
        {
            throw new InvalidOperationException("Un permiso no tiene hijos.");
        }
    }
}
