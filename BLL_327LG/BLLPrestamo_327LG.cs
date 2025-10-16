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
    public class BLLPrestamo_327LG
    {
        DALPrestamo_327LG dalPrestamo_327LG;
        BLLEvento_327LG bllEvento_327LG;
        public BLLPrestamo_327LG() 
        {
            dalPrestamo_327LG = new DALPrestamo_327LG();
            bllEvento_327LG = new BLLEvento_327LG();
        }

        public void RegistrarPrestamo_327LG( BECliente_327LG cliente_327LG, BEEjemplar_327LG ejemplar_327LG)
        {
            BEPrestamo_327LG prestamo_327LG = new BEPrestamo_327LG(ejemplar_327LG,cliente_327LG, DateTime.Now.AddDays(30), null, true);
            dalPrestamo_327LG.GuardarPrestamo_327LG(prestamo_327LG);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Préstamos y devoluciones", "Registro de préstamo", 3);

        }
        public List<BEPrestamo_327LG> ObtenerPrestamos_327LG(string? dni)
        {
            return dalPrestamo_327LG.ObtenerPrestamos_327LG(dni);
        }

        public void RegistrarDevolucion_327LG(BEPrestamo_327LG prestamo)
        {
            dalPrestamo_327LG.ActualizarPrestamo_327LG(prestamo);
            bllEvento_327LG.RegistrarEvento_327LG(SessionManager_327LG.Instancia.Usuario.dni_327LG, "Préstamos y devoluciones", "Registro de devolución", 2);

        }
    }
}
