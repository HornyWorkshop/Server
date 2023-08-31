using System.ComponentModel.DataAnnotations;

namespace Endpoint.Requests.Common;

public sealed class LocaleCommonRequest
{
    [Required]
    public Locale Locale { get; init; }

    [Required]
    public string Value { get; init; } = string.Empty;
}
