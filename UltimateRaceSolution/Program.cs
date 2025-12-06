using _RaceStateService.Hubs;
using _RaceStateService.Services;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// SignalR for auto update in the razor page
builder.Services.AddSignalR();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<RaceService>();
// Injecting service
builder.Services.AddScoped<IRaceService, RaceService>();
builder.Services.AddHostedService(provider => provider.GetService<RaceService>());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
//Mapping race hub
app.MapHub<RaceHub>("/raceHub");

app.Run();
