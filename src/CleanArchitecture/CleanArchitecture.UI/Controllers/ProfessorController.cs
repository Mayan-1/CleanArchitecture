using CleanArchitecture.Application.Professors.Create;
using CleanArchitecture.Application.UseCases.Auth.Register;
using CleanArchitecture.Application.UseCases.Professors.Delete;
using CleanArchitecture.Application.UseCases.Professors.Get;
using CleanArchitecture.Application.UseCases.Professors.GetAll;
using CleanArchitecture.Application.UseCases.Professors.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        IMediator _mediator;

        public ProfessorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProfessorResponse>> Get(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetProfessorRequest(id), cancellationToken);
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ICollection<GetAllProfessorResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var reponse = await _mediator.Send(new GetAllProfessorRequest(), cancellationToken);
            return Ok(reponse);
        }


        [HttpPost]
        public async Task<ActionResult> Create(RegisterRequest request)
        {
            var professor = await _mediator.Send(request);
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var deleteProfessorRequest = new DeleteProfessorRequest(id);

            var response = await _mediator.Send(deleteProfessorRequest, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProfessorRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id)
                return BadRequest();

            var response = await _mediator.Send(request);

            return Ok(response);

        }
    }
}
