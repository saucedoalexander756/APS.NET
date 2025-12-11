using ApiVete.Context;
using ApiVete.Models;
using ApiVete.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiVete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly ApiDbContext _db;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IJwtService jwtService, ApiDbContext db, ILogger<AuthController> logger)
        {
            _jwtService = jwtService;
            _db = db;
            _logger = logger;
        }

        // POST: api/Auth/register
        // Permite crear un usuario (útil para pruebas). En producción proteger o eliminar.
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (request is null || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Usuario y contraseña requeridos." });
            }

            var exists = await _db.Usuarios.AnyAsync(u => u.Username == request.Username);
            if (exists)
            {
                return Conflict(new { message = "El nombre de usuario ya existe." });
            }

            var user = new Usuario
            {
                Username = request.Username,
                PasswordHash = PasswordHasher.CreateHash(request.Password),
                Role = request.Role ?? "User"
            };

            _db.Usuarios.Add(user);
            await _db.SaveChangesAsync();

            return CreatedAtAction(null, new { username = user.Username });
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request is null || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Usuario/contraseña requeridos." });
            }

            try
            {
                var user = await _db.Usuarios.SingleOrDefaultAsync(u => u.Username == request.Username);
                if (user == null)
                {
                    _logger.LogWarning("Login fallido: usuario no encontrado {User}", request.Username);
                    return Unauthorized(new { message = "Usuario o contraseña incorrectos." });
                }

                if (!PasswordHasher.Verify(request.Password, user.PasswordHash))
                {
                    _logger.LogWarning("Login fallido: contraseña incorrecta {User}", request.Username);
                    return Unauthorized(new { message = "Usuario o contraseña incorrectos." });
                }

                var token = _jwtService.GenerateToken(user.Username, new Dictionary<string, string>
                {
                    { System.Security.Claims.ClaimTypes.Role, user.Role ?? "User" }
                });

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en Login para {User}", request.Username);
                return StatusCode(500, new { message = "Error interno al procesar la autenticación." });
            }
        }
    }
}