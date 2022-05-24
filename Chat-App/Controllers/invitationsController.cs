using Chat_App.services;
using Chat_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class invitationsController : Controller
    {
        private readonly IInvitationService _service;

        public invitationsController()
        {
            _service = new InvitationService();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,To,Server")] Invitations invitation)
        {
            if (ModelState.IsValid)
            {
                _service.Create(invitation.Id, invitation.To, invitation.Server);
                return NoContent();
            }
            return BadRequest();
        }
    }
}
