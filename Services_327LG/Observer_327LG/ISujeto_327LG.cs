using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_327LG.Observer_327LG
{
    public interface ISujeto_327LG
    {
        void AgregarObservador_327LG(IObserverIdioma_327LG observador);
        void EliminarObservador_327LG(IObserverIdioma_327LG observador);
        void NotificarObservadores_327LG();
    }
}
