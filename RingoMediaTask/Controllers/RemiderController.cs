using Application.IServices;
using Context;
using Microsoft.AspNetCore.Mvc;

namespace RingoMediaTask.Controllers
{
    public class RemiderController : Controller
    {
        private readonly IEmailService _emailService;
        public RemiderController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public async Task<IActionResult> Index()
        {
            await _emailService.SendReminderEmail(0);
            return View();
        }
    }
}
