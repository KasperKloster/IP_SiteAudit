using System;
using HtmlAgilityPack;
using SiteAudit.Application.UseCases.AnalyseWebpage;

namespace SiteAudit.Infrastructure.Services.Crawler;

public class WebCrawlerService : IWebCrawlerService
{
    private readonly HttpClient _httpClient;
    public WebCrawlerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Actual HTML fetching and parsing logic here
    public async Task<PageAnalysisResultDTO> CrawlPageAsync(string url)
    {
        // Fetch HTML from web   
        var html = await _httpClient.GetStringAsync(url);        
        // Load HTML into HtmlAgilityPack
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);
        
        // Get the title tag
        var SEOTitleNode = htmlDoc.DocumentNode.SelectSingleNode("//title");
        var SEOTitle = SEOTitleNode?.InnerText ?? "No title found";
        
        
        return new PageAnalysisResultDTO
        {
            Url = url,
            SEOTitle = SEOTitle,                        
        };    
    }
}

