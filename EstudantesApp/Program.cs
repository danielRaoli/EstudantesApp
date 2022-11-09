using EstudantesApp.Dominio.IRepositories;
using EstudantesApp.Dominio.IServices;
using EstudantesApp.Persistence.Context;
using EstudantesApp.Persistence.Repositories;
using EstudantesApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AplicationDbContex>
    (option => option.UseSqlServer(builder.Configuration.GetConnectionString("conection")));

builder.Services.AddScoped<IEstudanteRepository, EstudanteRepository>();
builder.Services.AddScoped<IEstudanteService, EstudanteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Estudante}/{action=Index}/{id?}");

app.Run();
