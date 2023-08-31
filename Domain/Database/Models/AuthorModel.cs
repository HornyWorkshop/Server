namespace HornyWorkshop.Domain.Database.Models;

public sealed class AuthorModel
{
    public int Id { get; init; }

    public string Name { get; set; } = string.Empty;

    internal static AuthorModel Empty => new();
}
