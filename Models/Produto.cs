using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeCompras.Models;

[Table("Produtos")]
public class Produto
{ 
    [Key]
    public int ProdutoId {get;set;}

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Display(Name = "Nome do Produto")]
    public string Nome {get;set;}

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MinLength(20)]
    [MaxLength(200)]
    public string DescricaoCurta {get;set;}

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MinLength(20)]
    [MaxLength(500)]
    public string DescricaoDetalhada {get;set;}

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Display(Name = "Preço do Produto")]
    public decimal Preco {get;set;}
    public string ImagemUrl {get;set;}
    public string ImagemThumbnailUrl {get;set;}
    public bool IsLanchePreferido {get;set;}
    public bool EmEstoque {get;set;}
    //definindo relacionamento entre as entidades
    public int CategoriaId {get;set;}           
    public virtual Categoria Categoria{get;set;}
}