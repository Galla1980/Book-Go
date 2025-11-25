using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public class DALBackUpRestore_327LG : DALAbstracta_327LG
    {

        public void HacerBackUp_327LG(string ruta)
        {
            string nombreBackup = $"BookGo.BCK_{DateTime.Now:ddMMyy_HHmm}.bak";
            string rutaCompleta = System.IO.Path.Combine(ruta, nombreBackup);
            string cmdBackUp = $"BACKUP DATABASE SistemaBiblioteca TO DISK='{rutaCompleta}'";
            using (SqlConnection con = new SqlConnection(connectionString_327LG)) 
            {
                SqlCommand cmd = new SqlCommand(cmdBackUp, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void HacerRestore_327LG(string ruta)
        {
            if(!File.Exists(ruta))
            {
                throw new Exception("El archivo de restauración no existe en la ruta especificada.");
            }
            using(SqlConnection con = new SqlConnection(connectionString_327LG))
            {
                con.Open();
                using (SqlCommand setMaster = new SqlCommand("USE master", con))
                {
                    setMaster.ExecuteNonQuery();
                }
                using (SqlCommand setSingleUser = new SqlCommand("ALTER DATABASE SistemaBiblioteca SET SINGLE_USER WITH ROLLBACK IMMEDIATE", con))
                {
                    setSingleUser.ExecuteNonQuery();
                }
                using(SqlCommand cmd = new SqlCommand($"RESTORE DATABASE SistemaBiblioteca FROM DISK='{ruta}' WITH REPLACE", con))
                {
                    cmd.ExecuteNonQuery();
                }
                using(SqlCommand setMultiUser = new SqlCommand("ALTER DATABASE SistemaBiblioteca SET MULTI_USER", con))
                {
                    setMultiUser.ExecuteNonQuery();
                }
            }
        }
    }
}
