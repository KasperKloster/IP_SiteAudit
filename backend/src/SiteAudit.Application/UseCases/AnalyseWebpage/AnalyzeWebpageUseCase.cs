namespace SiteAudit.Application.UseCases.AnalyseWebpage;

public class AnalyzeWebpageUseCase : IAnalyzeWebpageUseCase
{
    private readonly IWebCrawlerService _crawler;
    
    public AnalyzeWebpageUseCase(IWebCrawlerService crawler)
    {
        _crawler = crawler;
    }
    
    public async Task<PageAnalysisResultDTO> ExecuteAsync(string url)
    {
        return await _crawler.CrawlPageAsync(url);
    }
}

