using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Text.Json;
using aspnetegitim.Services;

namespace aspnetegitim.Endpoints;

public static class PagesEndpoints
{
  private record LoginRequest(string? UserName, string? Password);

    public static void MapPages(this WebApplication app)
    {
        // Ana Sayfa
        app.MapGet("/", () =>
        {
            var body = """
<h1>Mini Site</h1>
<div class="card">
  <p>Bu site ASP.NET Core Minimal API ile yapılıyor.</p>
  <p>Menüden sayfalarrrr arasında gezebilirsin.</p>
</div>
""";
            return Results.Content(Layout("Ana Sayfa", body), "text/html; charset=utf-8");
        });

        // Hakkımda
        app.MapGet("/hakkimda", () =>
        {
            var body = """
<h1>Hakkımda</h1>
<div class="card">
  <p>Ben Halitcan. .NET öğreniyorum ve küçük bir web sitesi yapıyorum.</p>
  <p>Bir sonraki adım: Razor Pages ile gerçek sayfa dosyalarına geçmek.</p>
</div>
""";
            return Results.Content(Layout("Hakkımda", body), "text/html; charset=utf-8");
        });

        // Projeler
app.MapGet("/projeler", (Services.ProjectService projectService) =>
{
    // Load all projects and order by Id (newest first)
    var projects = projectService.GetAll().OrderByDescending(p => p.Id).ToList();

    string items;
    if (!projects.Any())
    {
        items = "<li><em>Henüz proje yok.</em></li>";
    }
    else
    {
        items = string.Join("", projects.Select(p =>
            $"""
<li>
  <b>{System.Net.WebUtility.HtmlEncode(p.Name)}</b> — {System.Net.WebUtility.HtmlEncode(p.Status)}<br/>
  <small>{System.Net.WebUtility.HtmlEncode(p.Description)}</small>
</li>
"""
        ));
    }

  var body = $"""
<h1>Projeler <small>({projects.Count})</small></h1>
<div class="card">
  <h3>Yeni Proje Ekle</h3>
  <form id="projectForm" method="post" action="/projeler">
    <label>Proje Adı</label>
    <input name="name" placeholder="Proje adı" />

    <label style="display:block; margin-top:8px;">Açıklama</label>
    <textarea name="description" rows="3" placeholder="Kısa açıklama"></textarea>

    <label style="display:block; margin-top:8px;">Durum</label>
    <input name="status" placeholder="Devam ediyor / Tamamlandı" />

    <div style="margin-top:12px;">
      <button type="submit">Ekle</button>
    </div>
  </form>
  <hr/>
  <ul id="projectsList">
    {items}
  </ul>
</div>
""";

    return Results.Content(Layout("Projeler", body), "text/html; charset=utf-8");
});

// API endpoint to create project via fetch (JSON)
app.MapPost("/api/projeler", (aspnetegitim.Models.Project project, Services.ProjectService projectService) =>
{
  if (project == null) return Results.BadRequest();
  var added = projectService.Add(project);
  return Results.Json(added);
});

// API endpoint to list projects as JSON
app.MapGet("/api/projeler", (Services.ProjectService projectService) =>
{
    var list = projectService.GetAll().OrderByDescending(p => p.Id).ToList();
    return Results.Json(list);
});


// Projeler (POST) - yeni proje oluştur
app.MapPost("/projeler", async (HttpRequest request, Services.ProjectService projectService) =>
{
    var form = await request.ReadFormAsync();
    var name = System.Net.WebUtility.HtmlEncode(form["name"].ToString());
    var description = System.Net.WebUtility.HtmlEncode(form["description"].ToString());
    var status = System.Net.WebUtility.HtmlEncode(form["status"].ToString());

    var project = new aspnetegitim.Models.Project
    {
        Name = name,
        Description = description,
        Status = string.IsNullOrWhiteSpace(status) ? "Devam ediyor" : status
    };

    projectService.Add(project);

    return Results.Redirect("/projeler");
});
        // İletişim (GET)
        app.MapGet("/iletisim", () =>
        {
            var body = """
<h1>İletişim</h1>
<div class="card">
  <form method="post" action="/iletisim">
    <label>Ad Soyad</label>
    <input name="fullName" placeholder="Ad Soyad" />

    <label style="display:block; margin-top:12px;">Mesaj</label>
    <textarea name="message" rows="5" placeholder="Mesajın..."></textarea>

    <div style="margin-top:12px;">
      <button type="submit">Gönder</button>
    </div>
  </form>
</div>
""";
            return Results.Content(Layout("İletişim", body), "text/html; charset=utf-8");
        });

        // İletişim (POST)
        app.MapPost("/iletisim", async (HttpRequest request, Services.ContactService contactService, Services.MessageService messageService) =>
        {
            var result = await contactService.HandleAsync(request);

            // Mesajı kaydet (HTML-encoded ve satır sonları <br/> ile)
            messageService.Add(result.FullName, result.MessageHtml);

            var body = $"""
<h1>Teşekkürler!</h1>
<div class="card">
  <p><b>Ad Soyad:</b> {result.FullName}</p>
  <p><b>Mesaj:</b><br/>{result.MessageHtml}</p>
</div>
""";

            return Results.Content(Layout("Gönderildi", body), "text/html; charset=utf-8");
        });

        // Mesajlar - kayıtlı iletişim mesajları
        app.MapGet("/mesajlar", (Services.MessageService messageService) =>
        {
            var messages = messageService.GetAll();

            var items = string.Join("", messages.Select(m =>
                $"""
<li>
  <b>{System.Net.WebUtility.HtmlEncode(m.FullName)}</b> — <small>{m.CreatedAt.ToLocalTime():g}</small>
  <div style=\"margin-top:6px;\">{m.BodyHtml}</div>
</li>
"""
            ));

            var body = $"""
<h1>Mesajlar</h1>
<div class="card">
  <ul>
    {items}
  </ul>
</div>
""";

            return Results.Content(Layout("Mesajlar", body), "text/html; charset=utf-8");
        }).RequireAuthorization();

    // Notes API - list notes
    app.MapGet("/api/notes", (Services.NoteService noteService) =>
    {
      var list = noteService.GetAll();
      return Results.Json(list);
    });

    // Notes API - create note
    app.MapPost("/api/notes", (aspnetegitim.Models.Note note, Services.NoteService noteService) =>
    {
      if (note == null) return Results.BadRequest();
      var added = noteService.Add(note.Title ?? string.Empty, note.Body ?? string.Empty);
      return Results.Json(added);
    });

    // Authentication: login
    app.MapPost("/api/login", async (HttpContext http, aspnetegitim.Services.UserService userService) =>
    {
      try
      {
        var body = await System.Text.Json.JsonSerializer.DeserializeAsync<LoginRequest>(http.Request.Body);
        if (body == null) return Results.BadRequest();
        if (!userService.ValidateCredentials(body.UserName ?? string.Empty, body.Password ?? string.Empty))
          return Results.Unauthorized();

                var claims = new[] { new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, body.UserName ?? string.Empty) };
        var identity = new System.Security.Claims.ClaimsIdentity(claims, "MyCookie");
        var principal = new System.Security.Claims.ClaimsPrincipal(identity);
        await http.SignInAsync("MyCookie", principal);
        return Results.Ok();
      }
      catch
      {
        return Results.BadRequest();
      }
    });

    app.MapPost("/api/logout", async (HttpContext http) =>
    {
      await http.SignOutAsync("MyCookie");
      return Results.Ok();
    });
    }

    // UI (layout) burada, sonra ayrı dosyaya da taşıyacağız
    private static string Layout(string title, string body)
    {
        return @"<!doctype html>
<html lang=""tr"">
<head>
  <meta charset=""utf-8"" />
  <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
  <title>" + title + @"</title>
  <style>
    body { font-family: -apple-system, system-ui, Arial; max-width: 900px; margin: 40px auto; padding: 0 16px; }
    nav a { margin-right: 12px; text-decoration: none; }
    nav a:hover { text-decoration: underline; }
    .card { border: 1px solid #ddd; border-radius: 12px; padding: 16px; margin-top: 16px; }
    input, textarea { width: 100%; padding: 10px; margin-top: 6px; border-radius: 10px; border: 1px solid #ccc; }
    button { padding: 10px 14px; border-radius: 10px; border: 1px solid #ccc; cursor: pointer; }
  </style>
</head>
<body>
  <nav>
    <a href=""/"">Ana Sayfa</a>
    <a href=""/hakkimda"">Hakkımda</a>
    <a href=""/projeler"">Projeler</a>
    <a href=""/iletisim"">İletişim</a>
    <a href=""/mesajlar"">Mesajlar</a>
  </nav>

  " + body + @"
</body>
</html>";
    }
}
