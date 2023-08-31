namespace HornyWorkshop.Domain.Database.Models;

public sealed class LocaleModel
{
    public int Id { get; init; }

    public string En { get; set; } = string.Empty;
    public string Ru { get; set; } = string.Empty;

    internal static LocaleModel Empty => new();
}
