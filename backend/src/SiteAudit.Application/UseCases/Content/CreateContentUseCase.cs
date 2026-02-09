using SiteAudit.Application.DTOs;
using SiteAudit.Application.Interfaces;

namespace SiteAudit.Application.UseCases.Content;

public class CreateContentUseCase : ICreateContentUseCase
{    
    private readonly IRepairTemplateService _repairTemplateService;
    private readonly IContentTemplateService _contentTemplateService;

    public CreateContentUseCase(IRepairTemplateService repairTemplateService, IContentTemplateService contentTemplateService)
    {
        _repairTemplateService = repairTemplateService;
        _contentTemplateService = contentTemplateService;
    }

    public async Task<List<DeviceDTO>> CreateDeviceContent(List<CreateDeviceRequest> requests)
    {
        var devices = new List<DeviceDTO>();

        foreach (var request in requests)
        {
            var contentTemplate = _contentTemplateService.GetRandomDeviceContent(request.DeviceType, request.DeviceName);

            var device = new DeviceDTO
            {
                Brand = request.Brand,
                Name = request.DeviceName,
                SEOTitle = ReplaceVariables(contentTemplate.SeoTitle, request),
                SubTitle = ReplaceVariables(contentTemplate.SubTitle, request),
                FeatureOne = "Erfaring siden 2005",
                FeatureTwo = "Uddannede teknikere",
                FeatureThree = "1 års garanti",
                ModelDetailOne = request.ModelDetailOne,
                ModelDetailTwo = request.ModelDetailTwo,
                ModelDetailThree = request.ModelDetailThree,                                
                Repairs = []
            };

            // Get repair templates based on device type
            var repairTemplates = _repairTemplateService.GetRepairsForDeviceType(request.DeviceType);
            
            // Create repair entries
            foreach (var repairTemplate in repairTemplates)
            {
                device.Repairs.Add(new RepairDTO
                {                
                    Name = ReplaceVariables(repairTemplate.Name, request),
                    SubTitle = ReplaceVariables(repairTemplate.SubTitle, request),
                    Price = repairTemplate.Price
                });
            }
            devices.Add(device);           
        }
 
        return devices;
    }

    private string ReplaceVariables(string? text, CreateDeviceRequest request)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        return text
            .Replace("[MODEL_NAME]", request.DeviceName)
            .Replace("[BRAND]", request.Brand)
            .Replace("[DEVICE_TYPE]", request.DeviceType);
    }

}
