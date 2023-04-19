using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModel;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace prjMvcCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CLoginViewModel vm)
        {
            TCustomer user = new dbDemoContext().TCustomers.FirstOrDefault(
                t=>t.FEmail.Equals(vm.txtAccount)&&t.FPassword.Equals(vm.txtPassword));
            if(user !=null&&user.FPassword.Equals(vm.txtPassword))
            {
                string json =JsonSerializer.Serialize(user);
                HttpContext.Session.SetString(CDictionary.SK_LOGINED_USER, json);
                return RedirectToAction("Index");
            }
            return View();
        }
        public string demoObj2Json()
        {
            TCustomer x = new TCustomer()
            {
                Fid=1,
                FName="Marco",
                FPhone="092569784315",
                FEmail="Marco@gmail.com",
                FAddress="Taipei",
                FPassword="123"
            };
            string json =JsonSerializer.Serialize(x);
            return json;
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USER))
                return View();
            return RedirectToAction("Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}