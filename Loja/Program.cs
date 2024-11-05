using Loja.Context;
using Loja.Models;
using Loja.Repositories;
using Loja.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Repositories
builder.Services.AddTransient<IJogoRepository, JogoRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

//session
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();

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

//session
app.UseSession();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "teste",
//    pattern: "testme",
//    defaults: new { controller="teste", Action = "index" });

//app.MapControllerRoute(
//    name: "admin",
//    pattern: "admin/{action=Index}/{id?}",
//     defaults: new { controller = "admin" });

app.MapControllerRoute(
    name: "categoriaFiltro",
    pattern: "Jogo/{action}/{categoria?}",
     defaults: new { Controller = "Jogo", action="List" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();