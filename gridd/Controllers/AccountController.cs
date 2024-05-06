using Microsoft.AspNetCore.Mvc;

namespace gridd.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyDbContext _context; // Ваш контекст данных

        public AccountController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult StartPage()
        {
            return View(); // Возвращает представление с формой входа
        }

       
    }
}
