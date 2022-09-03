using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace SistemaDeCompras.Models;

public class ProdutoGrafico
{
    public string ProdutoNome {get;set;}
    public int ProdutosQuantidade {get;set;}
    public decimal ProdutosValorTotal{get;set;}

}
