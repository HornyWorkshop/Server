using Endpoint.Application.Commands.Card;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Endpoint.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UploadController : ControllerBase
{
    [HttpPost("card/{id}")]
    public Task Post(int id, [FromForm] IFormFile file, IMediator mediator, CancellationToken cancellationToken)
    {
        var command = new UploadCardCommand
        {
            Id = id,
            File = file,
        };

        return mediator.Send(command, cancellationToken);
    }
}
