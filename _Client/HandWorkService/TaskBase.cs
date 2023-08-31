using System.Threading.Tasks;

namespace HandWorkService;

public abstract class TaskBase
{
    public string Guid { get; init; } = "";

    public ValueTask Run() => ValueTask.CompletedTask;
}
