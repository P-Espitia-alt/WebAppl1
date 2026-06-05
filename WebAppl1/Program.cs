using ClassLibraryInfrastructure1.Data;
using ClassLibraryInfrastructure1.Repositories;
using ClassLibraryInfrastructure1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AddPageRoute("/AgregarAstronauta", "");
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAstronautaRepository, AstronautaRepository>();
builder.Services.AddScoped<IMisionRepository, MisionRepository>();
builder.Services.AddScoped<IPaisRepository, PaisRepository>();
builder.Services.AddScoped<IMisionAstronautaRepository, MisionAstronautaRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();   // <- En .NET 8

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
