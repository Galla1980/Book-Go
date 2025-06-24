using BE_327LG;
using DAL_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLFactura_327LG
    {
        DALFactura_327LG dalFactura_327LG;
        public BLLFactura_327LG()
        {
            dalFactura_327LG = new DALFactura_327LG();
        }

        public void GenerarFactura_327LG(BECliente_327LG cliente, decimal monto,BELibro_327LG libro)
        {
            dalFactura_327LG.GuardarFactura_327LG(new BEFactura_327LG(DateTime.Now, cliente, monto, libro));
        }
    }
}
