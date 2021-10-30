using Microsoft.AspNetCore.Mvc;
using ajinomoto_app.Models;
using ajinomoto_app.Data;
using System.Linq;

namespace ajinomoto_app.Controllers
{
public class ContactController:Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View(_context.DataContactos.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact objContacto)
        {
            _context.Add(objContacto);
            _context.SaveChanges();
            ViewData["Message"] = "El contacto ya esta registrado";
            //return RedirectToAction(nameof(Index));
            return View();
        }


        public IActionResult Edit(int id)
        {
            Contact objContacto = _context.DataContactos.Find(id);
            if(objContacto == null){
                return NotFound();
            }
            return View(objContacto);
        }

        [HttpPost]
        public IActionResult Edit(int id,[Bind("Id,Name,Email,Comment,Phone")] Contact objContacto)
        {
             _context.Update(objContacto);
             _context.SaveChanges();
              ViewData["Message"] = "El contacto ya esta actualizado";
             return View(objContacto);
        }

        public IActionResult Delete(int id)
        {
            Contact objContacto = _context.DataContactos.Find(id);
            _context.DataContactos.Remove(objContacto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
} 




}