namespace IssuesManager.Core.Interfaces;

public interface IIssueService
{
    Task CreateIssue(string title, string body, string repoName);
    Task UpdateIssue(string title, string body, string repoName, int number);
    Task CloseIssue(string repoName, int number);
}