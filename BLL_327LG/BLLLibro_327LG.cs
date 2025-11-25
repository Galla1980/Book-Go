using BE_327LG;
using DAL_327LG;
using Services_327LG.Singleton_327LG;
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
        private readonly BLLEvento_327LG bllEvento_327LG = new BLLEvento_327LG();
        private readonly BLLDigitoVerificador_327LG bllDigitoVerificador_327LG = new BLLDigitoVerificador_327LG();

        public BLLLibro_327LG() 
        {
            dalLibro_327LG = new DALLibro_327LG();
        }

        public void CargarLibro_327LG(BELibro_327LG libro)
        {
            dalLibro_327LG.AgregarLibro_327LG(libro);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG,"Maestro libros", "Agregado nuevo libro" , 5);
            bllDigitoVerificador_327LG.GuardarDigitoVerificador_327LG(new BEDigitoVerificador_327LG("Libro_327LG"));

        }

        public void EliminarLibro_327LG(BELibro_327LG libroEliminar)
        {
            dalLibro_327LG.EliminarLibro_327LG(libroEliminar);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Maestro libros", "Eliminado libro", 4);
            bllDigitoVerificador_327LG.GuardarDigitoVerificador_327LG(new BEDigitoVerificador_327LG("Libro_327LG"));

        }

        public List<BELibro_327LG> FiltrarLibros_327LG(string? isbn, string? titulo_327LG, string? autor_327LG, string? editorial_327LG, int? edicion_327LG)
        {
            return dalLibro_327LG.BuscarLibros_327LG(isbn, titulo_327LG, autor_327LG, editorial_327LG, edicion_327LG);
        }

        public void ModificarLibro_327LG(BELibro_327LG libroModificado)
        {
            dalLibro_327LG.ModificarLibro_327LG(libroModificado);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Maestro libros", "Modificación libro", 5);
            bllDigitoVerificador_327LG.GuardarDigitoVerificador_327LG(new BEDigitoVerificador_327LG("Libro_327LG"));
        }

        public List<BELibro_327LG> ObtenerLibros_327LG()
        {
            return dalLibro_327LG.ListarLibros_327LG();
        }

        public List<BELibro_327LG> ObtenerTodosLibros_327LG()
        {
            return dalLibro_327LG.ObtenerTodosLibros_327LG();
        }
    }
}