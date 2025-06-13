using Backend.Data;
using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var user = await _userService.RegisterAsync(dto);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            var token = await _userService.LoginAsync(dto);
            if (token == null) return Unauthorized("Email ou mot de passe incorrect.");
            return Ok(new { token });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }


        [HttpPost("{id}/profile-picture")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadProfilePicture(
            Guid id,
            IFormFile file,
            [FromServices] IWebHostEnvironment env,
            [FromServices] ApplicationDbContext context)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Fichier invalide.");

            var rootPath = env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var uploadsDir = Path.Combine(rootPath, "profiles");

            if (!Directory.Exists(uploadsDir))
                Directory.CreateDirectory(uploadsDir);

            var fileName = $"{id}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadsDir, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            var user = await context.Users.FindAsync(id);
            if (user == null) return NotFound();

            user.ProfilePictureUrl = $"/profiles/{fileName}";
            await context.SaveChangesAsync();

            return Ok(new { url = user.ProfilePictureUrl });
        }
        
        [HttpPost("{userId}/test-notif")]
        public async Task<IActionResult> TestNotification(Guid userId, [FromServices] INotificationService notifService)
        {
            await notifService.SendAsync(userId, "test", "Ceci est une notification test");
            return Ok("Notification envoyée.");
        }

    }
}
