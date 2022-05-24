using Chat_App.services;
using Chat_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransfersController : Controller
    {
        private readonly ITransferService _service;

        public TransfersController()
        {
            _service = new TransferService();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,To,Content")] Transfer transfer)
        {
            if (ModelState.IsValid)
            {
                _service.Create(transfer.Id, transfer.To, transfer.Content);
                return NoContent();
            }
            return BadRequest();
        }
    }
}
