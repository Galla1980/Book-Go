using BE_327LG;
using DAL_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLLibro_327LG
    {
        DALLibro_327LG dalLibro_327LG;
        public BLLLibro_327LG() 
        {
            dalLibro_327LG = new DALLibro_327LG();
        }

        public void CargarLibro_327LG(BELibro_327LG libro)
        {
            dalLibro_327LG.AgregarLibro_327LG(libro);
        }

        public List<BELibro_327LG> FiltrarLibros_327LG(string? isbn, string? titulo_327LG, string? autor_327LG, string? editorial_327LG, int? edicion_327LG)
        {
            return dalLibro_327LG.BuscarLibros_327LG(isbn, titulo_327LG, autor_327LG, editorial_327LG, edicion_327LG);
        }

        public List<BELibro_327LG> ObtenerLibros_327LG()
        {
            return dalLibro_327LG.ListarLibros_327LG();
        }
    }
}