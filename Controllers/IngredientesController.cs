using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NutriYA.Controllers
{
    public class IngredientesController : Controller
    {   
        //int Hola = 3;
        IngredientesRepository repo = new IngredientesRepository();
        //public IngredientesController(IngredientesRepository IngredientesRepo){
        //    repo = IngredientesRepo;
        //}
        // GET: Ingredientes
        public ActionResult Index()
        {
            List<Ingrediente> model = repo.LeerIngrediente();
            System.Threading.Thread.Sleep(1000);
            return View(model);
        }

        // GET: Ingredientes/Details/5
        public ActionResult Details(string PK, string RK)
        {
            System.Threading.Thread.Sleep(1000);
            var model = repo.LeerPorPKRK(PK,RK);
            if(model == null){
                return NotFound();
            }
            return View(model);
        }

        // GET: Ingredientes/Create
        public ActionResult Create()
        {
            var model = new Ingrediente();
            return View(model);
        }

        // POST: Ingredientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ingrediente model)
        {
            try
            {
                var resultado = repo.CrearIngrediente(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Ingredientes/Edit/5
        public ActionResult Edit(string PK, string RK)
        {   
            var model = repo.LeerPorPKRK(PK, RK);
            if(model == null){
                return NotFound();
            }

            return View(model);
        }

        // POST: Ingredientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ingrediente model)
        {   


            if(model == null){
                return NotFound();
            }

            var pack = repo.LeerPorPKRK(model.Nombre, model.OtraCosa);

            try
            {
                pack.Nombre = model.Nombre;
                pack.OtraCosa = model.OtraCosa;


                var resultado = repo.ActualizarIngrediente(pack);
                System.Threading.Thread.Sleep(800);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Ingredientes/Delete/5
        public ActionResult Delete(string PK, string RK)
        {   
            var model = repo.LeerPorPKRK(PK, RK);

            if(model == null){
                return NotFound();
            }

            return View(model);
        }

        // POST: Ingredientes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Ingrediente model, IFormCollection collection)
        {
            if(model == null){
                return NotFound();
            }

            var pack = repo.LeerPorPKRK(model.Nombre, model.OtraCosa);

            try
            {
                System.Threading.Thread.Sleep(1000);
                var resultado = repo.BorrarIngrediente(model);
                System.Threading.Thread.Sleep(1000);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}