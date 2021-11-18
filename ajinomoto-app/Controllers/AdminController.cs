using Microsoft.AspNetCore.Mvc;
using ajinomoto_app.Data;
using Microsoft.AspNetCore.Authorization;

namespace ajinomoto_app.Controllers
{
    
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context){
            _context = context;
        }

        public IActionResult Panel(){
            return View();
        }

    }
}