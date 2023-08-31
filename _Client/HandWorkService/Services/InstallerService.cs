using Grpc.Core;
using Service.Protos;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HandWorkService.Services;

public sealed class InstallerService : InstallerServiceProto.InstallerServiceProtoBase, IDisposable
{
    public override Task<InstallResponse> OnGameInstallRequest(InstallRequest request, ServerCallContext context) => Task
        .FromResult(new InstallResponse
        {
            Result = true,
            Message = "Hello",
        });

    public override Task<InstallResponse> OnModInstallRequest(InstallRequest request, ServerCallContext context) => Task
        .FromResult(new InstallResponse
        {
            Result = true,
            Message = "Hello",
        });

    public override Task<InstallResponse> OnCardInstallRequest(InstallRequest request, ServerCallContext context) => Task
        .FromResult(new InstallResponse
        {
            Result = true,
            Message = "Hello",
        });

    public override Task<InstallResponse> OnPluginInstallRequest(InstallRequest request, ServerCallContext context) => Task
        .FromResult(new InstallResponse
        {
            Result = true,
            Message = "Hello",
        });

    public void Dispose() => _httpClient.Dispose();

    public InstallerService(HttpClient httpClient) => _httpClient = httpClient;

    private readonly HttpClient _httpClient;
}
