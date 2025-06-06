using IssuesManager.Core.Interfaces;
using IssuesManager.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace IssuesManager.Endpoints;

public static class GitEndpoint
{
    public static void MapGitEndpoint(this RouteGroupBuilder api)
    {
        api.MapPost("/issues/create", CreateIssue);

        api.MapPatch("/issues/update", UpdateIssue);

        api.MapPatch("/issues/close", CloseIssue);
    }

    private static async Task<IResult> CreateIssue([FromBody] CreateIssueRequest req,
        [FromServices] IPlatformFactory factory)
    {
        try
        {
            var service = factory.GetIssueService(req.Platform);
            await service.CreateIssue(req.IssueName, req.IssueDescription, req.RepositoryName);
            return Results.Ok("Issue created");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return Results.BadRequest($"Platform not supported: {ex.Message}");
        }
        catch (Exception ex)
        {
            return Results.Problem($"Internal error: {ex.Message}");
        }
    }

    private static async Task<IResult> UpdateIssue([FromBody] UpdateIssueRequest req,
        [FromServices] IPlatformFactory factory)
    {
        try
        {
            var service = factory.GetIssueService(req.Platform);
            await service.UpdateIssue(req.IssueName, req.IssueDescription, req.RepositoryName, req.IssueNumber);
            return Results.Ok("Issue updated");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return Results.BadRequest($"Platform not supported: {ex.Message}");
        }
        catch (Exception ex)
        {
            return Results.Problem($"Internal error: {ex.Message}");
        }
    }

    private static async Task<IResult> CloseIssue([FromBody] CloseIssueRequest req,
        [FromServices] IPlatformFactory factory)
    {
        try
        {
            var service = factory.GetIssueService(req.Platform);
            await service.CloseIssue(req.RepositoryName, req.IssueNumber);
            return Results.Ok("Issue closed");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return Results.BadRequest($"Platform not supported: {ex.Message}");
        }
        catch (Exception ex)
        {
            return Results.Problem($"Internal error: {ex.Message}");
        }
    }
}