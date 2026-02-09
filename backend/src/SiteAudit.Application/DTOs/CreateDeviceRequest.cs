using System;

namespace SiteAudit.Application.DTOs;

public class CreateDeviceRequest
{
    public required string DeviceType { get; set; } // "smartphone", "tablet", "mac"
    public required string Brand { get; set; }
    public required string DeviceName { get; set; }

    public string? ModelDetailOne {get; set; }
    public string? ModelDetailTwo {get; set; }
    public string? ModelDetailThree {get; set; }
}
