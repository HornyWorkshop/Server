using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Endpoint.Requests.Common;
using Microsoft.AspNetCore.Http;

namespace Endpoint.Requests.Card;

public sealed record CardCreateRequest
{
    [Required]
    public IFormFile File { get; init; } = default!;

    [Required]
    public IReadOnlyCollection<LocaleCommonRequest> Name { get; init; } = default!;
}
