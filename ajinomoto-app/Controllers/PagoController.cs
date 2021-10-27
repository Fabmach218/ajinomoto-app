using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ajinomoto_app.Data;
using ajinomoto_app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace ajinomoto_app.Controllers
{
    public class PagoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PagoController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Create(Decimal MontoTotal)
        {
            Pago pago = new Pago();
            pago.UserID = _userManager.GetUserName(User);
            pago.MontoTotal = MontoTotal;
            return View(pago);
        }

        [HttpPost]
        public IActionResult Pagar(Pago pago){
            
            pago.FechaPago = DateTime.Now;
            _context.Add(pago);

            var itemsProforma = from o in _context.DataProforma select o;
            itemsProforma = itemsProforma.
                Include(p => p.Producto).
                Where(p => p.UserID.Equals(pago.UserID) && p.Status.Equals("Pendiente"));
            
            Pedido pedido = new Pedido();
            pedido.UserID = pago.UserID;
            pedido.Total = pago.MontoTotal;
            pedido.Pago = pago;
            pedido.Status = "Pendiente";
            _context.Add(pedido);

            List<DetallePedido> itemsPedido = new List<DetallePedido>();
            foreach(var item in itemsProforma.ToList()){
                DetallePedido detallePedido = new DetallePedido();
                detallePedido.Pedido=pedido;
                detallePedido.Precio = item.Price;
                detallePedido.Producto = item.Producto;
                detallePedido.Cantidad = item.Quantity;
                itemsPedido.Add(detallePedido);
            }

            _context.AddRange(itemsPedido);

            foreach (Proforma p in itemsProforma.ToList())
            {
                p.Status="Procesado";
            }
            _context.UpdateRange(itemsProforma);

            _context.SaveChanges();

            ViewData["Message"] = "El pago se ha registrado";
            return View("Create");


        }


    }
}