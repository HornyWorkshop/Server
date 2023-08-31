
namespace Endpoint.Database.Models;

public enum ContentType
{

}

public sealed class ModerateModel
{
    public int Id {  get; init; }
    public int ContentId { get; init; }
    public ContentType ContentType { get; init; }
}
