namespace HornyWorkshop.Services.WorkshopService;

internal static class Defaults
{
    internal static DirectoryInfo AssetsDirectory = Directory.CreateDirectory(System.IO.Path.Combine(Environment.CurrentDirectory, "wwwroot", "assets"));
    internal static DirectoryInfo UploadsDirectory = Directory.CreateDirectory(System.IO.Path.Combine(Environment.CurrentDirectory, "wwwroot", "uploads"));
}
