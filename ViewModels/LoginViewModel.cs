using System;
using SistemaDeCompras.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeCompras.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Informe o usuário")]
    [Display(Name = "Usuário")]
    public string UserName {get;set;}

    [Required(ErrorMessage = "Informe a senha")]
    [DataType(DataType.Password)] //definindo os carcateres no formato de senha
    [Display(Name = "Senha")]
    public string Password{get;set;}

    public string ReturnUrl{get;set;}
}