using Microsoft.AspNetCore.Mvc;
using ajinomoto_app.Models;
using ajinomoto_app.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ajinomoto_app.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CatalogoController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Catalogo()
        {
            var productos = from on in _context.DataProductos select o;
            return View(await productos.ToListAsync());
        }

        public async Task<IActionResult> Detalles(int? id)
        {
            Producto objProducto = await _context.DataProductos.FindAsync(id);
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