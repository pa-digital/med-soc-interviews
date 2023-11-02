using HealthView.Domain.Repositories;
using HealthView.Infrastructure.Persistence;
using HealthView.Infrastructure.Repositories;
using HealthView.Web.Services;

var builder = WebApplication.CreateBuilder(args);

MainDatabase mainDatabase = new();
mainDatabase.Generate();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<MainDatabase>(_ => mainDatabase);
builder.Services.AddScoped<IHealthDataRepository, HealthDataRepository>();
builder.Services.AddScoped<WebService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();