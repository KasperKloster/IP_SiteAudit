using System;
using System.Diagnostics.Contracts;

namespace SiteAudit.Application.UseCases.AnalyseWebpage;

public class PageAnalysisResultDTO
{
    public required string Url { get; set; }
    public required string SEOTitle {get; set; }
    public string? Headline {get; set; }
    public List<string>? SubPageUrls { get; set; }
    public string? BottomDescription { get; set; }
}