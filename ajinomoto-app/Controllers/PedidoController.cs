using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ajinomoto_app.Models;
using ajinomoto_app.Data;
using Microsoft.AspNetCore.Authorization;

namespace ajinomoto_app.Controllers
{
    public class PedidoController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        
        public PedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ListarPedidos(string usuario, decimal precioMenor, decimal precioMayor, string fechaMenor, string fechaMayor)
        {   
            var lista = _context.DataPedidos.Include(p => p.Pago);
            return View(await lista.ToListAsync());
        }
    }
}