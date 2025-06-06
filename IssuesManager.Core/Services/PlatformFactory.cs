using IssuesManager.Core.Interfaces;
using IssuesManager.Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace IssuesManager.Core.Services;

public class PlatformFactory :IPlatformFactory
{
    private readonly IServiceProvider _serviceProvider;

    public PlatformFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }


    public IIssueService GetIssueService(Platform platform)
    {
        return platform switch
        {
            Platform.GitHub => _serviceProvider.GetRequiredService<GitHubService>(),
            Platform.GitLab => _serviceProvider.GetRequiredService<GitHubService>(), //TODO: change service
            _ => throw new ArgumentOutOfRangeException(nameof(platform), platform,
                $"Platform {platform} is not supported.")
        };
    }
    
}