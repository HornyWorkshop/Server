using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Service.Protos;
using System.Threading.Tasks;

namespace HandWorkService.Services;

public sealed class TaskService : TaskServiceProto.TaskServiceProtoBase
{
    public override async Task OnList(Empty request, IServerStreamWriter<TaskResponse> responseStream, ServerCallContext context)
    {
        for (var i = 1; i <= 18; ++i)
        {
            await responseStream.WriteAsync(new TaskResponse
            {
                Guid = $"asd-{i}",
                Parts = (uint)i
            });

            await Task.Delay(500);
        }
    }

    public override async Task OnUpdate(Empty request, IServerStreamWriter<TaskResponse> responseStream, ServerCallContext context)
    {
        for (var i = 1; i <= 18; ++i)
        {
            await responseStream.WriteAsync(new TaskResponse
            {
                Guid = $"asd-{i}",
                Parts = (uint)i
            });

            await Task.Delay(100);
        }
    }
}
