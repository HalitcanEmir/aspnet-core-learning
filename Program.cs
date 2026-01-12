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

// User service for authentication
builder.Services.AddScoped<UserService>();

// Configure EF Core with SQLite (file under Data/app.db)
var dbPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "app.db");
var dbDir = Path.GetDirectoryName(dbPath)!;
if (!Directory.Exists(dbDir)) Directory.CreateDirectory(dbDir);
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlite($"Data Source={dbPath}"));

// Register NoteService
builder.Services.AddScoped<NoteService>();

// Authentication - Cookie
builder.Services.AddAuthentication("MyCookie")
	.AddCookie("MyCookie", options =>
	{
		options.LoginPath = "/login.html";
		options.Cookie.HttpOnly = true;
		options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
	});
builder.Services.AddAuthorization();


var app = builder.Build();

// Serve static files from wwwroot
app.UseStaticFiles();

// Authentication/Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

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
	// Ensure Notes table exists (for deployments where DB already existed)
	db.Database.ExecuteSqlRaw(@"CREATE TABLE IF NOT EXISTS Notes (
		Id INTEGER PRIMARY KEY AUTOINCREMENT,
		Title TEXT,
		Body TEXT,
		CreatedAt TEXT NOT NULL
	);");

	// Ensure Users table exists and create default admin if none
	if (!db.Set<aspnetegitim.Models.User>().Any())
	{
		// create default admin user
		var userService = scope.ServiceProvider.GetRequiredService<UserService>();
		userService.Create("admin", "admin");
	}
}

// Route’ları ayrı dosyada tanımladık
app.MapPages();


app.Run();