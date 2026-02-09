using System;
using System.Text;
using SiteAudit.Application.DTOs;
using SiteAudit.Application.Interfaces;

namespace SiteAudit.Infrastructure.Services.FileExport;

public class CsvExportService : ICsvExportService
{
    public byte[] ExportDevicesToCsv(List<DeviceDTO> devices)
    {
        var csv = new StringBuilder();
        csv.AppendLine("Name,SEOTitle,SubTitle,FeatureOne,FeatureTwo,FeatureThree,ModelDetailOne,ModelDetailTwo,ModelDetailThree,BottomDescription");

        foreach (var device in devices)
        {
            csv.AppendLine($"{device.Name},{device.SEOTitle},{device.SubTitle},{device.FeatureOne},{device.FeatureTwo},{device.FeatureThree},{device.ModelDetailOne},{device.ModelDetailTwo},{device.ModelDetailThree},{device.BottomDescription}");

            // foreach (var repair in device.Repairs)
            // {
            //     csv.AppendLine($"{repair.Name},{repair.SubTitle},{repair.Price}");
            // }
        }
        
        return Encoding.UTF8.GetBytes(csv.ToString());
    }
}
