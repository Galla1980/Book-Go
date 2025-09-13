using BE_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BLL_327LG
{
    public class BLLSerializacion_327LG
    {
        public List<BECliente_327LG> DeserializarClientes_327LG(string ruta)
        {
            var deserializador = new XmlSerializer(typeof(List<BECliente_327LG>));
            List<BECliente_327LG> listaClientes = new List<BECliente_327LG>();
            using (FileStream fs = new FileStream(ruta, FileMode.Open))
            {
                listaClientes = (List<BECliente_327LG>)deserializador.Deserialize(fs);
            }
            return listaClientes;
        }

        public string[] ObtenerArchivo_327LG(string ruta)
        {
            string[] lineas = File.ReadAllLines(ruta);
            return lineas;
        }

        public void SerializarClientes_327LG(List<BECliente_327LG> listaCLientes, string ruta)
        {
            using (FileStream fs = new FileStream(ruta, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<BECliente_327LG>));
                xmlSerializer.Serialize(fs, listaCLientes);
            }
        }
    }
}
