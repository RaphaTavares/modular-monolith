﻿using Evently.Common.Domain;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Events.Application.Categories.UpdateCategory;
using Evently.Modules.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Categories;

internal sealed class UpdateCategory : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPut("categories/{id}", async (Guid id, Request request, ISender sender) =>
        {
            Result result = await sender.Send(new UpdateCategoryCommand(id, request.Name));

            return result.Match(() => Results.Ok(), ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Categories);
    }

    internal sealed class Request
    {
        public string Name { get; init; }
    }
}
