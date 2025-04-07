using BlazorApp3.Components;

using BlazorApp3.Components.Models.ModelsDataBases;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Сначала регистрируем сервисы Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Затем регистрируем DbContext с правильными параметрами
builder.Services.AddDbContext<DataBaseContext>(options => 
        options.UseSqlite("Data Source=TestDB.db"),
    contextLifetime: ServiceLifetime.Scoped,  // Основной контекст
    optionsLifetime: ServiceLifetime.Singleton);  // Параметры конфигурации

// 3. Регистрируем фабрику DbContext (если используется)
builder.Services.AddDbContextFactory<DataBaseContext>(options => 
    options.UseSqlite("Data Source=TestDB.db"));

var app = builder.Build();

// Настройка middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Настройка маршрутизации Blazor
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Инициализация БД - важно делать после MapRazorComponents
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
    db.Database.EnsureCreated();
}

app.Run();