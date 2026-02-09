using Microsoft.AspNetCore.Mvc;
using SiteAudit.Application.UseCases.AnalyseWebpage;

namespace SiteAudit.API.Controllers.WebCrawler
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebCrawlerController : ControllerBase
    {
        private readonly IAnalyzeWebpageUseCase _analyzeWebpageUseCase;
        public WebCrawlerController(IAnalyzeWebpageUseCase analyzeWebpageUseCase)
        {
            _analyzeWebpageUseCase = analyzeWebpageUseCase;
        }
        
        [HttpGet("analyze")]
        public async Task<IActionResult> GetWebpage([FromQuery] string url)
        {
            try
            {
                var result = await _analyzeWebpageUseCase.ExecuteAsync(url);
                // Return DTO as JSON - ASP.NET Core handles serialization automatically
                return Ok(result);
            }
            catch (Exception ex)
            {                
                return BadRequest($"Failed to. crawl url: {ex.Message}");
            }
        }
    }
}