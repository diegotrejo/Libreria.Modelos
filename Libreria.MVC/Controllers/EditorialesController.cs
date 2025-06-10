﻿using Libreria.Modelos;
using Librerria.API.Consumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.MVC.Controllers
{
    public class EditorialesController : Controller
    {
        // GET: EditorialesController
        public ActionResult Index()
        {
            var data = Crud<Editorial>.GetAll();
            return View(data);
        }

        // GET: EditorialesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Editorial>.GetById(id);
            return View(data);
        }

        // GET: EditorialesController/Create
        public ActionResult Create()
        {
            ViewBag.Paises = GetPaises();
            //ViewData["Paises"] = GetPaises();
            return View();
        }

        private List<SelectListItem> GetPaises() { 
            var paises = Crud<Pais>.GetAll();
            return paises.Select(p => new SelectListItem
            {
                Value = p.Codigo.ToString(),
                Text = p.Nombre
            }).ToList();
        }

        // POST: EditorialesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Editorial data)
        {
            try
            {
                Crud<Editorial>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch( Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: EditorialesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Editorial>.GetById(id);
            ViewBag.Paises = GetPaises();
            return View(data);
        }

        // POST: EditorialesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Editorial data)
        {
            try
            {
                Crud<Editorial>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: EditorialesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Editorial>.GetById(id);
            return View(data);
        }

        // POST: EditorialesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Editorial data)
        {
            try
            {
                Crud<Editorial>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}
