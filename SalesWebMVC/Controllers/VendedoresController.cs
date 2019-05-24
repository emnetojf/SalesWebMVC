using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exceptions;
using System.Threading.Tasks;

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


        /* sync
        public IActionResult Index()
        {
            var list = _vendedoresService.FindAll();

            return View(list);
            
        }
        */

        //Async
        public async Task<IActionResult> Index()
        {
            var list = await _vendedoresService.FindAllAsync();

            return View(list);

        }

        /* sync        
        public IActionResult Create()
        {
            var departs = _departamentoService.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = departs };

            return View(viewModel);
        }
        */

        // Async
        public async Task<IActionResult> Create()
        {
            var departs = await _departamentoService.FindAllAsync();
            var viewModel = new VendedorFormViewModel { Departamentos = departs };

            return View(viewModel);
        }


        /* sync
        [HttpPost] // anotação 
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            if ( !ModelState.IsValid ) // Se o modelo não foi validado
            {
                var departs = _departamentoService.FindAll();
                VendedorFormViewModel vwModel = new VendedorFormViewModel { Departamentos = departs, Vendedor = vendedor };
                return View(vwModel); // retorna o create repassando meu obj para terminar de consertar
            }

            _vendedoresService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        } 
        */

        //Async
        [HttpPost] // anotação 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid) // Se o modelo não foi validado
            {
                var departs = await _departamentoService.FindAllAsync();
                VendedorFormViewModel vwModel = new VendedorFormViewModel { Departamentos = departs, Vendedor = vendedor };
                return View(vwModel); // retorna o create repassando meu obj para terminar de consertar
            }

            await _vendedoresService.InsertAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }

        /* sync
         
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
        */

        // Async
        public async Task<IActionResult> Delete(int? id) // ? indica que é opcional
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id not provided" });
            }

            var vendedor = await _vendedoresService.FindByIdAsync(id.Value);

            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id inexistente" });
            }

            return View(vendedor);
        }

        /* sync
        [HttpPost] // anotação 
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedoresService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        */

        // Async
        [HttpPost] // anotação 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _vendedoresService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        /* Sync
         
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
        */

        // Async
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id not provided" });
            }

            var vendedor = await _vendedoresService.FindByIdAsync(id.Value);

            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id inexistente" });
            }

            return View(vendedor);
        }

        /* Sync
         
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
        */

        // Async
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id provided" });
            }

            var vendedor = await _vendedoresService.FindByIdAsync(id.Value);

            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id inexistente" });
            }

            List<Departamento> departs = await _departamentoService.FindAllAsync();
            VendedorFormViewModel vwModel = new VendedorFormViewModel { Departamentos = departs, Vendedor = vendedor };


            return View(vwModel);
        }


        /* Sync
         
        [HttpPost] // anotação 
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid) // Se o modelo não foi validado
            {
                var departs = _departamentoService.FindAll();
                VendedorFormViewModel vwModel = new VendedorFormViewModel { Departamentos = departs, Vendedor = vendedor };
                return View(vwModel); // retorna o create repassando minha view model para terminar de consertar
            }

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
        */

        // Async

        [HttpPost] // anotação 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid) // Se o modelo não foi validado
            {
                var departs = await _departamentoService.FindAllAsync();
                VendedorFormViewModel vwModel = new VendedorFormViewModel { Departamentos = departs, Vendedor = vendedor };
                return View(vwModel); // retorna o create repassando minha view model para terminar de consertar
            }

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { Mensagem = "Id diferentes" });
            }

            try
            {
                await _vendedoresService.UpdateAsync(vendedor);
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