using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPIDatingAPP.Entities;

namespace HS.Web.UI.Controllers
{
    public class UsersController : Controller
    {
        Uri baseUrl = new Uri("https://localhost:9999/api");
        private readonly HttpClient _Client;

        public UsersController()
        {
            _Client = new HttpClient();    
            _Client.BaseAddress = baseUrl;  
        }

        public IActionResult Index()
        {
            string data = null;
            HttpResponseMessage response = _Client.GetAsync(_Client.BaseAddress + "/AppUsers").Result;

            if (response.IsSuccessStatusCode)
            {
                 data = response.Content.ReadAsStringAsync().Result;

            }
            var appUsers = JsonConvert.DeserializeObject<IEnumerable<AppUsers>>(data);
            return View("Index", appUsers);
        }
    }
}
