using Microsoft.AspNetCore.Mvc;
using SiteAudit.Application.DTOs;
using SiteAudit.Application.Interfaces;
using SiteAudit.Application.Interfaces.FileExport;
using SiteAudit.Application.UseCases.Content;

namespace SiteAudit.API.Controllers.Content
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly ICreateContentUseCase _createContentUseCase;
        private readonly IExcelExportService _excelExportService;
        public ContentController(
            ICreateContentUseCase createContentUseCase,
            IExcelExportService excelExportService)
        {
            _createContentUseCase = createContentUseCase;
            _excelExportService = excelExportService;
        }

        [HttpPost("create-devices")]
        public async Task<IActionResult> CreateDeviceContent([FromBody] List<CreateDeviceRequest> requests)
        {
            try
            {
                var result = await _createContentUseCase.CreateDeviceContent(requests);
                var excel = _excelExportService.ExportDevicesToExcel(result);
                
                return File(excel,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "device-content.xlsx");
            }
            catch (Exception ex)
            {                
                return BadRequest($"Failed to create content: {ex.Message}");
            }
        }


    }
}
