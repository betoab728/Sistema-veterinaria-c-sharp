using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Interfaces
{
    public interface IPedido
    {
        int Agregar(Pedido pedido, List<DetallePedido> detallepedido, List<ProductoVitrina> productoVitrinas, Movimiento movimiento, List<Entrada> entrada);
        DataTable DetallePedido(int idPedido);
        DataTable ImprimirPedido(int idped);
    }
}
