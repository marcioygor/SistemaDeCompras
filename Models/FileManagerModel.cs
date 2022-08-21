using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace SistemaDeCompras.Models;

public class FileManagerModel
{
    public FileInfo[] Files{get;set;}
    public IFormFile[] IFormFile{get;set;}
    public List<IFormFile> IFormFiles {get;set;}
    public string PathImagensProduto {get;set;}

}
