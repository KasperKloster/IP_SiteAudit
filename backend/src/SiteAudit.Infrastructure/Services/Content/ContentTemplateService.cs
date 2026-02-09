using System.Text.Json;
using SiteAudit.Application.DTOs.Content;
using SiteAudit.Application.Interfaces;

namespace SiteAudit.Infrastructure.Services.Content;

public class ContentTemplateService : IContentTemplateService
{
    private readonly Dictionary<string, DeviceTemplate> _templates;
    private readonly Random _random = new();

    public ContentTemplateService()
    {
        _templates = LoadTemplatesFromJson();
    }

    public DeviceContentResult GetRandomDeviceContent(string deviceType, string deviceName)
    {
        if (!_templates.ContainsKey(deviceType.ToLower()))
        {
            throw new ArgumentException($"No templates found for device type: {deviceType}");
        }

        var template = _templates[deviceType.ToLower()];
        
        // Pick random SEO title and subtitle        
        var randomSeoTitle = template.SeoTitles[_random.Next(template.SeoTitles.Count)];
        var randomSubTitle = template.SubTitles[_random.Next(template.SubTitles.Count)];
        
        // Replace placeholders
        return new DeviceContentResult
        {
            SeoTitle = randomSeoTitle,
            SubTitle = randomSubTitle
        };
    }

    private Dictionary<string, DeviceTemplate> LoadTemplatesFromJson()
    {
        var jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates/Device", "main-templates.json");
        var json = File.ReadAllText(jsonPath);
        return JsonSerializer.Deserialize<Dictionary<string, DeviceTemplate>>(json) 
            ?? [];
    }
}
