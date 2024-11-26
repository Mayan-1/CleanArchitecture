using CleanArchitecture.Application.UseCases.Auth.Login;
using CleanArchitecture.Application.UseCases.Auth.RefreshToken;
using CleanArchitecture.Application.UseCases.Auth.Register;
using CleanArchitecture.Application.UseCases.Auth.Revoke;
using CleanArchitecture.Application.UseCases.Auth.Role.Create;
using CleanArchitecture.Application.UseCases.Auth.Role.UserToRole;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}
