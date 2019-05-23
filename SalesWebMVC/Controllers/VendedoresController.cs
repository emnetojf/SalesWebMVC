using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;


namespace SalesWebMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedoresService _vendedoresService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedoresService vendedoresService, DepartamentoService departamentoService)
        {
            _vendedoresService = vendedoresService;
            _departamentoService = departamentoService;
        }

    

        public IActionResult Index()
        {
            var list = _vendedoresService.FindAll();
            
            return View(list);
        }

        public IActionResult Create()
        {
            var departs = _departamentoService.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = departs };

            return View(viewModel);
        }

        [HttpPost] // anotação 
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedoresService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

       public IActionResult Delete(int? id ) // ? indica que é opcional
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = _vendedoresService.FindById(id.Value);

            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        [HttpPost] // anotação 
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedoresService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

    }
}