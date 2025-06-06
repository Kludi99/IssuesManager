using IssuesManager.Core.Models;

namespace IssuesManager.Core.Interfaces;

public interface IPlatformFactory
{
    IIssueService GetIssueService(Platform platform);
}