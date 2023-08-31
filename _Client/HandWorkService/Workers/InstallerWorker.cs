using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HandWorkService.Workers
{
    public sealed class InstallerWorker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var reader = _channel.Reader;

            await foreach (var task in reader.ReadAllAsync(cancellationToken))
            {
                await task.Run();
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _channel.Writer.Complete();
            return Task.CompletedTask;
        }

        public InstallerWorker(Channel<TaskBase> channel) => _channel = channel;

        private readonly Channel<TaskBase> _channel;
    }
}
