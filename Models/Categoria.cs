using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeCompras.Models;

[Table("Categorias")]
public class Categoria
{
    [Key]
    public int CategoriaId {get;set;}

    [StringLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres")]
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Display(Name = "Nome da categoria")]
    public string CategoriaNome {get;set;}

    [StringLength(200, ErrorMessage = "O tamanho máximo é de 200 caracteres")]
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Display(Name = "Descrição da categoria")]
    public string Descricao {get;set;}
    
    public List<Produto> Produtos {get;set;} //definindo relaciomento 1 para N
}