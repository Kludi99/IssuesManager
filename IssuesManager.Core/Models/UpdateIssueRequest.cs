namespace IssuesManager.Core.Models;

public class UpdateIssueRequest : BaseIssueRequest
{
    public string IssueName { get; set; }
    public string IssueDescription { get; set; }
    public int IssueNumber { get; set; }
}