using Endpoint.Database.Models.Locale;
using Endpoint.Database.Models.File;
using System.Collections.Generic;
using System;

namespace Endpoint.Database.Models.Card;

public class CardModel
{
    public int Id { get; init; }
    
    public virtual IList<FileModel> File { get; init; } = Array.Empty<FileModel>();
    public virtual LocaleModel Name { get; init; } = default!;
}
