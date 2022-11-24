using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using obilet.Business.Abstract;
using System.Threading.Tasks;


namespace obilet.MVC.Controllers
{
    public class AccountController : Controller
    {

        private ISessionService _sessionService;
        private ICookieService _cookieService;
        public AccountController(ISessionService sessionService, ICookieService cookieService)
        {
            _sessionService = sessionService;
            _cookieService = cookieService;
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
           var resultCookie =  await _cookieService.CreateCookie(_sessionService.GetSession().Result.Data);
            if (!resultCookie)
            {
                return RedirectToAction("Error", "Home");
            }
            return RedirectToAction("Index", "Home");           
        }

       
        public async Task<IActionResult> Logout()
        {
            await _cookieService.DeleteCookie();

            return RedirectToAction("Login");
        }
        
    }
}
