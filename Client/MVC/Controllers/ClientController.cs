using Contracts;
using Microsoft.AspNetCore.Mvc;
using MVC.DTOs.SubscriberDtos;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class ClientController : Controller
    {
        private IServiceManager _service;

        public ClientController(IServiceManager service)
        {
            _service = service;
        }

        public IActionResult Home()
        {
            return View();
        }
        public async Task<IActionResult> Subscribe(CreateSubscriberDto subscriber)
        {
            await _service.SubscriberService.Subscribe(subscriber);
            return Json(new {success= true});   
        }
    }
}
