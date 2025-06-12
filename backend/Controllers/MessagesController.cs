using System.Security.Claims;
using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("channel/{channelId}")]
        [Authorize]
        public async Task<IActionResult> GetByChannel(Guid channelId)
        {
            var messages = await _messageService.GetMessagesByChannelAsync(channelId);
            return Ok(messages);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateMessageDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("Token invalide ou manquant.");

            if (!Guid.TryParse(userIdClaim, out Guid userId))
                return Unauthorized("ID utilisateur invalide dans le token.");

            var message = await _messageService.CreateMessageAsync(dto, userId);
            return Ok(message);
        }
    }
}
