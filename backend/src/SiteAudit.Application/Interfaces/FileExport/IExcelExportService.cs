using SiteAudit.Application.DTOs;

namespace SiteAudit.Application.Interfaces.FileExport;

public interface IExcelExportService
{
    byte[] ExportDevicesToExcel(List<DeviceDTO> devices);
}
