using ETickets.ModelView;
using ETickets.Services.UserServic;
using Microsoft.AspNetCore.Mvc;

namespace ETickets.Controllers
{
    public class UserAuth : Controller
    {
        private readonly IUserAuthentication _service;
        public UserAuth(IUserAuthentication service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _service.LoginAsync(model);

            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));

            }


        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            model.Role = "user"; 
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           

            var result = await _service.RegiseringAsync(model);

            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));

            }


        }

        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction(nameof(Login));

        }

        public async Task<IActionResult> rg()
        {
            var model = new RegistrationModel
            {
                Username = "admin",
                Name = "hussein",
                Email = "hussein@gmail.com",
                Password = "Admin@123",
                
            };
            model.Role = "Admin";
            var result = await _service.RegiseringAsync(model);
            return Ok(result);
        }
    }
}
