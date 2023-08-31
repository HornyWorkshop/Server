namespace HornyWorkshop.Services.WorkshopService.Extensions;

internal static class IEnumerableExtension
{
    internal static async ValueTask<bool> AllAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, ValueTask<bool>> predicate, CancellationToken ct)
    {
        foreach (var item in source)
        {
            ct.ThrowIfCancellationRequested();

            if (await predicate(item) is false)
                return false;
        }

        return true;
    }
}
