namespace IssuesManager.Core.Models;

public abstract class BaseIssueRequest
{
    public Platform Platform { get; set; }
    public string RepositoryName { get; set; }
}