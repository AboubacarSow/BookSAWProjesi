using Contracts;
using Microsoft.AspNetCore.Mvc;
using MVC.DTOs.SubscriberDtos;
using MVC.Infrastructure.Utilities.Email;
using System.Text.Json;

namespace MVC.Controllers;
public class SubscriberController : Controller
{
    private readonly IServiceManager _serviceManager;
    private readonly EmailService emailService;

    public SubscriberController(IServiceManager serviceManager, EmailService emailService)
    {
        _serviceManager = serviceManager;
        this.emailService = emailService;
    }
    public async Task<IActionResult> Index()
    {
        var  subscribers=await _serviceManager.SubscriberService.GetAll();
        return View(subscribers);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var result=await _serviceManager.SubscriberService.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> SendEmail([FromBody]Message message)
    {
        var result=await emailService.SendEmailAsync(message);
        return result ? Json(new { success = true }) : Json(new { success = false });
    }
}
