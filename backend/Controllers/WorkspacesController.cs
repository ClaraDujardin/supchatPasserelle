using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkspacesController : ControllerBase
    {
        private readonly IWorkspaceService _workspaceService;

        public WorkspacesController(IWorkspaceService workspaceService)
        {
            _workspaceService = workspaceService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var workspaces = await _workspaceService.GetAllAsync();
            return Ok(workspaces);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateWorkspaceDto dto)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized("Token invalide.");

            var creatorId = Guid.Parse(userId);
            var workspace = await _workspaceService.CreateAsync(dto, creatorId);
            return Ok(workspace);
        }


        [HttpPost("{id}/members")]
        [Authorize]
        public async Task<IActionResult> AddMember(Guid id, [FromBody] AddMemberDto dto)
        {
            var added = await _workspaceService.AddMemberAsync(id, dto);
            if (!added) return BadRequest("Utilisateur déjà membre.");
            return Ok("Utilisateur ajouté.");
        }
    }
}
