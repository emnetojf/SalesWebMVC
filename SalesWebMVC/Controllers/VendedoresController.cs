using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exceptions;

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

        public IActionResult Delete(int? id) // ? indica que é opcional
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id not provided" });
            }

            var vendedor = _vendedoresService.FindById(id.Value);

            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id inexistente" });
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


        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id not provided" });
            }

            var vendedor = _vendedoresService.FindById(id.Value);

            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id inexistente" });
            }

            return View(vendedor);
        }



        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id provided" });
            }

            var vendedor = _vendedoresService.FindById(id.Value);

            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id inexistente" });
            }

            List<Departamento> departs = _departamentoService.FindAll();
            VendedorFormViewModel vwModel = new VendedorFormViewModel { Departamentos = departs, Vendedor = vendedor };


            return View(vwModel);
        }



        [HttpPost] // anotação 
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id diferentes" });
            }

            try
            {
                _vendedoresService.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = e.Message });
            }
        }

       
        public IActionResult Error(string Mensagem)
        {
            var viewModel = new ErrorViewModel
            {
                Mensagem = Mensagem,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }

    }
}