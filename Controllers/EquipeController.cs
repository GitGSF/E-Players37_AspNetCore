using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_Players37_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace E_Players37_AspNetCore.Controllers
{
    public class EquipeController : Controller
    {
        Equipe equipeModel  = new Equipe();
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe equipeModel   = new Equipe();
            equipeModel.IdEquipe = Int32.Parse(form["IdEquipe"]);
            equipeModel.Nome     = form["Nome"];

            // Upload Início
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                equipeModel.Imagem   = file.FileName;
            }
            else
            {
                equipeModel.Imagem   = "padrao.png";
            }
            // Upload Final

            equipeModel.Imagem   = form["Imagem"];

            equipeModel.Create(equipeModel);            
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe");
        }

        [Route("Equipe/{id}")]
        public IActionResult Excluir(int id)
        {
            equipeModel.Delete(id);
            ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipe");
        }
    }
}
