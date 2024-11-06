using CleanArchitecture.Application.Professors.Create;
using CleanArchitecture.Application.UseCases.Professors.Delete;
using CleanArchitecture.Application.UseCases.Professors.GetAll;
using MediatR;
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

        [HttpGet]
        public async Task<ActionResult<ICollection<GetAllProfessorResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var reponse = await _mediator.Send(new GetAllProfessorRequest(), cancellationToken);
            return Ok(reponse);
        }


        [HttpPost]
        public async Task<ActionResult> Create(CreateProfessorRequest request)
        {
            var professorId = await _mediator.Send(request);
            return Ok(professorId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var deleteProfessorRequest = new DeleteProfessorRequest(id);

            var response = await _mediator.Send(deleteProfessorRequest, cancellationToken);
            return Ok(response);
        }
    }
}
