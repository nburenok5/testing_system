using BlazorApp3.Components;
using BlazorApp3.Components.Models.ModelsDataBases;
using BlazorApp3.Models; // Добавлен using для TestAccessService
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Сначала регистрируем сервисы Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Затем регистрируем DbContext с правильными параметрами
builder.Services.AddDbContext<DataBaseContext>(options => 
        options.UseSqlite("Data Source=TestDB.db"),
    contextLifetime: ServiceLifetime.Scoped,
    optionsLifetime: ServiceLifetime.Singleton);

// 3. Регистрируем фабрику DbContext
builder.Services.AddDbContextFactory<DataBaseContext>(options => 
    options.UseSqlite("Data Source=TestDB.db"));

// 4. Регистрируем сервис для проверки доступа к тестам (из папки Models)
builder.Services.AddScoped<TestAccessService>();

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

// Инициализация БД
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
    db.Database.EnsureCreated();
    
    // Можно добавить начальные данные, если нужно
    // await SeedData.Initialize(db);
}

app.Run();