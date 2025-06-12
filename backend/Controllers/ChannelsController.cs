using System.Security.Claims;
using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelService _channelService;

        public ChannelsController(IChannelService channelService)
        {
            _channelService = channelService;
        }

        [HttpGet("workspace/{workspaceId}")]
        [Authorize]
        public async Task<IActionResult> GetAllInWorkspace(Guid workspaceId)
        {
            var channels = await _channelService.GetAllInWorkspaceAsync(workspaceId);
            return Ok(channels);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateChannelDto dto)
        {
            var creatorId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var channel = await _channelService.CreateAsync(dto, creatorId);
            return Ok(channel);
        }


        [HttpPost("{channelId}/members")]
        [Authorize]
        public async Task<IActionResult> AddMember(Guid channelId, [FromBody] AddChannelMemberDto dto)
        {
            var added = await _channelService.AddMemberAsync(channelId, dto);
            if (!added) return BadRequest("Utilisateur déjà membre du canal.");
            return Ok("Utilisateur ajouté au canal.");
        }
    }
}
