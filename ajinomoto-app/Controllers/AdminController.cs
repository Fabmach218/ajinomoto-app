using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ajinomoto_app.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller 
    {
        
      
      public IActionResult Panel(){

           return View();

      }

    }
}