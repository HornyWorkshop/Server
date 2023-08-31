using Endpoint.Application.Commands.Card;
using Endpoint.Database;
using Endpoint.Database.Models.Card;
using Endpoint.Database.Models.File;
using Endpoint.Database.Models.Locale;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Endpoint.Application.Handlers.Card;

public sealed class AddCardHandler : IRequestHandler<AddCardCommand, CardModel>
{
    public async Task<CardModel> Handle(AddCardCommand request, CancellationToken cancellationToken)
    {
        await using var context = await _factory.CreateDbContextAsync(cancellationToken);

        var card = context.Cards.Add(new CardModel
        {
            Name = new LocaleModel
            {
                Ru = request.Name.Ru,
                En = request.Name.En,
                Kr = request.Name.Kr,
                Jp = request.Name.Jp,
            },
            File = Array.Empty<FileModel>()
        }).Entity;

        await context.SaveChangesAsync(cancellationToken);

        return card;
    }

    public AddCardHandler(IDbContextFactory<DatabaseContext> factory) => _factory = factory;

    private readonly IDbContextFactory<DatabaseContext> _factory;

}
