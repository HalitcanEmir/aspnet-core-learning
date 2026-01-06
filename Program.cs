using aspnetegitim.Endpoints;
using aspnetegitim.Services;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection: Bu servis her request’te kullanılabilsin diye ekliyoruz
builder.Services.AddScoped<ContactService>();
builder.Services.AddSingleton<ProjectService>();


var app = builder.Build();

// Route’ları ayrı dosyada tanımladık
app.MapPages();

app.Run();