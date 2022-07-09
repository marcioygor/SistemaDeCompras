using System.Collections.Generic;
using SistemaDeCompras.Models;

namespace SistemaDeCompras.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        //IEnumerable<Pedido> Pedidos{get;}

        void CriarPedido(Pedido pedido);
    }
}