using CleanArchitecture.Application.UseCases.Auth.Login;
using CleanArchitecture.Application.UseCases.Auth.RefreshToken;
using CleanArchitecture.Application.UseCases.Auth.Register;
using CleanArchitecture.Application.UseCases.Auth.Revoke;
using CleanArchitecture.Application.UseCases.Auth.Role.Create;
using CleanArchitecture.Application.UseCases.Auth.Role.UserToRole;
using CleanArchitecture.Infra.Identity.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace CleanArchitecture.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private UserManager<ApplicationUser> _userManager;

        public AuthController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<ActionResult> CreateRole(CreateRoleRequest request)
        {
            await _mediator.Send(request);
            return Ok($"Role { request.RoleName} added successfully");
        }

        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<ActionResult> AddUserToRole(UserToRoleRequest request)
        {
            await _mediator.Send(request);
            return Ok($"User {request.Email} added to the {request.RoleName} role");
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            var user = await _mediator.Send(request);
            return Ok(user);
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<ActionResult> RefreshToken(RefreshTokenRequest request)
        {
            var token = await _mediator.Send(request);
            return Ok(token);
        }

        [HttpPost]
        [Route("revoke")]
        public async Task<ActionResult> Revoke(RevokeRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
                return BadRequest("UserId and Token are required");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound("User not found");

            var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

            if (result.Succeeded)
                return Ok("Email confirmed successfully!");

            return BadRequest("Error confirming email.");
        }

    }
}
