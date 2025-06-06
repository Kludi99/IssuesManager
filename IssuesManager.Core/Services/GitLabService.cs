﻿using System.Text;
using IssuesManager.Core.Interfaces;
using IssuesManager.Core.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace IssuesManager.Core.Services;

public class GitLabService : IIssueService
{
    private readonly HttpClient _httpClient;
    private readonly GitLabOptions _options;

    public GitLabService(IOptions<GitLabOptions> options)
    {
        _options = options.Value;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(_options.Url);
        _httpClient.DefaultRequestHeaders.Add("PRIVATE-TOKEN", _options.Token);
    }

    public async Task CreateIssue(string title, string body, string projectPath)
    {
        var encodedProject = Uri.EscapeDataString(projectPath);
        var url = $"{encodedProject}/issues";

        var payload = new
        {
            title, body
        };

        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8, @"application/json");
        var response = await _httpClient.PostAsync(url, content);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateIssue(string title, string body, string projectPath, int number)
    {
        var encodedProject = Uri.EscapeDataString(projectPath);
        var url = $"{encodedProject}/issues/{number}";
        var payload = new { title, body };
        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8, @"application/json");

        var response = await _httpClient.PutAsync(url, content);
        response.EnsureSuccessStatusCode();
    }

    public async Task CloseIssue(string projectPath, int number)
    {
        var encodedProject = Uri.EscapeDataString(projectPath);
        var url = $"{encodedProject}/issues/{number}";

        var payload = new { state_event = "close" };
        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8, @"application/json");

        var response = await _httpClient.PutAsync(url, content);
        response.EnsureSuccessStatusCode();
    }
}