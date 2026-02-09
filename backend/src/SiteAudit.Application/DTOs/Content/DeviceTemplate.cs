using System;

namespace SiteAudit.Application.DTOs.Content;

public class DeviceTemplate
{
    public List<string> SeoTitles { get; set; } = new();
    public List<string> SubTitles { get; set; } = new();
}