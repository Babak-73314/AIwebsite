using AIwebsite.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;
using System.Globalization;
using AIwebsite.Shared;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Localization;
using AIwebsite.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Add services to the container.

var cultureInfo = new CultureInfo("tr");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;



var supportedCultures = new[] { "en-US", "tr" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[1]) // This sets Turkish as the default language
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(supportedCultures[1]);
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(supportedCultures[1]);

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NGaF5cXmVCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdgWXldcHVRR2RdVER1WUQ=");

// Register Syncfusion services
builder.Services.AddSyncfusionBlazor();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<ChatService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRequestLocalization(localizationOptions);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
