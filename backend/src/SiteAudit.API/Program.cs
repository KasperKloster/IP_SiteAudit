using Scalar.AspNetCore;
using SiteAudit.Application.Interfaces;
using SiteAudit.Application.Interfaces.FileExport;
using SiteAudit.Application.UseCases.AnalyseWebpage;
using SiteAudit.Application.UseCases.Content;
using SiteAudit.Infrastructure.Services.Content;
using SiteAudit.Infrastructure.Services.Crawler;
using SiteAudit.Infrastructure.Services.FileExport;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Register Application services
builder.Services.AddScoped<IAnalyzeWebpageUseCase, AnalyzeWebpageUseCase>();
builder.Services.AddScoped<ICreateContentUseCase, CreateContentUseCase>();
builder.Services.AddScoped<IRepairTemplateService, RepairTemplateService>();
builder.Services.AddScoped<ICsvExportService, CsvExportService>();
builder.Services.AddScoped<IExcelExportService, ExcelExportService>();
builder.Services.AddScoped<IContentTemplateService, ContentTemplateService>();

// Register Infrastructure services
builder.Services.AddHttpClient<IWebCrawlerService, WebCrawlerService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Build
var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); 
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
// Controllers
app.MapControllers();
// Optional test endpoint
app.MapGet("/", () => "Hello World!");

app.Run();
