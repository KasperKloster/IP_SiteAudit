using SiteAudit.Application.DTOs;

namespace SiteAudit.Application.Interfaces;

public interface ICsvExportService
{
    byte[] ExportDevicesToCsv(List<DeviceDTO> devices);
}
