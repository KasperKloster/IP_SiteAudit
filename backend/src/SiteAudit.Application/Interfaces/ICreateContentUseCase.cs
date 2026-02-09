using SiteAudit.Application.DTOs;

namespace SiteAudit.Application.UseCases.Content;

public interface ICreateContentUseCase
{
    Task<List<DeviceDTO>> CreateDeviceContent(List<CreateDeviceRequest> requests);    
}
