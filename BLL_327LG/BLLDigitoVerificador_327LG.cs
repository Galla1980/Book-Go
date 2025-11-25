using BE_327LG;
using DAL_327LG;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLDigitoVerificador_327LG
    {
        private readonly DALDigitoVerificador_327LG dalDigito;

        public BLLDigitoVerificador_327LG()
        {
            dalDigito = new DALDigitoVerificador_327LG();
            
        }

        public void GuardarDigitoVerificador_327LG(BEDigitoVerificador_327LG digito) 
        {
            digito.DigitoVerificadorHorizontal_327LG = dalDigito.CalcularDigitoVerificadorHorizontal_327LG(digito);
            digito.DigitoVerificadorVertical_327LG = dalDigito.CalcularDigitoVerificadorVertical_327LG(digito);
            dalDigito.GuardarDigitoVerificador_327LG(digito);
        }

        public List<string> CompararDigito_327LG()
        {
            List<string> lista = new List<string>();
            foreach(BEDigitoVerificador_327LG item in dalDigito.ObtenerTodos_327LG())
            {
                if(dalDigito.CalcularDigitoVerificadorHorizontal_327LG(item) != item.DigitoVerificadorHorizontal_327LG || dalDigito.CalcularDigitoVerificadorVertical_327LG(item) != item.DigitoVerificadorVertical_327LG)
                {
                    lista.Add(item.NombreTabla_327LG);
                }
            }
            return lista;
        }

        public List<BEDigitoVerificador_327LG> ObtenerTodos_327LG()
        {
            return dalDigito.ObtenerTodos_327LG();
        }
    }
}
