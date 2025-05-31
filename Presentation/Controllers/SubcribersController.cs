using Entities.DataManipulationObject.SubscriberDtos;
using Entities.Exceptions.ProductExceptions;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionsFilters;
using Services.Contracts;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/subscribers")]
    [ApiController]

    [ServiceFilter(typeof(LogFilterAttribute))]
    public class SubcribersController:ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public SubcribersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetSubscribers()
        {
            return Ok(await _serviceManager.SubscriberService.GetAllSubscriberAsync(false));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSubscriber(int id)
        {
            var model=await _serviceManager.SubscriberService.GetOneSubscriberByIdAsync(id,false);
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> Subscribe(CreateSubscriberDto subscriberDto)
        {
            await _serviceManager.SubscriberService.CreateOneSubscriberAsync(subscriberDto);
            return Ok(new { StatusCode = 201, Message = $"One subscriber is created successfully" });

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceManager.SubscriberService.DeleteOneSubscriberAsync(id, false);
            return NoContent();
        }
    }
}
