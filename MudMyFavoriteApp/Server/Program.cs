using Microsoft.EntityFrameworkCore;
using MudMyFavoriteApp.DataBaseEF;
using MudMyFavoriteApp.Extensions.Mapping;
using MudMyFavoriteApp.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));

builder.Services.AddScoped<IGameDbContext>(provider =>
    provider.GetService<GameDbContext>());

builder.Services.AddScoped<IGameService, GameService>();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IGameDbContext).Assembly));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    try
    {
        //Создание базы данных с таблицами, при ее отсутствии на сервере.
        var mainDbContext = serviceProvider.GetRequiredService<GameDbContext>();
        mainDbContext.Database.EnsureCreated();
    }
    catch (Exception ex)
    {

    }
}

app.Run();