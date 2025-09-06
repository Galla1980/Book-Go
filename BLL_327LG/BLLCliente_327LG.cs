using BE_327LG;
using DAL_327LG;
using Services_327LG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_327LG
{
    public class BLLCliente_327LG
    {
        DALCliente_327LG dalCliente_327LG;
        public BLLCliente_327LG()
        {
            dalCliente_327LG = new DALCliente_327LG();
        }

        public void EliminarCliente_327LG(BECliente_327LG cliente)
        {
            cliente.Activo = false;
            dalCliente_327LG.EliminarCliente_327LG(cliente);
        }

        public void ModificarCliente_327LG(BECliente_327LG clienteModificar)
        {
            clienteModificar.Email_327LG = Encriptador_327LG.EncriptarReversible_327LG(clienteModificar.Email_327LG);
            dalCliente_327LG.ModificarCliente_327LG(clienteModificar);
        }

        public List<BECliente_327LG> ObtenerClientes_327LG()
        {
            List<BECliente_327LG> listaCLientes = dalCliente_327LG.ObtenerTodos_327LG();
            return listaCLientes;
        }

        public void RegistrarCliente_327LG(BECliente_327LG cliente)
        {
            cliente.Email_327LG = Encriptador_327LG.EncriptarReversible_327LG(cliente.Email_327LG);
            dalCliente_327LG.CargarCliente_327LG(cliente);
        }
            
    }
}
