using Microsoft.AspNetCore.Mvc;

namespace gridd.Controllers
{
    public class AccountController : Controller
    {
        private readonly YourDbContext _context; // Ваш контекст данных

        public AccountController(YourDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult StartPage()
        {
            return View(); // Возвращает представление с формой входа
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Pass == password);
            if (user != null)
            {
                // Аутентификация прошла успешно, перенаправление или открытие сессии пользователя
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Неверный email или пароль";
                return View(); // Повторно показать форму с сообщением об ошибке
            }
        }
    }
}
