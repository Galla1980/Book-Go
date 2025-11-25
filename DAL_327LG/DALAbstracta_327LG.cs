using Org.BouncyCastle.Bcpg;
using Services_327LG.Observer_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL_327LG
{
    public abstract class DALAbstracta_327LG
    {
        public static string connectionString_327LG = string.Empty;
        static DALAbstracta_327LG()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ConnectionString.json");

            if (!File.Exists(path))
                throw new FileNotFoundException($"No se encontró el archivo de configuración: {path}");

            string json = File.ReadAllText(path);

            var datos = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            if (datos != null && datos.ContainsKey("ConnectionString"))
                connectionString_327LG = datos["ConnectionString"];
            else
                throw new Exception("No se encontró la clave 'ConnectionString' en el archivo JSON.");
        }
            
    }
}
