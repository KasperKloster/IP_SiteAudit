using System;

namespace SiteAudit.Application.UseCases.AnalyseWebpage;

public interface IAnalyzeWebpageUseCase
{
    Task<PageAnalysisResultDTO> ExecuteAsync(string url);
}
