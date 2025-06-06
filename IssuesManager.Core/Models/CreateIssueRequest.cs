namespace IssuesManager.Core.Models;

public class CreateIssueRequest :BaseIssueRequest
{
    //public Platform Platform { get; set; }
   // public string RepositoryName { get; set; }
    public string IssueName { get; set; }
    public string IssueDescription { get; set; }
    
   // public int? IssueNumber { get; set; }
}