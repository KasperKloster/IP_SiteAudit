using System;
using SiteAudit.Application.DTOs;

namespace SiteAudit.Application.UseCases.Content;

public interface IRepairTemplateService
{
    List<RepairDTO> GetRepairsForDeviceType(string deviceType);
}
