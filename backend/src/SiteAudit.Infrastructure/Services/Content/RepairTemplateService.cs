using SiteAudit.Application.DTOs;
using SiteAudit.Application.UseCases.Content;

namespace SiteAudit.Infrastructure.Services.Content;

public class RepairTemplateService : IRepairTemplateService
{
    public List<RepairDTO> GetRepairsForDeviceType(string deviceType)
    {        
        return deviceType.ToLower() switch
        {
            "smartphone" => new List<RepairDTO>
            {
                new() { Name = "Screen Repair", SEOTitle = "SEO Title Screen", SEODescription = "SEO Desc Screen", SubTitle = "SubTitle Screen", BottomDescription = "Screen Bottom Desc", UrlPath = "screen-repair" },
                new() { Name = "Battery Repair", SEOTitle = "SEO Title Battery", SEODescription = "SEO Desc Battery", SubTitle = "SubTitle Battery", BottomDescription = "Battery Bottom Desc", UrlPath = "Battery-repair" },
                new() { Name = "Camera Repair", SEOTitle = "SEO Title Camera", SEODescription = "SEO Desc Camera", SubTitle = "SubTitle Camera", BottomDescription = "Camera Bottom Desc", UrlPath = "Camera-repair" },                
                // ... more smartphone repairs
            },
            "tablet" => new List<RepairDTO>
            {
                new() { Name = "Tablet Screen Repair", SEOTitle = "SEO Title Tablet Screen", SEODescription = "SEO Desc Tablet Screen", SubTitle = "SubTitle Tablet Screen", BottomDescription = "Tablet Screen Bottom Desc", UrlPath = "Tablet screen-repair" },
                new() { Name = "Tablet Battery Repair", SEOTitle = "Tablet SEO Title Battery", SEODescription = "Tablet SEO Desc Battery", SubTitle = "Tablet SubTitle Battery", BottomDescription = "Tablet Battery Bottom Desc", UrlPath = "Tablet Battery-repair" },
                // ... tablet-specific repairs
            },
            "mac" => new List<RepairDTO>
            {
                new() { Name = "[MODEL_NAME] Skærm Reparation (Original)", SubTitle = "Udskiftning til ny original [MODEL_NAME] Apple skærm"},
                new() { Name = "[MODEL_NAME] Skærm Reparation (Pulled)", SubTitle = "Udskiftning til Apple brugt original [MODEL_NAME] skærm"},
                new() { Name = "[MODEL_NAME] Batteri Skift", SubTitle ="Udskiftning af [MODEL_NAME] batteri" },
                new() { Name = "[MODEL_NAME] Keyboard Reparation", SubTitle ="Reparation af [MODEL_NAME] keyboard" },
                new() { Name = "[MODEL_NAME] Touchpad Reparation", SubTitle ="Reparation af [MODEL_NAME] touchpad" },
                new() { Name = "[MODEL_NAME] Ladeport Reparation" , SubTitle ="Reparation af [MODEL_NAME] ladeport" },
                new() { Name = "[MODEL_NAME] Software opdatering", SubTitle ="Vi opdaterer softwaren på din [MODEL_NAME]" },
                new() { Name = "[MODEL_NAME] Backup af data" },
                new() { Name = "[MODEL_NAME] Fejlfinding", Price = "Gratis", SubTitle ="Er du i tvivl om hvad din [MODEL_NAME] fejler? Vi assistere med at fejlfinde" },
                new() { Name = "[MODEL_NAME] Vandskade", SubTitle ="Har du en vandskadet[MODEL_NAME]? Vi diagnosticere den." },
            },
            _ => new List<RepairDTO>()
        };
    }
}