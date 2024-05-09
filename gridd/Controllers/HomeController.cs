using gridd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
            return View("StartPage");
        }
        [HttpPost]
        public IActionResult Login( string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Pass == password);
            if (user != null)
            {
                userrr = user;
                ViewBag.DateOfBirth = userrr.Age;
                ViewBag.RealName = userrr.FullNameUser;
                ViewBag.Email = userrr.Email;
                ViewBag.Img= userrr.Img;
                ViewBag.NameUser = userrr.NameUser;
                return View("ProfilePage");
                
            }
            
            else
            {
                ViewBag.Error = "Неверный email или пароль";
                return View(); // Повторно показать форму с сообщением об ошибке
            }
        }
      

    }
}
