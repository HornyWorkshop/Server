using HornyWorkshop.Domain.Database.Models;
using HornyWorkshop.Services.WorkshopService.DataTypes;

namespace HornyWorkshop.Services.WorkshopService.Helpers;

internal static class MapperHelper
{
    internal static void LangIfNotNull(LocaleModel @out, LangInput? @in)
    {
        if (@in is not null)
            Lang(@out, @in);
    }

    internal static void Lang(LocaleModel @out, LangInput @in)
    {
        foreach (var (lang, value) in @in)
        {
            switch (lang)
            {
                case LangVariant.En:
                    @out.En = value;
                    continue;

                case LangVariant.Ru:
                    @out.Ru = value;
                    continue;

                default: throw new NotImplementedException();
            }
        }
    }
}
