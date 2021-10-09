using Microsoft.AspNetCore.Mvc;
using ajinomoto-app.Models;
using ajinomoto-app.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ajinomoto_app.Controllers
{
    public class CatalogoController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CatalogoController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var productos = from o in _context.DataProductos.FindAsync(id);
            if(objProducto == null){
                return NotFound();
            }
            return View(objProducto);
        }

        public async Task<IActionResult> Add(int? id)
        {
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] = "POR FAVOR, PRIMERO INGRESE A SU CUENTA PARA QUE PUEDA AGREGAR UN PRODUCTO";
                List<Producto> productos = new List<Producto>();
                return View("Index", productos);
            }else{
                var producto = await _context.DataProductos.FindAsync(id);
            }
        }

    }
}