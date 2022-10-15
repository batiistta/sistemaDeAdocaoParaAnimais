using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using sistemaDeAdocaoParaAnimais.Helper;
using sistemaDeAdocaoParaAnimais.Models;
using sistemaDeAdocaoParaAnimais.Services;

var builder = WebApplication.CreateBuilder(args);

string mysqlconnection = builder.Configuration.GetConnectionString("MysqlConnection");
builder.Services.AddDbContext<SistemaDeAdocaoParaAnimaisContext>(opt =>
{
    opt.UseMySql(mysqlconnection, ServerVersion.AutoDetect(mysqlconnection));
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ISessao, Sessao>();

builder.Services.AddSession(o => 
{
    o.Cookie.HttpOnly = true; 
    o.Cookie.IsEssential = true; 
}); 

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
