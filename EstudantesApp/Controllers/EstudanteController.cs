using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstudantesApp.Persistence.Context;
using EstudantesApp.Transporte;
using EstudantesApp.Dominio.IServices;
using System.Globalization;

namespace EstudantesApp.Controllers
{
    public class EstudanteController : Controller
    {
        private readonly IEstudanteService _estudanteService;

        public EstudanteController(IEstudanteService estudanteService)
        {
            _estudanteService = estudanteService;
        }

        // GET: EstudanteDTOes
        public async Task<IActionResult> Index()
        {
            var estudantes = await _estudanteService.ConsultaEstudantes();
              return View(estudantes);
        }

        // GET: EstudanteDTOes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            EstudanteDTO estudante = await _estudanteService.ConsultaEstudantes(id);
            return View(estudante);
        }

        // GET: EstudanteDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstudanteDTOes/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection colletion)
        {

            try
            {
                EstudanteDTO estudante = Formulario(colletion);
                var resposta = await _estudanteService.CriarEstudante(estudante);

                if (resposta == false)
                {
                    TempData["Error"] = "an error is ocorred in create";
                }
                else
                {
                    TempData["Sucess"] = "Create conclud";
                }
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        private EstudanteDTO Formulario(IFormCollection colletion)
        {
            return new EstudanteDTO
            {
                Id = int.Parse(string.IsNullOrEmpty(colletion["Id"]) ? "0" : colletion["Id"]),
                Nome = colletion["Nome"],
                Sobrenome = colletion["Sobrenome"],
                FechaInscrição = colletion["FechaInscrição"]
            };
        }

        // GET: EstudanteDTOes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            EstudanteDTO estudante = await _estudanteService.ConsultaEstudantes(id);
            return View(estudante);
            
        }

        // POST: EstudanteDTOes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,IFormCollection colletion)
        {
            try
            {
                EstudanteDTO estudante = Formulario(colletion);
                var fecha = "" + colletion["FechaDate"];
                var fechaDate = DateTime.Parse(fecha);
                estudante.FechaInscrição = fechaDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                var resposta = await _estudanteService.EditarEstudantes(estudante);
                if (resposta == false)
                {
                    TempData["Error"] = "an error is ocorred in create";
                }
                else
                {
                    TempData["Sucess"] = "Edtion conclud";
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstudanteDTOes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            EstudanteDTO estudante = await _estudanteService.ConsultaEstudantes(id);

            return View(estudante);
        }

        // POST: EstudanteDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection colletion)
        {
            try
            {
                var resposta= await _estudanteService.DeletarEstudante(id);
                if (resposta == false)
                {
                    TempData["Error"] = "an error is ocorred in create";
                }
                else
                {
                    TempData["Sucess"] = "Count delete with sucess";
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }

        private bool EstudanteDTOExists(int id)
        {
            return true;
        }
    }
}
