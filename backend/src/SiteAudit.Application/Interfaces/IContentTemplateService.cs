using SiteAudit.Application.DTOs.Content;

namespace SiteAudit.Application.Interfaces;

public interface IContentTemplateService
{    
    public DeviceContentResult GetRandomDeviceContent(string deviceType, string deviceName);
}
