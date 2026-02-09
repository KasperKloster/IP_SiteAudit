using ClosedXML.Excel;
using SiteAudit.Application.DTOs;
using SiteAudit.Application.Interfaces.FileExport;

namespace SiteAudit.Infrastructure.Services.FileExport;

public class ExcelExportService : IExcelExportService
{
    public byte[] ExportDevicesToExcel(List<DeviceDTO> devices)
    {
        using var workbook = new XLWorkbook();
        
        // Create Devices sheet
        var devicesSheet = workbook.Worksheets.Add("Devices");
        CreateDevicesSheet(devicesSheet, devices);
        
        // Create Repairs sheet
        var repairsSheet = workbook.Worksheets.Add("Repairs");
        CreateRepairsSheet(repairsSheet, devices);
        
        // Save to memory stream
        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }
    private static void CreateDevicesSheet(IXLWorksheet sheet, List<DeviceDTO> devices)
    {
        // Headers
        sheet.Cell(1, 1).Value = "Brand";
        sheet.Cell(1, 2).Value = "Name";
        sheet.Cell(1, 3).Value = "SEO Title";
        sheet.Cell(1, 4).Value = "Sub Title";
        sheet.Cell(1, 5).Value = "Feature One";
        sheet.Cell(1, 6).Value = "Feature Two";
        sheet.Cell(1, 7).Value = "Feature Three";
        sheet.Cell(1, 8).Value = "Model Detail One";
        sheet.Cell(1, 9).Value = "Model Detail Two";
        sheet.Cell(1, 10).Value = "Model Detail Three";
        sheet.Cell(1, 11).Value = "Bottom Description";
        
        // Style headers
        var headerRow = sheet.Range(1, 1, 1, 11);
        headerRow.Style.Font.Bold = true;
        headerRow.Style.Fill.BackgroundColor = XLColor.LightBlue;
        
        // Data
        int row = 2;
        foreach (var device in devices)
        {
            sheet.Cell(row, 1).Value = device.Brand;
            sheet.Cell(row, 2).Value = device.Name;
            sheet.Cell(row, 3).Value = device.SEOTitle;
            sheet.Cell(row, 4).Value = device.SubTitle;
            sheet.Cell(row, 5).Value = device.FeatureOne;
            sheet.Cell(row, 6).Value = device.FeatureTwo;
            sheet.Cell(row, 7).Value = device.FeatureThree;
            sheet.Cell(row, 8).Value = device.ModelDetailOne;
            sheet.Cell(row, 9).Value = device.ModelDetailTwo;
            sheet.Cell(row, 10).Value = device.ModelDetailThree;
            sheet.Cell(row, 11).Value = device.BottomDescription;
            row++;
        }
        
        // Auto-fit columns
        sheet.Columns().AdjustToContents();
    }

    private static void CreateRepairsSheet(IXLWorksheet sheet, List<DeviceDTO> devices)
    {
        // Headers
        sheet.Cell(1, 1).Value = "Device Name";
        sheet.Cell(1, 2).Value = "Repair Name";
        sheet.Cell(1, 3).Value = "Sub Title";
        sheet.Cell(1, 4).Value = "Bottom Description";        
        sheet.Cell(1, 5).Value = "Price";
        
        // Style headers
        var headerRow = sheet.Range(1, 1, 1, 8);
        headerRow.Style.Font.Bold = true;
        headerRow.Style.Fill.BackgroundColor = XLColor.LightGreen;
        
        // Data
        int row = 2;
        foreach (var device in devices)
        {
            foreach (var repair in device.Repairs)
            {
                sheet.Cell(row, 1).Value = device.Name;
                sheet.Cell(row, 2).Value = repair.Name;
                sheet.Cell(row, 3).Value = repair.SubTitle;
                sheet.Cell(row, 4).Value = repair.BottomDescription;                
                sheet.Cell(row, 5).Value = repair.Price;
                row++;
            }
        }
        
        // Auto-fit columns
        sheet.Columns().AdjustToContents();
    }

}
