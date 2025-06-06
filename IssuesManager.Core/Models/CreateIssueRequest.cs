namespace IssuesManager.Core.Models;

public class CreateIssueRequest : BaseIssueRequest
{
    public string IssueName { get; set; }
    public string IssueDescription { get; set; }
}