using IssuesManager.Core.Interfaces;

namespace IssuesManager.Core.Models;

public class GitLabOptions : IPlatformOptions
{
    public const string PLATFORM_NAME = "GitLab";
    public string Token { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}