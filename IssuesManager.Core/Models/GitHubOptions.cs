﻿using IssuesManager.Core.Interfaces;

namespace IssuesManager.Core.Models;

public class GitHubOptions : IPlatformOptions
{
    public const string PLATFORM_NAME = "GitHub";
    public string Owner { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}