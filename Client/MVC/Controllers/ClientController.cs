using Contracts;
using Microsoft.AspNetCore.Mvc;
using MVC.DTOs.SubscriberDtos;

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
        public async Task<IActionResult> Subscribe([FromBody]CreateSubscriberDto subscriber)
        {
            var result=await _service.SubscriberService.Subscribe(subscriber);
            return result? Json(new {success=true}) : Json(new {success=false});
        }
    }
}
