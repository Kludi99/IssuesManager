using System.Net.Http.Headers;
using System.Text;
using IssuesManager.Core.Interfaces;
using IssuesManager.Core.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace IssuesManager.Core.Services;

public class GitHubService : IIssueService
{
    private readonly HttpClient _httpClient;
    private readonly GitHubOptions _options;

    public GitHubService(IOptions<GitHubOptions> options)
    {
        _options = options.Value;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(_options.Url);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _options.Token);
        _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("IssuesManager", "1.0"));
    }

    public async Task CreateIssue(string title, string body, string repoName)
    {
        var url = $"{_httpClient.BaseAddress}{_options.Owner}/{repoName}/issues";

        var payload = new
        {
            title, body
        };

        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8);
        var response = await _httpClient.PostAsync(url, content);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateIssue(string title, string body, string repoName, int number)
    {
        var url = $"{_httpClient.BaseAddress}{_options.Owner}/{repoName}/issues/{number}";

        var payload = new { title, body };
        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8);

        var response = await _httpClient.PatchAsync(url, content);
        response.EnsureSuccessStatusCode();
    }

    public async Task CloseIssue(string repoName, int number)
    {
        var url = $"{_httpClient.BaseAddress}{_options.Owner}/{repoName}/issues/{number}";

        var payload = new { state = "closed" };
        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8);

        var response = await _httpClient.PatchAsync(url, content);
        response.EnsureSuccessStatusCode();
    }
}