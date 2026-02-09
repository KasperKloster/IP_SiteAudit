namespace SiteAudit.Application.DTOs;

public class PageDTO
{    
    required public string Name {get; set; }
    public string? SEOTitle { get; set; }
    public string? SEODescription { get; set; }
    public string? SubTitle { get; set; }
    public string? BottomDescription { get; set; }
    public string? UrlPath  { get; set; }
}
