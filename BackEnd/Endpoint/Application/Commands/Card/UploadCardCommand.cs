
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Endpoint.Application.Commands.Card;

public sealed class UploadCardCommand : IRequest
{
    public int Id;
    public IFormFile File { get; init; } = default!;
}