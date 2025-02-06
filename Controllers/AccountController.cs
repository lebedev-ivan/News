using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News.Domain;
using System.Threading.Tasks;

namespace News.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Для GET запроса, чтобы отобразить форму входа
        public IActionResult Login()
        {
            return View();
        }

        // Для POST запроса для авторизации
        [HttpPost]
        public async Task<IActionResult> Login(string name, string password)
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                ViewBag.Message = "Неверное имя или пароль";
                return View("Login");
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (!result.Succeeded)
            {
                ViewBag.Message = "Неверное имя или пароль";
                return View("Login");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(string name, string password)
        {
            var user = new IdentityUser { UserName = name };

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                // После успешной регистрации перенаправляем на страницу входа
                return RedirectToAction("Login", "Account");
            }

            // Если возникла ошибка при регистрации, показываем сообщение
            ViewBag.Message = "Ошибка при регистрации";
            return View();
        }

    }
}
