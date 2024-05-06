using EmailSender.API.Data.Interfaces;
using EmailSender.API.Domain.Entities;
using EmailSender.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        private readonly IEmailService _service;
        public SendController(IEmailService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult SendEmail([FromBody] SendEmailDto dto)
        {
            var newEmail = new EmailEntity(dto.ReceiverEmailAddress,dto.EmailContent);
            _service.SendEmail(newEmail);
            return Ok();
        }
    }
}
