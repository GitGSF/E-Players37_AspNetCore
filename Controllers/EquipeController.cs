using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_Players37_AspNetCore.Models;
using Microsoft.AspNetCore.Http;

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
            equipeModel.Imagem   = form["Imagem"];

            equipeModel.Create(equipeModel);            
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe");
        }
    }
}
