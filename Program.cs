using aspnetegitim.Endpoints;
using aspnetegitim.Services;
using aspnetegitim.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection: Bu servis her request’te kullanılabilsin diye ekliyoruz
builder.Services.AddScoped<ContactService>();
// ProjectService and MessageService depend on AppDbContext (scoped),
// so they must be registered as scoped as well.
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<MessageService>();

// Configure EF Core with SQLite (file under Data/app.db)
var dbPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "app.db");
var dbDir = Path.GetDirectoryName(dbPath)!;
if (!Directory.Exists(dbDir)) Directory.CreateDirectory(dbDir);
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlite($"Data Source={dbPath}"));


var app = builder.Build();

// Ensure database created
using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
	db.Database.EnsureCreated();
	// Seed default projects if none exist
	if (!db.Projects.Any())
	{
		db.Projects.AddRange(new[] {
			new aspnetegitim.Models.Project { Name = "LifePlan", Description = "Hedef, alışkanlık, günlük takip platformu", Status = "Devam ediyor" },
			new aspnetegitim.Models.Project { Name = "Fikir Pazarı", Description = "Fikir oylama ve ekip kurma uygulaması", Status = "Devam ediyor" },
			new aspnetegitim.Models.Project { Name = "HSD OSTİMTECH Web", Description = "Topluluk için etkinlik/duyuru web arayüzü", Status = "Tamamlandı" },
		});
		db.SaveChanges();
	}
}

// Route’ları ayrı dosyada tanımladık
app.MapPages();


app.Run();