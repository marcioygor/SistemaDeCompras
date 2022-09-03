using System.Reflection;
using System.Security.AccessControl;
using System;
using SistemaDeCompras.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace SistemaDeCompras.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminImagensController : Controller
    {
        private readonly ConfigurationImagens _myConfig;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminImagensController(IWebHostEnvironment hostEnvironment, 
        IOptions<ConfigurationImagens> myConfiguration)
        {
            _hostEnvironment=hostEnvironment;
            _myConfig=myConfiguration.Value;

        }

        public IActionResult Index()
        {
            return View();
        }

            public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }

            if (files.Count > 10)
            {
                ViewData["Erro"] = "Error: Quantidade de arquivos excedeu o limite";
                return View(ViewData);
            }

            long size = files.Sum(f => f.Length);

            var filePathsName = new List<string>();

            var filePath = Path.Combine(_hostEnvironment.WebRootPath,
                _myConfig.NomePastaImagensProdutos);

            foreach (var formFile in files)
            {
                if (formFile.FileName.Contains(".jpg") || formFile.FileName.Contains(".gif")
                    || formFile.FileName.Contains(".png"))
                {
                    var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);

                    filePathsName.Add(fileNameWithPath);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }

                else
                {
                    ViewData["Resultado"] = "Não é permitido enviar arquivos com este formato.";
                    return View(ViewData);
                }
            }

            ViewData["Resultado"] = $"{files.Count} arquivos foram enviados ao servidor, " +
                                     $"com tamanho total de : {size} bytes";

            ViewBag.Arquivos = filePathsName;

            return View(ViewData);
        }

        public async Task<IActionResult> GetImagens(){
           FileManagerModel model = new FileManagerModel();

            //Capturando caminho do servidor.
            var userImagesPath = Path.Combine(_hostEnvironment.WebRootPath,
                 _myConfig.NomePastaImagensProdutos);

            //Capturando arquivos.
            DirectoryInfo dir = new DirectoryInfo(userImagesPath);
            FileInfo[] files = dir.GetFiles();
            model.PathImagensProduto = _myConfig.NomePastaImagensProdutos;

            if (files.Length == 0)
            {
                ViewData["Erro"] = $"Nenhum arquivo encontrado na pasta {userImagesPath}";
            }

            model.Files = files;
            return View(model);
        }

        public async Task<IActionResult> DeleteFile(string fname){

            string _imagemDeleta=Path.Combine(_hostEnvironment.WebRootPath,
                 _myConfig.NomePastaImagensProdutos + "\\", fname);

             if(System.IO.File.Exists(_imagemDeleta)){
                System.IO.File.Delete(_imagemDeleta);
                 ViewData["Deletado"] = $"Arquivo(s) {_imagemDeleta} deletado com sucesso";
             }


             return View("index");
        }


       
    }
}
