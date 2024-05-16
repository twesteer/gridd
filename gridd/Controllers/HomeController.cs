using gridd.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace gridd.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _context;
        Users userrr;
        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult StartPage()
        {
            return View();
        }

        public IActionResult StartPage2()
        {
            var users = _context.Users.ToList(); // Получение списка пользователей из базы данных
            return View(users);
        }
        [Authorize]
        public IActionResult ProfilePage()
        {
            var users = _context.Users.ToList(); // Получение списка пользователей из базы данных
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                ViewBag.RealName = claimsIdentity.FindFirst("FullName")?.Value;
                ViewBag.Email = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
                ViewBag.Img = claimsIdentity.FindFirst("Img")?.Value;
                ViewBag.NameUser = claimsIdentity.FindFirst("NameUser")?.Value;
                ViewBag.DateOfBirth = claimsIdentity.FindFirst("DateOfBirth")?.Value;
            }

            return View(users);
        }

        public IActionResult WaitPage()
        {
            var users = _context.Users.ToList(); // Получение списка пользователей из базы данных
            return View(users); // Передача списка пользователей в представление
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ActualPage()
        {
            var users = _context.Users.ToList(); // Получение списка пользователей из базы данных
            return View(users); // Передача списка пользователей в представление
        }

        public IActionResult NewsPage()
        {
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult RegistrationPage()
        {
            ViewBag.Countries = _context.Countries.ToList();
            return View();
        }

 
        [HttpPost]
        public IActionResult AddUser(string FullNameUser, string NameUser, string Patronymic, int Age, string Phone, string AddressUser, string Img, string Email, string Pass, int CountryId, string NameCountry)
        {
            // Получаем объект Country из базы данных по его Id
            var country = _context.Countries.FirstOrDefault(c => c.NameCountry == NameCountry);

            // Создаем нового пользователя, передавая полученный объект Country в конструктор
            var user = new Users(FullNameUser, NameUser, Patronymic, Age, Phone, AddressUser, Img, Email, Pass, CountryId)
            {
                FullNameUser = FullNameUser,
                NameUser = NameUser,
                Patronymic = Patronymic,
                Age = Age,
                Phone = Phone,
                AddressUser = AddressUser,
                Img = Img,
                Email = Email,
                Pass = Pass,
                CountryId = CountryId,
             
            };

            // Добавляем пользователя в контекст базы данных и сохраняем изменения
            _context.Users.Add(user);
            _context.SaveChanges();

            // Возвращаем представление "StarPage" из контроллера "Home"
            return RedirectToAction("LoginPage2");
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Pass == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("FullName", user.FullNameUser),
                new Claim("Img", user.Img),
                new Claim("NameUser", user.NameUser),
                new Claim("DateOfBirth", user.Age.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("ProfilePage", "Home");
            }
            else
            {
                ViewBag.Error = "Неверный email или пароль";
                return View(); // Повторно показать форму с сообщением об ошибке
            }
        }



        public IActionResult LoginPage2()
        {
            return View();
        }

    }
}
