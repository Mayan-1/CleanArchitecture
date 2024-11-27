using CleanArchitecture.Application.UseCases.Auth.ConfirmEmail;
using CleanArchitecture.Application.UseCases.Auth.RefreshToken;
using CleanArchitecture.Application.UseCases.Auth.Revoke;
using CleanArchitecture.Application.UseCases.Auth.Role.Create;
using CleanArchitecture.Application.UseCases.Auth.Role.UserToRole;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ForgotPasswordRequest = CleanArchitecture.Application.UseCases.Auth.ForgotPassword.ForgotPasswordRequest;
using LoginRequest = CleanArchitecture.Application.UseCases.Auth.Login.LoginRequest;
using ResetPasswordRequest = CleanArchitecture.Application.UseCases.Auth.ResetPassword.ResetPasswordRequest;

namespace CleanArchitecture.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create-role")]
        public async Task<ActionResult> CreateRole(CreateRoleRequest request)
        {
            await _mediator.Send(request);
            return Ok($"Role { request.RoleName} added successfully");
        }

        [HttpPost]
        [Route("add-user-to-role")]
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
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
        {
            await _mediator.Send(request);
            return Ok("Password reset link has been sent to your email.");
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            await _mediator.Send(request);
            return Ok("Password reset sucessfully");
        }
        

        

    }
}
