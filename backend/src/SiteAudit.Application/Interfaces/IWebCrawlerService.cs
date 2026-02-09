using System;

namespace SiteAudit.Application.UseCases.AnalyseWebpage;

public interface IWebCrawlerService
{
    Task<PageAnalysisResultDTO> CrawlPageAsync(string url);
}
