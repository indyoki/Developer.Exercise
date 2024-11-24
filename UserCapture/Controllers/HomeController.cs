using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UserCapture.Data_Storage;
using UserCapture.Models;

namespace UserCapture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserData user)
        {
            if (user == null || (string.IsNullOrEmpty(user.FirstName) && string.IsNullOrEmpty(user.LastName)))
                return View();

            var userService = new UserService();

            user.Id ??= Guid.NewGuid().ToString();
            

            userService.SaveUser(user);

            return UserList();
        }
        public IActionResult UserList()
        {
            var userService = new UserService();
            var users = userService.GetUsers();
            return View("UserList", users);
        }
        public IActionResult Update(string id)
        {
            var userService = new UserService();
            var users = userService.GetUsers();
            var user = users.FirstOrDefault(x => x.Id ==  id);
            ViewData["Action"] = "Update User Details";
            return View("Index", user);
        }

        public IActionResult Delete(string id)
        {
            var userService = new UserService();

            if (!string.IsNullOrEmpty(id))
                userService.DeleteUser(id);

            return UserList();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
