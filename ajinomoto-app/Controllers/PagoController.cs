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


    }
}