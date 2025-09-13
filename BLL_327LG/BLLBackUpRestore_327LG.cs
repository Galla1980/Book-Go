using DAL_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLBackUpRestore_327LG
    {
        private DALBackUpRestore_327LG dalBackUpRestore_327LG = new DALBackUpRestore_327LG();

        public bool ExisteBackUp_327LG(string ruta)
        {
            string nombreBackup = $"BookGo.BCK_{DateTime.Now:ddMMyy_HHmm}.bak";
            string rutaCompleta = System.IO.Path.Combine(ruta, nombreBackup);
            return File.Exists(rutaCompleta);
        }

        public void HacerBackUp_327LG(string ruta)
        {
            dalBackUpRestore_327LG.HacerBackUp_327LG(ruta);
        }

        public void HacerRestore_327LG(string ruta)
        {
            dalBackUpRestore_327LG.HacerRestore_327LG(ruta);
        }
    }
}
