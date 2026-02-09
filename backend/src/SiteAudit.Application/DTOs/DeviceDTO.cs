namespace SiteAudit.Application.DTOs;

public class DeviceDTO : PageDTO
{   
    public string? Brand { get; set; }         
    public string? FeatureOne { get; set; }    
    public string? FeatureTwo { get; set; }
    public string? FeatureThree { get; set; }
    public string? ModelDetailOne { get; set; }
    public string? ModelDetailTwo { get; set; }
    public string? ModelDetailThree { get; set; }
    public ICollection<RepairDTO> Repairs {get; set; } = [];
}
