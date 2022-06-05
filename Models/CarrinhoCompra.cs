using System;
using SistemaDeCompras.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SistemaDeCompras.Models;

public class CarrinhoCompra
{
    public readonly Context _context;

    public CarrinhoCompra(Context context)
    {
        _context = context;
    }

    public string CarrinhoCompraId { get; set; }
    public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

    public static CarrinhoCompra GetCarrinho(IServiceProvider services)
    {
        //Define uma sessão
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        //obtem o serviço do contexto.
        var context = services.GetService<Context>();

        //obtem ou gera o id do carrinho.
        string carrinhoid = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

        session.SetString("CarrinhoId", carrinhoid);

        //retorna o carrinho com o contexto e o id
        return new CarrinhoCompra(context)
        {
            CarrinhoCompraId = carrinhoid
        };
    }

    public void AdicionarAoCarrinho(Produto produto)
    {
        var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                 s => s.Produto.ProdutoId == produto.ProdutoId &&
                 s.CarrinhoCompraId == CarrinhoCompraId);

        if (carrinhoCompraItem == null)
        {
            carrinhoCompraItem = new CarrinhoCompraItem
            {
                CarrinhoCompraId = CarrinhoCompraId,
                Produto = produto,
                Quantidade = 1
            };
            _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
        }
        else
        {
            carrinhoCompraItem.Quantidade++;
        }
        _context.SaveChanges();
    }

    public int RemoverDoCarrinho(Produto produto)
    {
        //verificando se o produto existe na tabela CarrinhoCompraItens
        var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
               s => s.Produto.ProdutoId == produto.ProdutoId &&
               s.CarrinhoCompraId == CarrinhoCompraId);

        var quantidadeLocal = 0;

        if (carrinhoCompraItem != null)
        {
            if (carrinhoCompraItem.Quantidade > 1)
            {
                carrinhoCompraItem.Quantidade--;
                quantidadeLocal = carrinhoCompraItem.Quantidade;
            }
            else
            {
                _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
            }
        }
        _context.SaveChanges();
        return quantidadeLocal;
    }

    public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
    {
        return CarrinhoCompraItens ??
               (CarrinhoCompraItens =
                   _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                       .Include(s => s.Produto)
                       .ToList());
    }

    public void LimparCarrinho()
    {
        var carrinhoItens = _context.CarrinhoCompraItens
                             .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

        _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
        _context.SaveChanges();
    }

    public decimal GetCarrinhoCompraTotal()
    {
        var total = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
            .Select(c => c.Produto.Preco * c.Quantidade).Sum();
        return total;
    }
}