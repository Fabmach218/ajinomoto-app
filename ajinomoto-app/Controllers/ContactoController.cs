using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ajinomoto_app.Models;
using ajinomoto_app.Data;
using Microsoft.EntityFrameworkCore;

namespace ajinomoto_app.Controllers
{
    public class ContactoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacto(Contacto contacto)
        {
            _context.Add(contacto);
            _context.SaveChanges();
            return View("Confirmacion");
        }

        public async Task<IActionResult> ListaContacto()
        {
            return View(await _context.DataContacto.ToListAsync());
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var contacto = await _context.DataContacto.FindAsync(id);
            _context.DataContacto.Remove(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListaContacto));
        }

    }
}
