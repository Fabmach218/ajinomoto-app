using Microsoft.AspNetCore.Mvc;
using ajinomoto_app.Models;
using ajinomoto_app.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;

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
            var productos = from o in _context.DataProductos select o;
            return View(await productos.ToListAsync());
        }

        public async Task<IActionResult> Detalles(int? id)
        {
            Producto objProducto = await _context.DataProductos.FindAsync(id);
            if(objProducto == null){
                return NotFound();
            }

            ViewBag.MyRouteId = id;
            return View(objProducto);
        }
        
     
         public async Task<IActionResult> Agregar( int id)
        {   
          
           Console.WriteLine(id);

            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                List<Producto> productos = new List<Producto>();
                return  RedirectToAction("Catalogo");
            }else{
                var producto = _context.DataProductos.Find(id);
                Proforma proforma;
                
                Proforma itemProforma = _context.DataProforma.FirstOrDefault(p => p.UserID.Equals(userID) && p.Producto == producto && p.Status.Equals("Pendiente"));

                if(itemProforma == null){
                    
                    proforma = new Proforma();
                    proforma.Producto = producto;
                    proforma.Price = producto.Precio;
                    proforma.Quantity = 1;
                    proforma.UserID = userID;
                    _context.Add(proforma);
                    
                }else{
                    itemProforma.Quantity++;
                    _context.Update(itemProforma);
                }
                
                await _context.SaveChangesAsync();
                return  RedirectToAction(nameof(Catalogo));
            }
        }
       
    
       
     

    }
}