using _04_Data.Data;
using System.Collections.Generic;

namespace _04_Data.ViewModels
{
    public class ClientesEmpleadosNavierasPedidoViewModel
    {
        public IList<Cliente> clientes { get; set; }
        public IList<Empleado> empleados { get; set; }
        public IList<Naviera> navieras { get; set; }
        public Pedido pedido { get; set; }
    }
}
